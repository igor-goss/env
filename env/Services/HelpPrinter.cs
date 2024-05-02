namespace env.Services
{
    internal class HelpPrinter
    {
        public static void PrintHelp()
        {
            Console.WriteLine("Usage: env [OPTION]... [-] [NAME=VALUE]... [COMMAND [ARG]...]");
            Console.WriteLine("  env print existing env vars");
            Console.WriteLine("  -i, --ignore-environment  start with an empty environment");
            Console.WriteLine("  -a [NAME=VALUE] add new env vars");
            Console.WriteLine("  -d [NAME] delete specified env vars");
            Console.WriteLine("  -h, --help print this message");
        }
    }
}
