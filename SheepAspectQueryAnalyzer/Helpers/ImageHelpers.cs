using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SheepAspectQueryAnalyzer.Helpers
{
    public static class ImageHelpers
    {
       public static ImageSource ToImageSource(this Bitmap bitmap)
        {
            var hbitmap = bitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(bitmap.Width, bitmap.Height));
            }
            finally
            {
                NativeMethods.DeleteObject(hbitmap);
            }
        }

        public static class NativeMethods
        {
            [DllImport("gdi32")]
            public static extern int DeleteObject(IntPtr hObject);
        }
    }
}