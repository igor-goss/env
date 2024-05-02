namespace env.Services
{
    internal static class DeleteVarService
    {
        public static void DeleteVar(string[] args)
        {
            if (args.Length >= 2)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    string variableName = args[i];
                    Environment.SetEnvironmentVariable(variableName, null);
                }
            }
            else
            {
                Console.WriteLine("Env vars names are missing");
            }
        }
    }
}
