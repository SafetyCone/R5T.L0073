using System;


namespace R5T.L0073.F001
{
    public class MemberModifiers : IMemberModifiers
    {
        #region Infrastructure

        public static IMemberModifiers Instance { get; } = new MemberModifiers();


        private MemberModifiers()
        {
        }

        #endregion
    }
}
