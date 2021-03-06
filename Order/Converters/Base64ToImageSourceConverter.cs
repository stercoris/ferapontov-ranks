﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Order.WPF.Converters
{
    class Base64ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage bitmapImage = new();

            int width = System.Convert.ToInt32(parameter);
            int height = width / 16 * 9;
            string base64String = (string)value;

            bitmapImage.BeginInit();
            bitmapImage.DecodePixelWidth = width;
            bitmapImage.DecodePixelHeight = height;
            bitmapImage.CacheOption = BitmapCacheOption.None;
            if (base64String == null)
            {
                return ("\\Images\\no_image.png");
            }
            var ms = new MemoryStream(System.Convert.FromBase64String(base64String));
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return (bitmapImage);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapSource image = (BitmapSource)value;
            MemoryStream outStream = new();
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(image));
            enc.Save(outStream);
            Bitmap bitmap = new(outStream);
            Bitmap bm = new(bitmap);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            outStream.Close();
            ms.Close();
            return (System.Convert.ToBase64String(byteImage));
        }
    }
}
