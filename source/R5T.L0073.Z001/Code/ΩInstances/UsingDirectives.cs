using System;


namespace R5T.L0073.Z001
{
    public class UsingDirectives : IUsingDirectives
    {
        #region Infrastructure

        public static IUsingDirectives Instance { get; } = new UsingDirectives();


        private UsingDirectives()
        {
        }

        #endregion
    }
}
