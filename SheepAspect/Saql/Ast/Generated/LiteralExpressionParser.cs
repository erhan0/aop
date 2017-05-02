// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g 2011-05-08 17:18:36

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

namespace  SheepAop.Saql.Ast 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class LiteralExpressionParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ACCESSOR", "IDENTIFIER", "UScore", "WS", "'.'", "'('", "')'", "'..'", "'*'", "','"
	};
	public const int EOF=-1;
	public const int T__8=8;
	public const int T__9=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int ACCESSOR=4;
	public const int IDENTIFIER=5;
	public const int UScore=6;
	public const int WS=7;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public LiteralExpressionParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public LiteralExpressionParser(ITokenStream input, RecognizerSharedState state)
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

	public override string[] TokenNames { get { return LiteralExpressionParser.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class methodExp_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_methodExp();
	partial void Leave_methodExp();

	// $ANTLR start "methodExp"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:12:1: public methodExp : ( ACCESSOR )? type '.' method '(' args ')' ;
	[GrammarRule("methodExp")]
	public LiteralExpressionParser.methodExp_return methodExp()
	{
		Enter_methodExp();
		EnterRule("methodExp", 1);
		TraceIn("methodExp", 1);
		LiteralExpressionParser.methodExp_return retval = new LiteralExpressionParser.methodExp_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ACCESSOR1=null;
		IToken char_literal3=null;
		IToken char_literal5=null;
		IToken char_literal7=null;
		LiteralExpressionParser.type_return type2 = default(LiteralExpressionParser.type_return);
		LiteralExpressionParser.method_return method4 = default(LiteralExpressionParser.method_return);
		LiteralExpressionParser.args_return args6 = default(LiteralExpressionParser.args_return);

		object ACCESSOR1_tree=null;
		object char_literal3_tree=null;
		object char_literal5_tree=null;
		object char_literal7_tree=null;

		try { DebugEnterRule(GrammarFileName, "methodExp");
		DebugLocation(12, 52);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:11: ( ( ACCESSOR )? type '.' method '(' args ')' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:13: ( ACCESSOR )? type '.' method '(' args ')'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(13, 13);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:13: ( ACCESSOR )?
			int alt1=2;
			try { DebugEnterSubRule(1);
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if ((LA1_0==ACCESSOR))
			{
				int LA1_1 = input.LA(2);

				if (((LA1_1>=ACCESSOR && LA1_1<=IDENTIFIER)||LA1_1==12))
				{
					alt1=1;
				}
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:14: ACCESSOR
				{
				DebugLocation(13, 14);
				ACCESSOR1=(IToken)Match(input,ACCESSOR,Follow._ACCESSOR_in_methodExp55); 
				ACCESSOR1_tree = (object)adaptor.Create(ACCESSOR1);
				adaptor.AddChild(root_0, ACCESSOR1_tree);


				}
				break;

			}
			} finally { DebugExitSubRule(1); }

			DebugLocation(13, 25);
			PushFollow(Follow._type_in_methodExp59);
			type2=type();
			PopFollow();

			adaptor.AddChild(root_0, type2.Tree);
			DebugLocation(13, 30);
			char_literal3=(IToken)Match(input,8,Follow._8_in_methodExp61); 
			char_literal3_tree = (object)adaptor.Create(char_literal3);
			adaptor.AddChild(root_0, char_literal3_tree);

			DebugLocation(13, 34);
			PushFollow(Follow._method_in_methodExp63);
			method4=method();
			PopFollow();

			adaptor.AddChild(root_0, method4.Tree);
			DebugLocation(13, 41);
			char_literal5=(IToken)Match(input,9,Follow._9_in_methodExp65); 
			char_literal5_tree = (object)adaptor.Create(char_literal5);
			adaptor.AddChild(root_0, char_literal5_tree);

			DebugLocation(13, 45);
			PushFollow(Follow._args_in_methodExp67);
			args6=args();
			PopFollow();

			adaptor.AddChild(root_0, args6.Tree);
			DebugLocation(13, 50);
			char_literal7=(IToken)Match(input,10,Follow._10_in_methodExp69); 
			char_literal7_tree = (object)adaptor.Create(char_literal7);
			adaptor.AddChild(root_0, char_literal7_tree);


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
			TraceOut("methodExp", 1);
			LeaveRule("methodExp", 1);
			Leave_methodExp();
		}
		DebugLocation(13, 52);
		} finally { DebugExitRule(GrammarFileName, "methodExp"); }
		return retval;

	}
	// $ANTLR end "methodExp"

	public class type_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type();
	partial void Leave_type();

	// $ANTLR start "type"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:15:1: public type : typeNamespace ( keyword | IDENTIFIER ) ;
	[GrammarRule("type")]
	public LiteralExpressionParser.type_return type()
	{
		Enter_type();
		EnterRule("type", 2);
		TraceIn("type", 2);
		LiteralExpressionParser.type_return retval = new LiteralExpressionParser.type_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER10=null;
		LiteralExpressionParser.typeNamespace_return typeNamespace8 = default(LiteralExpressionParser.typeNamespace_return);
		LiteralExpressionParser.keyword_return keyword9 = default(LiteralExpressionParser.keyword_return);

		object IDENTIFIER10_tree=null;

		try { DebugEnterRule(GrammarFileName, "type");
		DebugLocation(15, 43);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:16:6: ( typeNamespace ( keyword | IDENTIFIER ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:16:8: typeNamespace ( keyword | IDENTIFIER )
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(16, 8);
			PushFollow(Follow._typeNamespace_in_type79);
			typeNamespace8=typeNamespace();
			PopFollow();

			adaptor.AddChild(root_0, typeNamespace8.Tree);
			DebugLocation(16, 22);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:16:22: ( keyword | IDENTIFIER )
			int alt2=2;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0==ACCESSOR))
			{
				alt2=1;
			}
			else if ((LA2_0==IDENTIFIER))
			{
				alt2=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:16:23: keyword
				{
				DebugLocation(16, 23);
				PushFollow(Follow._keyword_in_type82);
				keyword9=keyword();
				PopFollow();

				adaptor.AddChild(root_0, keyword9.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:16:33: IDENTIFIER
				{
				DebugLocation(16, 33);
				IDENTIFIER10=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_type86); 
				IDENTIFIER10_tree = (object)adaptor.Create(IDENTIFIER10);
				adaptor.AddChild(root_0, IDENTIFIER10_tree);


				}
				break;

			}
			} finally { DebugExitSubRule(2); }


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
			TraceOut("type", 2);
			LeaveRule("type", 2);
			Leave_type();
		}
		DebugLocation(16, 43);
		} finally { DebugExitRule(GrammarFileName, "type"); }
		return retval;

	}
	// $ANTLR end "type"

	public class typeNamespace_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_typeNamespace();
	partial void Leave_typeNamespace();

	// $ANTLR start "typeNamespace"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:18:1: public typeNamespace : ( namespaceFragment ( '.' | '..' ) )* ;
	[GrammarRule("typeNamespace")]
	public LiteralExpressionParser.typeNamespace_return typeNamespace()
	{
		Enter_typeNamespace();
		EnterRule("typeNamespace", 3);
		TraceIn("typeNamespace", 3);
		LiteralExpressionParser.typeNamespace_return retval = new LiteralExpressionParser.typeNamespace_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set12=null;
		LiteralExpressionParser.namespaceFragment_return namespaceFragment11 = default(LiteralExpressionParser.namespaceFragment_return);

		object set12_tree=null;

		try { DebugEnterRule(GrammarFileName, "typeNamespace");
		DebugLocation(18, 38);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:20:2: ( ( namespaceFragment ( '.' | '..' ) )* )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:20:4: ( namespaceFragment ( '.' | '..' ) )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(20, 4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:20:4: ( namespaceFragment ( '.' | '..' ) )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==IDENTIFIER))
				{
					int LA3_2 = input.LA(2);

					if ((LA3_2==8))
					{
						switch (input.LA(3))
						{
						case ACCESSOR:
							{
							int LA3_5 = input.LA(4);

							if ((LA3_5==8||LA3_5==10||LA3_5==13))
							{
								alt3=1;
							}


							}
							break;
						case IDENTIFIER:
							{
							int LA3_6 = input.LA(4);

							if ((LA3_6==8||(LA3_6>=10 && LA3_6<=11)||LA3_6==13))
							{
								alt3=1;
							}


							}
							break;
						case 12:
							{
							alt3=1;
							}
							break;

						}

					}
					else if ((LA3_2==11))
					{
						alt3=1;
					}


				}
				else if ((LA3_0==12))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:20:5: namespaceFragment ( '.' | '..' )
					{
					DebugLocation(20, 5);
					PushFollow(Follow._namespaceFragment_in_typeNamespace99);
					namespaceFragment11=namespaceFragment();
					PopFollow();

					adaptor.AddChild(root_0, namespaceFragment11.Tree);
					DebugLocation(20, 23);
					set12=(IToken)input.LT(1);
					set12=(IToken)input.LT(1);
					if (input.LA(1)==8||input.LA(1)==11)
					{
						input.Consume();
						root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set12), root_0);
						state.errorRecovery=false;
					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}


					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }


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
			TraceOut("typeNamespace", 3);
			LeaveRule("typeNamespace", 3);
			Leave_typeNamespace();
		}
		DebugLocation(20, 38);
		} finally { DebugExitRule(GrammarFileName, "typeNamespace"); }
		return retval;

	}
	// $ANTLR end "typeNamespace"

	public class namespaceFragment_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_namespaceFragment();
	partial void Leave_namespaceFragment();

	// $ANTLR start "namespaceFragment"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:22:1: namespaceFragment : ( '*' | IDENTIFIER );
	[GrammarRule("namespaceFragment")]
	private LiteralExpressionParser.namespaceFragment_return namespaceFragment()
	{
		Enter_namespaceFragment();
		EnterRule("namespaceFragment", 4);
		TraceIn("namespaceFragment", 4);
		LiteralExpressionParser.namespaceFragment_return retval = new LiteralExpressionParser.namespaceFragment_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set13=null;

		object set13_tree=null;

		try { DebugEnterRule(GrammarFileName, "namespaceFragment");
		DebugLocation(22, 19);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:23:2: ( '*' | IDENTIFIER )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(23, 2);
			set13=(IToken)input.LT(1);
			if (input.LA(1)==IDENTIFIER||input.LA(1)==12)
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set13));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


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
			TraceOut("namespaceFragment", 4);
			LeaveRule("namespaceFragment", 4);
			Leave_namespaceFragment();
		}
		DebugLocation(23, 19);
		} finally { DebugExitRule(GrammarFileName, "namespaceFragment"); }
		return retval;

	}
	// $ANTLR end "namespaceFragment"

	public class method_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_method();
	partial void Leave_method();

	// $ANTLR start "method"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:25:1: method : ( keyword | IDENTIFIER );
	[GrammarRule("method")]
	private LiteralExpressionParser.method_return method()
	{
		Enter_method();
		EnterRule("method", 5);
		TraceIn("method", 5);
		LiteralExpressionParser.method_return retval = new LiteralExpressionParser.method_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER15=null;
		LiteralExpressionParser.keyword_return keyword14 = default(LiteralExpressionParser.keyword_return);

		object IDENTIFIER15_tree=null;

		try { DebugEnterRule(GrammarFileName, "method");
		DebugLocation(25, 29);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:25:8: ( keyword | IDENTIFIER )
			int alt4=2;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if ((LA4_0==ACCESSOR))
			{
				alt4=1;
			}
			else if ((LA4_0==IDENTIFIER))
			{
				alt4=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 4, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:25:10: keyword
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(25, 10);
				PushFollow(Follow._keyword_in_method133);
				keyword14=keyword();
				PopFollow();

				adaptor.AddChild(root_0, keyword14.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:25:20: IDENTIFIER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(25, 20);
				IDENTIFIER15=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_method137); 
				IDENTIFIER15_tree = (object)adaptor.Create(IDENTIFIER15);
				adaptor.AddChild(root_0, IDENTIFIER15_tree);


				}
				break;

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
			TraceOut("method", 5);
			LeaveRule("method", 5);
			Leave_method();
		}
		DebugLocation(25, 29);
		} finally { DebugExitRule(GrammarFileName, "method"); }
		return retval;

	}
	// $ANTLR end "method"

	public class args_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_args();
	partial void Leave_args();

	// $ANTLR start "args"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:1: args : ( type ( ',' type )* )? ;
	[GrammarRule("args")]
	private LiteralExpressionParser.args_return args()
	{
		Enter_args();
		EnterRule("args", 6);
		TraceIn("args", 6);
		LiteralExpressionParser.args_return retval = new LiteralExpressionParser.args_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal17=null;
		LiteralExpressionParser.type_return type16 = default(LiteralExpressionParser.type_return);
		LiteralExpressionParser.type_return type18 = default(LiteralExpressionParser.type_return);

		object char_literal17_tree=null;

		try { DebugEnterRule(GrammarFileName, "args");
		DebugLocation(27, 26);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:6: ( ( type ( ',' type )* )? )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:8: ( type ( ',' type )* )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(27, 8);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:8: ( type ( ',' type )* )?
			int alt6=2;
			try { DebugEnterSubRule(6);
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			int LA6_0 = input.LA(1);

			if (((LA6_0>=ACCESSOR && LA6_0<=IDENTIFIER)||LA6_0==12))
			{
				alt6=1;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:9: type ( ',' type )*
				{
				DebugLocation(27, 9);
				PushFollow(Follow._type_in_args146);
				type16=type();
				PopFollow();

				adaptor.AddChild(root_0, type16.Tree);
				DebugLocation(27, 14);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:14: ( ',' type )*
				try { DebugEnterSubRule(5);
				while (true)
				{
					int alt5=2;
					try { DebugEnterDecision(5, decisionCanBacktrack[5]);
					int LA5_0 = input.LA(1);

					if ((LA5_0==13))
					{
						alt5=1;
					}


					} finally { DebugExitDecision(5); }
					switch ( alt5 )
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:27:15: ',' type
						{
						DebugLocation(27, 15);
						char_literal17=(IToken)Match(input,13,Follow._13_in_args149); 
						char_literal17_tree = (object)adaptor.Create(char_literal17);
						adaptor.AddChild(root_0, char_literal17_tree);

						DebugLocation(27, 19);
						PushFollow(Follow._type_in_args151);
						type18=type();
						PopFollow();

						adaptor.AddChild(root_0, type18.Tree);

						}
						break;

					default:
						goto loop5;
					}
				}

				loop5:
					;

				} finally { DebugExitSubRule(5); }


				}
				break;

			}
			} finally { DebugExitSubRule(6); }


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
			TraceOut("args", 6);
			LeaveRule("args", 6);
			Leave_args();
		}
		DebugLocation(27, 26);
		} finally { DebugExitRule(GrammarFileName, "args"); }
		return retval;

	}
	// $ANTLR end "args"

	public class keyword_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_keyword();
	partial void Leave_keyword();

	// $ANTLR start "keyword"
	// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:29:1: keyword : ACCESSOR ;
	[GrammarRule("keyword")]
	private LiteralExpressionParser.keyword_return keyword()
	{
		Enter_keyword();
		EnterRule("keyword", 7);
		TraceIn("keyword", 7);
		LiteralExpressionParser.keyword_return retval = new LiteralExpressionParser.keyword_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ACCESSOR19=null;

		object ACCESSOR19_tree=null;

		try { DebugEnterRule(GrammarFileName, "keyword");
		DebugLocation(29, 19);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:29:9: ( ACCESSOR )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:29:12: ACCESSOR
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(29, 12);
			ACCESSOR19=(IToken)Match(input,ACCESSOR,Follow._ACCESSOR_in_keyword164); 
			ACCESSOR19_tree = (object)adaptor.Create(ACCESSOR19);
			adaptor.AddChild(root_0, ACCESSOR19_tree);


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
			TraceOut("keyword", 7);
			LeaveRule("keyword", 7);
			Leave_keyword();
		}
		DebugLocation(29, 19);
		} finally { DebugExitRule(GrammarFileName, "keyword"); }
		return retval;

	}
	// $ANTLR end "keyword"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _ACCESSOR_in_methodExp55 = new BitSet(new ulong[]{0x1030UL});
		public static readonly BitSet _type_in_methodExp59 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _8_in_methodExp61 = new BitSet(new ulong[]{0x30UL});
		public static readonly BitSet _method_in_methodExp63 = new BitSet(new ulong[]{0x200UL});
		public static readonly BitSet _9_in_methodExp65 = new BitSet(new ulong[]{0x1430UL});
		public static readonly BitSet _args_in_methodExp67 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _10_in_methodExp69 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _typeNamespace_in_type79 = new BitSet(new ulong[]{0x30UL});
		public static readonly BitSet _keyword_in_type82 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_type86 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _namespaceFragment_in_typeNamespace99 = new BitSet(new ulong[]{0x900UL});
		public static readonly BitSet _set_in_typeNamespace101 = new BitSet(new ulong[]{0x1022UL});
		public static readonly BitSet _set_in_namespaceFragment0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _keyword_in_method133 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_method137 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _type_in_args146 = new BitSet(new ulong[]{0x2002UL});
		public static readonly BitSet _13_in_args149 = new BitSet(new ulong[]{0x1030UL});
		public static readonly BitSet _type_in_args151 = new BitSet(new ulong[]{0x2002UL});
		public static readonly BitSet _ACCESSOR_in_keyword164 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  SheepAop.Saql.Ast 
