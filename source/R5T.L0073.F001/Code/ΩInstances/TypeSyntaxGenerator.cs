using System;


namespace R5T.L0073.F001
{
    public class TypeSyntaxGenerator : ITypeSyntaxGenerator
    {
        #region Infrastructure

        public static ITypeSyntaxGenerator Instance { get; } = new TypeSyntaxGenerator();


        private TypeSyntaxGenerator()
        {
        }

        #endregion
    }
}
