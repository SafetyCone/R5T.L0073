using System;


namespace R5T.L0073.F000
{
    public static class Instances
    {
        public static L0074.IFileOperator FileOperator => L0074.FileOperator.Instance;
        public static F001.ISyntaxGenerator SyntaxGenerator => F001.SyntaxGenerator.Instance;
        public static F001.ISyntaxOperator SyntaxOperator => F001.SyntaxOperator.Instance;
    }
}