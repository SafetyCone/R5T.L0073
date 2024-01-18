# R5T.L0073
Roslyn (Microsoft.CodeAnalysis) library.


## How this library works

* Syntax element-level operators and operations are in R5T.L0073.F001.
	These work on the value-based semantics of the Roslyn syntax elements, so are Func{TSyntax, TSyntax}.

* IHasX/IWithX interface types are defined in R5T.L0073.T001.

* IHasX/IWithX operators and operations are in R5T.L0073.F002.
	These work on the reference-based semantics of IHasX/IWithX, so are Action{IHasX}.

* Context classes and interfaces are in R5T.L0073.T002.
	These implement sets of the IHasX/IWithX interfaces from R5T.L0073.T001.

* Contextual operations are in R5T.L0073.O002.

* R5T.L0073.F002.ICompilationUnitOperator inherits from R5T.L0073.F001.ICompilationUnitOperator, but works on the I{Has/With}CompilationUnit interfaces.

## Prior Work

* R5T.E0068 (most recent, best)
* R5T.E0030.Private (R5T.E0030, R5T.E0030.E001)
* R5T.E0029.Private
* R5T.Q0001 (useful)

* R5T.L0011.* - Lots of useful extension method base extensions related to Roslyn.
	(Access through R5T.E0030)

* R5T.F0003 – LOTS of Roslyn syntax functionality.
* R5T.F0004 – Generation, initial, simple of Roslyn syntax elements.
* R5T.F0005 – Generation, initial, parse of Roslyn syntax elements.
* R5T.F0006 – a 
* R5T.F0007 – a
* R5T.F0008 – a
* R5T.F0009 – a
* R5T.F0010 – All Roslyn syntax element operations.
* R5T.F0011 – A 
* R5T.F0012 – a
* R5T.F0013 – a 
* R5T.F0014 – a
* R5T.F0015 – a 
* R5T.F0021 – Some useful stuff.
* R5T.F0022 – Some more useful stuff.
* R5T.F0023 - 
