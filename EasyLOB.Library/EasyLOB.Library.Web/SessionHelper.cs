using System.Collections.Generic;
using System.Web;

namespace EasyLOB.Library.Web
{
    public static class SessionHelper
    {
        #region Properties

        public static System.Web.SessionState.HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        private static Dictionary<string, object> SessionDictionary = new Dictionary<string, object>();

        #endregion Properties

        #region Methods Session

        public static void Abandon()
        {
            if (WebHelper.IsWeb)
            {
                if (Session != null)
                {
                    Session.Abandon();
                }
            }
        }

        public static void Clear()
        {
            if (WebHelper.IsWeb)
            {
                if (Session != null)
                {
                    Session.Clear();
                }
            }
            else
            {
                SessionDictionary.Clear();
            }
        }

        public static void Clear(string sessionName)
        {
            if (WebHelper.IsWeb)
            {
                if (Session != null)
                {
                    Session[sessionName] = null;
                }
            }
            else
            {
                if (SessionDictionary.ContainsKey(sessionName))
                {
                    SessionDictionary.Remove(sessionName);
                }
            }
        }

        public static object Read(string sessionName)
        {
            object result = null;

            if (WebHelper.IsWeb)
            {
                if (Session != null)
                {
                    result = Session[sessionName];
                }
            }
            else
            {
                if (SessionDictionary.ContainsKey(sessionName))
                {
                    result = SessionDictionary[sessionName];
                }
            }

            return result;
        }

        public static void Write(string sessionName, object value)
        {
            if (WebHelper.IsWeb)
            {
                if (Session != null)
                {
                    Session[sessionName] = value;
                }
            }
            else
            {
                if (SessionDictionary.ContainsKey(sessionName))
                {
                    SessionDictionary[sessionName] = value;
                }
                else
                {
                    SessionDictionary.Add(sessionName, value);
                }
            }
        }

        #endregion Methods Session
    }
}