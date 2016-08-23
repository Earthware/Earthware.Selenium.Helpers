namespace Earthware.Selenium.Helpers.Drivers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;

    public class iPadAir2DriverContainer : DriverContainer
    {
        protected override DesiredCapabilities Capabilities
        {
            get
            {
                var caps = new DesiredCapabilities();

                caps.SetCapability("browserName", "iPad");
                caps.SetCapability("platform", "MAC");
                caps.SetCapability("device", "iPad Air 2");

                return caps;
            }
        }
    }
}