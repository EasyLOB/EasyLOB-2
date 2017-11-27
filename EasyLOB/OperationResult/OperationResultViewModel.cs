namespace EasyLOB
{
    public class OperationResultViewModel
    {
        public ZOperationResult OperationResult { get; set; }

        public OperationResultViewModel()
        {
            OperationResult = new ZOperationResult();
        }

        public OperationResultViewModel(ZOperationResult operationResult)
        {
            OperationResult = operationResult;
        }
    }
}