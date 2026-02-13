using Clgproj.Test.TestInfrastructure;
using Microsoft.EntityFrameworkCore;
namespace Clgproj.Test.Services
{
    internal class WateringServiceTests
    {
    }
}


namespace Clgproj.Tests.Unit
{
    internal class WateringServiceTests
    {
        private WateringDbContext _context = null!;
        private WateringService _service = null!;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WateringDbContext>()
                .UseInMemoryDatabase("WateringService_Test")
                .Options;

            _context = new WateringDbContext(options);
            _service = new WateringService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [Test]
        public async Task GenerateScheduleAsync_Returns_Result()
        {
            var result = await _service.GenerateScheduleAsync(1);

            Assert.That(result, Is.Not.Null);
        }
    }

    internal class WateringService
    {
        private WateringDbContext context;

        public WateringService(WateringDbContext context)
        {
            this.context = context;
        }
    }
}
