using EasyLOB.Activity.Data;
using EasyLOB.Activity.Resources;
using EasyLOB.Identity.Data;
using EasyLOB.Persistence;
using EasyLOB.Security;
using System;
using System.Linq;

namespace EasyLOB.Activity
{
    public class AuthorizationManager : IAuthorizationManager
    {
        #region Properties

        protected IActivityUnitOfWork UnitOfWork { get; }

        public IAuthenticationManager AuthenticationManager
        {
            get { return UnitOfWork.AuthenticationManager; }
        }

        #endregion Properties

        #region Methods

        public AuthorizationManager(IActivityUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IQueryable<ActivityRole> GetActivityRoles(string activity)
        {
            IGenericRepository<ActivityRole> repositoryActivityRole = UnitOfWork.GetRepository<ActivityRole>();
            IGenericRepository<EasyLOB.Activity.Data.Activity> repositoryActivity = UnitOfWork.GetRepository<EasyLOB.Activity.Data.Activity>();
            IGenericRepository<UserRole> repositoryUserRole = UnitOfWork.GetRepository<UserRole>();

            IQueryable<EasyLOB.Activity.Data.Activity> queryActivity = repositoryActivity.Query(); // ???
            IQueryable<ActivityRole> queryActivityRole = repositoryActivityRole.Query(); // ???

            IQueryable<ActivityRole> activityRoles =
                from
                    Activity in queryActivity
                from
                    ActivityRole in queryActivityRole
                where
                    Activity.Name == activity
                    && ActivityRole.ActivityId == Activity.Id
                    && AuthenticationManager.Roles.Contains(ActivityRole.RoleName)
                select
                    ActivityRole;

            return activityRoles;
        }

        public ZActivityOperations GetOperations(string activity)
        {
            ZActivityOperations result = new ZActivityOperations();
            result.Activity = activity;

            if (AuthenticationManager.IsAdministrator)
            {
                result.IsSearch = true;
                result.IsCreate = true;
                result.IsRead = true;
                result.IsUpdate = true;
                result.IsDelete = true;
                result.IsExport = true;
                result.IsImport = true;
                result.IsExecute = true;

                return result;
            }

            if (!String.IsNullOrEmpty(activity))
            {
                string operationSearchAcronym = SecurityHelper.GetSecurityOperationAcronym(ZOperations.Search);
                string operationCreateAcronym = SecurityHelper.GetSecurityOperationAcronym(ZOperations.Create);
                string operationReadAcronym = SecurityHelper.GetSecurityOperationAcronym(ZOperations.Read);
                string operationUpdateAcronym = SecurityHelper.GetSecurityOperationAcronym(ZOperations.Update);
                string operationDeleteAcronym = SecurityHelper.GetSecurityOperationAcronym(ZOperations.Delete);

                IGenericRepository<ActivityRole> repositoryActivityRole = UnitOfWork.GetRepository<ActivityRole>();
                IGenericRepository<EasyLOB.Activity.Data.Activity> repositoryActivity = UnitOfWork.GetRepository<EasyLOB.Activity.Data.Activity>();
                IGenericRepository<UserRole> repositoryUserRole = UnitOfWork.GetRepository<UserRole>();

                IQueryable<ActivityRole> activityRoles = GetActivityRoles(activity);
                foreach (ActivityRole activityRole in activityRoles.ToList())
                {
                    string operations = activityRole.Operations.ToUpper();

                    result.IsSearch = result.IsSearch || operations.Contains(operationSearchAcronym);
                    result.IsCreate = result.IsCreate || operations.Contains(operationCreateAcronym);
                    result.IsRead = result.IsRead || operations.Contains(operationReadAcronym);
                    result.IsUpdate = result.IsUpdate || operations.Contains(operationUpdateAcronym);
                    result.IsDelete = result.IsDelete || operations.Contains(operationDeleteAcronym);
                }
            }

            return result;
        }

        public bool IsAuthorized(string activity, ZOperations operation)
        {
            if (AuthenticationManager.IsAdministrator)
            {
                return true;
            }

            bool result = false;

            if (!String.IsNullOrEmpty(activity))
            {
                string operationAcronym = SecurityHelper.GetSecurityOperationAcronym(operation);

                IGenericRepository<ActivityRole> repositoryActivityRole = UnitOfWork.GetRepository<ActivityRole>();
                IGenericRepository<EasyLOB.Activity.Data.Activity> repositoryActivity = UnitOfWork.GetRepository<EasyLOB.Activity.Data.Activity>();
                IGenericRepository<UserRole> repositoryUserRole = UnitOfWork.GetRepository<UserRole>();

                IQueryable<ActivityRole> activityRoles = GetActivityRoles(activity);
                foreach (ActivityRole activityRole in activityRoles.ToList())
                {
                    if (activityRole.Operations.ToUpper().Contains(operationAcronym))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public bool IsAuthorized(string activity, ZOperations operation, ZOperationResult operationResult)
        {
            bool result = IsAuthorized(activity, operation);

            if (!result)
            {
                operationResult.ErrorMessage = MessageNotAuthorized(activity, operation);
            }

            return result;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Methods IsOperation

        public bool IsOperation(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsSearch &&
                !activityOperations.IsCreate &&
                !activityOperations.IsRead &&
                !activityOperations.IsUpdate &&
                !activityOperations.IsDelete &&
                !activityOperations.IsExport &&
                !activityOperations.IsImport &&
                !activityOperations.IsExecute)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity));
            }

            return result;
        }

        public bool IsSearch(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsSearch)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Search));
            }

            return result;
        }

        public bool IsCreate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsCreate)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Create));
            }

            return result;
        }

        public bool IsRead(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsRead)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Read));
            }

            return result;
        }

        public bool IsUpdate(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsUpdate)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Update));
            }

            return result;
        }

        public bool IsDelete(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsDelete)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Delete));
            }

            return result;
        }

        public bool IsExport(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsExport)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Export));
            }

            return result;
        }

        public bool IsImport(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsImport)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Import));
            }

            return result;
        }

        public bool IsExecute(ZActivityOperations activityOperations, ZOperationResult operationResult)
        {
            bool result = true;

            if (!activityOperations.IsExecute)
            {
                result = false;
                (operationResult as ZOperationResult).AddOperationError("", MessageNotAuthorized(activityOperations.Activity, ZOperations.Delete));
            }

            return result;
        }

        public bool IsDashboard(string domain, string dashboardDirectory, string dashboardName, ZOperationResult operationResult)
        {
            return IsAuthorized(SecurityHelper.DashboardActivity(domain, dashboardDirectory, dashboardName), ZOperations.Execute, operationResult);
        }

        public bool IsReport(string domain, string reportDirectory, string reportName, ZOperationResult operationResult)
        {
            return IsAuthorized(SecurityHelper.ReportActivity(domain, reportDirectory, reportName), ZOperations.Execute, operationResult);
        }

        public bool IsTask(string domain, string task, ZOperationResult operationResult)
        {
            return IsAuthorized(SecurityHelper.TaskActivity(domain, task), ZOperations.Execute, operationResult);
        }

        #endregion Methods IsOperation

        #region Methods Message

        public string MessageAuthorized(string activity, ZOperations operation)
        {
            return String.Format(SecurityActivityResources.ActivityOperationAuthorized,
                activity,
                SecurityHelper.GetSecurityOperationName(operation),
                AuthenticationManager.UserName);
        }

        public string MessageNotAuthorized(string activity)
        {
            return String.Format(SecurityActivityResources.ActivityOperationNotAuthorized,
                activity,
                "*",
                AuthenticationManager.UserName);
        }

        public string MessageNotAuthorized(string activity, ZOperations operation)
        {
            return String.Format(SecurityActivityResources.ActivityOperationNotAuthorized,
                activity,
                SecurityHelper.GetSecurityOperationName(operation),
                AuthenticationManager.UserName);
        }

        #endregion Methods Message
    }
}