using System;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Net;
using VideoStore.Controllers;
using Newtonsoft.Json;
using VideoStore.Models;

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

        [Test]
        public async Task whenICalculateWithMoreThanOneRentalDayInAnyCatergory_thenPricesShouldBeOverZeroAndFrequentRenterPointsAreOverZero() {
            int days = new Random().Next(1,100);
            Array values = Enum.GetValues(typeof(MovieCategory));
            MovieCategory randomCategory = (MovieCategory)values.GetValue(new Random().Next(0, values.Length));

            var response  = await httpClient.GetAsync($"/rental/calculate?rentaldays={days}&moviecategory={randomCategory.ToString()}");
            CalculatedRental calculatedRental = JsonConvert.DeserializeObject<CalculatedRental>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(calculatedRental.Price > 0);
            Assert.IsTrue(calculatedRental.FrequentRentalPoints > 0);

        }

    }
}