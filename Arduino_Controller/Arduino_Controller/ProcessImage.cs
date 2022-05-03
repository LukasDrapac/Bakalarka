using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Arduino_Controller
{
    class ProcessImage
    {
        private int xPosition = 100;
        private int yPosition = 100;
        private int xLength = 250;
        private int yLength = 250;



        string[] images;
        Rectangle cropRectangle;
        Bitmap croppedImage;

        public Bitmap processImage(string path, string imageName)
        {
            if (croppedImage != null)
            {
                croppedImage.Dispose();
                croppedImage = null;
            }
            images = Directory.GetFiles(path);
            //Console.WriteLine(images);
            for (int i = images.Length - 1; i >= 0; i--)
            {
                string name = imageName + "_" + (i) + ".jpg";
                Console.WriteLine(name);
                for (int j = 0; j < images.Length; j++)
                {
                    if (images[j].Contains(name))
                    {
                        Console.WriteLine(images[j]);
                        cropImage(images[j]);
                        j = images.Length - 1;
                    }
                }
            }
            croppedImage.Save(path + "/Processed_Image.jpg");
            return croppedImage;
        }

        private void cropImage(string picturePath)
        {
            cropRectangle = new Rectangle(xPosition, yPosition, xLength, yLength);
            Bitmap imageToCrop = new Bitmap(picturePath);
            Bitmap cropped = imageToCrop.Clone(cropRectangle, imageToCrop.PixelFormat);
            makePanoImage(cropped);

            imageToCrop.Dispose();
            cropped.Dispose();
        }

        private void makePanoImage(Bitmap bitmap)
        {
            if (croppedImage == null)
            {
                croppedImage = new Bitmap(bitmap.Width, bitmap.Height);

                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    g.DrawImage(bitmap, 0, 0);
                    g.Dispose();
                }
            }
            else
            {
                Bitmap temporaryBitmap = new Bitmap(croppedImage);
                croppedImage = new Bitmap(temporaryBitmap.Width + bitmap.Width, temporaryBitmap.Height);

                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    g.DrawImage(temporaryBitmap, 0, 0);
                    g.DrawImage(bitmap, temporaryBitmap.Width, 0);
                    g.Dispose();
                }
                temporaryBitmap.Dispose();
            }

        }
    }
}
