using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int pictureBoxHeight, pictureBoxWidth;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBoxHeight = this.pictureBox1.Height;
            this.pictureBoxWidth = this.pictureBox1.Width;

            this.listBox1.Sorted = true;
            FillListBox(Application.StartupPath + "\\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select the folder";
            fb.ShowNewFolderButton = false;

            if (fb.ShowDialog() == DialogResult.OK)
            {
                if (!FillListBox(fb.SelectedPath + "\\"))
                    pictureBox1.Image = null;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double mh, mw;
            pictureBox1.Image = new Bitmap(label1.Text + listBox1.SelectedItem.ToString());
            if ((pictureBox1.Image.Width > pictureBoxWidth) ||
                (pictureBox1.Image.Height > pictureBoxHeight))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                mh = (double)pictureBoxHeight / (double)pictureBox1.Image.Height;
                mw = (double)pictureBoxWidth / (double)pictureBox1.Image.Width;

                if (mh < mw)
                {
                    pictureBox1.Width = Convert.ToInt32(pictureBox1.Image.Width * mh);
                    pictureBox1.Height = pictureBoxHeight;
                }
                else
                {
                    pictureBox1.Width = pictureBoxWidth;
                    pictureBox1.Height = Convert.ToInt32(pictureBox1.Image.Height * mw);
                }
            }
            else
            {
                if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        public Boolean FillListBox(string aPath)
        {
            DirectoryInfo di = new DirectoryInfo(aPath);
            FileInfo[] fileInfo = di.GetFiles("*.jpg");
            listBox1.Items.Clear();

            foreach (FileInfo fc in fileInfo)
            {
                listBox1.Items.Add(fc.Name);
            }
            label1.Text = aPath;

            if (fileInfo.Length == 0)
            {
                return false;
            }
            else
            {
                listBox1.SelectedIndex = 0;
                return true;
            }
        }

    }
    
}
