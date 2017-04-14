namespace EasyLOB.Data
{
    public interface IZDataBase
    {
        #region Properties

        string LookupText { get; set; } // ??? "LookupText" could be read-only, but OData needs "set"

        #endregion Properties

        #region Methods

        object[] GetId();

        void OnConstructor();

        void SetId(object[] ids);

        #endregion Methods

        #region Triggers

        bool BeforeCreate(ZOperationResult operationResult);

        bool AfterCreate(ZOperationResult operationResult);

        bool BeforeDelete(ZOperationResult operationResult);

        bool AfterDelete(ZOperationResult operationResult);

        bool BeforeUpdate(ZOperationResult operationResult);

        bool AfterUpdate(ZOperationResult operationResult);

        #endregion Triggers
    }
}