using System;


namespace R5T.L0073.Z001.Strings
{
    public class VariableNames : IVariableNames
    {
        #region Infrastructure

        public static IVariableNames Instance { get; } = new VariableNames();


        private VariableNames()
        {
        }

        #endregion
    }
}
