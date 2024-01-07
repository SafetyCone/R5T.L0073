using System;

using R5T.T0131;


namespace R5T.L0073.F001.Strings
{
    [ValuesMarker]
    public partial interface IIdentifiers : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>Task</value></para>
        /// </summary>
        public string var => "var";

#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>Task</value></para>
        /// </summary>
        public string Task => "Task";
    }
}
