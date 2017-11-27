using System;

namespace EasyLOB.Security
{
    public static partial class SecurityHelper
    {
        #region Properties

        public static string[] OperationAcronyms
        {
            get
            {
                return new string[] {
                    "I", // Index
                    "S", // Search
                    "C", // Create
                    "R", // Read
                    "U", // Update
                    "D", // Delete
                    "E", // Export
                    "X"  // Execute
                };
            }
        }

        public static string[] OperationNames
        {
            get
            {
                return new string[] {
                    "Index", // Index
                    "Search", // Search
                    "Create", // Create
                    "Read",   // Read
                    "Update", // Update
                    "Delete", // Delete
                    "Export", // Export
                    "Execute" // Execute
                };
            }
        }

        #endregion Properties

        #region Methods Activity

        public static string DashboardActivity(string domain, string dashboardDirectory, string dashboardName)
        {
            // Domain-Dashboard-DashboardName
            // Domain-Dashboard-DashboardDirectory-DashboardName

            string activity = "";

            if (!String.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Dashboard";

            if (!String.IsNullOrEmpty(dashboardDirectory))
            {
                activity = activity + (activity == "" ? "" : "-") + dashboardDirectory;
            }

            if (!String.IsNullOrEmpty(dashboardName))
            {
                activity = activity + (activity == "" ? "" : "-") + dashboardName;
            }

            return activity;
        }

        public static string EntityActivity(string domain, string entity)
        {
            // Domain-Entity

            string activity = "";

            if (!String.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            if (!String.IsNullOrEmpty(entity))
            {
                activity = activity + (activity == "" ? "" : "-") + entity;
            }

            return activity;
        }

        public static string ReportActivity(string domain, string reportDirectory, string reportName)
        {
            // Domain-Report-ReportName
            // Domain-Report-ReportDirectory-ReportName

            string activity = "Report";

            if (!String.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Report";

            if (!String.IsNullOrEmpty(reportDirectory))
            {
                activity = activity + (activity == "" ? "" : "-") + reportDirectory;
            }

            if (!String.IsNullOrEmpty(reportName))
            {
                activity = activity + (activity == "" ? "" : "-") + reportName;
            }

            return activity;
        }

        public static string TaskActivity(string domain, string taskName)
        {
            // Domain-Task-TaskName

            string activity = "";

            if (!String.IsNullOrEmpty(domain))
            {
                activity = domain;
            }

            activity = activity + (activity == "" ? "" : "-") + "Task";

            if (!String.IsNullOrEmpty(taskName))
            {
                activity = activity + (activity == "" ? "" : "-") + taskName;
            }

            return activity;
        }

        #endregion Methods Activity

        #region Methods GetSecurityOperations

        public static string GetSecurityOperationAcronym(ZOperations operation)
        {
            string result = "";

            try
            {
                int index = (int)operation;
                result = OperationAcronyms[index];
            }
            catch
            {
            }

            return result;
        }

        public static ZOperations GetSecurityOperationByAcronym(string acronym)
        {
            ZOperations result = ZOperations.None;

            try
            {
                int index = Array.IndexOf(OperationAcronyms, acronym);
                if (index > 0)
                {
                    result = (ZOperations)index;
                }
            }
            catch
            {
            }

            return result;
        }

        public static ZOperations GetSecurityOperationByName(string name)
        {
            ZOperations result = ZOperations.None;

            try
            {
                int index = Array.IndexOf(OperationNames, name);
                if (index > 0)
                {
                    result = (ZOperations)index;
                }
            }
            catch
            {
            }

            return result;
        }

        public static string GetSecurityOperationName(ZOperations operation)
        {
            string result = "";

            try
            {
                int index = (int)operation;
                result = OperationNames[index];
            }
            catch
            {
            }

            return result;
        }

        #endregion Methods GetSecurityOperations

        #region Methods GetIsSecurityOperation

        public static bool GetIsSecurityOperation(ZActivityOperations activityOperations, ZOperations operation)
        {
            bool result = false;

            switch (operation)
            {
                case ZOperations.Index:
                    result = activityOperations.IsIndex;
                    break;

                case ZOperations.Search:
                    result = activityOperations.IsSearch;
                    break;

                case ZOperations.Create:
                    result = activityOperations.IsCreate;
                    break;

                case ZOperations.Read:
                    result = activityOperations.IsRead;
                    break;

                case ZOperations.Update:
                    result = activityOperations.IsUpdate;
                    break;

                case ZOperations.Delete:
                    result = activityOperations.IsDelete;
                    break;

                case ZOperations.Export:
                    result = activityOperations.IsExport;
                    break;

                case ZOperations.Execute:
                    result = activityOperations.IsExecute;
                    break;
            }

            return result;
        }

        public static bool GetIsSecurityOperationByAcronym(ZActivityOperations activityOperations, string acronym)
        {
            return GetIsSecurityOperation(activityOperations, SecurityHelper.GetSecurityOperationByAcronym(acronym));
        }

        public static bool GetIsSecurityOperationByName(ZActivityOperations activityOperations, string name)
        {
            return GetIsSecurityOperation(activityOperations, SecurityHelper.GetSecurityOperationByAcronym(name));
        }

        #endregion Methods GetIsSecurityOperation
    }
}