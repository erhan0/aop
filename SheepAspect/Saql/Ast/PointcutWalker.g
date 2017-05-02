tree grammar PointcutWalker;

options
{
	language=CSharp3;
	output=AST;
	tokenVocab=Pointcut;
	ASTLabelType=CommonTree;
}

@header {
    using System;
}

@namespace {SheepAspect.Saql.Ast}

public
pointcut returns [IPointcutValueNode value]
	: (node { $value = $node.value; })? EOF;

node returns [IPointcutValueNode value]
	: compound
		{$value = $compound.value;}
	| negation
		{$value = $negation.value;}
	| criteria
		{$value = $criteria.value;}
	| literal
		{$value = $literal.value;}
	| array
		{$value = $array.value; }
	| pointcutRef
		{$value = $pointcutRef.value; };
	

compound returns [IPointcutValueNode value]
	: ^(And l=node r=node)
	  { $value = new AndCompoundNode(Aspect,
		$l.value, $r.value); }
	| ^(Or l=node r=node)
	  { $value = new OrCompoundNode(Aspect,
		$l.value, $r.value);};
		
negation returns [CriteriaNode value]
	: ^(NOT node)
	{
		$value = new CriteriaNode(Aspect, "Not", $node.value);
	};

criteria returns [CriteriaNode value]	
	:^(CRITERIA Identifier node?)
	{
		$value = new CriteriaNode(Aspect,
			$Identifier.Text, $node.value);
	};

literal returns [LiteralValueNode value]
	: Value
	{
		$value = new LiteralValueNode(Aspect, $Value.Text.Substring(1, $Value.Text.Length-2));
	};

array returns [ArrayValueNode value]
	@init {var list = new List<IPointcutValueNode>(); }
	: ^(ARRAY (p=node {list.Add(p.value); })*)
	{
		$value = new ArrayValueNode(Aspect, list.ToArray());
	};
	
pointcutRef returns [PointcutRefNode value]
	: ^(POINTCUTREF Identifier)
	{
		$value = new PointcutRefNode(Aspect, Pointcut, $Identifier.Text);
	};
	