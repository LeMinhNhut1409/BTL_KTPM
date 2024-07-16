using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Security.Policy;
using Docker.DotNet.Models;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Drawing.Drawing2D;


namespace _50_Nhut_N1_WebGitHub
{
    [TestClass]
    public class Test_Login
    {
        //public TestContext TestContext { get; set; }
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"..\..\DataUserLogin\UserLoginSuccess.csv",
        //    "UserLoginSuccess#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void LoginWeb_50_Nhut_Success()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive.header-overlay.home-campaign > " +
                "div.position-relative.js-header-wrapper > header > div > " +
                "div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex.flex-column." +
                "flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(5000);

            //string username = TestContext.DataRow[0].ToString();
            //string password = TestContext.DataRow[1].ToString();

            //50_Nhut_N1_WebGitHub_Email
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut8952@gmail.com");

            //50_Nhut_N1_WebGitHub_Password
            driver.FindElement(By.Id("password")).SendKeys("minhnhut1409");

            //50_Nhut_N1_WebGitHub_SubmitDangNhap
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            Thread.Sleep(20000);
            //driver.Quit();

        }

        [TestMethod]
        public void LoginWeb_50_Nhut_Checkmail()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive.header-overlay.home-campaign > " +
                "div.position-relative.js-header-wrapper > header > div > " +
                "div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex.flex-column." +
                "flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(5000);

            //50_Nhut_N1_WebGitHub_Email_Fail
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut8952@gmail.com.vn");

            //50_Nhut_N1_WebGitHub_Password_Fail
            driver.FindElement(By.Id("password")).SendKeys("minhnhut1409");

            //50_Nhut_N1_WebGitHub_SubmitDangNhap
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            Thread.Sleep(20000);
            driver.Quit();
            
        }
        [TestMethod]
        public void LoginWeb_50_Nhut_Fail()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive.header-overlay.home-campaign > " +
                "div.position-relative.js-header-wrapper > header > div > " +
                "div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex.flex-column." +
                "flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(5000);

            //50_Nhut_N1_WebGitHub_Email_True
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut8952@gmail.com");

            //50_Nhut_N1_WebGitHub_Password_Fail
            driver.FindElement(By.Id("password")).SendKeys("minhnhut14092003");

            //50_Nhut_N1_WebGitHub_SubmitDangNhap
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            Thread.Sleep(20000);

            driver.Quit();
        }

        
    }
}
