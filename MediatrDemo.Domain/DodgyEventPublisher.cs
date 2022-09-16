namespace MediatrDemo.Domain
{
    public static class DodgyEventPublisher
    {
        public static void PublishEvent(OrderCreatedEvent eventModel)
        {

        }

        public static void PublishEvent(FlightBookingCreatedEvent eventModel)
        {

        }
    }
    public class OrderCreatedEvent
    {
        public OrderCreatedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class FlightBookingCreatedEvent
    {
        public FlightBookingCreatedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
