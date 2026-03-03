using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TAProgramme_2.Pages
{
    public class TMPage
    {
		public void CreateTimeRecord(IWebDriver driver)
		{
			IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
			createNewButton.Click();

			IWebElement timeDropDownButton = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
			timeDropDownButton.Click();

			IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
			timeOption.Click();

			IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
			codeTextBox.SendKeys("TA2026");

			IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
			descriptionTextBox.SendKeys("TA2026 description");

			IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
			priceTagOverlap.Click();

			IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
			priceTextBox.SendKeys("100");

			IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
			saveButton.Click();

			// using OpenQA.Selenium.Support.UI;
			// using SeleniumExtras.WaitHelpers; // if using ExpectedConditions shim

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

			// Wait until grid exists
			wait.Until(d => d.FindElements(By.Id("tmsGrid")).Count > 0);

			// Find pager buttons inside the grid and click "last" robustly.
			// Example uses attribute/title or text (adjust to real DOM).
			var lastBtn = wait.Until(d =>
			{
				var pagerLinks = d.FindElements(By.CssSelector("#tmsGrid .k-pager-wrap a, #tmsGrid .k-pager a"));
				foreach (var el in pagerLinks)
				{
					var title = el.GetAttribute("title") ?? string.Empty;
					if (title.Contains("Last", StringComparison.OrdinalIgnoreCase) || el.Text.Trim().Equals("Last", StringComparison.OrdinalIgnoreCase))
						return el;
				}
				return null;
			});
			lastBtn.Click();
			// Verify row exists safely
			var newCode = wait.Until(d => d.FindElement(By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[1]")));
			if (newCode.Text == "TA2026") // remove stray semicolon
			{
				Console.WriteLine("New Time and Material record created successfully. Test Pass");
			}
			else
			{
				Console.WriteLine("Failed to create new Time and Material record. Test Fail");
			}
		}

		public void EditTimeRecord()
		{
			IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[5]/td[5]/a[1]"));
			editButton.Click();
			
			IWebElement codeTextBoxEdit = driver.FindElement(By.Id("Code"));
			codeTextBoxEdit.Clear();
			codeTextBoxEdit.SendKeys("TA2026Edited");
			
			IWebElement saveButtonEdit = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
			saveButtonEdit.Click();
			
			IWebElement lastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
			lastButton.Click();
			
		}
		public void DeleteTimeRecord()
		{
			//Deleting the Record
			IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[5]/a[2]"));
			deleteButton.Click();
			Thread.Sleep(3000);
			IAlert alert = driver.SwitchTo().Alert();
			alert.Accept();
			Thread.Sleep(3000);
		}

		}
	}

