using System.IO;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ETL
{
    namespace Common
    {
        public static class Helper
        {
            public static byte[] GetBytesFromSource(string sFilename)
            {
                if (File.Exists(sFilename))
                {
                    return File.ReadAllBytes(sFilename);
                }
                return null;
            }
            public static byte[] ResizeImageFile(byte[] imageFile, Size newSize, ImageFormat imageFormat)
            {
                using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
                {
                    Size newSizeTemp = CalculateDimensions(oldImage.Size, newSize);
                    using (Bitmap newImage = new Bitmap(newSizeTemp.Width, newSizeTemp.Height, PixelFormat.Format24bppRgb))
                    {
                        using (Graphics canvas = Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.AntiAlias;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSizeTemp));
                            MemoryStream m = new MemoryStream();
                            newImage.Save(m, imageFormat);
                            return m.GetBuffer();
                        }
                    }
                }
            }
            private static Size CalculateDimensions(Size oldSize, Size newSize)
            {
                Size newSizeTemp = new Size();
                if (oldSize.Height > oldSize.Width)
                {
                    newSizeTemp.Width = (int)(oldSize.Width * ((float)newSize.Height / (float)oldSize.Height));
                    newSizeTemp.Height = newSize.Height;
                }
                else
                {
                    newSizeTemp.Width = newSize.Width;
                    newSizeTemp.Height = (int)(oldSize.Height * ((float)newSize.Width / (float)oldSize.Width));
                }
                return newSizeTemp;
            }
            public static MemoryStream GetMemoryStream(byte[] byteBLOBData)
            {
                return new MemoryStream(byteBLOBData);
            }
        }
    }
}
