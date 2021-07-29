using System.Drawing;
using FastBitmapLib;

namespace AutoAIM.Scr
{
    class ScreenCapture
    {
        private static Bitmap GetCapture()
        {
            return ApplicationCapture.CaptureApplication("League of Legends");
        }
        public static Point? GetColorPosition(Color color)
        {
            int searchValue = color.ToArgb();

            using (Bitmap bmp = GetCapture())
            {
                using (FastBitmap bitmap = new FastBitmap(bmp))
                {
                    bitmap.Lock();

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            if (searchValue == bitmap.GetPixelInt(x, y))
                            {
                                bitmap.Unlock();
                                return new Point(x, y);
                            }
                        }
                    }
                }
            }
            return null;
        }

    }
}
