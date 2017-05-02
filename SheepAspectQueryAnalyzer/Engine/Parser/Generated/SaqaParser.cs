// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g 2011-06-13 03:10:05

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

namespace  SheepAspectQueryAnalyzer.Engine.Parser 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class SaqaParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ID", "STRING", "COMMENT", "WS", "'='", "'['", "'('", "')'", "']'"
	};
	public const int EOF=-1;
	public const int T__8=8;
	public const int T__9=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int ID=4;
	public const int STRING=5;
	public const int COMMENT=6;
	public const int WS=7;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public SaqaParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public SaqaParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return SaqaParser.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class pointcuts_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public IEnumerable<PointcutExpression> values;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_pointcuts();
	partial void Leave_pointcuts();

	// $ANTLR start "pointcuts"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:12:8: public pointcuts returns [IEnumerable<PointcutExpression> values] : (p= pointcut )* ;
	[GrammarRule("pointcuts")]
	public SaqaParser.pointcuts_return pointcuts()
	{
		Enter_pointcuts();
		EnterRule("pointcuts", 1);
		TraceIn("pointcuts", 1);
		SaqaParser.pointcuts_return retval = new SaqaParser.pointcuts_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		SaqaParser.pointcut_return p = default(SaqaParser.pointcut_return);


		var list = new List<PointcutExpression>(); 
		try { DebugEnterRule(GrammarFileName, "pointcuts");
		DebugLocation(12, 2);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:2: ( (p= pointcut )* )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:4: (p= pointcut )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(14, 4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:4: (p= pointcut )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0==ID||LA1_0==9))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:5: p= pointcut
					{
					DebugLocation(14, 6);
					PushFollow(Follow._pointcut_in_pointcuts68);
					p=pointcut();
					PopFollow();

					adaptor.AddChild(root_0, p.Tree);
					DebugLocation(14, 16);
					list.Add((p!=null?p.value:default(PointcutExpression)));

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(15, 2);

					retval.values = list;
				

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("pointcuts", 1);
			LeaveRule("pointcuts", 1);
			Leave_pointcuts();
		}
		DebugLocation(17, 2);
		} finally { DebugExitRule(GrammarFileName, "pointcuts"); }
		return retval;

	}
	// $ANTLR end "pointcuts"

	public class pointcut_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public PointcutExpression value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_pointcut();
	partial void Leave_pointcut();

	// $ANTLR start "pointcut"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:19:1: pointcut returns [PointcutExpression value] : ( alias '=' )? '[' attribute '(' saql ')' ']' ;
	[GrammarRule("pointcut")]
	private SaqaParser.pointcut_return pointcut()
	{
		Enter_pointcut();
		EnterRule("pointcut", 2);
		TraceIn("pointcut", 2);
		SaqaParser.pointcut_return retval = new SaqaParser.pointcut_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal2=null;
		IToken char_literal3=null;
		IToken char_literal5=null;
		IToken char_literal7=null;
		IToken char_literal8=null;
		SaqaParser.alias_return alias1 = default(SaqaParser.alias_return);
		SaqaParser.attribute_return attribute4 = default(SaqaParser.attribute_return);
		SaqaParser.saql_return saql6 = default(SaqaParser.saql_return);

		object char_literal2_tree=null;
		object char_literal3_tree=null;
		object char_literal5_tree=null;
		object char_literal7_tree=null;
		object char_literal8_tree=null;

		try { DebugEnterRule(GrammarFileName, "pointcut");
		DebugLocation(19, 2);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:20:2: ( ( alias '=' )? '[' attribute '(' saql ')' ']' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:20:4: ( alias '=' )? '[' attribute '(' saql ')' ']'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(20, 4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:20:4: ( alias '=' )?
			int alt2=2;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0==ID))
			{
				alt2=1;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:20:5: alias '='
				{
				DebugLocation(20, 5);
				PushFollow(Follow._alias_in_pointcut89);
				alias1=alias();
				PopFollow();

				adaptor.AddChild(root_0, alias1.Tree);
				DebugLocation(20, 11);
				char_literal2=(IToken)Match(input,8,Follow._8_in_pointcut91); 
				char_literal2_tree = (object)adaptor.Create(char_literal2);
				adaptor.AddChild(root_0, char_literal2_tree);


				}
				break;

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(20, 17);
			char_literal3=(IToken)Match(input,9,Follow._9_in_pointcut95); 
			char_literal3_tree = (object)adaptor.Create(char_literal3);
			adaptor.AddChild(root_0, char_literal3_tree);

			DebugLocation(20, 21);
			PushFollow(Follow._attribute_in_pointcut97);
			attribute4=attribute();
			PopFollow();

			adaptor.AddChild(root_0, attribute4.Tree);
			DebugLocation(20, 31);
			char_literal5=(IToken)Match(input,10,Follow._10_in_pointcut99); 
			char_literal5_tree = (object)adaptor.Create(char_literal5);
			adaptor.AddChild(root_0, char_literal5_tree);

			DebugLocation(20, 35);
			PushFollow(Follow._saql_in_pointcut101);
			saql6=saql();
			PopFollow();

			adaptor.AddChild(root_0, saql6.Tree);
			DebugLocation(20, 40);
			char_literal7=(IToken)Match(input,11,Follow._11_in_pointcut103); 
			char_literal7_tree = (object)adaptor.Create(char_literal7);
			adaptor.AddChild(root_0, char_literal7_tree);

			DebugLocation(20, 44);
			char_literal8=(IToken)Match(input,12,Follow._12_in_pointcut105); 
			char_literal8_tree = (object)adaptor.Create(char_literal8);
			adaptor.AddChild(root_0, char_literal8_tree);

			DebugLocation(21, 2);

					retval.value = new PointcutExpression((alias1!=null?alias1.value:default(string)), (attribute4!=null?attribute4.value:default(string)), (saql6!=null?saql6.value:default(string)));
				

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("pointcut", 2);
			LeaveRule("pointcut", 2);
			Leave_pointcut();
		}
		DebugLocation(23, 2);
		} finally { DebugExitRule(GrammarFileName, "pointcut"); }
		return retval;

	}
	// $ANTLR end "pointcut"

	public class alias_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public string value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_alias();
	partial void Leave_alias();

	// $ANTLR start "alias"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:25:1: alias returns [string value] : ID ;
	[GrammarRule("alias")]
	private SaqaParser.alias_return alias()
	{
		Enter_alias();
		EnterRule("alias", 3);
		TraceIn("alias", 3);
		SaqaParser.alias_return retval = new SaqaParser.alias_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ID9=null;

		object ID9_tree=null;

		try { DebugEnterRule(GrammarFileName, "alias");
		DebugLocation(25, 27);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:26:2: ( ID )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:26:4: ID
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(26, 4);
			ID9=(IToken)Match(input,ID,Follow._ID_in_alias122); 
			ID9_tree = (object)adaptor.Create(ID9);
			adaptor.AddChild(root_0, ID9_tree);

			DebugLocation(26, 7);
			retval.value = ID9.Text;

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("alias", 3);
			LeaveRule("alias", 3);
			Leave_alias();
		}
		DebugLocation(26, 27);
		} finally { DebugExitRule(GrammarFileName, "alias"); }
		return retval;

	}
	// $ANTLR end "alias"

	public class attribute_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public string value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_attribute();
	partial void Leave_attribute();

	// $ANTLR start "attribute"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:28:1: attribute returns [string value] : ID ;
	[GrammarRule("attribute")]
	private SaqaParser.attribute_return attribute()
	{
		Enter_attribute();
		EnterRule("attribute", 4);
		TraceIn("attribute", 4);
		SaqaParser.attribute_return retval = new SaqaParser.attribute_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ID10=null;

		object ID10_tree=null;

		try { DebugEnterRule(GrammarFileName, "attribute");
		DebugLocation(28, 26);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:29:2: ( ID )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:29:4: ID
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(29, 4);
			ID10=(IToken)Match(input,ID,Follow._ID_in_attribute138); 
			ID10_tree = (object)adaptor.Create(ID10);
			adaptor.AddChild(root_0, ID10_tree);

			DebugLocation(29, 7);
			retval.value = ID10.Text;

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("attribute", 4);
			LeaveRule("attribute", 4);
			Leave_attribute();
		}
		DebugLocation(29, 26);
		} finally { DebugExitRule(GrammarFileName, "attribute"); }
		return retval;

	}
	// $ANTLR end "attribute"

	public class saql_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public string value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_saql();
	partial void Leave_saql();

	// $ANTLR start "saql"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:31:1: saql returns [string value] : STRING ;
	[GrammarRule("saql")]
	private SaqaParser.saql_return saql()
	{
		Enter_saql();
		EnterRule("saql", 5);
		TraceIn("saql", 5);
		SaqaParser.saql_return retval = new SaqaParser.saql_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken STRING11=null;

		object STRING11_tree=null;

		try { DebugEnterRule(GrammarFileName, "saql");
		DebugLocation(31, 44);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:32:2: ( STRING )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:32:4: STRING
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(32, 4);
			STRING11=(IToken)Match(input,STRING,Follow._STRING_in_saql154); 
			STRING11_tree = (object)adaptor.Create(STRING11);
			adaptor.AddChild(root_0, STRING11_tree);

			DebugLocation(32, 11);
			retval.value = ProcessString(STRING11);

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("saql", 5);
			LeaveRule("saql", 5);
			Leave_saql();
		}
		DebugLocation(32, 44);
		} finally { DebugExitRule(GrammarFileName, "saql"); }
		return retval;

	}
	// $ANTLR end "saql"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _pointcut_in_pointcuts68 = new BitSet(new ulong[]{0x212UL});
		public static readonly BitSet _alias_in_pointcut89 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _8_in_pointcut91 = new BitSet(new ulong[]{0x200UL});
		public static readonly BitSet _9_in_pointcut95 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _attribute_in_pointcut97 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _10_in_pointcut99 = new BitSet(new ulong[]{0x20UL});
		public static readonly BitSet _saql_in_pointcut101 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _11_in_pointcut103 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _12_in_pointcut105 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_alias122 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_attribute138 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _STRING_in_saql154 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  SheepAspectQueryAnalyzer.Engine.Parser 
