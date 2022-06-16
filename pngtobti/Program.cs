using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace pngtobti
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("* png2bti by Anthe");
                Console.WriteLine("* uses nconvert");
                Console.WriteLine("* uses tga2bti by lunaboy");
                Console.WriteLine("* used software belongs to their respective owners");
                Console.WriteLine("* usage: tga2bti \"file.png\"");
            }
            else
            {
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

                Process toTga = new Process();
                toTga.StartInfo.Arguments = "-out tga \"" + args[0] + "\"";
                string tgafilename = Path.GetFileName(args[0]);
                toTga.StartInfo.FileName = Path.GetDirectoryName(appPath.Replace("file:///", "")) + "/bin/nconvert.exe";
                toTga.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                toTga.Start();
                toTga.WaitForExit();

                Process toBti = new Process();
                toBti.StartInfo.Arguments = "-4A3 \"" + tgafilename.Replace("png", "tga") + "\" \"" + tgafilename.Replace("png", "bti") + "\"";
                toBti.StartInfo.FileName = Path.GetDirectoryName(appPath.Replace("file:///", "")) + "/bin/tga2bti.exe";
                toBti.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                toBti.Start();
                toBti.WaitForExit();

                //File.Delete(tgafilename.Replace("png", "tga"));
            }
        }
    }
}
