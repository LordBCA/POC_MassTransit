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
    public class CreateAssigmentFunction
    {
        private readonly ILogger _logger;
        private readonly ISender _sender;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
        public record CreateAssigmentRequest(AssigmentDto Assigment);
        public record CreateAssigmentResponse(Guid Id);

        public CreateAssigmentFunction(ILoggerFactory loggerFactory, ISender sender)
        {
            _logger = loggerFactory.CreateLogger<CreateAssigmentFunction>();
            _sender = sender;
        }

        [Function("CreateAssigmentFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Read request body
            //string requestBody = await req.ReadAsStringAsync();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(requestBody))
            {
                _logger.LogError("the payload was empty");
                var response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                response.WriteString("Invalid request body format.");
                return response;
            }

            var assignmentRequest = JsonSerializer.Deserialize<CreateAssigmentRequest>(requestBody, _jsonSerializerOptions);

            if (assignmentRequest?.Assigment == null)
            {
                var response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                response.WriteString("Invalid request body format.");
                return response;
            }            

            var result = await _sender.Send(new CreateAssigmentCommand(assignmentRequest.Assigment));
            
            var responseCommand = JsonSerializer.Serialize(result);

            var responseMessage = req.CreateResponse(HttpStatusCode.OK);
            responseMessage.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            responseMessage.WriteStringAsync(responseCommand);

            return responseMessage;
        }
    }
}
