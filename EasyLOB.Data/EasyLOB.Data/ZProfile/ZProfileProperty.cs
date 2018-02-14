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
        public string Name { get; set; }

        [DataMember]
        public bool IsGridVisible { get; set; }

        [DataMember]
        public bool IsGridSearch { get; set; }

        [DataMember]
        public int GridWidth { get; set; }

        [DataMember]
        public bool IsEditVisible { get; set; }

        [DataMember]
        public bool IsEditReadOnly { get; set; }

        [DataMember]
        public string EditCSS { get; set; }

        #endregion Properties

        #region Methods

        public ZProfileProperty()
        {
        }

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