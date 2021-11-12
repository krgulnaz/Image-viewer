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
        private int pictureBoxHeight, pictureBozWidth;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBoxHeight = this.pictureBox1.Height;
            this.pictureBozWidth = this.pictureBox1.Width;

            this.listBox1.Sorted = true;
            FillListBox(Application.StartupPath + "\\");
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
