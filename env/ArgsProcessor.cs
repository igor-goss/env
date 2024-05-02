using env.Services;
using System.Collections;
using System.Diagnostics;

class ArgsProcessor
{
    public static void Handle(string[] args)
    {
        if (args.Length == 0)
        {
            foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{variable.Key}={variable.Value}");
            }
        }
        else
        {
            switch (args[0])
            {
                case "-a":
                    AddVariableService.AddVariable(args);
                    break;

                case "-i":
                    IgnoreEnvSerice.IgnoreEnv(args);
                    break;

                case "-d":
                    DeleteVarService.DeleteVar(args);
                    break;
                    
                default:
                    Console.WriteLine("Usage:");
                    Console.WriteLine("  env - вывод текущих переменных окружения");
                    Console.WriteLine("  env -i [переменные] [программа] [аргументы]");
                    Console.WriteLine("    -i         - установить переменные окружения и выполнить программу");
                    Console.WriteLine("    переменные - список переменных в формате KEY=VALUE");
                    Console.WriteLine("    программа   - путь к программе, которую нужно запустить");
                    Console.WriteLine("    аргументы  - дополнительные аргументы для программы");
                    return;
            }
        }
    }
}