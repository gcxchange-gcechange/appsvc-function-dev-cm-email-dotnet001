namespace appsvc_function_dev_cm_email_dotnet001
{
    public static class Globals
    {
        public static readonly string azureWebJobsStorage = GetEnvironmentString("AzureWebJobsStorage");
        public static readonly string tenantId = GetEnvironmentString("tenantId");
        public static readonly string clientId = GetEnvironmentString("clientId");
        public static readonly string keyVaultUrl = GetEnvironmentString("keyVaultUrl");
        public static readonly string secretNameClient = GetEnvironmentString("secretNameClient");
        public static readonly string delegateEmail = GetEnvironmentString("delegateEmail");
        public static readonly string secretNameDelegatePassword = GetEnvironmentString("secretNameDelegatePassword");

        private static string GetEnvironmentString(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
