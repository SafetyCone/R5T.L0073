using System;

using R5T.T0131;


namespace R5T.L0073.Z001.Strings
{
    [ValuesMarker]
    public partial interface IClassNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>Documentation</value></para>
        /// </summary>
        public string Documentation => "Documentation";

        /// <summary>
        /// <para><value>Instances</value></para>
        /// </summary>
        public string Instances => "Instances";

        /// <summary>
        /// <para><value>Program</value></para>
        /// </summary>
        public string Program => "Program";
    }
}
