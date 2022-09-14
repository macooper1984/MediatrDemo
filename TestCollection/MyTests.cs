using MediatrDemo.Logic.Commands;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestCollection
{
    public class MyTests
    {
        private TestWebApplicationFactory testWebApplicationFactory;
        private HttpClient httpClient;

        [OneTimeSetUp]
        public void Setup()
        {
            testWebApplicationFactory = new TestWebApplicationFactory();
            httpClient = testWebApplicationFactory.CreateClient();
        }

        [Test]
        public async Task TestTheEndpoints()
        {
            var testData = TestData.CreateOrder;
            var response = await StoreData(testData);

            Assert.IsTrue(response.IsSuccessStatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var id = JsonConvert.DeserializeObject<int>(content);

            response = await ReadBackData(id);

            Assert.IsTrue(response.IsSuccessStatusCode);
            content = await response.Content.ReadAsStringAsync();
            var returnedData = JsonConvert.DeserializeObject<CreateOrderCommand>(content);
        }

        private async Task<HttpResponseMessage> ReadBackData(int id)
        {
            var url = $"api/orders/{id}";
            var response = await httpClient.GetAsync(url);

            return response;
        }

        private async Task<HttpResponseMessage> StoreData(CreateOrderCommand testData)
        {
            const string url = "api/orders";
            var content = JsonContent.Create(testData);

            var response = await httpClient.PostAsync(url, content);
            return response;
        }
    }
}
