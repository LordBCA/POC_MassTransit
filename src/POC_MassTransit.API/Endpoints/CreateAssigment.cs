using Carter;
using Mapster;
using MediatR;
using POC_MassTransit.Application.Assigments.Commands.CreateAssigment;
using POC_MassTransit.Application.Assigments.Common;

namespace POC_MassTransit.API.Endpoints;

public record CreateAssigmentRequest(AssigmentDto Assigment);
public record CreateAssigmentResponse(Guid Id);

public class CreateAssigment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/assigment", async (CreateAssigmentRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateAssigmentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateAssigmentResponse>();

            return Results.Created($"/assigment/{response.Id}", response);
        })
        .WithName("CreateAssigment")
        .Produces<CreateAssigmentResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Assigment")
        .WithDescription("Create Assigment");
    }
}