using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Factory.SetUp
{
    /// <summary>
    /// Initialize the Appium Driver.
    /// </summary>
    public static class SetUpWebDriver
    {
        private const string AndroidApplicationPath = @"\Factory.SetUp\binaries\mylist.apk";

        /// <summary>
        /// Appium Driver.
        /// </summary>
        public static AppiumDriver<AndroidElement> AppiumDriver { get; private set; }

        /// <summary>
        /// See Wiki to set up the desired capabilities.
        /// <seealso cref="https://github.com/appium/appium/blob/master/docs/en/writing-running-appium/caps.md"/>
        /// </summary>
        public static AppiumDriver<AndroidElement> SetUpAppiumDriver()
        {
            var appFullPath = Directory.GetParent(Directory.GetCurrentDirectory()) + AndroidApplicationPath;

            // Set up capabilities.
            // See Appium Capabilities wiki.
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.0");
            capabilities.SetCapability("fullReset", "True");
            capabilities.SetCapability("app", appFullPath);

            // To see the device name with the cmd console check adb devices -l
            capabilities.SetCapability("deviceName", "generic_x86");

            AppiumDriver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);

            return AppiumDriver;
        }
    }
}
