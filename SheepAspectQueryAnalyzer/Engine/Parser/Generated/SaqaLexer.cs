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

namespace  SheepAspectQueryAnalyzer.Engine.Parser 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class SaqaLexer : Antlr.Runtime.Lexer
{
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
	const int HIDDEN = Hidden;

    // delegates
    // delegators

	public SaqaLexer()
	{
		OnCreated();
	}

	public SaqaLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public SaqaLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g"; } }

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
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:10:6: ( '=' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:10:8: '='
			{
			DebugLocation(10, 8);
			Match('='); 

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
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:11:6: ( '[' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:11:8: '['
			{
			DebugLocation(11, 8);
			Match('['); 

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
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:12:7: ( '(' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:12:9: '('
			{
			DebugLocation(12, 9);
			Match('('); 

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
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:13:7: ( ')' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:13:9: ')'
			{
			DebugLocation(13, 9);
			Match(')'); 

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
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:7: ( ']' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:14:9: ']'
			{
			DebugLocation(14, 9);
			Match(']'); 

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

	partial void Enter_STRING();
	partial void Leave_STRING();

	// $ANTLR start "STRING"
	[GrammarRule("STRING")]
	private void mSTRING()
	{
		Enter_STRING();
		EnterRule("STRING", 6);
		TraceIn("STRING", 6);
		try
		{
			int _type = STRING;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:35:2: ( '\"' (~ ( '\"' ) )* '\"' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:35:4: '\"' (~ ( '\"' ) )* '\"'
			{
			DebugLocation(35, 4);
			Match('\"'); 
			DebugLocation(35, 8);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:35:8: (~ ( '\"' ) )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if (((LA1_0>='\u0000' && LA1_0<='!')||(LA1_0>='#' && LA1_0<='\uFFFF')))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:35:9: ~ ( '\"' )
					{
					DebugLocation(35, 9);
					if ((input.LA(1)>='\u0000' && input.LA(1)<='!')||(input.LA(1)>='#' && input.LA(1)<='\uFFFF'))
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
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(35, 18);
			Match('\"'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("STRING", 6);
			LeaveRule("STRING", 6);
			Leave_STRING();
		}
	}
	// $ANTLR end "STRING"

	partial void Enter_ID();
	partial void Leave_ID();

	// $ANTLR start "ID"
	[GrammarRule("ID")]
	private void mID()
	{
		Enter_ID();
		EnterRule("ID", 7);
		TraceIn("ID", 7);
		try
		{
			int _type = ID;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:37:4: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )* )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:37:6: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
			{
			DebugLocation(37, 6);
			if ((input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(37, 30);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:37:30: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if (((LA2_0>='0' && LA2_0<='9')||(LA2_0>='A' && LA2_0<='Z')||LA2_0=='_'||(LA2_0>='a' && LA2_0<='z')))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:
					{
					DebugLocation(37, 30);
					if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
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
					goto loop2;
				}
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
			TraceOut("ID", 7);
			LeaveRule("ID", 7);
			Leave_ID();
		}
	}
	// $ANTLR end "ID"

	partial void Enter_COMMENT();
	partial void Leave_COMMENT();

	// $ANTLR start "COMMENT"
	[GrammarRule("COMMENT")]
	private void mCOMMENT()
	{
		Enter_COMMENT();
		EnterRule("COMMENT", 8);
		TraceIn("COMMENT", 8);
		try
		{
			int _type = COMMENT;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' | '/*' ( options {greedy=false; } : . )* '*/' )
			int alt6=2;
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			int LA6_0 = input.LA(1);

			if ((LA6_0=='/'))
			{
				int LA6_1 = input.LA(2);

				if ((LA6_1=='/'))
				{
					alt6=1;
				}
				else if ((LA6_1=='*'))
				{
					alt6=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 6, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:9: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
				{
				DebugLocation(40, 9);
				Match("//"); 

				DebugLocation(40, 14);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:14: (~ ( '\\n' | '\\r' ) )*
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, decisionCanBacktrack[3]);
					int LA3_0 = input.LA(1);

					if (((LA3_0>='\u0000' && LA3_0<='\t')||(LA3_0>='\u000B' && LA3_0<='\f')||(LA3_0>='\u000E' && LA3_0<='\uFFFF')))
					{
						alt3=1;
					}


					} finally { DebugExitDecision(3); }
					switch ( alt3 )
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:14: ~ ( '\\n' | '\\r' )
						{
						DebugLocation(40, 14);
						if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\uFFFF'))
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
						goto loop3;
					}
				}

				loop3:
					;

				} finally { DebugExitSubRule(3); }

				DebugLocation(40, 28);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:28: ( '\\r' )?
				int alt4=2;
				try { DebugEnterSubRule(4);
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if ((LA4_0=='\r'))
				{
					alt4=1;
				}
				} finally { DebugExitDecision(4); }
				switch (alt4)
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:40:28: '\\r'
					{
					DebugLocation(40, 28);
					Match('\r'); 

					}
					break;

				}
				} finally { DebugExitSubRule(4); }

				DebugLocation(40, 34);
				Match('\n'); 
				DebugLocation(40, 39);
				_channel=HIDDEN;

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:41:9: '/*' ( options {greedy=false; } : . )* '*/'
				{
				DebugLocation(41, 9);
				Match("/*"); 

				DebugLocation(41, 14);
				// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:41:14: ( options {greedy=false; } : . )*
				try { DebugEnterSubRule(5);
				while (true)
				{
					int alt5=2;
					try { DebugEnterDecision(5, decisionCanBacktrack[5]);
					int LA5_0 = input.LA(1);

					if ((LA5_0=='*'))
					{
						int LA5_1 = input.LA(2);

						if ((LA5_1=='/'))
						{
							alt5=2;
						}
						else if (((LA5_1>='\u0000' && LA5_1<='.')||(LA5_1>='0' && LA5_1<='\uFFFF')))
						{
							alt5=1;
						}


					}
					else if (((LA5_0>='\u0000' && LA5_0<=')')||(LA5_0>='+' && LA5_0<='\uFFFF')))
					{
						alt5=1;
					}


					} finally { DebugExitDecision(5); }
					switch ( alt5 )
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:41:42: .
						{
						DebugLocation(41, 42);
						MatchAny(); 

						}
						break;

					default:
						goto loop5;
					}
				}

				loop5:
					;

				} finally { DebugExitSubRule(5); }

				DebugLocation(41, 47);
				Match("*/"); 

				DebugLocation(41, 52);
				_channel=HIDDEN;

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMENT", 8);
			LeaveRule("COMMENT", 8);
			Leave_COMMENT();
		}
	}
	// $ANTLR end "COMMENT"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 9);
		TraceIn("WS", 9);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:44:5: ( ( ' ' | '\\t' | '\\r' | '\\n' ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:44:9: ( ' ' | '\\t' | '\\r' | '\\n' )
			{
			DebugLocation(44, 9);
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

			DebugLocation(48, 11);
			_channel=HIDDEN;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 9);
			LeaveRule("WS", 9);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:8: ( T__8 | T__9 | T__10 | T__11 | T__12 | STRING | ID | COMMENT | WS )
		int alt7=9;
		try { DebugEnterDecision(7, decisionCanBacktrack[7]);
		switch (input.LA(1))
		{
		case '=':
			{
			alt7=1;
			}
			break;
		case '[':
			{
			alt7=2;
			}
			break;
		case '(':
			{
			alt7=3;
			}
			break;
		case ')':
			{
			alt7=4;
			}
			break;
		case ']':
			{
			alt7=5;
			}
			break;
		case '\"':
			{
			alt7=6;
			}
			break;
		case 'A':
		case 'B':
		case 'C':
		case 'D':
		case 'E':
		case 'F':
		case 'G':
		case 'H':
		case 'I':
		case 'J':
		case 'K':
		case 'L':
		case 'M':
		case 'N':
		case 'O':
		case 'P':
		case 'Q':
		case 'R':
		case 'S':
		case 'T':
		case 'U':
		case 'V':
		case 'W':
		case 'X':
		case 'Y':
		case 'Z':
		case '_':
		case 'a':
		case 'b':
		case 'c':
		case 'd':
		case 'e':
		case 'f':
		case 'g':
		case 'h':
		case 'i':
		case 'j':
		case 'k':
		case 'l':
		case 'm':
		case 'n':
		case 'o':
		case 'p':
		case 'q':
		case 'r':
		case 's':
		case 't':
		case 'u':
		case 'v':
		case 'w':
		case 'x':
		case 'y':
		case 'z':
			{
			alt7=7;
			}
			break;
		case '/':
			{
			alt7=8;
			}
			break;
		case '\t':
		case '\n':
		case '\r':
		case ' ':
			{
			alt7=9;
			}
			break;
		default:
			{
				NoViableAltException nvae = new NoViableAltException("", 7, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
		}

		} finally { DebugExitDecision(7); }
		switch (alt7)
		{
		case 1:
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:10: T__8
			{
			DebugLocation(1, 10);
			mT__8(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:15: T__9
			{
			DebugLocation(1, 15);
			mT__9(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:20: T__10
			{
			DebugLocation(1, 20);
			mT__10(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:26: T__11
			{
			DebugLocation(1, 26);
			mT__11(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:32: T__12
			{
			DebugLocation(1, 32);
			mT__12(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:38: STRING
			{
			DebugLocation(1, 38);
			mSTRING(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:45: ID
			{
			DebugLocation(1, 45);
			mID(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:48: COMMENT
			{
			DebugLocation(1, 48);
			mCOMMENT(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// D:\\Dev\\Codeplex\\sheepaop\\SheepAspectQueryAnalyzer\\Engine\\Parser\\Saqa.g:1:56: WS
			{
			DebugLocation(1, 56);
			mWS(); 

			}
			break;

		}

	}


	#region DFA

	protected override void InitDFAs()
	{
		base.InitDFAs();
	}

 
	#endregion

}

} // namespace  SheepAspectQueryAnalyzer.Engine.Parser 
