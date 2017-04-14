using System;
using System.IO;
using System.Web;

namespace EasyLOB.Library.Mvc
{
    public static partial class MvcHelper
    {
        #region Properties

        public static string ApplicationBaseDirectory
        {
            get
            {
                if (IsWeb)
                {
                    return HttpContext.Current.Server.MapPath("~");
                }
                else
                {
                    return AppDomain.CurrentDomain.BaseDirectory;
                }
            }
        }

        public static bool IsWeb
        {
            get { return HttpContext.Current != null; }
        }

        public static string WebPath
        {
            get
            {
                string result = "";

                if (IsWeb)
                {
                    // http://www.easylob.com/controller/action => www.easylob.com/controller/action
                    result = HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
                }

                return result;
            }
        }

        public static string WebUrl
        {
            get
            {
                string result = "";

                if (IsWeb)
                {
                    // http://www.easylob.com/controller/action => http://www.easylob.com/controller/action
                    return HttpContext.Current.Request.Url.AbsoluteUri.TrimEnd('/');
                }

                return result;
            }
        }

        public static string WebDomain
        {
            get
            {
                string result = "";

                if (IsWeb)
                {
                    Uri uri = new Uri(WebUrl);
                    if (uri.HostNameType == UriHostNameType.Dns)
                    {
                        result = uri.Host;
                    }
                }

                return result;
            }
        }

        public static string WebDirectory(object p)
        {
            throw new NotImplementedException();
        }

        public static string WebSubDomain
        {
            get
            {
                string result = "";

                if (IsWeb)
                {
                    Uri uri = new Uri(WebUrl);
                    if (uri.HostNameType == UriHostNameType.Dns)
                    {
                        string host = uri.Host;
                        string[] words = host.Split('.');
                        if (words.Length >= 2)
                        {
                            // subdomain.domain
                            // subdomain.domain.com
                            // subdomain.domain.com.br
                            result = words[0];
                        }
                    }
                }

                return result;
            }
        }

        #endregion Properties

        #region Methods

        public static string WebDirectory(string path)
        {
            string result = "";

            if (IsWeb)
            {
                // Virtual Path => Physical Path
                //   Directory
                //     ~/EasyLOB-Configuration => C:\GitHub\EasyLOB-Northwind\Northwind.Mvc.AJAX\EasyLOB-Configuration
                //   Path
                //     ~/EasyLOB-Configuration/Menu.json => C:\GitHub\EasyLOB-Northwind\Northwind.Mvc.AJAX\EasyLOB-Configuration\Menu.json
                result = HttpContext.Current.Server.MapPath(path);
            }
            else
            {
                result = Path.Combine(ApplicationBaseDirectory, path);
            }

            return result;
        }

        #endregion Methods
    }
}