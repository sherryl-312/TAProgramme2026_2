using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAProgramme_2.Pages;
using TAProgramme_2.Utilites;

namespace TAProgramme_2.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
   

        [SetUp]
     public void SetUpSteps() 
     {
            // Open Chrome Browser
            driver = new ChromeDriver();

            //Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);

      }
     [Test]
     public void CreateTime_Test() 
     {
            // TM Page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
      }
     [Test]
     public void EditTime_Test() 
     {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver);
      }
     [Test]
     public void DeleteTime_Test() 
     {
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
     }
     [TearDown]
     public void CloseTestRun() 
        
     {
        driver.Quit();
        }

    }
}
