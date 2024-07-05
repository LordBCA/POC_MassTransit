using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using POC_MassTransit.Application.Assigments.Commands.CreateAssigment;
using POC_MassTransit.Application.Assigments.Common;
using MediatR;

namespace POC_MassTransit.Functions.Functions
{
    public class CreateAssigmentFunction(ILoggerFactory loggerFactory, ISender sender)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<CreateAssigmentFunction>();
        private readonly ISender _sender = sender;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
        public record CreateAssigmentRequest(AssigmentDto Assigment);
        public record CreateAssigmentResponse(Guid Id);

        [Function("CreateAssigmentFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Read request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(requestBody))
            {
                return await WriteErrorAsync(req, HttpStatusCode.BadRequest, "Invalid request body format.");
            }

            var assignmentRequest = JsonSerializer.Deserialize<CreateAssigmentRequest>(requestBody, _jsonSerializerOptions);

            if (assignmentRequest?.Assigment == null)
            {
                return await WriteErrorAsync(req, HttpStatusCode.BadRequest, "Invalid request body format.");
            }            

            var result = await _sender.Send(new CreateAssigmentCommand(assignmentRequest.Assigment));
            
            return await WriteSuccessAsync(req, result);
        }

        private async Task<HttpResponseData> WriteErrorAsync(HttpRequestData request, HttpStatusCode httpStatusCode, string message)
        {
            var response = request.CreateResponse(httpStatusCode);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            await response.WriteStringAsync(message);
            return response;
        }   

        private async Task<HttpResponseData> WriteSuccessAsync(HttpRequestData request, CreateAssigmentResult result)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            var responseCommand = JsonSerializer.Serialize(new CreateAssigmentResponse(result.Id));
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            await response.WriteStringAsync(responseCommand);
            return response;
        }  
    }
}
