namespace VivesBlog.Model.ServiceResult
{
    public class GenericServiceResult<T>
    {
        public T? Data { get; set; }
        public IList<ServiceError> Errors { get; set; } = new List<ServiceError>();
        public bool IsSuccess => !Errors.Any(e => e.Type == ErrorType.Error);
    }

    public class ServiceError
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public ErrorType Type { get; set; }
    }

    public enum ErrorType
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}