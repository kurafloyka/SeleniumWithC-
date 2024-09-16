using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithCSharp.Pages;

namespace SeleniumWithCSharp;

[TestFixture("https://testcase.eminevim.com.tr/CaseForm.aspx", "faruk","akyol","email","03.01.1993")]
public class Tests1
{
    IWebDriver? _driver = null;
    private readonly string _url;
    private readonly string _name;
    private readonly string _surname;
    private readonly string _email;
    private readonly string _birthdate;

    public Tests1(string url,string name,string surname,string email,string birthdate)
    {
        this._url = url;
        this._name = name;
        this._surname = surname;
        this._email = email;
        this._birthdate = birthdate;
    }
    
    [SetUp]
    public void Setup()
    {

        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        SeleniumCustomMethods.MaximizeWindow(_driver);
        SeleniumCustomMethods.NavigateToUrl(_driver, _url);

    }

    [Test]
    public void SubmitFormTest()
    {
        Console.WriteLine(SeleniumCustomMethods.GetTitle(_driver));
        var kayitPage = new KayitPage(_driver);
        kayitPage.FillRecordForm(_name, _surname, _email, _birthdate);
        Assert.IsTrue(kayitPage.IsRecordAddSuccessfully());
        
    }

    [Test]
    public void EmptyFieldTestForNameAndSurname()
    {
        var kayitPage = new KayitPage(_driver);
        kayitPage.FillRecordForm("", "", _email, _birthdate);

        Assert.IsTrue(kayitPage.EmptyCheckField().Item1);
        Assert.IsTrue(kayitPage.EmptyCheckField().Item2);
    }

    [Test]
    public void EntriedValueIntoEmailAndBirthdateTest()
    {
        var kayitPage = new KayitPage(_driver);
        kayitPage.FillRecordForm("", "", _email, _birthdate);

        Assert.IsTrue(kayitPage.EntriedValueIntoEmailAndBirthdate(_email,_birthdate).Item1);
        Assert.IsTrue(kayitPage.EntriedValueIntoEmailAndBirthdate(_email, _birthdate).Item2);

    }



    [Test]
    public void IsRecordAddSuccessfullyWithGreenMessageTest()
    {
        var kayitPage = new KayitPage(_driver);
        kayitPage.FillRecordForm(_name, _surname, _email, _birthdate);
        kayitPage.IsRecordAddSuccessfullyWithGreenMessage("color:Green;");
    }


    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
    }
