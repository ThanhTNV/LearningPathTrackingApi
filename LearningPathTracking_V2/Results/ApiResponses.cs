namespace LearningPathTracking_V2.Results
{
    /// <summary>
    /// Extension class providing standard HTTP response methods to use in controllers
    /// </summary>
    public static class ApiResponses
    {
        // 2xx Success responses
        public static ApiResult Ok200(string message = "Success", object data = null)
        {
            return new ApiResult(ApiResponse.Successful(message, data), 200);
        }

        public static ApiResult Created201(string message = "Resource created successfully", object data = null)
        {
            return new ApiResult(ApiResponse.Successful(message, data), 201);
        }

        public static ApiResult Accepted202(string message = "Request accepted for processing", object data = null)
        {
            return new ApiResult(ApiResponse.Successful(message, data), 202);
        }

        public static ApiResult NoContent204()
        {
            // 204 responses should have no content body per HTTP spec
            return new ApiResult(null, 204);
        }

        // 4xx Client Error responses
        public static ApiResult BadRequest400(string message = "Invalid request", object errors = null)
        {
            return new ApiResult(ApiResponse.Error(message, errors), 400);
        }

        public static ApiResult Unauthorized401(string message = "Authentication required")
        {
            return new ApiResult(ApiResponse.Error(message), 401);
        }

        public static ApiResult Forbidden403(string message = "Access forbidden")
        {
            return new ApiResult(ApiResponse.Error(message), 403);
        }

        public static ApiResult NotFound404(string message = "Resource not found", object errors = null)
        {
            return new ApiResult(ApiResponse.Error(message, errors), 404);
        }

        public static ApiResult Conflict409(string message = "Request conflicts with current state", object errors = null)
        {
            return new ApiResult(ApiResponse.Error(message, errors), 409);
        }

        public static ApiResult ValidationError422(string message = "Validation failed", object errors = null)
        {
            return new ApiResult(ApiResponse.Error(message, errors), 422);
        }

        // 5xx Server Error responses
        public static ApiResult InternalError500(string message = "An unexpected error occurred")
        {
            return new ApiResult(ApiResponse.Error(message), 500);
        }

        public static ApiResult ServiceUnavailable503(string message = "Service temporarily unavailable")
        {
            return new ApiResult(ApiResponse.Error(message), 503);
        }
    }
}
