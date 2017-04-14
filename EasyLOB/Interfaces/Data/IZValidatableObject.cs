namespace EasyLOB.Data
{
    public interface IZValidatableObject
    {
        #region Methods

        bool Validate(ZOperationResult operationResult);

        #endregion Methods
    }
}