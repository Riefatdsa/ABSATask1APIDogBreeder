using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
/* Author: Riefat Dollie
 * Module: Test Suite
 * Descr: This module contains a string minipulator function and an HTTP url checker
 * Date:  07/04/2023
 *  */

namespace ABSATask1APIDogBreederTestSuite
{
    public class Utilities
    {
        public string minipulator(string sFormat)
        {
            sFormat = sFormat.Replace("{", "");
            sFormat = sFormat.Replace("}", "");

            return sFormat;
        }

        public bool ValidateURL(Uri sURL)
        {
            bool urlValid = false;
            HttpWebRequest URLReq;
            HttpWebResponse URLRes;
            URLReq = (HttpWebRequest)WebRequest.Create(sURL);
            URLRes = (HttpWebResponse)URLReq.GetResponse();
            if (URLRes.StatusCode == HttpStatusCode.OK)
            {
                urlValid = true;
            }
            return urlValid;
        }
    }
}
