using System;
using OpenQA.Selenium;

namespace SeleniumWithCSharp.Pages
{
	public class KayitPage
	{
        private readonly IWebDriver driver;
        public KayitPage(IWebDriver driver)
		{
            this.driver = driver;
        }

        IWebElement recordFormHeader => driver.FindElement(By.ClassName("card-title"));
        IWebElement nameInput => driver.FindElement(By.Id("txtAdi"));
        IWebElement surnameInput => driver.FindElement(By.Id("txtSoyadi"));
        IWebElement emailInput => driver.FindElement(By.Id("txtEPosta"));
        IWebElement birthdateInput => driver.FindElement(By.Id("txtDogumTarihi"));
        IWebElement submitButton => driver.FindElement(By.Name("btnGonder"));
        IWebElement successMessageForRecord => driver.FindElement(By.Id("lblResult"));


        IWebElement nameIsRequiredField => driver.FindElement(By.Id("rfvAdi"));
        IWebElement surnameIsRequiredField => driver.FindElement(By.Id("RequiredFieldValidator1"));


        public void FillRecordForm(string name, string surname, string email, string birthdate)
        {
            Assert.IsTrue(recordFormHeader.Displayed);

            nameInput.SendKeysElement(name);
            surnameInput.SendKeysElement(surname);
            emailInput.SendKeysElement(email);
            birthdateInput.SendKeysElement(birthdate);
            submitButton.ClickElement();
    }

        public bool IsRecordAddSuccessfully()
        {
            return successMessageForRecord.Displayed;
        }

        public (bool,bool) EmptyCheckField()
        {
            return (nameIsRequiredField.Displayed,surnameIsRequiredField.Displayed);
        }
    }

    
}

