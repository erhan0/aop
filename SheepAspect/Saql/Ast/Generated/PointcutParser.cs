// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g 2011-08-16 15:05:00

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

namespace  SheepAspect.Saql.Ast 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class PointcutParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "CRITERIA", "ARRAY", "POINTCUTREF", "And", "Or", "NOT", "Identifier", "Value", "UScore", "Ws", "','", "':'", "'@'", "'('", "')'"
	};
	public const int EOF=-1;
	public const int T__14=14;
	public const int T__15=15;
	public const int T__16=16;
	public const int T__17=17;
	public const int T__18=18;
	public const int CRITERIA=4;
	public const int ARRAY=5;
	public const int POINTCUTREF=6;
	public const int And=7;
	public const int Or=8;
	public const int NOT=9;
	public const int Identifier=10;
	public const int Value=11;
	public const int UScore=12;
	public const int Ws=13;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public PointcutParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public PointcutParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = default(ITreeAdaptor);
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

	public override string[] TokenNames { get { return PointcutParser.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class pointcut_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_pointcut();
	partial void Leave_pointcut();

	// $ANTLR start "pointcut"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:18:1: public pointcut : ( compound )? EOF ;
	[GrammarRule("pointcut")]
	public PointcutParser.pointcut_return pointcut()
	{
		Enter_pointcut();
		EnterRule("pointcut", 1);
		TraceIn("pointcut", 1);
		PointcutParser.pointcut_return retval = new PointcutParser.pointcut_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken EOF2=null;
		PointcutParser.compound_return compound1 = default(PointcutParser.compound_return);

		object EOF2_tree = default(object);

		try { DebugEnterRule(GrammarFileName, "pointcut");
		DebugLocation(18, 23);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:19:9: ( ( compound )? EOF )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:19:11: ( compound )? EOF
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(19, 11);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:19:11: ( compound )?
			int alt1=2;
			try { DebugEnterSubRule(1);
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if (((LA1_0>=NOT && LA1_0<=Value)||(LA1_0>=16 && LA1_0<=17)))
			{
				alt1=1;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:19:11: compound
				{
				DebugLocation(19, 11);
				PushFollow(Follow._compound_in_pointcut70);
				compound1=compound();
				PopFollow();

				adaptor.AddChild(root_0, compound1.Tree);

				}
				break;

			}
			} finally { DebugExitSubRule(1); }

			DebugLocation(19, 21);
			EOF2=(IToken)Match(input,EOF,Follow._EOF_in_pointcut73); 
			EOF2_tree = (object)adaptor.Create(EOF2);
			adaptor.AddChild(root_0, EOF2_tree);


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
			TraceOut("pointcut", 1);
			LeaveRule("pointcut", 1);
			Leave_pointcut();
		}
		DebugLocation(19, 23);
		} finally { DebugExitRule(GrammarFileName, "pointcut"); }
		return retval;

	}
	// $ANTLR end "pointcut"

	public class compound_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_compound();
	partial void Leave_compound();

	// $ANTLR start "compound"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:21:1: compound : array ( ( And | Or ) array )* ;
	[GrammarRule("compound")]
	private PointcutParser.compound_return compound()
	{
		Enter_compound();
		EnterRule("compound", 2);
		TraceIn("compound", 2);
		PointcutParser.compound_return retval = new PointcutParser.compound_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken set4=null;
		PointcutParser.array_return array3 = default(PointcutParser.array_return);
		PointcutParser.array_return array5 = default(PointcutParser.array_return);

		object set4_tree = default(object);

		try { DebugEnterRule(GrammarFileName, "compound");
		DebugLocation(21, 34);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:21:9: ( array ( ( And | Or ) array )* )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:21:11: array ( ( And | Or ) array )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(21, 11);
			PushFollow(Follow._array_in_compound80);
			array3=array();
			PopFollow();

			adaptor.AddChild(root_0, array3.Tree);
			DebugLocation(21, 17);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:21:17: ( ( And | Or ) array )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if (((LA2_0>=And && LA2_0<=Or)))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:21:18: ( And | Or ) array
					{
					DebugLocation(21, 18);
					set4=(IToken)input.LT(1);
					set4=(IToken)input.LT(1);
					if ((input.LA(1)>=And && input.LA(1)<=Or))
					{
						input.Consume();
						root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set4), root_0);
						state.errorRecovery=false;
					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(21, 28);
					PushFollow(Follow._array_in_compound90);
					array5=array();
					PopFollow();

					adaptor.AddChild(root_0, array5.Tree);

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

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
			TraceOut("compound", 2);
			LeaveRule("compound", 2);
			Leave_compound();
		}
		DebugLocation(21, 34);
		} finally { DebugExitRule(GrammarFileName, "compound"); }
		return retval;

	}
	// $ANTLR end "compound"

	public class array_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_array();
	partial void Leave_array();

	// $ANTLR start "array"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:23:1: array : negation ( ( ',' negation )+ -> ^( ARRAY ( negation )* ) | -> negation ) ;
	[GrammarRule("array")]
	private PointcutParser.array_return array()
	{
		Enter_array();
		EnterRule("array", 3);
		TraceIn("array", 3);
		PointcutParser.array_return retval = new PointcutParser.array_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken char_literal7=null;
		PointcutParser.negation_return negation6 = default(PointcutParser.negation_return);
		PointcutParser.negation_return negation8 = default(PointcutParser.negation_return);

		object char_literal7_tree = default(object);
		RewriteRuleITokenStream stream_14=new RewriteRuleITokenStream(adaptor,"token 14");
		RewriteRuleSubtreeStream stream_negation=new RewriteRuleSubtreeStream(adaptor,"rule negation");
		try { DebugEnterRule(GrammarFileName, "array");
		DebugLocation(23, 3);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:23:7: ( negation ( ( ',' negation )+ -> ^( ARRAY ( negation )* ) | -> negation ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:23:9: negation ( ( ',' negation )+ -> ^( ARRAY ( negation )* ) | -> negation )
			{
			DebugLocation(23, 9);
			PushFollow(Follow._negation_in_array100);
			negation6=negation();
			PopFollow();

			stream_negation.Add(negation6.Tree);
			DebugLocation(23, 18);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:23:18: ( ( ',' negation )+ -> ^( ARRAY ( negation )* ) | -> negation )
			int alt4=2;
			try { DebugEnterSubRule(4);
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if ((LA4_0==14))
			{
				alt4=1;
			}
			else if ((LA4_0==EOF||(LA4_0>=And && LA4_0<=Or)||LA4_0==18))
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
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:24:4: ( ',' negation )+
				{
				DebugLocation(24, 4);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:24:4: ( ',' negation )+
				int cnt3=0;
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, decisionCanBacktrack[3]);
					int LA3_0 = input.LA(1);

					if ((LA3_0==14))
					{
						alt3=1;
					}


					} finally { DebugExitDecision(3); }
					switch (alt3)
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:24:5: ',' negation
						{
						DebugLocation(24, 5);
						char_literal7=(IToken)Match(input,14,Follow._14_in_array108);  
						stream_14.Add(char_literal7);

						DebugLocation(24, 9);
						PushFollow(Follow._negation_in_array110);
						negation8=negation();
						PopFollow();

						stream_negation.Add(negation8.Tree);

						}
						break;

					default:
						if (cnt3 >= 1)
							goto loop3;

						EarlyExitException eee3 = new EarlyExitException( 3, input );
						DebugRecognitionException(eee3);
						throw eee3;
					}
					cnt3++;
				}
				loop3:
					;

				} finally { DebugExitSubRule(3); }



				{
				// AST REWRITE
				// elements: negation
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 24:20: -> ^( ARRAY ( negation )* )
				{
					DebugLocation(24, 23);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:24:23: ^( ARRAY ( negation )* )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(24, 25);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ARRAY, "ARRAY"), root_1);

					DebugLocation(24, 31);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:24:31: ( negation )*
					while ( stream_negation.HasNext )
					{
						DebugLocation(24, 31);
						adaptor.AddChild(root_1, stream_negation.NextTree());

					}
					stream_negation.Reset();

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:25:7: 
				{

				{
				// AST REWRITE
				// elements: negation
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 25:7: -> negation
				{
					DebugLocation(25, 10);
					adaptor.AddChild(root_0, stream_negation.NextTree());

				}

				retval.Tree = root_0;
				}

				}
				break;

			}
			} finally { DebugExitSubRule(4); }


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
			TraceOut("array", 3);
			LeaveRule("array", 3);
			Leave_array();
		}
		DebugLocation(26, 3);
		} finally { DebugExitRule(GrammarFileName, "array"); }
		return retval;

	}
	// $ANTLR end "array"

	public class negation_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_negation();
	partial void Leave_negation();

	// $ANTLR start "negation"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:28:1: negation : ( NOT )? criteria ;
	[GrammarRule("negation")]
	private PointcutParser.negation_return negation()
	{
		Enter_negation();
		EnterRule("negation", 4);
		TraceIn("negation", 4);
		PointcutParser.negation_return retval = new PointcutParser.negation_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken NOT9=null;
		PointcutParser.criteria_return criteria10 = default(PointcutParser.criteria_return);

		object NOT9_tree = default(object);

		try { DebugEnterRule(GrammarFileName, "negation");
		DebugLocation(28, 27);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:28:10: ( ( NOT )? criteria )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:28:12: ( NOT )? criteria
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(28, 12);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:28:12: ( NOT )?
			int alt5=2;
			try { DebugEnterSubRule(5);
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			int LA5_0 = input.LA(1);

			if ((LA5_0==NOT))
			{
				alt5=1;
			}
			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:28:13: NOT
				{
				DebugLocation(28, 16);
				NOT9=(IToken)Match(input,NOT,Follow._NOT_in_negation144); 
				NOT9_tree = (object)adaptor.Create(NOT9);
				root_0 = (object)adaptor.BecomeRoot(NOT9_tree, root_0);


				}
				break;

			}
			} finally { DebugExitSubRule(5); }

			DebugLocation(28, 20);
			PushFollow(Follow._criteria_in_negation149);
			criteria10=criteria();
			PopFollow();

			adaptor.AddChild(root_0, criteria10.Tree);

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
			TraceOut("negation", 4);
			LeaveRule("negation", 4);
			Leave_negation();
		}
		DebugLocation(28, 27);
		} finally { DebugExitRule(GrammarFileName, "negation"); }
		return retval;

	}
	// $ANTLR end "negation"

	public class criteria_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_criteria();
	partial void Leave_criteria();

	// $ANTLR start "criteria"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:30:1: criteria : ( atom | ( Identifier ( ':' array )? ) -> ^( CRITERIA Identifier ( array )? ) );
	[GrammarRule("criteria")]
	private PointcutParser.criteria_return criteria()
	{
		Enter_criteria();
		EnterRule("criteria", 5);
		TraceIn("criteria", 5);
		PointcutParser.criteria_return retval = new PointcutParser.criteria_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken Identifier12=null;
		IToken char_literal13=null;
		PointcutParser.atom_return atom11 = default(PointcutParser.atom_return);
		PointcutParser.array_return array14 = default(PointcutParser.array_return);

		object Identifier12_tree = default(object);
		object char_literal13_tree = default(object);
		RewriteRuleITokenStream stream_15=new RewriteRuleITokenStream(adaptor,"token 15");
		RewriteRuleITokenStream stream_Identifier=new RewriteRuleITokenStream(adaptor,"token Identifier");
		RewriteRuleSubtreeStream stream_array=new RewriteRuleSubtreeStream(adaptor,"rule array");
		try { DebugEnterRule(GrammarFileName, "criteria");
		DebugLocation(30, 60);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:30:10: ( atom | ( Identifier ( ':' array )? ) -> ^( CRITERIA Identifier ( array )? ) )
			int alt7=2;
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			int LA7_0 = input.LA(1);

			if ((LA7_0==Value||(LA7_0>=16 && LA7_0<=17)))
			{
				alt7=1;
			}
			else if ((LA7_0==Identifier))
			{
				alt7=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 7, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:30:12: atom
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(30, 12);
				PushFollow(Follow._atom_in_criteria157);
				atom11=atom();
				PopFollow();

				adaptor.AddChild(root_0, atom11.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:4: ( Identifier ( ':' array )? )
				{
				DebugLocation(31, 4);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:4: ( Identifier ( ':' array )? )
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:5: Identifier ( ':' array )?
				{
				DebugLocation(31, 5);
				Identifier12=(IToken)Match(input,Identifier,Follow._Identifier_in_criteria163);  
				stream_Identifier.Add(Identifier12);

				DebugLocation(31, 16);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:16: ( ':' array )?
				int alt6=2;
				try { DebugEnterSubRule(6);
				try { DebugEnterDecision(6, decisionCanBacktrack[6]);
				int LA6_0 = input.LA(1);

				if ((LA6_0==15))
				{
					alt6=1;
				}
				} finally { DebugExitDecision(6); }
				switch (alt6)
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:17: ':' array
					{
					DebugLocation(31, 17);
					char_literal13=(IToken)Match(input,15,Follow._15_in_criteria166);  
					stream_15.Add(char_literal13);

					DebugLocation(31, 21);
					PushFollow(Follow._array_in_criteria168);
					array14=array();
					PopFollow();

					stream_array.Add(array14.Tree);

					}
					break;

				}
				} finally { DebugExitSubRule(6); }


				}



				{
				// AST REWRITE
				// elements: array, Identifier
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 31:29: -> ^( CRITERIA Identifier ( array )? )
				{
					DebugLocation(31, 32);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:32: ^( CRITERIA Identifier ( array )? )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(31, 34);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(CRITERIA, "CRITERIA"), root_1);

					DebugLocation(31, 43);
					adaptor.AddChild(root_1, stream_Identifier.NextNode());
					DebugLocation(31, 54);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:31:54: ( array )?
					if (stream_array.HasNext)
					{
						DebugLocation(31, 54);
						adaptor.AddChild(root_1, stream_array.NextTree());

					}
					stream_array.Reset();

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

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
			TraceOut("criteria", 5);
			LeaveRule("criteria", 5);
			Leave_criteria();
		}
		DebugLocation(31, 60);
		} finally { DebugExitRule(GrammarFileName, "criteria"); }
		return retval;

	}
	// $ANTLR end "criteria"

	public class atom_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_atom();
	partial void Leave_atom();

	// $ANTLR start "atom"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:33:1: atom : ( '@' Identifier -> ^( POINTCUTREF Identifier ) | Value | '(' compound ')' );
	[GrammarRule("atom")]
	private PointcutParser.atom_return atom()
	{
		Enter_atom();
		EnterRule("atom", 6);
		TraceIn("atom", 6);
		PointcutParser.atom_return retval = new PointcutParser.atom_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = default(object);

		IToken char_literal15=null;
		IToken Identifier16=null;
		IToken Value17=null;
		IToken char_literal18=null;
		IToken char_literal20=null;
		PointcutParser.compound_return compound19 = default(PointcutParser.compound_return);

		object char_literal15_tree = default(object);
		object Identifier16_tree = default(object);
		object Value17_tree = default(object);
		object char_literal18_tree = default(object);
		object char_literal20_tree = default(object);
		RewriteRuleITokenStream stream_16=new RewriteRuleITokenStream(adaptor,"token 16");
		RewriteRuleITokenStream stream_Identifier=new RewriteRuleITokenStream(adaptor,"token Identifier");

		try { DebugEnterRule(GrammarFileName, "atom");
		DebugLocation(33, 22);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:33:6: ( '@' Identifier -> ^( POINTCUTREF Identifier ) | Value | '(' compound ')' )
			int alt8=3;
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			switch (input.LA(1))
			{
			case 16:
				{
				alt8=1;
				}
				break;
			case Value:
				{
				alt8=2;
				}
				break;
			case 17:
				{
				alt8=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 8, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:33:8: '@' Identifier
				{
				DebugLocation(33, 8);
				char_literal15=(IToken)Match(input,16,Follow._16_in_atom190);  
				stream_16.Add(char_literal15);

				DebugLocation(33, 12);
				Identifier16=(IToken)Match(input,Identifier,Follow._Identifier_in_atom192);  
				stream_Identifier.Add(Identifier16);



				{
				// AST REWRITE
				// elements: Identifier
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 33:23: -> ^( POINTCUTREF Identifier )
				{
					DebugLocation(33, 26);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:33:26: ^( POINTCUTREF Identifier )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(33, 28);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(POINTCUTREF, "POINTCUTREF"), root_1);

					DebugLocation(33, 40);
					adaptor.AddChild(root_1, stream_Identifier.NextNode());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:34:5: Value
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(34, 5);
				Value17=(IToken)Match(input,Value,Follow._Value_in_atom206); 
				Value17_tree = (object)adaptor.Create(Value17);
				adaptor.AddChild(root_0, Value17_tree);


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:35:5: '(' compound ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(35, 8);
				char_literal18=(IToken)Match(input,17,Follow._17_in_atom213); 
				DebugLocation(35, 10);
				PushFollow(Follow._compound_in_atom216);
				compound19=compound();
				PopFollow();

				adaptor.AddChild(root_0, compound19.Tree);
				DebugLocation(35, 22);
				char_literal20=(IToken)Match(input,18,Follow._18_in_atom218); 

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
			TraceOut("atom", 6);
			LeaveRule("atom", 6);
			Leave_atom();
		}
		DebugLocation(35, 22);
		} finally { DebugExitRule(GrammarFileName, "atom"); }
		return retval;

	}
	// $ANTLR end "atom"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _compound_in_pointcut70 = new BitSet(new ulong[]{0x0UL});
		public static readonly BitSet _EOF_in_pointcut73 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _array_in_compound80 = new BitSet(new ulong[]{0x182UL});
		public static readonly BitSet _set_in_compound83 = new BitSet(new ulong[]{0x30E00UL});
		public static readonly BitSet _array_in_compound90 = new BitSet(new ulong[]{0x182UL});
		public static readonly BitSet _negation_in_array100 = new BitSet(new ulong[]{0x4002UL});
		public static readonly BitSet _14_in_array108 = new BitSet(new ulong[]{0x30E00UL});
		public static readonly BitSet _negation_in_array110 = new BitSet(new ulong[]{0x4002UL});
		public static readonly BitSet _NOT_in_negation144 = new BitSet(new ulong[]{0x30E00UL});
		public static readonly BitSet _criteria_in_negation149 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _atom_in_criteria157 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Identifier_in_criteria163 = new BitSet(new ulong[]{0x8002UL});
		public static readonly BitSet _15_in_criteria166 = new BitSet(new ulong[]{0x30E00UL});
		public static readonly BitSet _array_in_criteria168 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _16_in_atom190 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _Identifier_in_atom192 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _Value_in_atom206 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _17_in_atom213 = new BitSet(new ulong[]{0x30E00UL});
		public static readonly BitSet _compound_in_atom216 = new BitSet(new ulong[]{0x40000UL});
		public static readonly BitSet _18_in_atom218 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  SheepAspect.Saql.Ast 
