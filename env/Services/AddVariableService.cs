using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace env.Services
{
    internal static class AddVariableService
    {
        public static void AddVariable(string[] args)
        {
            if (args.Length >= 2)
            {
                for (int i = 2; i < args.Length; i++)
                {
                    Console.WriteLine(args[i]);
                    string[] keyValue = args[i].Split('=');
                    if (keyValue.Length == 2)
                    {
                        Environment.SetEnvironmentVariable(keyValue[0], keyValue[1]);
                    }
                }

                if (args.Length >= 3)
                {
                    var processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = args[1];
                    processStartInfo.Arguments = string.Join(" ", args.Skip(args.Length));
                    using (Process process = Process.Start(processStartInfo))
                    {
                        process.WaitForExit();
                    }
                }
            }
            else
            {
                Console.WriteLine("Env vars names are missing");
            }
        }
    }
}
