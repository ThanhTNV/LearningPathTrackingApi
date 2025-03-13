namespace LearningPathTracking_V2.Results
{
    public class ApiResponse
    {
        // Basic response properties
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }

        // Private constructor to enforce use of factory methods
        private ApiResponse(bool success, string message, object data = null, object errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        /// <summary>
        /// Creates a successful response
        /// </summary>
        public static ApiResponse Successful(string message, object data = null)
        {
            return new ApiResponse(true, message, data);
        }

        /// <summary>
        /// Creates an error response
        /// </summary>
        public static ApiResponse Error(string message, object errors = null)
        {
            return new ApiResponse(false, message, errors: errors);
        }
    }
}
