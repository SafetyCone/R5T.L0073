using System;


namespace R5T.L0073.F001
{
    public class Indentations : IIndentations
    {
        #region Infrastructure

        public static IIndentations Instance { get; } = new Indentations();


        private Indentations()
        {
        }

        #endregion
    }
}
