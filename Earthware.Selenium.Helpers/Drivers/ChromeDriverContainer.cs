namespace Earthware.Selenium.Helpers.Drivers
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    public class ChromeDriverContainer : DriverContainer
    {
        protected override DesiredCapabilities Capabilities
        {
            get
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--disable-plugins");

                var capability = (DesiredCapabilities)chromeOptions.ToCapabilities();

                capability.SetCapability("browser", "Chrome");
                capability.SetCapability("browser_version", "52.0");
                capability.SetCapability("os", "Windows");
                capability.SetCapability("os_version", "10");
                capability.SetCapability("resolution", "2048x1536");

                return capability;
            }
        }
    }
}