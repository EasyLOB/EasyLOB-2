using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    //[DataContract]
    //[Serializable]
    //public class ZPropertyProfileCollection : KeyedCollection<string, IZPropertyProfile>
    //{
    //    #region Methods

    //    protected override string GetKeyForItem(IZPropertyProfile item)
    //    {
    //        return item.Name;
    //    }

    //    #endregion Methods
    //}

    [DataContract]
    [Serializable]
    public class ZPropertyProfile : IZPropertyProfile
    {
        #region Properties

        [DataMember]
        public string Name { get; }

        [DataMember]
        public bool IsGridVisible { get; }

        [DataMember]
        public bool IsGridSearch { get; }

        [DataMember]
        public int GridWidth { get; }

        [DataMember]
        public bool IsEditVisible { get; }

        [DataMember]
        public bool IsEditReadOnly { get; }

        [DataMember]
        public string EditWidthCSS { get; }

        #endregion Properties

        #region Methods

        public ZPropertyProfile(bool IsGridVisible, bool IsGridSearch, int GridWidth,
            bool IsEditVisible, bool IsEditReadOnly, string EditWidthCSS,
            string Name)
        {
            this.IsGridVisible = IsGridVisible;
            this.IsGridSearch = IsGridSearch;
            this.GridWidth = GridWidth;

            this.IsEditVisible = IsEditVisible;
            this.IsEditReadOnly = IsEditReadOnly;
            this.EditWidthCSS = EditWidthCSS;

            this.Name = Name;
        }

        #endregion Methods;
    }
}