using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tt
{
    static class Program
    {
        private static string GenerateString(int length = 25)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
        static void Main(string[] args)
        {
            string commit = "\'" + GenerateString()+ "\'";
            string remoteControl = "https://github.com/HaciIsma/tt.git";
            //string command = $@"cd..; cd..; git init;git add .; git commit -m {commit};git remote add origin {remoteControl} ;git push -u origin master;pause";

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("cd ..");
            process.StandardInput.WriteLine("cd ..");
            process.StandardInput.WriteLine("git init");
            process.StandardInput.WriteLine("git add .");
            process.StandardInput.WriteLine($"git commit -m {commit}");
            process.StandardInput.WriteLine($"git remote add origin {remoteControl}");
            process.StandardInput.WriteLine("git push -u origin master");
            process.StandardInput.WriteLine("exit");
            process.StandardInput.Flush();
            //process.StandardInput.Close();
            //process.WaitForExit();
            //Console.WriteLine(process.StandardOutput.ReadToEnd());
            //Console.ReadKey();
        }
    }
}
