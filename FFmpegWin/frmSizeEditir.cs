using System.Drawing;
using FFMpegCore;

namespace FFmpegWin
{
    public partial class frmSizeEditir : Form
    {
        public frmSizeEditir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filename = @$"Z:\frames\322.jpg";
            var image = Image.FromFile(filename);

            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            originalW = pictureBox1.Width;
            originalH = pictureBox1.Height;
            ratForPhone = ((float)originalW / originalH);
            //ratForMonitor = ((float)originalH / originalW);
            IncretentValue = originalW;
        }
        private int originalW = 0;
        private int originalH = 0;
        private int IncretentValue = 0;
        private float ratForPhone = 0;
        //private float ratForMonitor = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            IncretentValue += 15;
            // float widthIncrease = 5* IncretentValue;
            var htoInc = getHeight(IncretentValue);
            pictureBox1.Width = (int)IncretentValue;

            pictureBox1.Height = (int)htoInc;
            //288   640
        }

        private float getHeight(float widthIncrease)
        {
            //var w = pictureBox1.Width;
            //var h = pictureBox1.Height;
            //var rat2 = ((float)w / h);
            var incH = widthIncrease / ratForPhone;// (float) Math.Ceiling(rat * widthIncrease);
            return incH;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            var tmp = (float)pictureBox1.Height / originalH;
            var topCut = (float)e.Y / tmp;
            if (rdoTop.Checked)
            {
                rdoTop.Text = $"Top|{topCut}";
            }
            else if (rdoB.Checked)
            {
                rdoB.Text = $"Top|{topCut}";
            }
            else if (rdoL.Checked)
            {
                tmp = (float)pictureBox1.Width / originalW;
                topCut = (float)e.X / tmp;
                rdoL.Text = $"Left|{topCut}";
            }
            else if (rdoR.Checked)
            {
                tmp = (float)pictureBox1.Width / originalW;
                topCut = (float)e.X / tmp;
                rdoR.Text = $"Right|{topCut}";
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalW == 0)
            {
                return;
            }

            var incDone = IncretentValue - originalW;
            //var ratt = (float)incDone / originalW;
            var AcY = (float)pictureBox1.Height / originalH;
            Text = $"X={e.X},  Y={e.Y},   incDone {incDone},  {(float)incDone / originalW}, acY {(float)e.Y / AcY}";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private readonly FrameDataObject frameDataObject = new FrameDataObject();

        private void button2_Click(object sender, EventArgs e)
        {
            //Draw();
            //return;
            //var outFiles
            //D:\Video-Content\cat
            var files = Directory.GetFiles(txtImgSrc.Text, $"*.{txtExt.Text}").ToList();
            files = files.OrderBy(f => int.Parse(Path.GetFileName(f).Replace($".{txtExt.Text}", ""))).ToList();
            frameDataObject.YLoc.Add(40);
            frameDataObject.StringsToWrite.Add("Console:");
            int i = 1, lop = 1;

            foreach (var file in files)
            {
                CrpoImage(file);
                continue;
                if (lop % 30 == 0)
                {
                    frameDataObject.StringsToWrite.Add(@$"frameId: -- {i}");
                    frameDataObject.YLoc.Add(frameDataObject.YLoc.Last() + 50);

                    if (i % 20 == 0)
                    {
                        frameDataObject.YLoc.Clear();
                        frameDataObject.StringsToWrite.Clear();
                        frameDataObject.YLoc.Add(20);
                        frameDataObject.StringsToWrite.Add("Console:");
                    }

                    i++;
                }

                lop++;
            }

            //Test();
            MessageBox.Show("DONE.");
        }

        private void CrpoImage(string filename)
        {

            // Load the image from file
            try
            {
                var image = Image.FromFile(filename);

                var tmp = rdoTop.Text.Split('|');
                var xS = 0;
                var xE = 0;
                var yS = 0;
                var yE = 0;

                tmp = rdoL.Text.Split('|');
                xS = tmp.Length > 1 ? int.Parse(Math.Round(decimal.Parse(tmp[1]), 0).ToString()) : 0;

                tmp = rdoR.Text.Split('|');
                xE = tmp.Length > 1 ? int.Parse(Math.Round(decimal.Parse(tmp[1]), 0).ToString()) : 0;

                ////////////////////////
                tmp = rdoTop.Text.Split('|');
                yS = tmp.Length > 1 ? int.Parse(Math.Round(decimal.Parse(tmp[1]), 0).ToString()) : 0;

                tmp = rdoB.Text.Split('|');
                yE = tmp.Length > 1 ? int.Parse(Math.Round(decimal.Parse(tmp[1]), 0).ToString()) : 0;

                xE = xE == 0 ? image.Width : xE;
                yE = yE == 0 ? image.Height : yE;
                // Define the crop rectangle
                var cropRect = new Rectangle(xS, yS, image.Width - xS - (image.Width - xE), image.Height - yS - (image.Height - yE));

                // Create a new bitmap with the crop rectangle size
                var bmp = new Bitmap(cropRect.Width, cropRect.Height);

                // Create a graphics object from the bitmap
                var g = Graphics.FromImage(bmp);
                // g.RotateTransform(90);

                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), cropRect, GraphicsUnit.Pixel);
                var font = new Font("Arial", 10);
                var format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                // Set the color and background for the text
                var brush = new SolidBrush(Color.Black);
                var backgroundBrush = new SolidBrush(Color.FromArgb(128, Color.Transparent));
                var i = 0;
                // Define the text rectangle
                var textRect = new RectangleF(0, 200, 300, frameDataObject.YLoc[i]);

                //foreach (string tag in frameDataObject.StringsToWrite)
                //{
                //    textRect = new RectangleF(0, 0, 300, frameDataObject.YLoc[i]);
                //    g.DrawString(tag, font, brush, textRect, format);
                //    i++;
                //}
                //var tag = "দেহ বিড়ালের, কলিজা বাঘের!";
                //textRect = new RectangleF(0, 180, 300, frameDataObject.YLoc[i]);
                //g.DrawString(tag, font, brush, textRect, format);
                image.Dispose();
                try
                {
                    bmp.Save(@"Z:\out\" + Path.GetFileName(filename));
                }
                catch (Exception)
                {
                }
                //Task.Delay(200).ContinueWith(t =>
                //{
                //    try { bmp.Save(@"D:\Video-Content\cat-out\" + Path.GetFileName(filename)); } catch (Exception ex) { }
                //});
                // Dispose the graphics object and the image
                g.Dispose();
                image.Dispose();
                bmp.Dispose();
            }
            catch (Exception)
            {
            }
        }
        //private void Draw() 
        // {
        //     var image = Image.FromFile(@$"C:\Users\iqbal\source\repos\ImageModify\ImageModify\bin\Debug\net7.0-windows\1.{txtExt.Text}");

        //     Bitmap bmp = new Bitmap(image.Width, image.Height);

        //     // Create a graphics object from the bitmap
        //     Graphics g = Graphics.FromImage(bmp);
        //     g.DrawImage(image, new Rectangle(0, 120, image.Width, image.Height - 120 - 120));
        //     // Set the font and text options
        //     Font font = new Font("Arial", 24);
        //     StringFormat format = new StringFormat();
        //     format.Alignment = StringAlignment.Center;
        //     format.LineAlignment = StringAlignment.Center;

        //     // Set the color and background for the text
        //     SolidBrush brush = new SolidBrush(Color.Black);
        //     SolidBrush backgroundBrush = new SolidBrush(Color.White);

        //     // Define the text rectangle
        //     RectangleF textRect = new RectangleF(0, 0, 100, 50);

        //     // Draw the background rectangle for the text
        //     g.FillRectangle(backgroundBrush, textRect);

        //     // Draw the text on the graphics object
        //     g.DrawString("Hello, World!", font, brush, textRect, format);

        //     // Save the bitmap with the text to file
        //     //bmp.Save("output.bmp");
        //     pictureBox1.Image = bmp; pictureBox1.Invalidate();
        //     // Dispose the graphics object and the bitmap
        //     //g.Dispose();
        //     //bmp.Dispose();

        // }

        //private void Test()
        //{ 
        //    // Load the image from file
        //    var image = Image.FromFile(@$"C:\Users\iqbal\source\repos\ImageModify\ImageModify\bin\Debug\net7.0-windows\1.{txtExt.Text}");

        //    // Create a new bitmap with the same dimensions as the image
        //    var bmp = new Bitmap(image.Width, image.Height);

        //    // Create a graphics object from the bitmap
        //    var g = Graphics.FromImage(bmp);

        //    // Rotate the graphics object by 90 degrees
        //    //g.RotateTransform(90);
        //    //120
        //    // Draw the image on the graphics object with the rotated transform
        //    g.DrawImage(image, new Rectangle(0, 120, image.Width, image.Height - 120 - 120));

        //    // Save the rotated image to file
        //    bmp.Save("output.png");

        //    // Dispose the graphics object and the image
        //    g.Dispose();
        //    image.Dispose();
        //    bmp.Dispose();

        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMake_Click(object sender, EventArgs e)
        {

            var inputAudioPath = @"Z:\audio.aac";
            {
               // FFMpeg.ReplaceAudio(inputPath, inputAudioPath, outputPath);
            }

            var inputImagePath = "/path/to/input/image";
            {
                var files = Directory.GetFiles(@"Z:\out", $"*.{txtExt.Text}").ToList();
                files = files.OrderBy(f => int.Parse(Path.GetFileName(f).Replace($".{txtExt.Text}", ""))).ToList();
                var imgs=files.ToArray();
             
                FFMpeg.JoinImageSequence(@"Z:\final\output.mp4", 30, imgs);
                //FFMpeg.PosterWithAudio(inputPath, inputAudioPath, outputPath);
                //// or using FFMpegCore.Extensions.System.Drawing.Common
                // using var image = Image.FromFile(inputImagePath);
                //image.AddAudio(inputAudioPath, outputPath);
                // // or using FFMpegCore.Extensions.SkiaSharp
                //using var skiaSharpImage = SKBitmap.Decode(inputImagePath);
                //skiaSharpImage.AddAudio(inputAudioPath, outputPath);
            }

        }
    }
}
