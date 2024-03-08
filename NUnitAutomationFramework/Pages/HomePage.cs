using OpenQA.Selenium;
using NUnitAutomationFramework.WebElements;
using NUnitAutomationFramework.Base;
using AventStack.ExtentReports;
using AngleSharp.Dom;
using System;
using NUnitAutomationFramework.Utility;
using System.Security.Policy;

namespace NUnitAutomationFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly ExtentTest test;
        public HomePage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            this.test = test;
        }

        readonly string opentab = "//*[@id='opentab']";
        readonly string mouseover = "//*[@id='mousehover']";
        readonly string top = "//*[contains(text(), 'Top')]";

        public void OpenTab()
        {

            ActionsElements.Click(driver, By.XPath(opentab));
            test.Log(Status.Info, "Successfully clicked on open tab button");

        }
        public void MouseOver()
        {
            IWebElement element = ActionsElements.FindElement(driver, By.XPath(mouseover));
            ActionsElements.ScrollToView(driver, element);
            ActionsElements.MouseOver(driver, By.XPath(mouseover));
            test.Log(Status.Info, "Successfully mouseover on Mouseover button");
            ActionsElements.Click(driver, By.XPath(top));
            test.Log(Status.Info, "Successfully clicked on top button");

        }

        public void ValidateTrustApp(int index)
        {
            test.Log(Status.Info, "***** TrustApp Details For Twiter Post: " + index + " *****");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Hover Over TrustApp Symbol
            if (index > 1)
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("(//img[@alt='TrustApp mark'])[" + (index - 1) + "]")));
                Thread.Sleep(3000);
            }
            ActionsElements.MouseOver(driver, By.XPath("(//img[@alt='TrustApp mark'])[" + index + "]"));
            Thread.Sleep(5000);

            // Log The UserName In HTML Report
            test.Log(Status.Pass, "UserName: " + driver.FindElement(By.XPath("(//a//span[contains(text(),'@')])[" + index + "]")).Text);

            // Log The Status In HTML Report
            test.Log(Status.Pass, "Status: " + driver.FindElement(By.XPath("(//div[@class='status']/div)[" + index + "]")).Text);

            // Log The Description In HTML Report
            string Description = (string)js.ExecuteScript("return arguments[0].innerText;", driver.FindElement(By.XPath("(//div[@class='text']/div)[" + index + "]")));
            test.Log(Status.Pass, "Description: " + Description);

            ActionsElements.MouseOver(driver, By.XPath("//span[text()='Settings']"));
            Thread.Sleep(2500);
        }

        public void NewWindow()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open();");

            // Get handles of all opened windows
            string[] windowHandles = driver.WindowHandles.ToArray();

            // Switch to the last window handle (newly opened tab)
            string lastWindowHandle = windowHandles[windowHandles.Length - 1];
            driver.SwitchTo().Window(lastWindowHandle);
        }
        
        public void NavigateToURL(string News)
        {
            string? url = GetEnvironementData.GetEnvData();
            ActionsElements.NavigateToUrl(driver, url + News);
            test.Log(Status.Info, "Navigated To: " + url + News);
            Thread.Sleep(10000);
        }
    }
}