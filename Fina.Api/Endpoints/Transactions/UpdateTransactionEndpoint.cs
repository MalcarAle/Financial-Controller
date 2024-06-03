using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapPut("/{id}", HandleAsync)
           .WithName("Transaction: Update")
           .WithSummary("Atualiza uma transação")
           .WithDescription("RAtualiza uma transação")
           .WithOrder(2)
           .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync(
            [FromServices] ITransactionHandler handler,
            [FromBody] UpdateTransactionRequest request,
            [FromRoute] long id)
        {
            request.UserId = ApiConfiguration.UserId;
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSucces
                   ? TypedResults.Ok(result)
                   : TypedResults.BadRequest(result);
        }
    }
}
