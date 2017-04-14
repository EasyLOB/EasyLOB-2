using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZClassProfile : IZClassProfile
    {
        #region Properties

        [DataMember]
        public string Name { get; }

        [DataMember]
        public bool IsIdentity { get; }

        [DataMember]
        public string[] Keys { get; }

        [DataMember]
        public string Lookup { get; }

        [DataMember]
        public string[] Associations { get; }

        [DataMember]
        public Dictionary<string, bool> CollectionsDictionary { get; }

        [DataMember]
        public string LINQOrderBy { get; }

        [DataMember]
        public string LINQWhere { get; }

        /*
        [DataMember]
        public bool IsLog { get; }
        */

        /*
        [DataMember]
        public bool IsSearch { get; }
         */

        [DataMember]
        public int RecordsByLookup { get; }

        [DataMember]
        public int RecordsByPage { get; }

        [DataMember]
        public int RecordsBySearch { get; }

        #endregion Properties

        #region Methods

        public ZClassProfile
        (
            string Name,
            bool IsIdentity,
            string[] Keys,
            string Lookup,
            string[] Associations,
            Dictionary<string, bool> CollectionsDictionary,
            string LINQOrderBy,
            string LINQWhere,
            //bool IsLog = false, 
            //bool IsSearch = false,
            int RecordsByLookup = 0,
            int RecordsByPage = 0,
            int RecordsBySearch = 0
        )
        {
            this.Name = Name;

            this.IsIdentity = IsIdentity;
            this.Keys = Keys;
            this.Lookup = Lookup;

            this.Associations = Associations;
            this.CollectionsDictionary = CollectionsDictionary;
            this.LINQOrderBy = LINQOrderBy;
            this.LINQWhere = LINQWhere;

            //this.IsLog = IsLog;
            //this.IsSearch = IsSearch;
            this.RecordsByLookup = RecordsByLookup;
            this.RecordsByPage = RecordsByPage;
            this.RecordsBySearch = RecordsBySearch;
        }

        #endregion Methods
    }
}