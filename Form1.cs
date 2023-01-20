using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment01Question07
{
    public partial class Form1 : Form
    {

        OpenFileDialog ofd = new OpenFileDialog();
        Operations oObj = new Operations();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox1.ImageLocation = picPath;
                oObj.LoadGrayScaleImage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox2.ImageLocation = picPath;
                oObj.LoadBinaryImage();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            oObj.ANDOperation();
            pictureBox3.ImageLocation = "logicAnd.jpg";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oObj.OROperation();
            pictureBox4.ImageLocation = "logicOr.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            oObj.NotOperation();
            pictureBox5.ImageLocation = "logicNot.jpg";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            oObj.XorOperation();
            pictureBox6.ImageLocation = "logicXor.jpg";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox7.ImageLocation = picPath;
                oObj.LoadGrayScaleImage();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox8.ImageLocation = picPath;
                oObj.LoadBinaryImage();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String stringOpacity = comboBox1.Text.ToString();
            float floatOpacity = float.Parse(stringOpacity);

            Bitmap first = new Bitmap(pictureBox7.Image);
            Bitmap second = oObj.SetImageOpacity(pictureBox8.Image, floatOpacity);
            Bitmap result = new Bitmap(Math.Max(first.Width, second.Width), Math.Max(first.Height, second.Height));
            Console.WriteLine(first.Width);
            Graphics g = Graphics.FromImage(result);
            g.DrawImageUnscaled(first, 0, 0);
            g.DrawImageUnscaled(second, 0, 0);
            pictureBox9.Image = result;
            result.Save("result.jpg");
            pictureBox9.ImageLocation = "result.jpg";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox10.ImageLocation = picPath;
                oObj.LoadGrayScaleImage();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                oObj.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox11.ImageLocation = picPath;
                oObj.LoadBinaryImage();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            oObj.ANDOperation();
            pictureBox12.ImageLocation = "logicAnd.jpg";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("0.3");
            comboBox1.Items.Add("0.7");
        }
    }
}
