using EasyLOB.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLOB.Data
{
    public abstract class ZDataBase : IZDataBase, INotifyPropertyChanged, IValidatableObject
    {
        #region Properties

        [JsonIgnore] // Newtonsoft.Json
        [NotMapped] // MongoDB
        public virtual string LookupText
        {
            get
            {
                string result = "";

                Type entityType = this.GetType();
                IZDataProfile dataProfile = DataHelper.GetDataProfile(entityType);
                if (!String.IsNullOrEmpty(dataProfile.Class.Lookup))
                {
                    try
                    {
                        var value = LibraryHelper.GetPropertyValue(this, dataProfile.Class.Lookup);
                        result = value == null ? "" : value.ToString();
                    }
                    catch { }
                }

                return result;
            }
            set { }
        }

        #endregion Properties

        #region Methods

        public virtual object[] GetId()
        {
            throw new NotImplementedException();
        }

        public virtual void OnConstructor()
        {
        }

        public virtual void SetId(object[] ids)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }

        #endregion Methods

        #region Triggers

        public virtual bool BeforeCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        #endregion Triggers

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}