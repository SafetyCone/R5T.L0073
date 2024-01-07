using System;


namespace R5T.L0073.F001
{
    public class HasMembersOperator : IHasMembersOperator
    {
        #region Infrastructure

        public static IHasMembersOperator Instance { get; } = new HasMembersOperator();


        private HasMembersOperator()
        {
        }

        #endregion
    }
}
