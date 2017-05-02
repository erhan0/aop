grammar Saqa;

options {
	language=CSharp3;
	output=AST;
}

@parser::namespace { SheepAspectQueryAnalyzer.Engine.Parser }
@lexer::namespace { SheepAspectQueryAnalyzer.Engine.Parser }
@lexer::members {const int HIDDEN = Hidden;}

public pointcuts returns [IEnumerable<PointcutExpression> values]
	@init {var list = new List<PointcutExpression>(); }
	:	(p=pointcut {list.Add($p.value);})*
	{
		$values = list;
	};

pointcut returns [PointcutExpression value]
	:	(alias '=')? '[' attribute '(' saql ')' ']'
	{
		$value = new PointcutExpression($alias.value, $attribute.value, $saql.value);
	};

alias returns [string value]	
	:	ID {$value = $ID.Text;} ;

attribute returns [string value]
	:	ID {$value = $ID.Text;};
	
saql	returns [string value]
	:	STRING {$value = ProcessString($STRING);};

STRING
	:	'"' (~('"'))* '"';

ID :	('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;

COMMENT
    :   '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    |   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        ) {$channel=HIDDEN;}
    ;
