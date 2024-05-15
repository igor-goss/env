using Newtonsoft.Json.Linq;

namespace env.Services
{
    internal static class LoadVariablesService
    {
        public static void LoadVariables(string[] args)
        {

            int jsonArgIndex = Array.IndexOf(args, "-l") + 1;

            if (jsonArgIndex < args.Length)
            {
                string jsonFilePath = args[jsonArgIndex];

                if (File.Exists(jsonFilePath))
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);

                    try
                    {
                        JObject jsonObject = JObject.Parse(jsonContent);

                        foreach (var item in jsonObject)
                        {
                            Environment.SetEnvironmentVariable(item.Key, item.Value.ToString());
                        }

                        Console.WriteLine("Environment variables from the file have been successfully added.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing JSON file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("The specified file does not exist.");
                }
            }
            else
            {
                Console.WriteLine("A path to the JSON file must be provided after the -l flag.");
            }
        }
    }
}
