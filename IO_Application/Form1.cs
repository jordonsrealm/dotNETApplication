using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IO_Application {

    public partial class Form1 : Form {

        private int ACCURACY_RANGE = 1000;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            // Gets the path from the textbox
            string pic_Path = textBox1.Text;

            try { 

                OpenFileDialog open = new OpenFileDialog();

                if (open.ShowDialog() == DialogResult.OK) {
                    Bitmap bm = new Bitmap(open.FileName);

                    textBox1.Text = open.FileName;

                    int bmWidth = bm.Width;
                    int bmHeight = bm.Height;

                    int boxWidth = pictureBox1.Width;
                    int boxHeight = pictureBox1.Height;

                    double resize_X = 1, resize_Y = 1;

                    Bitmap newBitmap = new Bitmap(boxWidth, boxHeight);

                    if(bmWidth > boxWidth || bmHeight > boxHeight) {

                        // Work on resizing the x axis
                        if (bmWidth > boxWidth) {
                            resize_X = ((bmWidth * ACCURACY_RANGE) / boxWidth);
                            resize_X /= ACCURACY_RANGE;
                        }

                        // Work on resizing the y axis
                        if(bmHeight > boxHeight) {
                            resize_Y = ((bmHeight * ACCURACY_RANGE) / boxHeight);
                            resize_Y /= ACCURACY_RANGE;
                        }


                        for(int x = 0; x < boxWidth; x++) {
                            for(int y = 0; y < boxHeight; y++) {

                                newBitmap.SetPixel( x, y, bm.GetPixel((int)(x * resize_X), (int)(y * resize_Y)));

                            }
                        }

                        pictureBox1.Image = newBitmap;

                    }

                    else {
                        pictureBox1.Image = bm;
                    }
                    
                }
            }
            catch (Exception) {
                throw new ApplicationException("Failed loading image");
            }

        }
    }
}
