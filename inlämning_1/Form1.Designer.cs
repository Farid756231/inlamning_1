namespace inlämning_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtInput = new TextBox();
            label2 = new Label();
            txtSalt = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            label3 = new Label();
            txtResult = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            txtBoxSalt = new TextBox();
            label5 = new Label();
            texAvkrypterade = new TextBox();
            label6 = new Label();
            label4 = new Label();
            txtKrypterde = new TextBox();
            txtNewInput = new TextBox();
            txtId = new TextBox();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(33, 50);
            label1.Name = "label1";
            label1.Size = new Size(167, 20);
            label1.TabIndex = 0;
            label1.Text = "Ange text för kryptering";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(33, 85);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(308, 27);
            txtInput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(33, 150);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 2;
            label2.Text = "Ange lösenord";
            // 
            // txtSalt
            // 
            txtSalt.Location = new Point(32, 185);
            txtSalt.Name = "txtSalt";
            txtSalt.Size = new Size(308, 27);
            txtSalt.TabIndex = 3;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = SystemColors.MenuHighlight;
            btnEncrypt.BackgroundImageLayout = ImageLayout.Zoom;
            btnEncrypt.ForeColor = SystemColors.ButtonHighlight;
            btnEncrypt.Location = new Point(33, 247);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(135, 40);
            btnEncrypt.TabIndex = 4;
            btnEncrypt.Text = "Krptera och spara";
            btnEncrypt.UseVisualStyleBackColor = false;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = SystemColors.MenuHighlight;
            btnDecrypt.ForeColor = SystemColors.ControlLightLight;
            btnDecrypt.Location = new Point(376, 247);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(136, 40);
            btnDecrypt.TabIndex = 5;
            btnDecrypt.Text = "Dekrptera";
            btnDecrypt.UseVisualStyleBackColor = false;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(33, 338);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 6;
            label3.Text = "krypterade text";
            // 
            // txtResult
            // 
            txtResult.Location = new Point(34, 374);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(308, 27);
            txtResult.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(787, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(639, 374);
            dataGridView1.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.NavajoWhite;
            button1.Location = new Point(791, 430);
            button1.Name = "button1";
            button1.Size = new Size(136, 40);
            button1.TabIndex = 9;
            button1.Text = "Read data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnShowData_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Location = new Point(791, 618);
            button3.Name = "button3";
            button3.Size = new Size(140, 40);
            button3.TabIndex = 11;
            button3.Text = "Delet data";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnDelete_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(1098, 618);
            button4.Name = "button4";
            button4.Size = new Size(136, 40);
            button4.TabIndex = 12;
            button4.Text = "Update data";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnUpdate_Click;
            // 
            // txtBoxSalt
            // 
            txtBoxSalt.Location = new Point(376, 185);
            txtBoxSalt.Name = "txtBoxSalt";
            txtBoxSalt.Size = new Size(309, 27);
            txtBoxSalt.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(376, 150);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 16;
            label5.Text = "Salt lösenord";
            // 
            // texAvkrypterade
            // 
            texAvkrypterade.Location = new Point(376, 374);
            texAvkrypterade.Name = "texAvkrypterade";
            texAvkrypterade.Size = new Size(309, 27);
            texAvkrypterade.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(376, 338);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 18;
            label6.Text = "Avkrypterde text";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(376, 50);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 19;
            label4.Text = "Krypterde text";
            // 
            // txtKrypterde
            // 
            txtKrypterde.Location = new Point(376, 85);
            txtKrypterde.Name = "txtKrypterde";
            txtKrypterde.Size = new Size(315, 27);
            txtKrypterde.TabIndex = 20;
            // 
            // txtNewInput
            // 
            txtNewInput.Location = new Point(1098, 567);
            txtNewInput.Name = "txtNewInput";
            txtNewInput.Size = new Size(209, 27);
            txtNewInput.TabIndex = 21;
            // 
            // txtId
            // 
            txtId.Location = new Point(791, 567);
            txtId.Name = "txtId";
            txtId.Size = new Size(200, 27);
            txtId.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(1098, 534);
            label7.Name = "label7";
            label7.Size = new Size(157, 20);
            label7.TabIndex = 24;
            label7.Text = "ny klartext att kryptera";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(787, 534);
            label8.Name = "label8";
            label8.Size = new Size(186, 20);
            label8.TabIndex = 25;
            label8.Text = "ID för post som ska ta bort";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1456, 742);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtId);
            Controls.Add(txtNewInput);
            Controls.Add(txtKrypterde);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(texAvkrypterade);
            Controls.Add(label5);
            Controls.Add(txtBoxSalt);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(txtResult);
            Controls.Add(label3);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtSalt);
            Controls.Add(label2);
            Controls.Add(txtInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInput;
        private Label label2;
        private TextBox txtSalt;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label label3;
        private TextBox txtResult;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private Button button4;
        private TextBox txtBoxSalt;
        private Label label5;
        private TextBox texAvkrypterade;
        private Label label6;
        private Label label4;
        private TextBox txtKrypterde;
        private TextBox txtNewInput;
        private TextBox txtId;
        private Label label7;
        private Label label8;
    }
}
