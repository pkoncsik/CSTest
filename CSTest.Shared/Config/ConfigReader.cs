namespace CSTest.Shared.Config
{
    public class ConfigReader
    {
        public static dynamic GetConfig(string configName)

        {
            return new ConfigStore(configName);
        }
    }
}
