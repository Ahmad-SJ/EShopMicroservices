namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string Username);

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string username, ISender sender) =>
        {
            var query = new GetBasketQuery(username);

            var result = await sender.Send(query);

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
            .WithName("Get Basket")
            .WithDescription("Get Basket")
            .WithSummary("Get Basket")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
