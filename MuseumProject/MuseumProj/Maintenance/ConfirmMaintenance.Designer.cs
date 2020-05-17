namespace MuseumProj
{
    partial class ConfirmMaintenance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmMaintenance));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.MaximumSize = new System.Drawing.Size(267, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 44);
            this.label1.TabIndex = 14;
            this.label1.Text = "You are requesting maintenance on the following date:";
            // 
            // Btn_Login
            // 
            this.Btn_Login.AutoEllipsis = true;
            this.Btn_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Login.BackgroundImage")));
            this.Btn_Login.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Location = new System.Drawing.Point(181, 158);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(111, 45);
            this.Btn_Login.TabIndex = 21;
            this.Btn_Login.Text = "Confirm";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // ConfirmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(325, 232);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConfirmMaintenance";
            this.Text = "Confirm Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmMaintenance_FormClosing);
            this.Load += new System.EventHandler(this.ConfirmMaintenance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Timer timer1;
    }
}