using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseThumbnailCreator
{
    public static class ThumbnailResizer
    {
        static ThumbnailResizer()
        {
            PREFIX = $"{Directory.GetCurrentDirectory()}\\t";
        }
        public static Bitmap ResizeImage(string imageFilePath)
        {
            Image image = Image.FromFile(imageFilePath);
            var destRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            var destImage = new Bitmap(WIDTH, HEIGHT);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.Tile);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }

                // Fix orientation if needed.
                if (image.PropertyIdList.Contains(OrientationKey))
                {
                    var orientation = (int)image.GetPropertyItem(OrientationKey).Value[0];
                    switch (orientation)
                    {
                        case NotSpecified: // Assume it is good.
                        case NormalOrientation:
                            // No rotation required.
                            break;
                        case MirrorHorizontal:
                            destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            break;
                        case UpsideDown:
                            destImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case MirrorVertical:
                            destImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                            break;
                        case MirrorHorizontalAndRotateRight:
                            destImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                            break;
                        case RotateLeft:
                            destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case MirorHorizontalAndRotateLeft:
                            destImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                            break;
                        case RotateRight:
                            destImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            throw new NotImplementedException("An orientation of " + orientation + " isn't implemented.");
                    }
                }
            }
            
            destImage.Save($"{PREFIX}{Path.GetFileName(imageFilePath)}");
            return destImage;
        }

        private static readonly string PREFIX;

        private const int WIDTH = 100;
        private const int HEIGHT = 100;
        private const int OrientationKey = 0x0112;
        private const int NotSpecified = 0;
        private const int NormalOrientation = 1;
        private const int MirrorHorizontal = 2;
        private const int UpsideDown = 3;
        private const int MirrorVertical = 4;
        private const int MirrorHorizontalAndRotateRight = 5;
        private const int RotateLeft = 6;
        private const int MirorHorizontalAndRotateLeft = 7;
        private const int RotateRight = 8;
    }
}