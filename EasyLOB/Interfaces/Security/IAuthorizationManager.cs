using System;

namespace EasyLOB.Security
{
    public interface IAuthorizationManager : IDisposable
    {
        #region Properties

        IAuthenticationManager AuthenticationManager { get; }

        #endregion Properties

        #region Methods

        ZActivityOperations GetOperations(string activity);

        bool IsAuthorized(string activity, ZOperations operation);

        bool IsAuthorized(string activity, ZOperations operation, ZOperationResult operationResult);

        #endregion Methods

        #region Methods IsOperation

        bool IsOperation(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsIndex(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsSearch(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsCreate(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsRead(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsUpdate(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsDelete(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsExport(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsExecute(ZActivityOperations activityOperations, ZOperationResult operationResult);

        bool IsDashboard(string domain, string dashboardDirectory, string dashboardName, ZOperationResult operationResult);

        bool IsReport(string domain, string reportDirectory, string reportName, ZOperationResult operationResult);

        bool IsTask(string domain, string task, ZOperationResult operationResult);

        #endregion Methods IsOperation

        #region Methods Message

        string MessageAuthorized(string activity, ZOperations operation);

        string MessageNotAuthorized(string activity, ZOperations operation);

        #endregion Methods Message
    }
}