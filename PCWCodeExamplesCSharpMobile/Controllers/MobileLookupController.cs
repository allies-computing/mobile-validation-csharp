using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using PCWCodeExamplesCSharpMobile.Models;

/*

    Mobile number validation with PHP
    Simple demo which passes mobile phone number to the API on form submit and shows a message based on response.

    For non UK numbers you will need to include the country code at the start, in either +44 or 0044 format

    Full mobile validation API documentation:-
    https://developers.alliescomputing.com/postcoder-web-api/mobile-validation
    
*/

namespace PCWCodeExamplesCSharpMobile.Controllers
{
	public class MobileLookupController : ApiController
    {
		[HttpGet]
		[Route("PCWCodeExamples/MobileLookup")]
		public string MobileLookup()
		{
			return "Pass a mobile phone number by appending +441234567789";
		}

		[HttpGet]
		[Route("PCWCodeExamples/MobileLookup/{mobile}")]
		public async Task<MobileReturn> MobileLookup(string mobile)
		{
			// Replace with your API key, test key will always return true regardless of mobile number
			string apiKey = "PCW45-12345-12345-1234X";

			// Grab the input text and trim any whitespace
			mobile = mobile.Trim();

			// URL encode our input string
			mobile = HttpUtility.UrlEncode(mobile);

			// Create empty containers for our output
			MobileLookup mobileResp = new MobileLookup();
			MobileReturn output = new MobileReturn();

			if (String.IsNullOrEmpty(mobile))
			{
				// Respond without calling API if no input supplied
				output.error_message = "No input supplied";
			}
			else
			{
				// Create the URL to API including API key and encoded mobile number
				string mobileUrl = $"https://ws.postcoder.com/pcw/{apiKey}/mobile/{mobile}";

				// Create a disposable HTTP client
				using (HttpClient client = new HttpClient())
				{
					// Specify "application/json" in content-type header to request json return values
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					
					// Execute our get request
					using (HttpResponseMessage resp = await client.GetAsync(mobileUrl))
					{
						// Triggered if API does not return 200 HTTP code
						// More info - https://developers.alliescomputing.com/postcoder-web-api/error-handling

						// Here we will output a basic message with HTTP code
						if (!resp.IsSuccessStatusCode)
						{
							output.error_message = $"An error occurred - {resp.StatusCode.ToString()}";
						}
						else
						{
							// Store JSON response in our MobileLookup object
							mobileResp = JsonConvert.DeserializeObject<MobileLookup>(await resp.Content.ReadAsStringAsync());

							// Store the results of our lookup in our return wrapper
							output.mobile = mobileResp;

							// Do something based on whether or not the mobile number is valid
							if (mobileResp.valid)
							{
								// Something good
							}
							else
							{
								// Something bad
							}
						}
						
						// Full list of "state" responses - https://developers.alliescomputing.com/postcoder-web-api/mobile-validation
					}
				}
			}
			
			return output;
		}
    }
}