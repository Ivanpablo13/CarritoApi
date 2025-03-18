
namespace CarritoApi.Application.Result
{
    public class CarritoResult
    {
        public string MessageType { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;

        public CarritoResult(string messageType, string? message = null)
        {
            MessageType = $"{messageType}".Trim();

            if (message is not null)
                Message = $"{message}".Trim();
        }

        public static CarritoResult Success(string? message = null) => new(MessageTypeCode.Success, message);
        public static CarritoResult Failure(string messageType, string? message = null) => new(messageType, message);
    }

    public class CarritoResult<T> : CarritoResult
    {
        public T? Data { get; set; }

        public CarritoResult(string messageType, string? message = null, T? data = default)
            : base(messageType, message)
        {
            if (messageType.Equals(MessageTypeCode.NoFound))
            {
                Message = "The requested resource was not found";
            }
            Data = data;
        }

        public static CarritoResult<T> Success(T? data = default, string? message = null) => new(MessageTypeCode.Success, message, data);

        public static new CarritoResult<T> Success(string? message = null) => new(MessageTypeCode.Success, message, default);
        public static new CarritoResult<T> Failure(string messageType, string? message = null) => new(messageType, message, default);
    }

    public static class MessageTypeCode
    {
        public readonly static string Success = "Success";
        public readonly static string Error = "Error";
        public readonly static string NoFound = "No Found";
        public readonly static string InsertProblems = "Problems when recording data";
    }

    public static class Message
    {
        public readonly static string InformationSuccesfullySaved = "The information was successfully saved";
        public readonly static string InformationSuccessfullyDeleted = "The information was successfully deleted";
    }
}
