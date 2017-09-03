using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZDataProfile : IZDataProfile
    {
        #region Properties

        [DataMember]
        public IZClassProfile Class { get; set; }

        [DataMember]
        public List<IZPropertyProfile> Properties { get; set; }

        #endregion Properties

        #region Properties Edit

        [DataMember]
        public List<string> EditCollections
        {
            get
            {
                List<string> result = new List<string>();

                foreach(KeyValuePair<string, bool> pair in Class.CollectionsDictionary)
                {
                    if (pair.Value)
                    {
                        result.Add(pair.Key);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditHiddenCollections
        {
            get
            {
                List<string> result = new List<string>();

                foreach (KeyValuePair<string, bool> pair in Class.CollectionsDictionary)
                {
                    if (!pair.Value)
                    {
                        result.Add(pair.Key);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditHiddenProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZPropertyProfile propertyProfile in Properties)
                {
                    if (!propertyProfile.IsEditVisible)
                    {
                        result.Add(propertyProfile.Name);
                    }
                }

                return result;
            }
        }

        //[DataMember]
        //public List<string> EditProperties
        //{
        //    get
        //    {
        //        List<string> result = new List<string>();

        //        foreach (ZPropertyProfile propertyProfile in Properties)
        //        {
        //            if (propertyProfile.IsEditVisible)
        //            {
        //                result.Add(propertyProfile.Name);
        //            }
        //        }

        //        return result;
        //    }
        //}

        [DataMember]
        public List<string> EditReadOnlyProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZPropertyProfile propertyProfile in Properties)
                {
                    if (propertyProfile.IsEditReadOnly)
                    {
                        result.Add(propertyProfile.Name);
                    }
                }

                return result;
            }
        }

        #endregion Properties Edit

        #region Properties Grid

        [DataMember]
        public List<string> GridProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZPropertyProfile propertyProfile in Properties)
                {
                    if (propertyProfile.IsGridVisible)
                    {
                        result.Add(propertyProfile.Name);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> GridSearchProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZPropertyProfile propertyProfile in Properties)
                {
                    if (propertyProfile.IsGridSearch)
                    {
                        result.Add(propertyProfile.Name);
                    }
                }

                return result;
            }
        }

        #endregion Properties Grid

        #region Methods Edit

        public string EditWidthCSSFor(string propertyName)
        {
            string result = "col-md-1";

            IZPropertyProfile propertyProfile = GetPropertyProfile(propertyName);
            if (propertyProfile != null)
            {
                result = propertyProfile.EditWidthCSS;
            }

            return result;
        }

        public bool IsCollectionVisibleFor(string collectionName)
        {
            bool result = false;

            try
            {
                if (Class.CollectionsDictionary.ContainsKey(collectionName))
                {
                    result = Class.CollectionsDictionary[collectionName];
                }
            }
            catch { }

            return result;
        }

        #endregion Methods Edit

        #region Methods Grid

        public bool IsGridVisibleFor(string propertyName)
        {
            bool result = false;

            IZPropertyProfile propertyProfile = GetPropertyProfile(propertyName);
            if (propertyProfile != null)
            {
                result = propertyProfile.IsGridVisible;
            }

            return result;
        }

        public int GridWidthFor(string propertyName)
        {
            int result = 100;

            IZPropertyProfile propertyProfile = GetPropertyProfile(propertyName);
            if (propertyProfile != null)
            {
                result = propertyProfile.GridWidth;
            }

            return result;
        }

        #endregion Methods Grid

        #region Dictionary

        private List<string> _propertyNames;

        private List<string> PropertyNames
        {
            get
            {
                if (_propertyNames == null)
                {
                    _propertyNames = new List<string>();
                    foreach (ZPropertyProfile propertyProfile in Properties)
                    {
                        _propertyNames.Add(propertyProfile.Name);
                    }
                }

                return _propertyNames;
            }
        }

        private IZPropertyProfile GetPropertyProfile(string name)
        {
            IZPropertyProfile result = null;

            int index = PropertyNames.IndexOf(name);
            if (index >= 0)
            {
                return Properties[index];
            }

            return result;
        }

        #endregion Dictionary
    }
}