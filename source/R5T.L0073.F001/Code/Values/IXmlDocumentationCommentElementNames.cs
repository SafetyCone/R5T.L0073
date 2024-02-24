using System;

using R5T.T0131;


namespace R5T.L0073.F001
{
    [ValuesMarker]
    public partial interface IXmlDocumentationCommentElementNames : IValuesMarker
    {
        /// <summary>
        /// <para><value>summary</value></para>
        /// </summary>
        public string Summary => "summary";
    }
}
