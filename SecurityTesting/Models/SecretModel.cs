using Microsoft.Extensions.Configuration;
namespace SecurityTesting.Models
{
    public class SecretModel
    {
        //This field will not be bound in the GetSection method
        public IConfigurationRoot? configRoot;
        //These properties will be bound in the GetSection method
        public string? ChainedValue1 { get; set; }
        public string? AppSettingValue2 { get; set; }
        public string? AppEnviromentValue3 { get; set; }
        public string? AppSecretValue4 { get; set; }
        public string? EnviromentValue5  { get; set; }
        public string? CommandLineValue6 { get; set; }
        public string? MyCustomProvider7 { get; set; }
        public string? Zero { get; set; }
        public string? One { get; set; }
        public string? Two { get; set; }
        public string? Three { get; set; }
        public string? Four { get; set; } 
        public string? Five { get; set; }
        public string? Six { get; set; }
        public string? Seven { get; set; }

    }
}
