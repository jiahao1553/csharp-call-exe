using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_call_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            var svmResult = RunLibSVM();
            Console.WriteLine(svmResult);
            Console.Read();
        }

        public static string RunLibSVM()
        {
            //Copy and paste the windows folder in the zip file to your desktop
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "windows");

            ProcessStartInfo psi = new ProcessStartInfo(path+"\\svmpredict.exe");

            //Put the input and command to that command here
            psi.Arguments = path + "\\hd3.TEST " + path + "\\hd3.train.model " + path + "\\hd0.out";

            //to make sure no CMD window is show when running the test
            psi.CreateNoWindow = true; 
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            Process svm;
            svm = Process.Start(psi);
            StreamReader svmOut = svm.StandardOutput;
            string output = "Error";
            while (svm.HasExited == false)
            {
                output = svmOut.ReadToEnd();
            }
            return output;
        }
    }
}
