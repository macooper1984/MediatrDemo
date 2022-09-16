namespace MediatrDemo.Logic
{
    public static class DodgyEventPublisher
    {
        public static void PublishEvent(OrderCreatedEvent eventModel)
        {

        }

        public static void PublishEvent(FlightBookingCreatedEvent eventModel)
        {

        }

        public static void PublishEvent(AllOrdersDeletedEvent eventModel)
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

    public class AllOrdersDeletedEvent
    {
    }
}