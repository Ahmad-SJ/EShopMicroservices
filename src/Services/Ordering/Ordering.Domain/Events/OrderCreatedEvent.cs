using Ordering.Domain.Models;


public record OrderCreatedEvent(Order order) : IDomainEvent
{

}
