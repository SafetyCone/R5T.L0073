using System;


namespace R5T.L0073.F001
{
    public class ModifiersOperationSets : IModifiersOperationSets
    {
        #region Infrastructure

        public static IModifiersOperationSets Instance { get; } = new ModifiersOperationSets();


        private ModifiersOperationSets()
        {
        }

        #endregion
    }
}
