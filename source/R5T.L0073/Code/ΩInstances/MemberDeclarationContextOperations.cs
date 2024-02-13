using System;


namespace R5T.L0073
{
    public class MemberDeclarationContextOperations : IMemberDeclarationContextOperations
    {
        #region Infrastructure

        public static IMemberDeclarationContextOperations Instance { get; } = new MemberDeclarationContextOperations();


        private MemberDeclarationContextOperations()
        {
        }

        #endregion
    }
}
