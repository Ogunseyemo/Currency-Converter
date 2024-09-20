namespace MOA_Currency_Converter
{
    partial class MOAConversion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOAConversion));
            this.AmounttextBox = new System.Windows.Forms.TextBox();
            this.namelabel1 = new System.Windows.Forms.Label();
            this.ExchangeMoneypictureBox = new System.Windows.Forms.PictureBox();
            this.Amountlabel = new System.Windows.Forms.Label();
            this.fromlabel = new System.Windows.Forms.Label();
            this.tolabel = new System.Windows.Forms.Label();
            this.Resultlabel = new System.Windows.Forms.Label();
            this.Convertbutton = new System.Windows.Forms.Button();
            this.AdminLoginbutton = new System.Windows.Forms.Button();
            this.ExchangearrowspictureBox = new System.Windows.Forms.PictureBox();
            this.FromcomboBox = new System.Windows.Forms.ComboBox();
            this.TocomboBox = new System.Windows.Forms.ComboBox();
            this.CloseXbutton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeMoneypictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangearrowspictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AmounttextBox
            // 
            this.AmounttextBox.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmounttextBox.Location = new System.Drawing.Point(637, 187);
            this.AmounttextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AmounttextBox.Name = "AmounttextBox";
            this.AmounttextBox.Size = new System.Drawing.Size(318, 29);
            this.AmounttextBox.TabIndex = 0;
            this.AmounttextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmounttextBox_KeyPress);
            // 
            // namelabel1
            // 
            this.namelabel1.AutoSize = true;
            this.namelabel1.Font = new System.Drawing.Font("Harrington", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel1.Location = new System.Drawing.Point(338, 45);
            this.namelabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.namelabel1.Name = "namelabel1";
            this.namelabel1.Size = new System.Drawing.Size(761, 76);
            this.namelabel1.TabIndex = 1;
            this.namelabel1.Text = "MOA Currency Converter";
            // 
            // ExchangeMoneypictureBox
            // 
            this.ExchangeMoneypictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExchangeMoneypictureBox.BackgroundImage")));
            this.ExchangeMoneypictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExchangeMoneypictureBox.InitialImage = null;
            this.ExchangeMoneypictureBox.Location = new System.Drawing.Point(0, 0);
            this.ExchangeMoneypictureBox.Name = "ExchangeMoneypictureBox";
            this.ExchangeMoneypictureBox.Size = new System.Drawing.Size(312, 622);
            this.ExchangeMoneypictureBox.TabIndex = 2;
            this.ExchangeMoneypictureBox.TabStop = false;
            // 
            // Amountlabel
            // 
            this.Amountlabel.AutoSize = true;
            this.Amountlabel.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amountlabel.Location = new System.Drawing.Point(477, 194);
            this.Amountlabel.Name = "Amountlabel";
            this.Amountlabel.Size = new System.Drawing.Size(133, 22);
            this.Amountlabel.TabIndex = 3;
            this.Amountlabel.Text = "Enter Amount";
            // 
            // fromlabel
            // 
            this.fromlabel.AutoSize = true;
            this.fromlabel.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromlabel.Location = new System.Drawing.Point(477, 269);
            this.fromlabel.Name = "fromlabel";
            this.fromlabel.Size = new System.Drawing.Size(56, 22);
            this.fromlabel.TabIndex = 4;
            this.fromlabel.Text = "From";
            // 
            // tolabel
            // 
            this.tolabel.AutoSize = true;
            this.tolabel.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolabel.Location = new System.Drawing.Point(756, 269);
            this.tolabel.Name = "tolabel";
            this.tolabel.Size = new System.Drawing.Size(35, 22);
            this.tolabel.TabIndex = 5;
            this.tolabel.Text = "To";
            // 
            // Resultlabel
            // 
            this.Resultlabel.AutoSize = true;
            this.Resultlabel.Font = new System.Drawing.Font("Baskerville Old Face", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultlabel.Location = new System.Drawing.Point(475, 497);
            this.Resultlabel.Name = "Resultlabel";
            this.Resultlabel.Size = new System.Drawing.Size(251, 31);
            this.Resultlabel.TabIndex = 6;
            this.Resultlabel.Text = "1 USD = 1500 NGN";
            this.Resultlabel.Visible = false;
            // 
            // Convertbutton
            // 
            this.Convertbutton.BackColor = System.Drawing.Color.DarkGray;
            this.Convertbutton.Font = new System.Drawing.Font("Baskerville Old Face", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convertbutton.Location = new System.Drawing.Point(826, 402);
            this.Convertbutton.Name = "Convertbutton";
            this.Convertbutton.Size = new System.Drawing.Size(129, 45);
            this.Convertbutton.TabIndex = 7;
            this.Convertbutton.Text = "Convert";
            this.Convertbutton.UseVisualStyleBackColor = false;
            this.Convertbutton.Click += new System.EventHandler(this.Convertbutton_Click);
            // 
            // AdminLoginbutton
            // 
            this.AdminLoginbutton.BackColor = System.Drawing.Color.Gainsboro;
            this.AdminLoginbutton.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminLoginbutton.Location = new System.Drawing.Point(977, 4);
            this.AdminLoginbutton.Name = "AdminLoginbutton";
            this.AdminLoginbutton.Size = new System.Drawing.Size(115, 26);
            this.AdminLoginbutton.TabIndex = 8;
            this.AdminLoginbutton.Text = "Admin Login";
            this.AdminLoginbutton.UseVisualStyleBackColor = false;
            this.AdminLoginbutton.Click += new System.EventHandler(this.AdminLoginbutton_Click);
            // 
            // ExchangearrowspictureBox
            // 
            this.ExchangearrowspictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExchangearrowspictureBox.BackgroundImage")));
            this.ExchangearrowspictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExchangearrowspictureBox.Location = new System.Drawing.Point(660, 311);
            this.ExchangearrowspictureBox.Name = "ExchangearrowspictureBox";
            this.ExchangearrowspictureBox.Size = new System.Drawing.Size(49, 32);
            this.ExchangearrowspictureBox.TabIndex = 9;
            this.ExchangearrowspictureBox.TabStop = false;
            this.ExchangearrowspictureBox.Click += new System.EventHandler(this.ExchangearrowspictureBox_Click);
            // 
            // FromcomboBox
            // 
            this.FromcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromcomboBox.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromcomboBox.FormattingEnabled = true;
            this.FromcomboBox.Location = new System.Drawing.Point(481, 311);
            this.FromcomboBox.Name = "FromcomboBox";
            this.FromcomboBox.Size = new System.Drawing.Size(121, 32);
            this.FromcomboBox.TabIndex = 10;
            // 
            // TocomboBox
            // 
            this.TocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TocomboBox.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TocomboBox.FormattingEnabled = true;
            this.TocomboBox.Location = new System.Drawing.Point(760, 311);
            this.TocomboBox.Name = "TocomboBox";
            this.TocomboBox.Size = new System.Drawing.Size(121, 32);
            this.TocomboBox.TabIndex = 11;
            // 
            // CloseXbutton1
            // 
            this.CloseXbutton1.BackColor = System.Drawing.Color.Gainsboro;
            this.CloseXbutton1.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseXbutton1.Location = new System.Drawing.Point(1092, 4);
            this.CloseXbutton1.Name = "CloseXbutton1";
            this.CloseXbutton1.Size = new System.Drawing.Size(29, 26);
            this.CloseXbutton1.TabIndex = 12;
            this.CloseXbutton1.Text = "X";
            this.CloseXbutton1.UseVisualStyleBackColor = false;
            this.CloseXbutton1.Click += new System.EventHandler(this.CloseXbutton1_Click);
            // 
            // MOAConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1125, 622);
            this.Controls.Add(this.CloseXbutton1);
            this.Controls.Add(this.TocomboBox);
            this.Controls.Add(this.FromcomboBox);
            this.Controls.Add(this.ExchangearrowspictureBox);
            this.Controls.Add(this.AdminLoginbutton);
            this.Controls.Add(this.Convertbutton);
            this.Controls.Add(this.Resultlabel);
            this.Controls.Add(this.tolabel);
            this.Controls.Add(this.fromlabel);
            this.Controls.Add(this.Amountlabel);
            this.Controls.Add(this.ExchangeMoneypictureBox);
            this.Controls.Add(this.namelabel1);
            this.Controls.Add(this.AmounttextBox);
            this.Font = new System.Drawing.Font("Baskerville Old Face", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MOAConversion";
            this.Text = "MOA Conversion";
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeMoneypictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangearrowspictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AmounttextBox;
        private System.Windows.Forms.Label namelabel1;
        private System.Windows.Forms.PictureBox ExchangeMoneypictureBox;
        private System.Windows.Forms.Label Amountlabel;
        private System.Windows.Forms.Label fromlabel;
        private System.Windows.Forms.Label tolabel;
        private System.Windows.Forms.Label Resultlabel;
        private System.Windows.Forms.Button Convertbutton;
        private System.Windows.Forms.Button AdminLoginbutton;
        private System.Windows.Forms.PictureBox ExchangearrowspictureBox;
        private System.Windows.Forms.ComboBox FromcomboBox;
        private System.Windows.Forms.ComboBox TocomboBox;
        private System.Windows.Forms.Button CloseXbutton1;
    }
}

