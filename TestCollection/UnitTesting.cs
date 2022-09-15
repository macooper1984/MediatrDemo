using MediatR;
using MediatrDemo.Logic.Interfaces.Repositories;
using MediatrDemo.Logic.Usecases.FlightBookings.Commands;
using NSubstitute;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestCollection.Helpers;

namespace TestCollection
{
    public class UnitTesting
    {
        [Test]
        public async Task TestCreateFlightBookingCommandHandler()
        {
            //Arrange
            var testData = TestData.CreateOrder.FlightBookings.First();

            var mockMediator = Substitute.For<IMediator>();
            var mockRepository = Substitute.For<IFlightBookingRepository>();

            var handler = new CreateFlightBookingCommandHandler(mockMediator, mockRepository);

            // Act
            await handler.Handle(testData, new CancellationToken());

            // Assert
            await mockRepository.Received().CreateAsync(Arg.Any<CreateFlightBookingCommand>());
        }
    }
}
