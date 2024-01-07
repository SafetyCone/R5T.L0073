using System;


namespace R5T.L0073.F001
{
    public class ModifierSets : IModifierSets
    {
        #region Infrastructure

        public static IModifierSets Instance { get; } = new ModifierSets();


        private ModifierSets()
        {
        }

        #endregion
    }
}
