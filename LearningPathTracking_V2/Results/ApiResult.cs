using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LearningPathTracking_V2.Results
{
    public class ApiResult : ActionResult
    {
        private readonly ApiResponse _response;
        private readonly int _statusCode;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly bool _hasContent;

        public ApiResult(ApiResponse response, int statusCode, JsonSerializerOptions jsonOptions = null)
        {
            _response = response;
            _statusCode = statusCode;
            _jsonOptions = jsonOptions ?? new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            // No content responses should not have a response body
            _hasContent = statusCode != 204;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            if (!response.HasStarted)
            {
                response.StatusCode = _statusCode;

                // Only provide content for non-204 responses
                if (_hasContent)
                {
                    response.ContentType = "application/json";

                    try
                    {
                        var json = JsonSerializer.Serialize(_response, _jsonOptions);
                        await response.WriteAsync(json);
                    }
                    catch (Exception ex)
                    {
                        // Only change status code if response hasn't started
                        if (!response.HasStarted)
                        {
                            response.StatusCode = 500;
                            var errorJson = JsonSerializer.Serialize(
                                ApiResponse.Error("Error generating response"), _jsonOptions);
                            await response.WriteAsync(errorJson);
                        }

                        // Log the exception
                        Console.WriteLine($"Error serializing response: {ex}");
                    }
                }
            }
            else
            {
                // Log that we couldn't set response details because it already started
                Console.WriteLine("Response already started, unable to modify headers or write content");
            }
        }
    }
}
