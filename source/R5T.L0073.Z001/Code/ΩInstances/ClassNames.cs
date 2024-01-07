using System;


namespace R5T.L0073.Z001
{
    public class ClassNames : IClassNames
    {
        #region Infrastructure

        public static IClassNames Instance { get; } = new ClassNames();


        private ClassNames()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.Z001.Strings
{
    public class ClassNames : IClassNames
    {
        #region Infrastructure

        public static IClassNames Instance { get; } = new ClassNames();


        private ClassNames()
        {
        }

        #endregion
    }
}
