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
                foreach (string path in args)
                    ThumbnailResizer.ResizeImage(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }
        }

    }
}
