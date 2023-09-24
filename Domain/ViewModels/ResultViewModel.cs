namespace Domain.ViewModels
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ResultViewModel(bool result, OperationType operationType)
        {
            IsSuccess = result;
            if (result)
            {
                if (operationType == OperationType.Insert)
                    Message = Constants.strMessageInsertSuccess;
                else if (operationType == OperationType.Update)
                    Message = Constants.strMessageUpdateSuccess;
                else
                    Message = Constants.strMessageDeleteSuccess;
            }
            else
            {
                if (operationType == OperationType.Insert)
                    Message = Constants.strMessageInsertError;
                else if (operationType == OperationType.Update)
                    Message = Constants.strMessageUpdateError;
                else
                    Message = Constants.strMessageDeleteError;
            }
        }
    }
}
