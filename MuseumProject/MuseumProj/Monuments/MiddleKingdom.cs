﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumProj
{
    public partial class MiddleKingdom : Form
    {
        List<PictureBox> PictureList = new List<PictureBox>();
        private Controller controllerObj; // A Reference of type Controller 
        public MiddleKingdom()
        {
            InitializeComponent();
            controllerObj = new Controller(); // Create the Controler Object
        }

        private void MiddleKingdom_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            int PieceCount = controllerObj.CountPieces(4);
            int x = 0;
            int y = 0;
            //PictureBox[] picture = new PictureBox[PieceCount];

            for (int i = 1; i <= PieceCount; i++)
            {
                string ImagePath = controllerObj.GetPieceImage(4, i);

                PictureBox picture = new PictureBox
                {
                    Name = i.ToString(),
                    Size = new Size(212, 185),
                    Location = new Point(30 + x, 37 + y),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Padding = new Padding(10,10,10,10)
                };

                if (ImagePath != "")
                {
                    picture.Image = Image.FromFile(@ImagePath);
                }

                PictureList.Add(picture);

                Label label = new Label();
                label.Location = new Point(30 + x, 230 + y);
                label.Text = controllerObj.GetPieceTitle(4, i);
                label.AutoSize = true;
                label.BackColor = Color.Transparent;
                //label.TextAlign = ContentAlignment.MiddleCenter;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Font = new Font("Microsoft Sans Serif",9);
                label.Size = new Size(300,25);
                label.MaximumSize = new Size(212, 40);
                this.Controls.Add(label);
                this.Controls.Add(PictureList[i-1]);
                PictureList[i-1].MouseClick += new MouseEventHandler(picture_click);
                x = x + 252;
                if (i % 5 == 0)
                {
                    x = 0;
                    y = y + 230;
                }
            }
        }
        protected void picture_click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            string name = clickedPictureBox.Name;

            int ID = Int32.Parse(name);
    
            Piece p = new Piece(4, ID);
            p.Show();
        }   
        
    }
}
