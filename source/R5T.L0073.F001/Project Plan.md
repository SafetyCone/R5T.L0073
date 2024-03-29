# R5T.L0073.F001
Utility functionality for Roslyn syntax elements. (strictly-platform)

The only allowed dependencies are:

* R5T.NG0019 - The Microsoft.CodeAnalysis NuGet package selector library.
* R5T.L0066 - The .NET Standard 2.1 strictly-platform library.
* R5T.L0073.Y000 - The dependency-free documentation library for the Roslyn platform.


## How this Library Works

* Platform types only (no strong types).


### Generation - By Construction

All syntax elements must come from the static methods a language-specific SyntaxFactory (Microsoft.CodeAnalysis.CSharp.SyntaxFactory).
However, these calls can be cumbersome (for example, to create a simple type name-and-identifier Parameter syntax node for a method declaration requires providing an empty list of attribute lists, an empty list modifiers, the type name, the identifier, and an null equals value clause (for possible optional values).
It would be nice to have a simple method for creating simple type name-and-identifier Parameter syntax nodes; thus the methods in ISyntaxGenerator.
For each syntax element type, there is a "canonical" initial configuration for that type. For example, for method declarations, the canonical configuration contains both a signature and a body, with the open and close braces of the body each on their own lines.
The default name methods of ISyntaxGenerator for each syntax type produce canonical configurations of each syntax element type (node, token, trivia, and other, primarily list types, like SyntaxList).
However, these canonical configurations are frequently *not* the configurations produced by a call to static syntax factory method for a type. Using method declarations as an example, the configuration produced by the static syntax factory method does *not* contain a body, and the default body (BlockSyntax) does *not* have its open and close braces on their own lines.
In that case, the ISyntaxGenerator default name method for the type *still* returns the canonical configuration, but does this by modifying the result of the call to the static syntax factory method, a call that is outsourced to the type's default name method in Raw.ISyntaxGenerator.

* ISyntaxGenerator - Generates basic syntax elements. This is the first stop for basic syntax elements that will later be combined into complex syntax elements. This contains methods named for each type of syntax element, and that produce the canonical syntax element of each type. The syntax elements are generated by direct calls to the CSharp syntax factory, unless the elements produced by SyntaxFactory are deficient in some way. In that case, a call is made to the syntax element's named method in Raw.ISyntaxGenerator, and the result of that call is modified to make them canonical.
* Raw.ISyntaxGenerator - If the syntax elements of a certain type as produced by a call to the language-specific syntax factory are *not* the canonical element of the type (for example, newly created method declarations contain no body!), then the canonical element is produced by the type's default named method in ISyntaxGenerator, via a call to the type's default named method in Raw.ISyntaxGenerator, then modification before being returned. This way the canonical element can be produced by the type's default named method in ISyntaxGenerator, while still being able to facade the cumbersome syntax factory calls.
* More complex syntax nodes, elements, and trivia are generated by ISyntaxNodeGenerator, ISyntaxTokenGenerator, and ISyntaxTriviaGenerator respectively.

Modification of syntax elements follows a builder pattern, in which a Build() method is called on either a constructor or existing instance of a type, and a set of modifier operations for that type.
In this way, modification of elements is really a configuration process for elements.


### Generation - By Parsing


## Capabilities

* Canonical configuration syntax element construction for each syntax element type - ISyntaxGenerator.
* Parsing of text into each syntax element type - ISyntaxParser.
* Valid ordering of member modifiers - IModifiersOperator.Ensure_OrderIsValid(): It's possible to add modifiers to a member in an order that would not compile. For example, adding the partial modifier anywhere except as the last modifier in the modifiers list will result in CS0267 - The 'partial' modifier can only appear immediately before 'class', 'record', 'struct', 'interface', or a method return type.
* Common, basic syntax element values - ITypes, IModifiers, IAttributeListLists, among others: An effort is made to keep provided values as simple as possible (like the tab-only syntax trivia list in IIndentations for use in leading trivias), with even simple syntax values (like the "static void Main()" method declaration signature for all entry points) provided in downstream libraries (like R5T.L0073.Z001).
