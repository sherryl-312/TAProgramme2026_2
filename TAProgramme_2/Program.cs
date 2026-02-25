using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
		// Open Chrome Browser
		IWebDriver driver = new ChromeDriver();

		// Launch Turnup Portal
		driver.Navigate().GoToUrl("http://horse.industryconnect.io");
		driver.Manage().Window.Maximize();
		Thread.Sleep(3000);

		// Identify username textbox and enter valid username
		IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
		usernameTextbox.SendKeys("hari");
		Thread.Sleep(3000);

		// Identify password textbox and enter valid password
		IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
		passwordTextbox.SendKeys("123123");
		Thread.Sleep(3000);

		// Click on login button
		IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
		loginButton.Click();
		Thread.Sleep(7000);

		// Check if the user has logged in successfully
		//IWebElement welcomeMessage = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
		//if welcomeMessage.Text == "Hello hari!";
		//{
		//Console.WriteLine("Login successful!");
		//}
		//else
		//{
		//Console.WriteLine("Login failed!Test fail");
		//}		

		IWebElement adminButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
		adminButton.Click();
		Thread.Sleep(3000);
		IWebElement timeAndMaterialButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
		timeAndMaterialButton.Click();
		Thread.Sleep(5000);
		IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
		createNewButton.Click();
		Thread.Sleep(3000);


		IWebElement timeDropDownButton = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
		timeDropDownButton.Click();
		Thread.Sleep(3000);
		IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
		timeOption.Click();
		Thread.Sleep(3000);
		IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
		codeTextBox.SendKeys("TA2026");
		Thread.Sleep(3000);
		IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
		descriptionTextBox.SendKeys("TA2026 description");

		IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
		priceTagOverlap.Click();

		IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
		priceTextBox.SendKeys("100");
		Thread.Sleep(3000);
		IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
		saveButton.Click();
		Thread.Sleep(9000);
		
		
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
		Thread.Sleep(3000);

		//IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[5]/td[5]/a[1]"));
		//editButton.Click();
		//Thread.Sleep(3000);
		//IWebElement codeTextBoxEdit = driver.FindElement(By.Id("Code"));
		//codeTextBoxEdit.Clear();
		//Thread.Sleep(1000);
		//codeTextBoxEdit.SendKeys("TA2026Edited");
		//Thread.Sleep(3000);
		//IWebElement saveButtonEdit = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
		//saveButtonEdit.Click();
		//Thread.Sleep(5000);
		//IWebElement lastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
		//lastButton.Click();
		//Thread.Sleep(3000);

		//Deleting the Record
		IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[5]/a[2]"));
		deleteButton.Click();
		Thread.Sleep(3000);
		IAlert alert = driver.SwitchTo().Alert();
		alert.Accept();
		Thread.Sleep(3000);

		/* Verify row exists safely
		var newCode = wait.Until(d => d.FindElement(By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[1]")));
		if (newCode.Text == "TA2026Edited") // remove stray semicolon
		{
		Console.WriteLine("New Time and Material record created successfully. Test Pass");
		}
		else
		{
		 Console.WriteLine("Failed to create new Time and Material record. Test Fail");
		}*/

	}
}  