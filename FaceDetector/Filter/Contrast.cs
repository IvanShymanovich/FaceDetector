using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FaceDetector.Filter
{
    class ContrastFilter
    {
        public Bitmap apply(Bitmap image, Rectangle rectangle, int contrast_count)
        {
            if (contrast_count == 100)
                return image;
            if (contrast_count == 200)
                contrast_count = 199;
            Bitmap contrast = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (var graphics = Graphics.FromImage(contrast))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            Int32 percent = contrast_count - 100;

            // look at every pixel in the blur rectangle
            // I = (I • (100 – N) + 128 • N) / 100 (2)
            // Увеличение контрастности на N процентов:
            // I = (I • 100 – 128 • N) / (100 – N) (3)
            for (Int32 x = 0; x < rectangle.Width; x++)
            {
                for (Int32 y = 0; y < rectangle.Height; y++)
                {
                    Color pixel = contrast.GetPixel(x, y);
                    contrast.SetPixel(x, y, Color.FromArgb(contrast_item_pixel(pixel.R, percent),
                        contrast_item_pixel(pixel.G, percent),
                        contrast_item_pixel(pixel.B, percent)));
                }
            }

            return contrast;
        }

        private int contrast_item_pixel(int contrast, int percent)
        {
            int result;
            if (percent > 0)
            {
                result = (contrast * 100 - 128 * percent) / (100 - percent);
            }
            else
            {
                result = (contrast * (100 - percent) + 128 * percent)/100;
            }
            if (result < 0)
                result = 0;
            if (result > 255)
                result = 255;
            return result;
        }

        public Bitmap apply2(Bitmap image, Rectangle rectangle, int contrast_count)
        {
            int lAB = 0;
            for (int y=0; y<image.Height; y++)
            for (int x = 0; x < image.Width; x++)
            {
                Color pixel = image.GetPixel(x, y);
	            
	            lAB += (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B* 0.114);
            }

            //средняя яркость 
            lAB /= image.Height * image.Width;   

            // для каждой яркости производим преобразование
            int[] array = new int[256];
             double k = 1.0 + contrast_count / 100.0;
             for (int i = 0; i < 256; i++)
            {
	            int delta = (int)i - lAB;
	            int temp  = (int)(lAB + k *delta);

	            if (temp < 0)
		            temp = 0;

	            if (temp >= 255)
		            temp = 255;
	            array[i] = temp;
            }

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    image.SetPixel(x, y, Color.FromArgb(array[pixel.R], array[pixel.G], array[pixel.B]));

                }
            return image;
        }
    }
}
