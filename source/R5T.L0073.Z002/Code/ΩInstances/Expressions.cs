using System;


namespace R5T.L0073.Z002
{
    public class Expressions : IExpressions
    {
        #region Infrastructure

        public static IExpressions Instance { get; } = new Expressions();


        private Expressions()
        {
        }

        #endregion
    }
}
