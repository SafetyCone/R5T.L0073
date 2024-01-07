using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.L0073.F001.Internal
{
    [FunctionalityMarker]
    public partial interface ISyntaxParser : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.ISyntaxParser _Raw => Raw.SyntaxParser.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public TSyntax Parse<TSyntax>(
            string text,
            Func<string, TSyntax> parser,
            IEnumerable<Func<TSyntax, TSyntax>> postParseOperations)
        {
            var syntax = parser(text);

            var output = Instances.FunctionOperator.Run_Modifiers(
                syntax,
                postParseOperations);

            return output;
        }

        public TSyntax Parse<TSyntax>(
            string text,
            Func<string, TSyntax> parser,
            params Func<TSyntax, TSyntax>[] postParseOperations)
        {
            return this.Parse(
                text,
                parser,
                postParseOperations.AsEnumerable());
        }
    }
}
