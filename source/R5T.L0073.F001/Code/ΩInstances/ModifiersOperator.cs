using System;


namespace R5T.L0073.F001
{
    public class ModifiersOperator : IModifiersOperator
    {
        #region Infrastructure

        public static IModifiersOperator Instance { get; } = new ModifiersOperator();


        private ModifiersOperator()
        {
        }

        #endregion
    }
}
