using System;

using R5T.T0131;


namespace R5T.L0073.Z001.Strings
{
    [ValuesMarker]
    public partial interface IVariableNames : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>app</value></para>
        /// </summary>
        public string app => "app";

        /// <summary>
        /// <para><value>args</value></para>
        /// </summary>
        public string args => "args";

        /// <summary>
        /// <para><value>builder</value></para>
        /// </summary>
        public string builder => "builder";

#pragma warning restore IDE1006 // Naming Styles
    }
}
