using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0132;


namespace R5T.L0073.F001
{
    [FunctionalityMarker]
    public partial interface ICompilationUnitOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Raw.ICompilationUnitOperator _Raw => Raw.CompilationUnitOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Adds two new lines before the namespace, then adds it.
        /// </summary>
        public CompilationUnitSyntax Add_Namespace(
            CompilationUnitSyntax compilationUnit,
            NamespaceDeclarationSyntax namespaceDeclaration)
        {
            var modifiedNamespaceDeclaration = Instances.SyntaxNodeOperator.Prepend_TwoBlankLines(namespaceDeclaration);

            var output = _Raw.Add_Namespace(
                compilationUnit,
                modifiedNamespaceDeclaration);

            return output;
        }

        public CompilationUnitSyntax Add_UsingDirective(
            CompilationUnitSyntax compilationUnit,
            string namespaceName)
        {
            var usingDirective = Instances.SyntaxGenerator.UsingDirective(namespaceName);

            var output = this.Add_UsingDirective(
                compilationUnit,
                usingDirective);

            return output;
        }

        public CompilationUnitSyntax Add_UsingDirective(
            CompilationUnitSyntax compilationUnit,
            UsingDirectiveSyntax usingDirective)
        {
            var output = this.Add_UsingDirectives(
                compilationUnit,
                usingDirective);

            return output;
        }

        /// <summary>
        /// Modifies the provided using directives by:
        /// <list type="number">
        /// <item>Removing all leading trivia.</item>
        /// <item>Setting each using directive on its own line.</item>
        /// </list>
        /// </summary>
        public CompilationUnitSyntax Add_UsingDirectives(
            CompilationUnitSyntax compilationUnit,
            params UsingDirectiveSyntax[] usingDirectives)
        {
            // Add leading new lines to using directives, except to the first (if it is the first because there are no already existing using directives).
            var hasUsings = this.Has_UsingDirectives(compilationUnit);

            // First remove all leading trivia.
            var modifiedUsingDirectives = usingDirectives
                .Select(Instances.SyntaxNodeOperator.Remove_LeadingTrivia)
                .Now();

            modifiedUsingDirectives = modifiedUsingDirectives
                .Take(1)
                .Select(usingDirective => hasUsings
                    // If there is already a first using, modify the first added using directive as well.
                    ? Instances.SyntaxOperator.Prepend_NewLine(usingDirective)
                    // Else, if the first using is the first node, do not modify it.
                    : usingDirective)
                .Append(usingDirectives
                    .Skip(1)
                    .Select(Instances.SyntaxOperator.Prepend_NewLine)
                )
                .Now();

            var output = _Raw.Add_UsingDirectives(
                compilationUnit,
                modifiedUsingDirectives);

            return output;
        }

        public CompilationUnitSyntax Add_UsingDirectives(
            CompilationUnitSyntax compilationUnit,
            IEnumerable<UsingDirectiveSyntax> usingDirectives)
        {
            var output = this.Add_UsingDirectives(
                compilationUnit,
                usingDirectives.ToArray());

            return output;
        }

        public bool Has_UsingDirectives(CompilationUnitSyntax compilationUnit)
        {
            var output = compilationUnit.Usings.Any();
            return output;
        }

        public CompilationUnitSyntax In_ModifyContext(
            CompilationUnitSyntax compilationUnit,
            IEnumerable<Func<CompilationUnitSyntax, CompilationUnitSyntax>> modifiers)
        {
            var output = Instances.FunctionOperator.Run_Modifiers(
                compilationUnit,
                modifiers);

            return output;
        }

        public CompilationUnitSyntax In_ModifyContext(
            CompilationUnitSyntax compilationUnit,
            params Func<CompilationUnitSyntax, CompilationUnitSyntax>[] modifiers)
        {
            return this.In_ModifyContext(
                compilationUnit,
                modifiers.AsEnumerable());
        }

        public CompilationUnitSyntax In_ModifyContext(
            Func<CompilationUnitSyntax> compilationUnitConstructor,
            IEnumerable<Func<CompilationUnitSyntax, CompilationUnitSyntax>> modifiers)
        {
            var compilationUnit = compilationUnitConstructor();

            var output = this.In_ModifyContext(
                compilationUnit,
                modifiers);

            return output;
        }

        public CompilationUnitSyntax In_ModifyContext(
            Func<CompilationUnitSyntax> compilationUnitConstructor,
            params Func<CompilationUnitSyntax, CompilationUnitSyntax>[] modifiers)
        {
            return this.In_ModifyContext(
                compilationUnitConstructor,
                modifiers.AsEnumerable());
        }

        public CompilationUnitSyntax In_NewContext(IEnumerable<Func<CompilationUnitSyntax, CompilationUnitSyntax>> modifiers)
        {
            var constructor = Instances.SyntaxConstructors.CompilationUnit;

            var output = this.In_ModifyContext(
                constructor,
                modifiers);

            return output;
        }

        public CompilationUnitSyntax In_NewContext(params Func<CompilationUnitSyntax, CompilationUnitSyntax>[] modifiers)
        {
            var output = this.In_NewContext(modifiers.AsEnumerable());
            return output;
        }

        public async Task<CompilationUnitSyntax> Load(
            string codeFilePath,
            Func<string, CompilationUnitSyntax> parser)
        {
            var code = await Instances.FileOperator.Read_Text(codeFilePath);

            var compilationUnit = parser(code);
            return compilationUnit;
        }

        public CompilationUnitSyntax Load_Synchronous(
            string codeFilePath,
            Func<string, CompilationUnitSyntax> parser)
        {
            var code = Instances.FileOperator.Read_Text_Synchronous(codeFilePath);

            var compilationUnit = parser(code);
            return compilationUnit;
        }

        public Task<CompilationUnitSyntax> Load(string codeFilePath)
        {
            return Instances.CompilationUnitOperator.Load(
                codeFilePath,
                Instances.SyntaxParser.Parse_CompilationUnit);
        }

        public CompilationUnitSyntax Load_Synchronous(string codeFilePath)
        {
            return Instances.CompilationUnitOperator.Load_Synchronous(
                codeFilePath,
                Instances.SyntaxParser.Parse_CompilationUnit);
        }

        public Task<CompilationUnitSyntax> Load_Raw(string codeFilePath)
        {
            return Instances.CompilationUnitOperator.Load(
                codeFilePath,
                Instances.SyntaxParser._Raw.Parse_CompilationUnit);
        }

        public CompilationUnitSyntax Load_Raw_Synchronous(string codeFilePath)
        {
            return Instances.CompilationUnitOperator.Load_Synchronous(
                codeFilePath,
                Instances.SyntaxParser._Raw.Parse_CompilationUnit);
        }

        public Task Write_ToFile(
            CompilationUnitSyntax compilationUnit,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            return Instances.SyntaxOperator.Write_ToFile(
                compilationUnit,
                codeFilePath,
                overwrite);
        }

        public void Write_ToFile_Synchronous(
            CompilationUnitSyntax compilationUnit,
            string codeFilePath,
            bool overwrite = L0066.IValues.Default_OverwriteValue_Constant)
        {
            Instances.SyntaxOperator.Write_ToFile_Synchronous(
                compilationUnit,
                codeFilePath,
                overwrite);
        }
    }
}
