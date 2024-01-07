using System;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IExceptions : IValuesMarker
    {
        public Exception TokenHadNoNextTokenException => Instances.ExceptionOperator.New(
            Instances.ExceptionMessages.TokenHadNoNextToken);

        public Exception TokenHadNoPreviousTokenException => Instances.ExceptionOperator.New(
            Instances.ExceptionMessages.TokenHadNoNextToken);
    }
}
