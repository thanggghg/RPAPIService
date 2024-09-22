using GoSell.Comments.Application.Queries.Files;
using GoSell.Comments.Domains.Models.Files;
using GoSell.Orders.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class FilesApi
    {
        public static async Task<Results<Ok<FileResponseModel>, NotFound>> FileAsync(FileModelQuery request, [AsParameters] OrderServices services)
        {
            try
            {
                var files = await services.Mediator.Send(request);
                return TypedResults.Ok(files);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

    }
}
