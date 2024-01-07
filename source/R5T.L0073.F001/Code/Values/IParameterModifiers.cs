using System;

using Microsoft.CodeAnalysis;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IParameterModifiers : IValuesMarker
    {
        public SyntaxToken In => Instances.Modifiers.In;
        public SyntaxToken Out => Instances.Modifiers.Out;
        public SyntaxToken Params => Instances.Modifiers.Params;
        public SyntaxToken Ref => Instances.Modifiers.Ref;
    }
}
