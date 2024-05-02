using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace env.Services
{
    internal static class IgnoreEnvSerice
    {
        public static void IgnoreEnv(string[] args)
        {
            if (args.Length >= 2)
            {
                var newEnvVariables = new Dictionary<string, string>();

                for (int i = 1; i < args.Length; i++)
                {
                    string[] keyValue = args[i].Split('=');
                    if (keyValue.Length == 2)
                    {
                        newEnvVariables[keyValue[0]] = keyValue[1];
                    }
                }

                var processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = args[1];
                processStartInfo.Arguments = string.Join(" ", args.Skip(args.Length));

                processStartInfo.EnvironmentVariables.Clear();
                foreach (var variable in newEnvVariables)
                {
                    processStartInfo.EnvironmentVariables[variable.Key] = variable.Value;
                }

                using (Process process = Process.Start(processStartInfo))
                {
                    process.WaitForExit();
                }
            }
            else
            {
                Console.WriteLine("Env vars names are missing");
            }
        }
    }
}
