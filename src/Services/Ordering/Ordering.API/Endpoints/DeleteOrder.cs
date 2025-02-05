using Ordering.Application.Orders.Commands.DeleteOrder;

namespace Ordering.API.Endpoints;

//Accept the order Id as parameter.
//Maps the request to a DeleteOrderCommand
//Uses MediatR to send the command to the corresponding handler.
//Returns a success or not found response.

//Directly obtained from url parameters.
//public record DeleteOrderRequest(Guid Id);

public record DeleteOrderResponse(bool IsSuccess);

public class DeleteOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("orders/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteOrderCommand(id);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteOrderResult>();

            return Results.Ok(response);
        })
            .WithName("DeleteOrder")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Delete Order")
            .WithSummary("Delete Order");
    }
}
