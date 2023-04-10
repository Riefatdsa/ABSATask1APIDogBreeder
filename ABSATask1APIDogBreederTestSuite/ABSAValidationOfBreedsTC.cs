using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ABSATask1APIDogBreeder;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Net.NetworkInformation;
/* Author: Riefat Dollie
 * Module: Test Suite
 * Descr: This module contains all test methods and makes a call to the respective api
 * Date:  07/04/2023
 *  */

namespace ABSATask1APIDogBreederTestSuite
{
    [TestClass]
    public class ABSAValidationOfBreedsTC
    {
        string subBreedOf = null;
        string publicURI = "https://dog.ceo";
        string requestParam = null;
        string requestParamSubreed = null;
        Utilities utils = new Utilities();

        //extent reports
        string workingDirectory = Environment.CurrentDirectory;
        ExtentReports extentReport = new ExtentReports();
        ExtentTest extentReportTest = null;

        //[OneTimeSetUp]
        public void ExtentReportStart()
        {
            //extentReport = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(Environment.CurrentDirectory + @"\" + "ExtentReports" + @"\" + "Retriever.html");
            extentReport.AttachReporter(htmlReporter);
            //return extentReport;
        }

        //[OneTimeTearDown]
        public void ExtentReportClose()
        {
            extentReport.Flush();
        }

        [TestMethod]
        public void VerifyListOfBreeds()
        {
           ExtentReportStart();
            extentReportTest = extentReport.CreateTest("VerifyListOfBreeds").Info("Test Started");

            var breedsList = new ABSAPerformAPIRequest();
            var responseFromAPI = breedsList.getListOfBreeds(publicURI, "/api/breeds/list/all", "breeder");

            foreach (var breedItem in responseFromAPI.Message)
            {
                //Assert.AreEqual("retriever", breedItem.Key.Contains("retriever"));
                if (breedItem.Key.Contains("retriever"))
                {
                    NUnit.Framework.Assert.AreEqual("retriever", breedItem.Key);
                    extentReportTest.Log(Status.Pass, "Verify - " + breedItem.Key + " is within list");

                    //to be used in subsequent requests
                    requestParam = breedItem.Key;
                }
            }
           ExtentReportClose();
        }

        [TestMethod]
        public void VerifyListOfSubBreeds()
        {
            var breedsList = new ABSAPerformAPIRequest();
            //var responseFromAPI = breedsList.getListOfSubBreeds(publicURI, "/api/breed/"+ requestParameter + "/list", "sub");
            var responseFromAPI = breedsList.getListOfSubBreeds(publicURI, "/api/breed/retriever/list", "sub");

            Console.WriteLine(responseFromAPI.Status);
            foreach (var subbreedItem in responseFromAPI.Message)
            {
                Console.WriteLine(subbreedItem);
            }
        }

        [TestMethod]
        public void VerifyRandomImageLink()
        {
            //ExtentReportStart();
            //extentReportTest = extentReport.CreateTest("VerifyImageLink").Info("Test Started");

            var breedsList = new ABSAPerformAPIRequest();
            //var responseFromAPI = breedsList.getListOfSubBreeds(publicURI, "/api/breed/"+ requestParameter + "/list", "sub");
            var responseFromAPI = breedsList.getListOfSubBreeds(publicURI, "/api/breed/retriever/list", "sub");

            Console.WriteLine(responseFromAPI.Status);
            foreach (var subbreedItem in responseFromAPI.Message)
            {
                if (subbreedItem.Contains("golden"))
                {
                    requestParamSubreed = subbreedItem;
                }
            }

            var responseFromAPIRandom = breedsList.getRandomImage(publicURI, "/api/breed/retriever/" + requestParamSubreed + "/images/random", "sub");

            if(utils.ValidateURL(responseFromAPIRandom.Message))
              NUnit.Framework.Assert.IsTrue(utils.ValidateURL(responseFromAPIRandom.Message));
              //extentReportTest.Log(Status.Pass, "HttpStatusCode.OK - Image URL is valid - " + responseFromAPIRandom.Message);
              //ExtentReportClose();
        }
    }
}
