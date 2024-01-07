using System;


namespace R5T.L0073.F001
{
    public class MemberDeclarationOperations : IMemberDeclarationOperations
    {
        #region Infrastructure

        public static IMemberDeclarationOperations Instance { get; } = new MemberDeclarationOperations();


        private MemberDeclarationOperations()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class MemberDeclarationOperations : IMemberDeclarationOperations
    {
        #region Infrastructure

        public static IMemberDeclarationOperations Instance { get; } = new MemberDeclarationOperations();


        private MemberDeclarationOperations()
        {
        }

        #endregion
    }
}
