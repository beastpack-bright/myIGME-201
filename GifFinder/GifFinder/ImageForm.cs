﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;

namespace GifFinder
{
    public partial class ImageForm : Form
    {
        string title;
        public ImageForm(GifFinder parent, string url, string title)
        {
            InitializeComponent();

            this.MdiParent = parent;
            this.Text = title;
            this.title = title;

            parent.closeAllToolStripMenuItem.Click += new EventHandler(CloseAllToolStripMenuItem_Click);
            parent.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem_Click);

            this.FormClosing += new FormClosingEventHandler(ImageForm_FormClosing);
            pictureBox1.ImageLocation = url;
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GifFinder parent = (GifFinder)this.MdiParent;
            parent.closeAllToolStripMenuItem.Click += new EventHandler(CloseAllToolStripMenuItem_Click);
            parent.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem_Click);
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this != this.MdiParent.ActiveMdiChild)
            {
                return;
            }
            saveFileDialog1.Filter = "Bmp(*.BMP)|*.BMP|Jpg(*.JPG)|*.JPG|Png(*.PNG)|*.PNG|Gif(*.GIF)|*.GIF|";
            saveFileDialog1.FileName = this.title;
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                switch(Path.GetExtension(saveFileDialog1.FileName).ToUpper())
                {
                    case ".BMP":
                        pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case ".PNG":
                        pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case ".JPG":
                        pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case ".GIF":
                        pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
            }
        }
    }
}
