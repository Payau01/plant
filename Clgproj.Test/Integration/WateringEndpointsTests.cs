
using System.Net;
using NUnit.Framework;
using Clgproj.Tests.TestInfrastructure;
namespace Clgproj.Test.Integration
{
    internal class WateringEndpointsTests
    {
        private HttpClient _client = null!;
        private CustomWebApplicationFactory _factory = null!;

        public CustomWebApplicationFactory Get_factory()
        {
            return _factory;
        }

        [SetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose(); 
        }

        [Test]
        public async Task Generate_Watering_Schedule_Returns_OK()
        {
            var response = await _client.PostAsync(
                "/api/plants/1/watering/schedule", null);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
internal class WateringEndpointsTests
{
    private HttpClient _client = null!;
    private CustomWebApplicationFactory _factory = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    [Test]
    public async Task Generate_Watering_Schedule_Returns_OK()
    {
        var response = await _client.PostAsync(
            "/api/plants/1/watering/schedule", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
