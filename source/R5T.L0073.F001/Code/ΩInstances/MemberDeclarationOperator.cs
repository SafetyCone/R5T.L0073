using System;


namespace R5T.L0073.F001
{
    public class MemberDeclarationOperator : IMemberDeclarationOperator
    {
        #region Infrastructure

        public static IMemberDeclarationOperator Instance { get; } = new MemberDeclarationOperator();


        private MemberDeclarationOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0073.F001.Raw
{
    public class MemberDeclarationOperator : IMemberDeclarationOperator
    {
        #region Infrastructure

        public static IMemberDeclarationOperator Instance { get; } = new MemberDeclarationOperator();


        private MemberDeclarationOperator()
        {
        }

        #endregion
    }
}
