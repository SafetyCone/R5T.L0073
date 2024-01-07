using System;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IExceptionMessages : IValuesMarker
    {
        public string TokenHadNoNextToken => "Token had no next token.";
        public string TokenHadNoPreviousToken => "Token had no previous token.";
    }
}
