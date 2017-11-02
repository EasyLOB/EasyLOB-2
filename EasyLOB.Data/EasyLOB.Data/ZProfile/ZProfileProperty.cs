using System;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZProfileProperty : IZProfileProperty
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
        public string EditCSS { get; }

        #endregion Properties

        #region Methods

        public ZProfileProperty(bool IsGridVisible, bool IsGridSearch, int GridWidth,
            bool IsEditVisible, bool IsEditReadOnly, string EditCSS,
            string Name)
        {
            this.IsGridVisible = IsGridVisible;
            this.IsGridSearch = IsGridSearch;
            this.GridWidth = GridWidth;

            this.IsEditVisible = IsEditVisible;
            this.IsEditReadOnly = IsEditReadOnly;
            this.EditCSS = EditCSS;

            this.Name = Name;
        }

        #endregion Methods;
    }
}