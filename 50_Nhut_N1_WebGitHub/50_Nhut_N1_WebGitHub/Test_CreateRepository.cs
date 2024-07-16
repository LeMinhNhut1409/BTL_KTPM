using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Security.Policy;
using Docker.DotNet.Models;
using OpenQA.Selenium.Interactions;

namespace _50_Nhut_N1_WebGitHub
{
    [TestClass]
    public class Test_CreateRepository
    {
        [TestMethod]
        public void CreateNewRepository_50_Nhut_Success()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive." +
                "header-overlay.home-campaign > div.position-relative.js-header-wrapper > header " +
                "> div > div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex." +
                "flex-column.flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(3000);

            //50_Nhut_N1_WebGitHub_Email
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut8952@gmail.com");

            //50_Nhut_N1_WebGitHub_Password
            driver.FindElement(By.Id("password")).SendKeys("minhnhut1409");

            //50_Nhut_N1_WebGitHub_Check_Email
            string enteredEmail = driver.FindElement(By.Id("login_field")).GetAttribute("value");
            string expectedEmail = "leminhnhut8952@gmail.com";
            string enteredPassword = driver.FindElement(By.Id("password")).GetAttribute("value");
            string expectedPassword = "minhnhut1409";
            if (enteredEmail.Equals(expectedEmail) && enteredPassword.Equals(expectedPassword))
            {
                //50_Nhut_N1_WebGitHub_SubmitDangNhap
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_click_button_create
                driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive" +
                    " > div.position-relative.js-header-wrapper > header " +
                    "> div > div.AppHeader-globalBar-end > div.AppHeader-actions.position-relative >" +
                    " react-partial-anchor")).Click();
                Thread.Sleep(1000);

                //50_Nhut_N1_WebGitHub_click_new_repository
                driver.FindElement(By.XPath("//*[@id=\"__primerPortalRoot__\"]/div/div/div/ul/li[1]")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_NhapTen_Repository
                driver.FindElement(By.ClassName("cDLBls")).SendKeys("TestRepository_50_Nhut_1");
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_NhapMoTa_Repository
                driver.FindElement(By.Name("Description")).SendKeys("DemoKTPM_50_Nhut");
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_ThuVien_Enter
                new Actions(driver).KeyDown(Keys.Enter).Build().Perform();
                Thread.Sleep(10000);
            }
            else
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void CreateNewRepository_50_Nhut_ErrorDuplicateName()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive." +
                "header-overlay.home-campaign > div.position-relative.js-header-wrapper > header " +
                "> div > div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex." +
                "flex-column.flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(3000);

            //50_Nhut_N1_WebGitHub_Email
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut8952@gmail.com");

            //50_Nhut_N1_WebGitHub_Password
            driver.FindElement(By.Id("password")).SendKeys("minhnhut1409");

            //50_Nhut_N1_WebGitHub_Check_Email
            string enteredEmail = driver.FindElement(By.Id("login_field")).GetAttribute("value");
            string expectedEmail = "leminhnhut8952@gmail.com";
            string enteredPassword = driver.FindElement(By.Id("password")).GetAttribute("value");
            string expectedPassword = "minhnhut1409";
            if (enteredEmail.Equals(expectedEmail) && enteredPassword.Equals(expectedPassword))
            {
                //50_Nhut_N1_WebGitHub_SubmitDangNhap
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_click_button_create
                driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive" +
                    " > div.position-relative.js-header-wrapper > header " +
                    "> div > div.AppHeader-globalBar-end > div.AppHeader-actions.position-relative >" +
                    " react-partial-anchor")).Click();
                Thread.Sleep(1000);

                //50_Nhut_N1_WebGitHub_click_new_repository
                driver.FindElement(By.XPath("//*[@id=\"__primerPortalRoot__\"]/div/div/div/ul/li[1]")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_NhapTen_Repository
                var repositoryNameField = driver.FindElement(By.ClassName("cDLBls"));
                repositoryNameField.SendKeys("TestRepository_50_Nhut");
                Thread.Sleep(2000);

                // Kiểm tra xem có thông báo lỗi về trùng tên hay không
                var errorMessage = driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive >" +
                    " div.application-main > main > react-app > div > form > div.Box-sc-g0xbh4-0.bBNZtE >" +
                    " div.Box-sc-g0xbh4-0.bBFNhO > div.Box-sc-g0xbh4-0.enACkX > div:nth-child(1) > fieldset > div >" +
                    " div:nth-child(3) > span.Text-sc-17v1xeu-0.dXVtmg"));
                if (errorMessage.Displayed)
                {
                    // Nếu có thông báo lỗi về trùng tên, in ra thông báo và thoát khỏi trình duyệt
                    driver.Quit();
                }
                else
                {
                    // Nếu không có thông báo lỗi, tiếp tục nhập mô tả và tạo repository
                    //50_Nhut_N1_WebGitHub_NhapMoTa_Repository
                    driver.FindElement(By.Name("Description")).SendKeys("DemoKTPM_50_Nhut");
                    Thread.Sleep(2000);

                    //50_Nhut_N1_WebGitHub_ThuVien_Enter
                    new Actions(driver).KeyDown(Keys.Enter).Build().Perform();
                    Thread.Sleep(10000);
                   
                }
            }
            else
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void CreateNewRepository_50_Nhut_ErrorLoginUsers()
        {
            //50_Nhut_N1_WebGitHub_Dang_Nhap
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://github.com/");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive." +
                "header-overlay.home-campaign > div.position-relative.js-header-wrapper > header " +
                "> div > div.HeaderMenu--logged-out.p-responsive.height-fit.position-lg-relative.d-lg-flex." +
                "flex-column.flex-auto.pt-7.pb-4.top-0 > div > div > div > a")).Click();
            Thread.Sleep(3000);

            //50_Nhut_N1_WebGitHub_Email
            driver.FindElement(By.Id("login_field")).SendKeys("leminhnhut@gmail.com");

            //50_Nhut_N1_WebGitHub_Password
            driver.FindElement(By.Id("password")).SendKeys("minhnhut1409");

            //50_Nhut_N1_WebGitHub_Check_Email
            string enteredEmail = driver.FindElement(By.Id("login_field")).GetAttribute("value");
            string expectedEmail = "leminhnhut8952@gmail.com";
            string enteredPassword = driver.FindElement(By.Id("password")).GetAttribute("value");
            string expectedPassword = "minhnhut1409";
            Thread.Sleep(3000);
            if (enteredEmail.Equals(expectedEmail) && enteredPassword.Equals(expectedPassword))
            {
                //50_Nhut_N1_WebGitHub_SubmitDangNhap
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_click_button_create
                driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive" +
                    " > div.position-relative.js-header-wrapper > header " +
                    "> div > div.AppHeader-globalBar-end > div.AppHeader-actions.position-relative >" +
                    " react-partial-anchor")).Click();
                Thread.Sleep(1000);

                //50_Nhut_N1_WebGitHub_click_new_repository
                driver.FindElement(By.XPath("//*[@id=\"__primerPortalRoot__\"]/div/div/div/ul/li[1]")).Click();
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_NhapTen_Repository
                driver.FindElement(By.ClassName("cDLBls")).SendKeys("TestRepository_50_Nhut");
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_NhapMoTa_Repository
                driver.FindElement(By.Name("Description")).SendKeys("DemoKTPM_50_Nhut");
                Thread.Sleep(2000);

                //50_Nhut_N1_WebGitHub_ThuVien_Enter
                new Actions(driver).KeyDown(Keys.Enter).Build().Perform();
                Thread.Sleep(10000);
            }
            else
            {
                driver.Quit();
            } 
        }
    }
}
