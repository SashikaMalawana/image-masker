using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Assignment01Question07
{
    class Operations
    {
        IplImage src, grayImage, maskImage, binaryImage, grayImgResult, colorImage, colorMask, negativeImage;

        public void LoadOriginalImage(String fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage(fname, src);
        }

        public void LoadGrayScaleImage()
        {
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", grayImage);

            colorImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            Cv.CvtColor(src, colorImage, ColorConversion.RgbaToRgb);
        }

        public void LoadGrayScaleMaskImage()
        {
            maskImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, maskImage, ColorConversion.RgbaToGray);
            Cv.SaveImage("mask.jpg", maskImage);

            colorMask = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            Cv.CvtColor(src, colorMask, ColorConversion.RgbaToRgb);
        }

        public void LoadBinaryImage()
        {
            LoadGrayScaleMaskImage();
            binaryImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.Threshold(maskImage, binaryImage, 150, 255, ThresholdType.Binary);
            Cv.SaveImage("binary.jpg", binaryImage);

        }

        public void PerformANDLogicOperations()
        {
            grayImgResult = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);

            for (int y = 1; y < binaryImage.Height; y++)
            {
                for (int x = 1; x < binaryImage.Width; x++)
                {
                    double getPixelValue = 0, newPixelValue = 0, value = 0;

                    getPixelValue = Cv.GetReal2D(binaryImage, y, x);
                    value = Cv.GetReal2D(grayImage, y, x);

                    if (getPixelValue == 0)
                    {
                        newPixelValue = 0;
                    }
                    else if (getPixelValue == 255)
                    {
                        newPixelValue = value;
                    }

                    Cv.SetReal2D(grayImgResult, y, x, newPixelValue);
                }
            }
            Cv.SaveImage("logicAnd.jpg", grayImgResult);
        }

        public void PerformORLogicOperations()
        {
            grayImgResult = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);

            for (int y = 1; y < binaryImage.Height; y++)
            {
                for (int x = 1; x < binaryImage.Width; x++)
                {
                    double getPixelValue = 0, newPixelValue = 0, value = 0;

                    getPixelValue = Cv.GetReal2D(binaryImage, y, x);
                    value = Cv.GetReal2D(grayImage, y, x);

                    if (getPixelValue == 0)
                    {
                        newPixelValue = value;
                    }
                    else if (getPixelValue == 255)
                    {
                        newPixelValue = value+50;
                    }

                    Cv.SetReal2D(grayImgResult, y, x, newPixelValue);
                }
            }
            Cv.SaveImage("logicOr.jpg", grayImgResult);
        }

        public void ANDOperation()
        {
            grayImgResult = Cv.CreateImage(colorImage.Size, BitDepth.U8, 3);
            Cv.And(colorImage, colorMask, grayImgResult);
            Cv.SaveImage("logicAnd.jpg", grayImgResult);
        }

        public void OROperation()
        {
            grayImgResult = Cv.CreateImage(colorImage.Size, BitDepth.U8, 3);
            Cv.Or(colorImage, colorMask, grayImgResult);
            Cv.SaveImage("logicOr.jpg", grayImgResult);
        }

        public void NotOperation()
        {
            grayImgResult = Cv.CreateImage(colorImage.Size, BitDepth.U8, 3);
            Cv.Not(colorImage, grayImgResult);
            Cv.SaveImage("logicNot.jpg", grayImgResult);
        }

        public void XorOperation()
        {
            grayImgResult = Cv.CreateImage(colorImage.Size, BitDepth.U8, 3);
            Cv.Xor(colorImage, colorMask, grayImgResult);
            Cv.SaveImage("logicXor.jpg", grayImgResult);
        }

        public Bitmap SetImageOpacity(Image image, float opacity)
        {
            try
            {
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = opacity;
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
