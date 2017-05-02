grammar Pointcut;

options {
	language=CSharp3;
	output=AST;
}

tokens{
	CRITERIA;
	ARRAY;
	POINTCUTREF;
}

@parser::namespace { SheepAspect.Saql.Ast }
@lexer::namespace { SheepAspect.Saql.Ast }
@lexer::members {const int HIDDEN = Hidden;}

public
pointcut:	compound? EOF;

compound:	array ((And|Or)^ array)*;

array	:	negation (
			(',' negation)+ -> ^(ARRAY negation*)
			|  -> negation
		);

negation	:	(NOT^)? criteria;

criteria :	atom
	|	(Identifier (':' array)?)-> ^(CRITERIA Identifier array?);
	
atom	:	'@' Identifier -> ^(POINTCUTREF Identifier)
		| Value 
		| '('! compound ')'!;

NOT	:	'!';
And	:	'&&' | '&';
Or	:	'||' | '|';

Identifier:	('A'..'z' | '0'..'9' | UScore)+;


Value
	:	'\'' ('A'..'z' | '0'..'9' | '(' | ')' | '*' | '.' | ' ' | UScore | ':')*'\'';


fragment UScore
	:	'_';

Ws  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {$channel=HIDDEN;}
    ;
