using System;


namespace R5T.L0073.F001
{
    public class ModifiersOperations : IModifiersOperations
    {
        #region Infrastructure

        public static IModifiersOperations Instance { get; } = new ModifiersOperations();


        private ModifiersOperations()
        {
        }

        #endregion
    }
}
