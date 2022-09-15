using MediatrDemo.Logic.Commands;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Commands.Hotels;
using System;
using System.Linq;

namespace TestCollection.Helpers
{
    public static class TestData
    {

        public static CreateOrderCommand CreateOrder
        {
            get
            {
                var result = new CreateOrderCommand
                {
                    Reference = ValueHelper.RandomString(10),
                    NumberOfAdults = ValueHelper.RandomInt(2) + 1,
                    NumberOfChildren = ValueHelper.RandomInt(2),
                    TotalCost = (ValueHelper.RandomInt(2000) + 2000) * 100,
                    Country = "Wales",
                    HotelBookings = Enumerable.Range(0, 2).Select(n => CreateHotelBooking).ToList(),
                    FlightBookings = Enumerable.Range(0, 2).Select(n => CreateFlightBooking).ToList(),

                };

                return result;
            }
        }

        private static CreateHotelBookingCommand CreateHotelBooking
        {
            get
            {
                var result = new CreateHotelBookingCommand
                {
                    HotelName = ValueHelper.RandomString(10),
                    RoomType = ValueHelper.RandomString(10),
                    NumberOfBeds = ValueHelper.RandomInt(3),
                    TotalCost = (ValueHelper.RandomInt(200) + 200) * 100,
                };
                return result;
            }
        }

        private static CreateFlightBookingCommand CreateFlightBooking
        {
            get
            {
                var result = new CreateFlightBookingCommand
                {
                    Reference = ValueHelper.RandomString(10),
                    AirlineName = ValueHelper.RandomString(10),
                    TotalCost = (ValueHelper.RandomInt(200) + 200) * 100,
                    FlightLegs = Enumerable.Range(0, 2).Select(n => CreateFlightLeg).ToList(),
                };
                return result;
            }
        }

        private static CreateFlightLegCommand CreateFlightLeg
        {
            get
            {
                var result = new CreateFlightLegCommand
                {
                    Reference = ValueHelper.RandomString(10),
                    FromIata = ValueHelper.RandomString(3),
                    ToIata = ValueHelper.RandomString(3),

                    DepartureTime = DateTime.Now.AddHours(ValueHelper.RandomInt(100)),
                    ArrivalTime = DateTime.Now.AddHours(ValueHelper.RandomInt(100))
                };

                return result;
            }
        }
    }
}
