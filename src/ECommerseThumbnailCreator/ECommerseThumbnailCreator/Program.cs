using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerseThumbnailCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int start = 0;
                int pixels = 0;
                if (Int32.TryParse(args[0], out pixels))
                {
                    ThumbnailResizer.Initialize(pixels);
                    ++start;
                }

                for (int i = start; i < args.Length; ++i)
                    ThumbnailResizer.ResizeImage(args[i]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
