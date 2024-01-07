using System;

using R5T.T0131;


namespace R5T.L0073.Z001.Strings
{
    [ValuesMarker]
    public partial interface IMethodNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>Main</value></para>
        /// </summary>
        public string Main => "Main";

        /// <summary>
        /// <para><value>Run</value></para>
        /// </summary>
        public string Run => "Run";

        /// <summary>
        /// <para><value>WriteLine</value></para>
        /// </summary>
        public string WriteLine => "WriteLine";
    }
}
