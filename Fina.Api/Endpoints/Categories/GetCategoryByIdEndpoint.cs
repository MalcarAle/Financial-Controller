using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core;
using Microsoft.AspNetCore.Mvc;
using Fina.Core.Responses;

namespace Fina.Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
          => app.MapGet("/{id}", HandleAsync)
           .WithName("Categories: Get By Id")
           .WithSummary("Recupera uma categoria")
           .WithDescription("Recupera uma categoria pelo ID")
           .WithOrder(4)
           .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync(
            [FromServices] ICategoryHandler handler,
            [FromRoute]long id)
        {
            var request = new GetCategoryByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id= id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSucces
                    ? TypedResults.Ok(result)
                    : TypedResults.BadRequest(result);
        }
    }
}
