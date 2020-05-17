namespace MuseumProj
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.TxtBx_username = new System.Windows.Forms.TextBox();
            this.TxtBx_pass = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Btn_Login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBx_username
            // 
            this.TxtBx_username.Location = new System.Drawing.Point(529, 98);
            this.TxtBx_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtBx_username.Name = "TxtBx_username";
            this.TxtBx_username.Size = new System.Drawing.Size(171, 26);
            this.TxtBx_username.TabIndex = 6;
            this.TxtBx_username.TextChanged += new System.EventHandler(this.TxtBx_username_TextChanged);
            // 
            // TxtBx_pass
            // 
            this.TxtBx_pass.Location = new System.Drawing.Point(529, 173);
            this.TxtBx_pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtBx_pass.Name = "TxtBx_pass";
            this.TxtBx_pass.PasswordChar = '*';
            this.TxtBx_pass.Size = new System.Drawing.Size(171, 26);
            this.TxtBx_pass.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(365, 168);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(128, 36);
            this.button2.TabIndex = 24;
            this.button2.TabStop = false;
            this.button2.Text = "Password";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.Location = new System.Drawing.Point(365, 93);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 36);
            this.button7.TabIndex = 23;
            this.button7.TabStop = false;
            this.button7.Text = "User Name";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Btn_Login
            // 
            this.Btn_Login.AutoEllipsis = true;
            this.Btn_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Login.BackgroundImage")));
            this.Btn_Login.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Location = new System.Drawing.Point(423, 260);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(221, 69);
            this.Btn_Login.TabIndex = 8;
            this.Btn_Login.Text = "&Login";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtBx_username);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.TxtBx_pass);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBx_username;
        private System.Windows.Forms.TextBox TxtBx_pass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button Btn_Login;
    }
}