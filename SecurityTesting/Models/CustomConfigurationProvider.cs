namespace SecurityTesting.Models
{
    //This is the class that provides the data through the load method
    public class MyCustomConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            //This mehtod wil access the data somwhow and load Data property
            //This is a simple hard coded implementation for the purposes of the demo
            Data.Add("MySecrets:MyCustomProvider7", "Value for MyCustomProvider7 from MyCustomConfigurationProvider");
            Data.Add("MySecrets:Seven", "Value for Seven from MyCustomConfigurationProvider");
            base.Load();
        }
    }

    //This is the class that regiter the class above
    public class MyCustomConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MyCustomConfigurationProvider();
        }
    }

    //This is the extensions class that allows the class above to be used in the webbuilder
    public static class CustomeCofigurationExtensions
    {
        public static IConfigurationBuilder AddMyCustomConfiguration(this IConfigurationBuilder builder)
        {
            return builder.Add(new MyCustomConfigurationSource());
        }
    }

}
