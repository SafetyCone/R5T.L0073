using System;


namespace R5T.L0073.Z001
{
    public class Statements : IStatements
    {
        #region Infrastructure

        public static IStatements Instance { get; } = new Statements();


        private Statements()
        {
        }

        #endregion
    }
}
