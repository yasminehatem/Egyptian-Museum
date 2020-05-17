namespace MuseumProj
{
    partial class ChangeAccountInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeAccountInfo));
            this.button9 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.Font = new System.Drawing.Font("Harlow Solid Italic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(226, 255);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(174, 71);
            this.button9.TabIndex = 45;
            this.button9.Text = "Update";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(215, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 26);
            this.textBox2.TabIndex = 43;
            this.textBox2.TabStop = false;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TabIndexChanged += new System.EventHandler(this.textBox2_TabIndexChanged);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 26);
            this.textBox1.TabIndex = 42;
            this.textBox1.TabStop = false;
            this.textBox1.TabIndexChanged += new System.EventHandler(this.textBox1_TabIndexChanged);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(35, 157);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(142, 36);
            this.button2.TabIndex = 40;
            this.button2.TabStop = false;
            this.button2.Text = "New Password";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.Location = new System.Drawing.Point(35, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 36);
            this.button7.TabIndex = 39;
            this.button7.TabStop = false;
            this.button7.Text = "New User Name";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(222, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(214, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "label2";
            // 
            // ChangeAccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(635, 353);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button7);
            this.Name = "ChangeAccountInfo";
            this.Text = "ChangeAccountInfo";
            this.Load += new System.EventHandler(this.ChangeAccountInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}