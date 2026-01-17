namespace TriVibe.Common.GlobalResponse.Errors;

public class ErrorResponse
{
    public int Code { get; set; }
    public string Message { get; set; }
    public string ErrorType { get; set; }
    public ErrorResponse(string message,ErrorTypes errorType)
    {
        Code = (int)errorType;
        Message = message;
        ErrorType = errorType.ToString();
    }
    public enum ErrorTypes
    {
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            FORBIDDEN = 403,
            NOT_FOUND = 404,
            INTERNAL_SERVER_ERROR = 500,
            VALIDATION_ERROR = 422
    }
}
