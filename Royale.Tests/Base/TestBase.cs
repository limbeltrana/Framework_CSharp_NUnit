﻿using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Royale.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        //Setup before each test method
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            WrapPages.Init();
            Driver.Current.Manage().Window.Maximize();
            // Driver.GoToPage("https://statsroyale.com");
            Driver.GoToPage(FW.Config.Test.Url);
        }

        [TearDown]
        //after each test
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == TestStatus.Passed)
            {
                FW.Log.Info("Outcome: Passed");
            }
            else if (outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Warning("Outcome: " + outcome);
            }
            Driver.Quit();
            //Driver.Current.Quit();
        }

    }
}
