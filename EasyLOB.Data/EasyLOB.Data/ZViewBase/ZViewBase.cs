using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ModelState.IsValid vs IValidateableObject in MVC3
// http://stackoverflow.com/questions/3744408/modelstate-isvalid-vs-ivalidateableobject-in-mvc3
// Validation using the DefaultModelBinder is a two stage process.
// First, Data Annotations are validated.
// Then (and only if the data annotations validation resulted in zero errors), IValidatableObject.Validate() is called.
// This all takes place automatically when your post action has a viewmodel parameter.ModelState.IsValid doesn't do anything as such.
// Rather it just reports whether any item in the ModelState collection has non-empty ModelErrorCollection.

namespace EasyLOB.Data
{
    public class ZViewBase<TEntityView, TEntityDTO, TEntity> : IZViewBase<TEntityView, TEntityDTO, TEntity>, IValidatableObject, IZValidatableObject
    {
        #region Properties

        public virtual string LookupText { get; set; }

        #endregion Properties

        #region Methods

        public virtual Func<TEntityView, TEntityDTO> GetDTOSelector()
        {
            throw new NotImplementedException();
        }

        public virtual Func<TEntityDTO, TEntityView> GetViewSelector()
        {
            throw new NotImplementedException();
        }

        public virtual void FromData(IZDataBase data)
        {
            throw new NotImplementedException();
        }

        public virtual void FromDTO(IZDTOBase<TEntityDTO, TEntity> dto)
        {
            throw new NotImplementedException();
        }

        public virtual void OnConstructor()
        {
        }

        public virtual IZDataBase ToData()
        {
            throw new NotImplementedException();
        }

        public virtual IZDTOBase<TEntityDTO, TEntity> ToDTO()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }

        public virtual bool Validate(ZOperationResult operationResult)
        {
            return true;
        }      

        #endregion Methods
    }
}