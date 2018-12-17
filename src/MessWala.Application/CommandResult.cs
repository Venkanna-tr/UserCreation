using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MessWala.Application
{
    public class CommandResult
    {
        public bool Successful { get; set; }

        public Exception Exception { get; set; }

        public static CommandResult Success()
        {
            return new CommandResult { Successful = true };
        }

        public static CommandResult Success(dynamic objectId)
        {
            return new CommandResult { Successful = true, ObjectId = objectId };
        }

        public dynamic ObjectId { get; set; }

        public static CommandResult Error(Exception exception)
        {
            return new CommandResult { Successful = false, Exception = exception };
        }

        private readonly IList<ValidationErrorResult> _messages = new List<ValidationErrorResult>();

        public IEnumerable<ValidationErrorResult> Errors { get; }
        public object Result { get; }

        public CommandResult() => Errors = new ReadOnlyCollection<ValidationErrorResult>(_messages);

        public CommandResult(object result) : this() => Result = result;

        public CommandResult AddError(string propName, string message)
        {
            _messages.Add(new ValidationErrorResult() { PropName = propName, ErrorMessage = message });
            return this;
        }


    }

    public class ValidationErrorResult
    {
        public string PropName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
