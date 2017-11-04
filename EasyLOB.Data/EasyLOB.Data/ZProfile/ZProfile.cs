using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZProfile : IZProfile
    {
        #region Properties

        [DataMember]
        public string Name { get; }

        [DataMember]
        public bool IsIdentity { get; }

        [DataMember]
        public List<string> Keys { get; }

        [DataMember]
        public string Lookup { get; }

        [DataMember]
        public string LINQOrderBy { get; }

        [DataMember]
        public string LINQWhere { get; }

        //[DataMember]
        //public bool IsLog { get; }

        //[DataMember]
        //public bool IsSearch { get; }

        //[DataMember]
        //public int RecordsByLookup { get; }

        //[DataMember]
        //public int RecordsByPage { get; }

        //[DataMember]
        //public int RecordsBySearch { get; }

        [DataMember]
        public List<string> Associations { get; }

        [DataMember]
        public Dictionary<string, bool> Collections { get; }

        [DataMember]
        public List<IZProfileProperty> Properties { get; set; }

        #endregion Properties

        #region Properties Edit

        [DataMember]
        public List<string> EditCollections
        {
            get
            {
                List<string> result = new List<string>();

                foreach(KeyValuePair<string, bool> pair in Collections)
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

                foreach (KeyValuePair<string, bool> pair in Collections)
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

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (!profileProperty.IsEditVisible)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditReadOnlyProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsEditReadOnly)
                    {
                        result.Add(profileProperty.Name);
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

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsGridVisible)
                    {
                        result.Add(profileProperty.Name);
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

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsGridSearch)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        #endregion Properties Grid

        #region Methods

        public ZProfile
        (
            string Name,
            bool IsIdentity,
            List<string> Keys,
            string Lookup,
            string LINQOrderBy,
            string LINQWhere,
            //bool IsLog = false, 
            //bool IsSearch = false,
            //int RecordsByLookup = 0,
            //int RecordsByPage = 0,
            //int RecordsBySearch = 0
            List<string> Associations,
            Dictionary<string, bool> Collections,
            List<IZProfileProperty> Properties
        )
        {
            this.Name = Name;
            this.IsIdentity = IsIdentity;
            this.Keys = Keys;
            this.Lookup = Lookup;
            this.LINQOrderBy = LINQOrderBy;
            this.LINQWhere = LINQWhere;
            //this.IsLog = IsLog;
            //this.IsSearch = IsSearch;
            //this.RecordsByLookup = RecordsByLookup;
            //this.RecordsByPage = RecordsByPage;
            //this.RecordsBySearch = RecordsBySearch;
            this.Associations = Associations;
            this.Collections = Collections;
            this.Properties = Properties;
        }

        #endregion Methods

        #region Methods Edit

        public string EditCSSFor(string propertyName)
        {
            string result = "col-md-1";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.EditCSS;
            }

            return result;
        }

        public bool IsCollectionVisibleFor(string collectionName)
        {
            bool result = false;

            try
            {
                if (Collections.ContainsKey(collectionName))
                {
                    result = Collections[collectionName];
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

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.IsGridVisible;
            }

            return result;
        }

        public int GridWidthFor(string propertyName)
        {
            int result = 100;

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.GridWidth;
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
                    foreach (ZProfileProperty profileProperty in Properties)
                    {
                        _propertyNames.Add(profileProperty.Name);
                    }
                }

                return _propertyNames;
            }
        }

        private IZProfileProperty GetProfileProperty(string name)
        {
            IZProfileProperty result = null;

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