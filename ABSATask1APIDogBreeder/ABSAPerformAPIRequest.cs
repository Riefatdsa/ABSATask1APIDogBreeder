using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Linq.Expressions;
using System.Security.Policy;
/* Author: Riefat Dollie
 * Module: Test Suite
 * Descr: This module contains each API request containing the JSON conversions for the Data transformation objects
 * Date:  07/04/2023
 *  */

namespace ABSATask1APIDogBreeder
{
    public class ABSAPerformAPIRequest
    {
        public ABSAListOfBreedsDTO getListOfBreeds(string sURI, string sReq, string a) 
        {
            try
            {
                var restClient = new RestClient(sURI);
                var restRequest = new RestRequest(sReq, Method.Get);
                restRequest.AddHeader("Accept", "Application/json");
                restRequest.RequestFormat = DataFormat.Json;

                RestResponse responseData = restClient.Execute(restRequest);
                var responseContent = responseData.Content;
         
                // var breeds2 = JsonConvert.DeserializeObject(responseContent);
                var breeds = JsonConvert.DeserializeObject<ABSAListOfBreedsDTO>(responseContent);
                return breeds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public ABSAListOfSubBreedsDTO getListOfSubBreeds(string sURI, string sReq, string a)
        {
            try
            {
                var restClient = new RestClient(sURI);
                var restRequest = new RestRequest(sReq, Method.Get);
                restRequest.AddHeader("Accept", "Application/json");
                restRequest.RequestFormat = DataFormat.Json;

                RestResponse responseData = restClient.Execute(restRequest);
                var responseContent = responseData.Content;

                var subBreeds = JsonConvert.DeserializeObject<ABSAListOfSubBreedsDTO>(responseContent);
                return subBreeds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ABSASubbreedsImageDTO getRandomImage(string sURI, string sReq, string a)
        {
            try
            {
                var restClient = new RestClient(sURI);
                var restRequest = new RestRequest(sReq, Method.Get);
                restRequest.AddHeader("Accept", "Application/json");
                restRequest.RequestFormat = DataFormat.Json;

                RestResponse responseData = restClient.Execute(restRequest);
                var responseContent = responseData.Content;
                string decodedString = HttpUtility.HtmlDecode(responseContent);

                var subBreedImageLink = JsonConvert.DeserializeObject<ABSASubbreedsImageDTO>(responseContent);
                return subBreedImageLink;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
