using System.Drawing;
using System.Drawing.Imaging;

namespace FaceDetector.Filter
{
    class ViolaJones
    {
        
        private ulong[ , ] ToIntegral (Bitmap image)
        {
            unsafe
            {
                var bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadWrite, image.PixelFormat);

                var bytesPerPixel = Image.GetPixelFormatSize(image.PixelFormat) / 8;
                var widthInBytes = bitmapData.Width * bytesPerPixel;
                var ptrFirstPixel = (byte*)bitmapData.Scan0;

                var result = new ulong[bitmapData.Height, bitmapData.Width];

                for (var x = 0; x < bitmapData.Height; x++)
                {
                    var currentLine = ptrFirstPixel + (x * bitmapData.Stride);

                    for (var c = 0; c < widthInBytes; c += bytesPerPixel)
                    {
                        var y = c / bytesPerPixel;

                        /*
                            Формула для пикселя интегрального изорбражения
                            L(x,y) = I(x, y) - L(x - 1, y - 1) + L(x - 1, y) + L(x, y - 1),
                            где I(x, y) - яркость пикселя исходного изображения
                        */

                        result[x, y] = GetPixelBright(currentLine[c + 2], currentLine[c + 1], currentLine[c]);

                        if ((x - 1 >= 0) && (y - 1 >= 0))
                        {
                            result[x, y] -= result[x - 1, y - 1];
                        }

                        if (y - 1 >= 0)
                        {
                            result[x, y] += result[x, y - 1];
                        }

                        if (x - 1 >= 0)
                        {
                            result[x, y] += result[x - 1, y];
                        }
                    }
                }

                image.UnlockBits(bitmapData);
                return result;
            }
        }

        private byte GetPixelBright(int R, int G, int B)
        {
            //Значение яркости лежит в диапазоне от 0 до 255 
            return (byte) (0.3 * R + 0.59 * G + 0.11 * B);
        }
    }
}
