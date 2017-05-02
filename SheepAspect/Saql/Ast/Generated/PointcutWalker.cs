// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g 2011-08-16 15:05:13

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


    using System;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


namespace SheepAspect.Saql.Ast
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class PointcutWalker : Antlr.Runtime.Tree.TreeParser
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
				false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public PointcutWalker( ITreeNodeStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public PointcutWalker(ITreeNodeStream input, RecognizerSharedState state)
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

	public override string[] TokenNames { get { return PointcutWalker.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class pointcut_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public IPointcutValueNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_pointcut();
	partial void Leave_pointcut();

	// $ANTLR start "pointcut"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:17:1: public pointcut returns [IPointcutValueNode value] : ( node )? EOF ;
	[GrammarRule("pointcut")]
	public PointcutWalker.pointcut_return pointcut()
	{
		Enter_pointcut();
		EnterRule("pointcut", 1);
		TraceIn("pointcut", 1);
		PointcutWalker.pointcut_return retval = new PointcutWalker.pointcut_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree EOF2=null;
		PointcutWalker.node_return node1 = default(PointcutWalker.node_return);

		CommonTree EOF2_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "pointcut");
		DebugLocation(17, 40);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:19:2: ( ( node )? EOF )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:19:4: ( node )? EOF
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(19, 4);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:19:4: ( node )?
			int alt1=2;
			try { DebugEnterSubRule(1);
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if (((LA1_0>=CRITERIA && LA1_0<=NOT)||LA1_0==Value))
			{
				alt1=1;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:19:5: node
				{
				DebugLocation(19, 5);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_pointcut61);
				node1=node();
				PopFollow();

				adaptor.AddChild(root_0, node1.Tree);
				DebugLocation(19, 10);
				 retval.value = (node1!=null?node1.value:default(IPointcutValueNode)); 

				}
				break;

			}
			} finally { DebugExitSubRule(1); }

			DebugLocation(19, 38);
			_last = (CommonTree)input.LT(1);
			EOF2=(CommonTree)Match(input,EOF,Follow._EOF_in_pointcut67); 
			EOF2_tree = (CommonTree)adaptor.DupNode(EOF2);

			adaptor.AddChild(root_0, EOF2_tree);


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("pointcut", 1);
			LeaveRule("pointcut", 1);
			Leave_pointcut();
		}
		DebugLocation(19, 40);
		} finally { DebugExitRule(GrammarFileName, "pointcut"); }
		return retval;

	}
	// $ANTLR end "pointcut"

	public class node_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public IPointcutValueNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_node();
	partial void Leave_node();

	// $ANTLR start "node"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:21:1: node returns [IPointcutValueNode value] : ( compound | negation | criteria | literal | array | pointcutRef );
	[GrammarRule("node")]
	private PointcutWalker.node_return node()
	{
		Enter_node();
		EnterRule("node", 2);
		TraceIn("node", 2);
		PointcutWalker.node_return retval = new PointcutWalker.node_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		PointcutWalker.compound_return compound3 = default(PointcutWalker.compound_return);
		PointcutWalker.negation_return negation4 = default(PointcutWalker.negation_return);
		PointcutWalker.criteria_return criteria5 = default(PointcutWalker.criteria_return);
		PointcutWalker.literal_return literal6 = default(PointcutWalker.literal_return);
		PointcutWalker.array_return array7 = default(PointcutWalker.array_return);
		PointcutWalker.pointcutRef_return pointcutRef8 = default(PointcutWalker.pointcutRef_return);


		try { DebugEnterRule(GrammarFileName, "node");
		DebugLocation(21, 33);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:22:2: ( compound | negation | criteria | literal | array | pointcutRef )
			int alt2=6;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			switch (input.LA(1))
			{
			case And:
			case Or:
				{
				alt2=1;
				}
				break;
			case NOT:
				{
				alt2=2;
				}
				break;
			case CRITERIA:
				{
				alt2=3;
				}
				break;
			case Value:
				{
				alt2=4;
				}
				break;
			case ARRAY:
				{
				alt2=5;
				}
				break;
			case POINTCUTREF:
				{
				alt2=6;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:22:4: compound
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(22, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._compound_in_node80);
				compound3=compound();
				PopFollow();

				adaptor.AddChild(root_0, compound3.Tree);
				DebugLocation(23, 3);
				retval.value = (compound3!=null?compound3.value:default(IPointcutValueNode));

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:24:4: negation
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(24, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._negation_in_node89);
				negation4=negation();
				PopFollow();

				adaptor.AddChild(root_0, negation4.Tree);
				DebugLocation(25, 3);
				retval.value = (negation4!=null?negation4.value:default(CriteriaNode));

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:26:4: criteria
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(26, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._criteria_in_node98);
				criteria5=criteria();
				PopFollow();

				adaptor.AddChild(root_0, criteria5.Tree);
				DebugLocation(27, 3);
				retval.value = (criteria5!=null?criteria5.value:default(CriteriaNode));

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:28:4: literal
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(28, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._literal_in_node107);
				literal6=literal();
				PopFollow();

				adaptor.AddChild(root_0, literal6.Tree);
				DebugLocation(29, 3);
				retval.value = (literal6!=null?literal6.value:default(LiteralValueNode));

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:30:4: array
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(30, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._array_in_node116);
				array7=array();
				PopFollow();

				adaptor.AddChild(root_0, array7.Tree);
				DebugLocation(31, 3);
				retval.value = (array7!=null?array7.value:default(ArrayValueNode)); 

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:32:4: pointcutRef
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(32, 4);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._pointcutRef_in_node125);
				pointcutRef8=pointcutRef();
				PopFollow();

				adaptor.AddChild(root_0, pointcutRef8.Tree);
				DebugLocation(33, 3);
				retval.value = (pointcutRef8!=null?pointcutRef8.value:default(PointcutRefNode)); 

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("node", 2);
			LeaveRule("node", 2);
			Leave_node();
		}
		DebugLocation(33, 33);
		} finally { DebugExitRule(GrammarFileName, "node"); }
		return retval;

	}
	// $ANTLR end "node"

	public class compound_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public IPointcutValueNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_compound();
	partial void Leave_compound();

	// $ANTLR start "compound"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:36:1: compound returns [IPointcutValueNode value] : ( ^( And l= node r= node ) | ^( Or l= node r= node ) );
	[GrammarRule("compound")]
	private PointcutWalker.compound_return compound()
	{
		Enter_compound();
		EnterRule("compound", 3);
		TraceIn("compound", 3);
		PointcutWalker.compound_return retval = new PointcutWalker.compound_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree And9=null;
		CommonTree Or10=null;
		PointcutWalker.node_return l = default(PointcutWalker.node_return);
		PointcutWalker.node_return r = default(PointcutWalker.node_return);

		CommonTree And9_tree = default(CommonTree);
		CommonTree Or10_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "compound");
		DebugLocation(36, 23);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:37:2: ( ^( And l= node r= node ) | ^( Or l= node r= node ) )
			int alt3=2;
			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
			int LA3_0 = input.LA(1);

			if ((LA3_0==And))
			{
				alt3=1;
			}
			else if ((LA3_0==Or))
			{
				alt3=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:37:4: ^( And l= node r= node )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(37, 4);
				_last = (CommonTree)input.LT(1);
				{
				CommonTree _save_last_1 = _last;
				CommonTree _first_1 = null;
				CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(37, 6);
				_last = (CommonTree)input.LT(1);
				And9=(CommonTree)Match(input,And,Follow._And_in_compound145); 
				And9_tree = (CommonTree)adaptor.DupNode(And9);

				root_1 = (CommonTree)adaptor.BecomeRoot(And9_tree, root_1);



				Match(input, TokenTypes.Down, null); 
				DebugLocation(37, 11);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_compound149);
				l=node();
				PopFollow();

				adaptor.AddChild(root_1, l.Tree);
				DebugLocation(37, 18);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_compound153);
				r=node();
				PopFollow();

				adaptor.AddChild(root_1, r.Tree);

				Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
				}

				DebugLocation(38, 4);
				 retval.value = new AndCompoundNode(Aspect,
						(l!=null?l.value:default(IPointcutValueNode)), (r!=null?r.value:default(IPointcutValueNode))); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:40:4: ^( Or l= node r= node )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(40, 4);
				_last = (CommonTree)input.LT(1);
				{
				CommonTree _save_last_1 = _last;
				CommonTree _first_1 = null;
				CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(40, 6);
				_last = (CommonTree)input.LT(1);
				Or10=(CommonTree)Match(input,Or,Follow._Or_in_compound165); 
				Or10_tree = (CommonTree)adaptor.DupNode(Or10);

				root_1 = (CommonTree)adaptor.BecomeRoot(Or10_tree, root_1);



				Match(input, TokenTypes.Down, null); 
				DebugLocation(40, 10);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_compound169);
				l=node();
				PopFollow();

				adaptor.AddChild(root_1, l.Tree);
				DebugLocation(40, 17);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_compound173);
				r=node();
				PopFollow();

				adaptor.AddChild(root_1, r.Tree);

				Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
				}

				DebugLocation(41, 4);
				 retval.value = new OrCompoundNode(Aspect,
						(l!=null?l.value:default(IPointcutValueNode)), (r!=null?r.value:default(IPointcutValueNode)));

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("compound", 3);
			LeaveRule("compound", 3);
			Leave_compound();
		}
		DebugLocation(42, 23);
		} finally { DebugExitRule(GrammarFileName, "compound"); }
		return retval;

	}
	// $ANTLR end "compound"

	public class negation_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public CriteriaNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_negation();
	partial void Leave_negation();

	// $ANTLR start "negation"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:44:1: negation returns [CriteriaNode value] : ^( NOT node ) ;
	[GrammarRule("negation")]
	private PointcutWalker.negation_return negation()
	{
		Enter_negation();
		EnterRule("negation", 4);
		TraceIn("negation", 4);
		PointcutWalker.negation_return retval = new PointcutWalker.negation_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree NOT11=null;
		PointcutWalker.node_return node12 = default(PointcutWalker.node_return);

		CommonTree NOT11_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "negation");
		DebugLocation(44, 2);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:45:2: ( ^( NOT node ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:45:4: ^( NOT node )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(45, 4);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(45, 6);
			_last = (CommonTree)input.LT(1);
			NOT11=(CommonTree)Match(input,NOT,Follow._NOT_in_negation195); 
			NOT11_tree = (CommonTree)adaptor.DupNode(NOT11);

			root_1 = (CommonTree)adaptor.BecomeRoot(NOT11_tree, root_1);



			Match(input, TokenTypes.Down, null); 
			DebugLocation(45, 10);
			_last = (CommonTree)input.LT(1);
			PushFollow(Follow._node_in_negation197);
			node12=node();
			PopFollow();

			adaptor.AddChild(root_1, node12.Tree);

			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}

			DebugLocation(46, 2);

					retval.value = new CriteriaNode(Aspect, "Not", (node12!=null?node12.value:default(IPointcutValueNode)));
				

			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("negation", 4);
			LeaveRule("negation", 4);
			Leave_negation();
		}
		DebugLocation(48, 2);
		} finally { DebugExitRule(GrammarFileName, "negation"); }
		return retval;

	}
	// $ANTLR end "negation"

	public class criteria_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public CriteriaNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_criteria();
	partial void Leave_criteria();

	// $ANTLR start "criteria"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:50:1: criteria returns [CriteriaNode value] : ^( CRITERIA Identifier ( node )? ) ;
	[GrammarRule("criteria")]
	private PointcutWalker.criteria_return criteria()
	{
		Enter_criteria();
		EnterRule("criteria", 5);
		TraceIn("criteria", 5);
		PointcutWalker.criteria_return retval = new PointcutWalker.criteria_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree CRITERIA13=null;
		CommonTree Identifier14=null;
		PointcutWalker.node_return node15 = default(PointcutWalker.node_return);

		CommonTree CRITERIA13_tree = default(CommonTree);
		CommonTree Identifier14_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "criteria");
		DebugLocation(50, 2);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:51:2: ( ^( CRITERIA Identifier ( node )? ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:51:3: ^( CRITERIA Identifier ( node )? )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(51, 3);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(51, 5);
			_last = (CommonTree)input.LT(1);
			CRITERIA13=(CommonTree)Match(input,CRITERIA,Follow._CRITERIA_in_criteria215); 
			CRITERIA13_tree = (CommonTree)adaptor.DupNode(CRITERIA13);

			root_1 = (CommonTree)adaptor.BecomeRoot(CRITERIA13_tree, root_1);



			Match(input, TokenTypes.Down, null); 
			DebugLocation(51, 14);
			_last = (CommonTree)input.LT(1);
			Identifier14=(CommonTree)Match(input,Identifier,Follow._Identifier_in_criteria217); 
			Identifier14_tree = (CommonTree)adaptor.DupNode(Identifier14);

			adaptor.AddChild(root_1, Identifier14_tree);

			DebugLocation(51, 25);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:51:25: ( node )?
			int alt4=2;
			try { DebugEnterSubRule(4);
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if (((LA4_0>=CRITERIA && LA4_0<=NOT)||LA4_0==Value))
			{
				alt4=1;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:51:25: node
				{
				DebugLocation(51, 25);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._node_in_criteria219);
				node15=node();
				PopFollow();

				adaptor.AddChild(root_1, node15.Tree);

				}
				break;

			}
			} finally { DebugExitSubRule(4); }


			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}

			DebugLocation(52, 2);

					retval.value = new CriteriaNode(Aspect,
						Identifier14.Text, (node15!=null?node15.value:default(IPointcutValueNode)));
				

			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("criteria", 5);
			LeaveRule("criteria", 5);
			Leave_criteria();
		}
		DebugLocation(55, 2);
		} finally { DebugExitRule(GrammarFileName, "criteria"); }
		return retval;

	}
	// $ANTLR end "criteria"

	public class literal_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public LiteralValueNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_literal();
	partial void Leave_literal();

	// $ANTLR start "literal"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:57:1: literal returns [LiteralValueNode value] : Value ;
	[GrammarRule("literal")]
	private PointcutWalker.literal_return literal()
	{
		Enter_literal();
		EnterRule("literal", 6);
		TraceIn("literal", 6);
		PointcutWalker.literal_return retval = new PointcutWalker.literal_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree Value16=null;

		CommonTree Value16_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "literal");
		DebugLocation(57, 2);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:58:2: ( Value )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:58:4: Value
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(58, 4);
			_last = (CommonTree)input.LT(1);
			Value16=(CommonTree)Match(input,Value,Follow._Value_in_literal237); 
			Value16_tree = (CommonTree)adaptor.DupNode(Value16);

			adaptor.AddChild(root_0, Value16_tree);

			DebugLocation(59, 2);

					retval.value = new LiteralValueNode(Aspect, Value16.Text.Substring(1, Value16.Text.Length-2));
				

			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("literal", 6);
			LeaveRule("literal", 6);
			Leave_literal();
		}
		DebugLocation(61, 2);
		} finally { DebugExitRule(GrammarFileName, "literal"); }
		return retval;

	}
	// $ANTLR end "literal"

	public class array_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public ArrayValueNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_array();
	partial void Leave_array();

	// $ANTLR start "array"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:63:1: array returns [ArrayValueNode value] : ^( ARRAY (p= node )* ) ;
	[GrammarRule("array")]
	private PointcutWalker.array_return array()
	{
		Enter_array();
		EnterRule("array", 7);
		TraceIn("array", 7);
		PointcutWalker.array_return retval = new PointcutWalker.array_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree ARRAY17=null;
		PointcutWalker.node_return p = default(PointcutWalker.node_return);

		CommonTree ARRAY17_tree = default(CommonTree);

		var list = new List<IPointcutValueNode>(); 
		try { DebugEnterRule(GrammarFileName, "array");
		DebugLocation(63, 2);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:65:2: ( ^( ARRAY (p= node )* ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:65:4: ^( ARRAY (p= node )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(65, 4);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(65, 6);
			_last = (CommonTree)input.LT(1);
			ARRAY17=(CommonTree)Match(input,ARRAY,Follow._ARRAY_in_array260); 
			ARRAY17_tree = (CommonTree)adaptor.DupNode(ARRAY17);

			root_1 = (CommonTree)adaptor.BecomeRoot(ARRAY17_tree, root_1);



			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(65, 12);
			    // D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:65:12: (p= node )*
			    try { DebugEnterSubRule(5);
			    while (true)
			    {
			    	int alt5=2;
			    	try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			    	int LA5_0 = input.LA(1);

			    	if (((LA5_0>=CRITERIA && LA5_0<=NOT)||LA5_0==Value))
			    	{
			    		alt5=1;
			    	}


			    	} finally { DebugExitDecision(5); }
			    	switch ( alt5 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:65:13: p= node
			    		{
			    		DebugLocation(65, 14);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._node_in_array265);
			    		p=node();
			    		PopFollow();

			    		adaptor.AddChild(root_1, p.Tree);
			    		DebugLocation(65, 20);
			    		list.Add(p.value); 

			    		}
			    		break;

			    	default:
			    		goto loop5;
			    	}
			    }

			    loop5:
			    	;

			    } finally { DebugExitSubRule(5); }


			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}

			DebugLocation(66, 2);

					retval.value = new ArrayValueNode(Aspect, list.ToArray());
				

			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("array", 7);
			LeaveRule("array", 7);
			Leave_array();
		}
		DebugLocation(68, 2);
		} finally { DebugExitRule(GrammarFileName, "array"); }
		return retval;

	}
	// $ANTLR end "array"

	public class pointcutRef_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>, IAstRuleReturnScope
	{
		public PointcutRefNode value;
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } }
		object IAstRuleReturnScope.Tree { get { return Tree; } }

	}

	partial void Enter_pointcutRef();
	partial void Leave_pointcutRef();

	// $ANTLR start "pointcutRef"
	// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:70:1: pointcutRef returns [PointcutRefNode value] : ^( POINTCUTREF Identifier ) ;
	[GrammarRule("pointcutRef")]
	private PointcutWalker.pointcutRef_return pointcutRef()
	{
		Enter_pointcutRef();
		EnterRule("pointcutRef", 8);
		TraceIn("pointcutRef", 8);
		PointcutWalker.pointcutRef_return retval = new PointcutWalker.pointcutRef_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree POINTCUTREF18=null;
		CommonTree Identifier19=null;

		CommonTree POINTCUTREF18_tree = default(CommonTree);
		CommonTree Identifier19_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "pointcutRef");
		DebugLocation(70, 2);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:71:2: ( ^( POINTCUTREF Identifier ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\PointcutWalker.g:71:4: ^( POINTCUTREF Identifier )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(71, 4);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(71, 6);
			_last = (CommonTree)input.LT(1);
			POINTCUTREF18=(CommonTree)Match(input,POINTCUTREF,Follow._POINTCUTREF_in_pointcutRef288); 
			POINTCUTREF18_tree = (CommonTree)adaptor.DupNode(POINTCUTREF18);

			root_1 = (CommonTree)adaptor.BecomeRoot(POINTCUTREF18_tree, root_1);



			Match(input, TokenTypes.Down, null); 
			DebugLocation(71, 18);
			_last = (CommonTree)input.LT(1);
			Identifier19=(CommonTree)Match(input,Identifier,Follow._Identifier_in_pointcutRef290); 
			Identifier19_tree = (CommonTree)adaptor.DupNode(Identifier19);

			adaptor.AddChild(root_1, Identifier19_tree);


			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}

			DebugLocation(72, 2);

					retval.value = new PointcutRefNode(Aspect, Pointcut, Identifier19.Text);
				

			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("pointcutRef", 8);
			LeaveRule("pointcutRef", 8);
			Leave_pointcutRef();
		}
		DebugLocation(74, 2);
		} finally { DebugExitRule(GrammarFileName, "pointcutRef"); }
		return retval;

	}
	// $ANTLR end "pointcutRef"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _node_in_pointcut61 = new BitSet(new ulong[]{0x0UL});
		public static readonly BitSet _EOF_in_pointcut67 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _compound_in_node80 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _negation_in_node89 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _criteria_in_node98 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _literal_in_node107 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _array_in_node116 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointcutRef_in_node125 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _And_in_compound145 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _node_in_compound149 = new BitSet(new ulong[]{0xBF0UL});
		public static readonly BitSet _node_in_compound153 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _Or_in_compound165 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _node_in_compound169 = new BitSet(new ulong[]{0xBF0UL});
		public static readonly BitSet _node_in_compound173 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _NOT_in_negation195 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _node_in_negation197 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _CRITERIA_in_criteria215 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _Identifier_in_criteria217 = new BitSet(new ulong[]{0xBF8UL});
		public static readonly BitSet _node_in_criteria219 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _Value_in_literal237 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ARRAY_in_array260 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _node_in_array265 = new BitSet(new ulong[]{0xBF8UL});
		public static readonly BitSet _POINTCUTREF_in_pointcutRef288 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _Identifier_in_pointcutRef290 = new BitSet(new ulong[]{0x8UL});

	}
	#endregion Follow sets
}

} // namespace SheepAspect.Saql.Ast
