namespace Order.Microservice.Domain.Commands.Output
{
    public class CommandResult<T>
    {
        public bool IsSuccess { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
        public T? Value { get; private set; }

        public CommandResult(bool isSuccess, IEnumerable<string> messages, T? value)
        {
            Messages = messages;
            IsSuccess = isSuccess;
            Value = value;
        }

        public static CommandResult<T> CreateSuccessedResult(T value)
        {
            return new CommandResult<T>(true, new List<string>(), value);
        }

        public static CommandResult<T> CreateFailedResult(IEnumerable<string> messages)
        {
            return new CommandResult<T>(false, messages, default);
        }
    }

    public class CommandResult : CommandResult<Object>
    {
        public CommandResult(bool isSuccess, IEnumerable<string> messages, object? value) : base(isSuccess, messages, value)
        {}
       
        public static CommandResult CreateSuccessedResult(Guid value)
        {
            return new CommandResult(true, new List<string>(), new {Id = value});
        }

        new public static CommandResult CreateFailedResult(IEnumerable<string> messages)
        {
            return new CommandResult(false, messages, default);
        }
    }
}