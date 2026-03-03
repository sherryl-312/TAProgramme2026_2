using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TAProgramme_2.Pages
{
    public class LoginPage
    {
        //Functions or methods that allow users to login to the application
        public void LoginActions(IWebDriver driver)
        {
			// Launch Turnup Portal
			driver.Navigate().GoToUrl("http://horse.industryconnect.io");
			driver.Manage().Window.Maximize();

			// Identify username textbox and enter valid username
			IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
			usernameTextbox.SendKeys("hari");

			// Identify password textbox and enter valid password
			IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
			passwordTextbox.SendKeys("123123");

			// Click on login button
			IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
			loginButton.Click();
			Thread.Sleep(7000);
		}
    }
}
