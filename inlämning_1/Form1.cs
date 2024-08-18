using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace inlämning_1
{
    public partial class Form1 : Form
    {
        private string dbFilePath = "kryptering.db";  // SQLite-databasens filnamn

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(dbFilePath))
            {
                CreateDatabase();
            }
        }

        // SQLite-databasen och tabellen
        private void CreateDatabase()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
                {
                    conn.Open();

                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS EncryptedData (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Data TEXT NOT NULL,
                                        Salt TEXT NOT NULL
                                        );";
                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Confirm the table was created
                    string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='EncryptedData';";
                    using (SQLiteCommand checkCommand = new SQLiteCommand(checkTableQuery, conn))
                    {
                        var tableName = checkCommand.ExecuteScalar();
                        if (tableName == null)
                        {
                            MessageBox.Show("Tabellen 'EncryptedData' kunde inte skapas.");
                        }
                        else
                        {
                            MessageBox.Show("Tabellen 'EncryptedData' har skapats.");
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett fel uppstod vid skapandet av databasen: {ex.Message}");
            }
        }
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Krypteringsfunktion
        private Tuple<byte[], string> EncryptData(string clearText)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            string salt = GenerateSalt();
            using (Aes aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(salt, Encoding.UTF8.GetBytes(salt), 10000, HashAlgorithmName.SHA256);
                aes.Key = key.GetBytes(32);
                aes.IV = key.GetBytes(16);

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] encryptedData = PerformCryptography(clearBytes, encryptor);
                    return new Tuple<byte[], string>(encryptedData, salt);
                }
            }
        }
        private string DecryptData(byte[] encryptedData, string salt)
        {
            using (Aes aes = Aes.Create())
            {

                var key = new Rfc2898DeriveBytes(salt, Encoding.UTF8.GetBytes(salt), 10000, HashAlgorithmName.SHA256);
                aes.Key = key.GetBytes(32);
                aes.IV = key.GetBytes(16);

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] decryptedBytes = PerformCryptography(encryptedData, decryptor);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        // Krypterings- och dekrypteringshjälpmetod
        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
        private void SaveToDatabase(byte[] encryptedData, string salt)
        {
            string encryptedDataBase64 = Convert.ToBase64String(encryptedData); // Konvertera till Base64

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                conn.Open();

                string insertQuery = "INSERT INTO EncryptedData (Data, Salt) VALUES (@Data, @Salt)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@Data", encryptedDataBase64); // Spara som TEXT
                    command.Parameters.AddWithValue("@Salt", salt);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Kunde inte spara data i databasen.");
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Data har sparats i databasen.");
        }
        private byte[] FetchFromDatabase(string salt)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                conn.Open();

                string selectQuery = "SELECT Data FROM EncryptedData WHERE Salt = @Salt ORDER BY Id DESC LIMIT 1";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, conn))
                {
                    command.Parameters.AddWithValue("@Salt", salt);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string encryptedDataBase64 = reader["Data"].ToString();
                            return Convert.FromBase64String(encryptedDataBase64); // Konvertera tillbaka till byte[]
                        }
                    }
                }
            }

            MessageBox.Show("Ingen data funnen.");
            return null;
        }


        private void UpdateDatabase(int id, byte[] newEncryptedData, string newSalt)
        {
            string newEncryptedDataBase64 = Convert.ToBase64String(newEncryptedData); // Konvertera till Base64

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                conn.Open();

                // Uppdatera den krypterade datan och saltet
                string updateQuery = "UPDATE EncryptedData SET Data = @Data, Salt = @Salt WHERE Id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@Data", newEncryptedDataBase64); // Spara Base64-sträng
                    command.Parameters.AddWithValue("@Salt", newSalt);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }

            MessageBox.Show("Data har uppdaterats i databasen.");
        }

        private void DeleteFromDatabase(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM EncryptedData WHERE Id = @Id";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@Id", id);
                    long count = (long)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Ingen data hittades med det angivna ID:t.");
                        return;
                    }
                }

               
                string deleteQuery = "DELETE FROM EncryptedData WHERE Id = @Id";
                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, conn))
                {
                    deleteCommand.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data har tagits bort.");
                    }
                    else
                    {
                        MessageBox.Show("Något gick fel vid borttagningen av data.");
                    }
                }

                conn.Close();
            }
        }
        private void ShowDataInDataGridView()
        {

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
                {
                    conn.Open();

                    string selectQuery = "SELECT Id, Data, Salt FROM EncryptedData";
                    using (var command = new SQLiteCommand(selectQuery, conn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Id", typeof(int));
                            dataTable.Columns.Add("Data (Encrypted)", typeof(string));  // Display byte[] as Base64 string
                            dataTable.Columns.Add("Salt", typeof(string));


                            while (reader.Read())
                            {
                                // Convert byte[] fields to Base64 strings
                                int id = reader.GetInt32(0);
                                string encryptedData = reader.GetString(1);
                                string salt = reader.GetString(2);

                                // Add a new row to the DataTable
                                dataTable.Rows.Add(id, encryptedData, salt);
                            }

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett fel uppstod vid hämtning av data: {ex.Message}");
            }

        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {

            string clearText = txtInput.Text;

            if (string.IsNullOrEmpty(clearText))
            {
                MessageBox.Show("Ange både text och salt.");
                return;
            }

            var encryptionResult = EncryptData(clearText);
            byte[] encryptedData = encryptionResult.Item1;
            string salt = encryptionResult.Item2;

            // Spara till databasen
            SaveToDatabase(encryptedData, salt);

            txtResult.Text = Convert.ToBase64String(encryptedData);

        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string salt = txtBoxSalt.Text; // Salt från användarens input
            string encryptedTextBase64 = txtKrypterde.Text;  // Krypterad text från användarens input

            if (string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(encryptedTextBase64))
            {
                MessageBox.Show("Ange både salt och krypterad text.");
                return;
            }

            byte[] encryptedData = Convert.FromBase64String(encryptedTextBase64);
            byte[] storedEncryptedData = FetchFromDatabase(salt);

            if (storedEncryptedData != null && storedEncryptedData.SequenceEqual(encryptedData))
            {
                try
                {
                    string decryptedText = DecryptData(storedEncryptedData, salt);
                    texAvkrypterade.Text = decryptedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ett fel uppstod vid dekryptering: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Fel salt eller krypterad text. Dekryptering misslyckades.");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string newClearText = txtNewInput.Text;
            var encryptionResult = EncryptData(newClearText);
            byte[] newEncryptedData = encryptionResult.Item1;
            string newSalt = encryptionResult.Item2;
            UpdateDatabase(id, newEncryptedData, newSalt);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtId.Text, out int id))
            {
                DeleteFromDatabase(id);
            }
            else
            {
                MessageBox.Show("Ange ett giltigt ID.");
            }
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            ShowDataInDataGridView();
        }
       
    }

}
