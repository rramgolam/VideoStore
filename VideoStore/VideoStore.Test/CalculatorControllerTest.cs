using System;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Net;
using VideoStore.Controllers;
using Newtonsoft.Json;

namespace VideoStore.Test
{
    public class CalculatorControllerTest
    {
        private readonly TestServer testServer;
        private readonly HttpClient httpClient;

        public CalculatorControllerTest()
        {
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            httpClient = testServer.CreateClient();
        }
        [Test]
        public async Task whenIcalculateWithNoValues_thenPriceIs0_And_FrequentRenterPointsAre0() {
            var response = await httpClient.GetAsync("/rental/calculate");
            CalculatedRental calculatedRental = JsonConvert.DeserializeObject<CalculatedRental>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(0.0f, calculatedRental.Price);
            Assert.AreEqual(0, calculatedRental.FrequentRentalPoints);

        }
    }
}
