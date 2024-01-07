using System;


namespace R5T.L0073.F001
{
    public class ParameterModifiers : IParameterModifiers
    {
        #region Infrastructure

        public static IParameterModifiers Instance { get; } = new ParameterModifiers();


        private ParameterModifiers()
        {
        }

        #endregion
    }
}
