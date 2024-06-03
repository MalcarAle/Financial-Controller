using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions
{
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Transaction: Get By Id")
           .WithSummary("Recupera uma transação")
           .WithDescription("Recupera uma transação pelo ID")
           .WithOrder(4)
           .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            [FromServices] ITransactionHandler handler,
            [FromRoute] long id)
        {
            var request = new GetTransactionByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSucces
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(result);
        }
    }
}
