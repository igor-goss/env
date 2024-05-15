using env.Services;
using System.Collections;

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

                case "-l":
                    LoadVariablesService.LoadVariables(args);
                    break;

                case "-h" or "--help":
                    HelpPrinter.PrintHelp();
                    break;

                default:
                    HelpPrinter.PrintHelp();
                    return;
            }
        }
    }
}