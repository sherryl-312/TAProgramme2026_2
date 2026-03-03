using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TAProgramme_2.Utilites;

namespace TAProgramme_2.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            // Click on Admin tab
            IWebElement adminButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);
            
            // Click on Time and Material option
            IWebElement timeAndMaterialButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialButton.Click();
            
		}
	}
}
