﻿using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints;

//Accepts a name parameter.
//Constructs a GetOrderByNameQuery.
//Retrieves and returns matching orders.

//Obtained from url parameters
//public record GetOrdersByNameRequest(string Name);

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("orders/{orderName}", async (string orderName, ISender sender) =>
        {
            var query = new GetOrdersByNameQuery(orderName);

            var result = await sender.Send(query);

            var response = result.Adapt<GetOrdersByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithDescription("Get Orders By Name")
        .WithSummary("Get Orders By Name");
        ;
    }
}
