using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MySeleniumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
                InteractWithForm(driver);

                Thread.Sleep(5000);
            }
        }

        static void InteractWithForm(IWebDriver driver)
        {
            FillTextField(driver, "Aditya");
            SelectRadioButton(driver, "Male");
            SelectDropdownOption(driver, "India");
        }

        static void FillTextField(IWebDriver driver, string value)
        {
            IWebElement inputElement = driver.FindElement(By.XPath("/html/body/div[1]/form/div[1]/div[2]/input"));
            inputElement.Clear();
            inputElement.SendKeys(value);
        }

        static void SelectRadioButton(IWebDriver driver, string radioButtonValue)
        {
            string radioButtonXPath = $"/html/body/div[1]/form/div[1]/div[4]/div/input[@value='{radioButtonValue}']";
            IWebElement radioButton = driver.FindElement(By.XPath(radioButtonXPath));
            if (!radioButton.Selected)
            {
                radioButton.Click();
            }
        }

        static void SelectDropdownOption(IWebDriver driver, string optionText)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("/html/body/div[1]/form/div[1]/div[9]/select"));
            SelectElement selectElement = new SelectElement(dropdown);
            selectElement.SelectByText(optionText);
        }
    }
}
