using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IModifiersOperations : IValuesMarker
    {
        public SyntaxTokenList Add_Async(SyntaxTokenList tokens)
        {
            return Instances.ModifiersOperator.Add_Async(tokens);
        }

        public SyntaxTokenList Add_Private(SyntaxTokenList tokens)
        {
            return Instances.ModifiersOperator.Add_Private(tokens);
        }

        public SyntaxTokenList Add_Public(SyntaxTokenList tokens)
        {
            return Instances.ModifiersOperator.Add_Public(tokens);
        }

        public SyntaxTokenList Add_Static(SyntaxTokenList tokens)
        {
            return Instances.ModifiersOperator.Add_Static(tokens);
        }
    }
}
