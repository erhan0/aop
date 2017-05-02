// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g 2011-05-08 17:18:37

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

namespace  SheepAop.Saql.Ast 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class LiteralExpressionLexer : Antlr.Runtime.Lexer
{
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
	const int HIDDEN = Hidden;

    // delegates
    // delegators

	public LiteralExpressionLexer()
	{
		OnCreated();
	}

	public LiteralExpressionLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public LiteralExpressionLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_T__8();
	partial void Leave_T__8();

	// $ANTLR start "T__8"
	[GrammarRule("T__8")]
	private void mT__8()
	{
		Enter_T__8();
		EnterRule("T__8", 1);
		TraceIn("T__8", 1);
		try
		{
			int _type = T__8;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:10:6: ( '.' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:10:8: '.'
			{
			DebugLocation(10, 8);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__8", 1);
			LeaveRule("T__8", 1);
			Leave_T__8();
		}
	}
	// $ANTLR end "T__8"

	partial void Enter_T__9();
	partial void Leave_T__9();

	// $ANTLR start "T__9"
	[GrammarRule("T__9")]
	private void mT__9()
	{
		Enter_T__9();
		EnterRule("T__9", 2);
		TraceIn("T__9", 2);
		try
		{
			int _type = T__9;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:11:6: ( '(' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:11:8: '('
			{
			DebugLocation(11, 8);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__9", 2);
			LeaveRule("T__9", 2);
			Leave_T__9();
		}
	}
	// $ANTLR end "T__9"

	partial void Enter_T__10();
	partial void Leave_T__10();

	// $ANTLR start "T__10"
	[GrammarRule("T__10")]
	private void mT__10()
	{
		Enter_T__10();
		EnterRule("T__10", 3);
		TraceIn("T__10", 3);
		try
		{
			int _type = T__10;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:12:7: ( ')' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:12:9: ')'
			{
			DebugLocation(12, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__10", 3);
			LeaveRule("T__10", 3);
			Leave_T__10();
		}
	}
	// $ANTLR end "T__10"

	partial void Enter_T__11();
	partial void Leave_T__11();

	// $ANTLR start "T__11"
	[GrammarRule("T__11")]
	private void mT__11()
	{
		Enter_T__11();
		EnterRule("T__11", 4);
		TraceIn("T__11", 4);
		try
		{
			int _type = T__11;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:7: ( '..' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:13:9: '..'
			{
			DebugLocation(13, 9);
			Match(".."); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__11", 4);
			LeaveRule("T__11", 4);
			Leave_T__11();
		}
	}
	// $ANTLR end "T__11"

	partial void Enter_T__12();
	partial void Leave_T__12();

	// $ANTLR start "T__12"
	[GrammarRule("T__12")]
	private void mT__12()
	{
		Enter_T__12();
		EnterRule("T__12", 5);
		TraceIn("T__12", 5);
		try
		{
			int _type = T__12;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:14:7: ( '*' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:14:9: '*'
			{
			DebugLocation(14, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__12", 5);
			LeaveRule("T__12", 5);
			Leave_T__12();
		}
	}
	// $ANTLR end "T__12"

	partial void Enter_T__13();
	partial void Leave_T__13();

	// $ANTLR start "T__13"
	[GrammarRule("T__13")]
	private void mT__13()
	{
		Enter_T__13();
		EnterRule("T__13", 6);
		TraceIn("T__13", 6);
		try
		{
			int _type = T__13;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:15:7: ( ',' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:15:9: ','
			{
			DebugLocation(15, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__13", 6);
			LeaveRule("T__13", 6);
			Leave_T__13();
		}
	}
	// $ANTLR end "T__13"

	partial void Enter_ACCESSOR();
	partial void Leave_ACCESSOR();

	// $ANTLR start "ACCESSOR"
	[GrammarRule("ACCESSOR")]
	private void mACCESSOR()
	{
		Enter_ACCESSOR();
		EnterRule("ACCESSOR", 7);
		TraceIn("ACCESSOR", 7);
		try
		{
			int _type = ACCESSOR;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:31:9: ( 'public' | 'private' )
			int alt1=2;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if ((LA1_0=='p'))
			{
				int LA1_1 = input.LA(2);

				if ((LA1_1=='u'))
				{
					alt1=1;
				}
				else if ((LA1_1=='r'))
				{
					alt1=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 1, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 1, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:31:11: 'public'
				{
				DebugLocation(31, 11);
				Match("public"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:31:22: 'private'
				{
				DebugLocation(31, 22);
				Match("private"); 


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ACCESSOR", 7);
			LeaveRule("ACCESSOR", 7);
			Leave_ACCESSOR();
		}
	}
	// $ANTLR end "ACCESSOR"

	partial void Enter_IDENTIFIER();
	partial void Leave_IDENTIFIER();

	// $ANTLR start "IDENTIFIER"
	[GrammarRule("IDENTIFIER")]
	private void mIDENTIFIER()
	{
		Enter_IDENTIFIER();
		EnterRule("IDENTIFIER", 8);
		TraceIn("IDENTIFIER", 8);
		try
		{
			int _type = IDENTIFIER;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:34:2: ( ( 'A' .. 'z' | UScore | '0' .. '9' )+ )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:34:4: ( 'A' .. 'z' | UScore | '0' .. '9' )+
			{
			DebugLocation(34, 4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:34:4: ( 'A' .. 'z' | UScore | '0' .. '9' )+
			int cnt2=0;
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if (((LA2_0>='0' && LA2_0<='9')||(LA2_0>='A' && LA2_0<='z')))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch (alt2)
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:
					{
					DebugLocation(34, 4);
					if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='z'))
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					if (cnt2 >= 1)
						goto loop2;

					EarlyExitException eee2 = new EarlyExitException( 2, input );
					DebugRecognitionException(eee2);
					throw eee2;
				}
				cnt2++;
			}
			loop2:
				;

			} finally { DebugExitSubRule(2); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDENTIFIER", 8);
			LeaveRule("IDENTIFIER", 8);
			Leave_IDENTIFIER();
		}
	}
	// $ANTLR end "IDENTIFIER"

	partial void Enter_UScore();
	partial void Leave_UScore();

	// $ANTLR start "UScore"
	[GrammarRule("UScore")]
	private void mUScore()
	{
		Enter_UScore();
		EnterRule("UScore", 9);
		TraceIn("UScore", 9);
		try
		{
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:37:2: ( '_' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:37:4: '_'
			{
			DebugLocation(37, 4);
			Match('_'); 

			}

		}
		finally
		{
			TraceOut("UScore", 9);
			LeaveRule("UScore", 9);
			Leave_UScore();
		}
	}
	// $ANTLR end "UScore"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 10);
		TraceIn("WS", 10);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:39:5: ( ( ' ' | '\\t' | '\\r' | '\\n' ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:39:9: ( ' ' | '\\t' | '\\r' | '\\n' )
			{
			DebugLocation(39, 9);
			if ((input.LA(1)>='\t' && input.LA(1)<='\n')||input.LA(1)=='\r'||input.LA(1)==' ')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(43, 11);
			_channel=HIDDEN;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 10);
			LeaveRule("WS", 10);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:8: ( T__8 | T__9 | T__10 | T__11 | T__12 | T__13 | ACCESSOR | IDENTIFIER | WS )
		int alt3=9;
		try { DebugEnterDecision(3, decisionCanBacktrack[3]);
		try
		{
			alt3 = dfa3.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(3); }
		switch (alt3)
		{
		case 1:
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:10: T__8
			{
			DebugLocation(1, 10);
			mT__8(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:15: T__9
			{
			DebugLocation(1, 15);
			mT__9(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:20: T__10
			{
			DebugLocation(1, 20);
			mT__10(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:26: T__11
			{
			DebugLocation(1, 26);
			mT__11(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:32: T__12
			{
			DebugLocation(1, 32);
			mT__12(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:38: T__13
			{
			DebugLocation(1, 38);
			mT__13(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:44: ACCESSOR
			{
			DebugLocation(1, 44);
			mACCESSOR(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:53: IDENTIFIER
			{
			DebugLocation(1, 53);
			mIDENTIFIER(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAop\\Saql\\Ast\\LiteralExpression.g:1:64: WS
			{
			DebugLocation(1, 64);
			mWS(); 

			}
			break;

		}

	}


	#region DFA
	DFA3 dfa3;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa3 = new DFA3(this);
	}

	private class DFA3 : DFA
	{
		private const string DFA3_eotS =
			"\x1\xFFFF\x1\xA\x4\xFFFF\x1\x7\x4\xFFFF\x8\x7\x1\x15\x1\x7\x1\xFFFF"+
			"\x1\x15";
		private const string DFA3_eofS =
			"\x17\xFFFF";
		private const string DFA3_minS =
			"\x1\x9\x1\x2E\x4\xFFFF\x1\x72\x4\xFFFF\x1\x62\x1\x69\x1\x6C\x1\x76\x1"+
			"\x69\x1\x61\x1\x63\x1\x74\x1\x30\x1\x65\x1\xFFFF\x1\x30";
		private const string DFA3_maxS =
			"\x1\x7A\x1\x2E\x4\xFFFF\x1\x75\x4\xFFFF\x1\x62\x1\x69\x1\x6C\x1\x76"+
			"\x1\x69\x1\x61\x1\x63\x1\x74\x1\x7A\x1\x65\x1\xFFFF\x1\x7A";
		private const string DFA3_acceptS =
			"\x2\xFFFF\x1\x2\x1\x3\x1\x5\x1\x6\x1\xFFFF\x1\x8\x1\x9\x1\x4\x1\x1\xA"+
			"\xFFFF\x1\x7\x1\xFFFF";
		private const string DFA3_specialS =
			"\x17\xFFFF}>";
		private static readonly string[] DFA3_transitionS =
			{
				"\x2\x8\x2\xFFFF\x1\x8\x12\xFFFF\x1\x8\x7\xFFFF\x1\x2\x1\x3\x1\x4\x1"+
				"\xFFFF\x1\x5\x1\xFFFF\x1\x1\x1\xFFFF\xA\x7\x7\xFFFF\x2F\x7\x1\x6\xA"+
				"\x7",
				"\x1\x9",
				"",
				"",
				"",
				"",
				"\x1\xC\x2\xFFFF\x1\xB",
				"",
				"",
				"",
				"",
				"\x1\xD",
				"\x1\xE",
				"\x1\xF",
				"\x1\x10",
				"\x1\x11",
				"\x1\x12",
				"\x1\x13",
				"\x1\x14",
				"\xA\x7\x7\xFFFF\x3A\x7",
				"\x1\x16",
				"",
				"\xA\x7\x7\xFFFF\x3A\x7"
			};

		private static readonly short[] DFA3_eot = DFA.UnpackEncodedString(DFA3_eotS);
		private static readonly short[] DFA3_eof = DFA.UnpackEncodedString(DFA3_eofS);
		private static readonly char[] DFA3_min = DFA.UnpackEncodedStringToUnsignedChars(DFA3_minS);
		private static readonly char[] DFA3_max = DFA.UnpackEncodedStringToUnsignedChars(DFA3_maxS);
		private static readonly short[] DFA3_accept = DFA.UnpackEncodedString(DFA3_acceptS);
		private static readonly short[] DFA3_special = DFA.UnpackEncodedString(DFA3_specialS);
		private static readonly short[][] DFA3_transition;

		static DFA3()
		{
			int numStates = DFA3_transitionS.Length;
			DFA3_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA3_transition[i] = DFA.UnpackEncodedString(DFA3_transitionS[i]);
			}
		}

		public DFA3( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 3;
			this.eot = DFA3_eot;
			this.eof = DFA3_eof;
			this.min = DFA3_min;
			this.max = DFA3_max;
			this.accept = DFA3_accept;
			this.special = DFA3_special;
			this.transition = DFA3_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( T__8 | T__9 | T__10 | T__11 | T__12 | T__13 | ACCESSOR | IDENTIFIER | WS );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}

} // namespace  SheepAop.Saql.Ast 
