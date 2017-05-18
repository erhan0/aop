// $ANTLR 3.3 Nov 30, 2010 12:45:30 D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g 2011-08-16 15:05:01

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162

using Antlr.Runtime;

namespace  SheepAspect.Saql.Ast 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class PointcutLexer : Antlr.Runtime.Lexer
{
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
	const int HIDDEN = Hidden;

    // delegates
    // delegators

	public PointcutLexer()
	{
		OnCreated();
	}

	public PointcutLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public PointcutLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_T__14();
	partial void Leave_T__14();

	// $ANTLR start "T__14"
	[GrammarRule("T__14")]
	private void mT__14()
	{
		Enter_T__14();
		EnterRule("T__14", 1);
		TraceIn("T__14", 1);
		try
		{
			int _type = T__14;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:10:7: ( ',' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:10:9: ','
			{
			DebugLocation(10, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__14", 1);
			LeaveRule("T__14", 1);
			Leave_T__14();
		}
	}
	// $ANTLR end "T__14"

	partial void Enter_T__15();
	partial void Leave_T__15();

	// $ANTLR start "T__15"
	[GrammarRule("T__15")]
	private void mT__15()
	{
		Enter_T__15();
		EnterRule("T__15", 2);
		TraceIn("T__15", 2);
		try
		{
			int _type = T__15;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:11:7: ( ':' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:11:9: ':'
			{
			DebugLocation(11, 9);
			Match(':'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__15", 2);
			LeaveRule("T__15", 2);
			Leave_T__15();
		}
	}
	// $ANTLR end "T__15"

	partial void Enter_T__16();
	partial void Leave_T__16();

	// $ANTLR start "T__16"
	[GrammarRule("T__16")]
	private void mT__16()
	{
		Enter_T__16();
		EnterRule("T__16", 3);
		TraceIn("T__16", 3);
		try
		{
			int _type = T__16;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:12:7: ( '@' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:12:9: '@'
			{
			DebugLocation(12, 9);
			Match('@'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__16", 3);
			LeaveRule("T__16", 3);
			Leave_T__16();
		}
	}
	// $ANTLR end "T__16"

	partial void Enter_T__17();
	partial void Leave_T__17();

	// $ANTLR start "T__17"
	[GrammarRule("T__17")]
	private void mT__17()
	{
		Enter_T__17();
		EnterRule("T__17", 4);
		TraceIn("T__17", 4);
		try
		{
			int _type = T__17;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:13:7: ( '(' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:13:9: '('
			{
			DebugLocation(13, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__17", 4);
			LeaveRule("T__17", 4);
			Leave_T__17();
		}
	}
	// $ANTLR end "T__17"

	partial void Enter_T__18();
	partial void Leave_T__18();

	// $ANTLR start "T__18"
	[GrammarRule("T__18")]
	private void mT__18()
	{
		Enter_T__18();
		EnterRule("T__18", 5);
		TraceIn("T__18", 5);
		try
		{
			int _type = T__18;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:14:7: ( ')' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:14:9: ')'
			{
			DebugLocation(14, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__18", 5);
			LeaveRule("T__18", 5);
			Leave_T__18();
		}
	}
	// $ANTLR end "T__18"

	partial void Enter_NOT();
	partial void Leave_NOT();

	// $ANTLR start "NOT"
	[GrammarRule("NOT")]
	private void mNOT()
	{
		Enter_NOT();
		EnterRule("NOT", 6);
		TraceIn("NOT", 6);
		try
		{
			int _type = NOT;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:37:5: ( '!' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:37:7: '!'
			{
			DebugLocation(37, 7);
			Match('!'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NOT", 6);
			LeaveRule("NOT", 6);
			Leave_NOT();
		}
	}
	// $ANTLR end "NOT"

	partial void Enter_And();
	partial void Leave_And();

	// $ANTLR start "And"
	[GrammarRule("And")]
	private void mAnd()
	{
		Enter_And();
		EnterRule("And", 7);
		TraceIn("And", 7);
		try
		{
			int _type = And;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:38:5: ( '&&' | '&' )
			int alt1=2;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if ((LA1_0=='&'))
			{
				int LA1_1 = input.LA(2);

				if ((LA1_1=='&'))
				{
					alt1=1;
				}
				else
				{
					alt1=2;}
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
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:38:7: '&&'
				{
				DebugLocation(38, 7);
				Match("&&"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:38:14: '&'
				{
				DebugLocation(38, 14);
				Match('&'); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("And", 7);
			LeaveRule("And", 7);
			Leave_And();
		}
	}
	// $ANTLR end "And"

	partial void Enter_Or();
	partial void Leave_Or();

	// $ANTLR start "Or"
	[GrammarRule("Or")]
	private void mOr()
	{
		Enter_Or();
		EnterRule("Or", 8);
		TraceIn("Or", 8);
		try
		{
			int _type = Or;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:39:4: ( '||' | '|' )
			int alt2=2;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0=='|'))
			{
				int LA2_1 = input.LA(2);

				if ((LA2_1=='|'))
				{
					alt2=1;
				}
				else
				{
					alt2=2;}
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
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:39:6: '||'
				{
				DebugLocation(39, 6);
				Match("||"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:39:13: '|'
				{
				DebugLocation(39, 13);
				Match('|'); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Or", 8);
			LeaveRule("Or", 8);
			Leave_Or();
		}
	}
	// $ANTLR end "Or"

	partial void Enter_Identifier();
	partial void Leave_Identifier();

	// $ANTLR start "Identifier"
	[GrammarRule("Identifier")]
	private void mIdentifier()
	{
		Enter_Identifier();
		EnterRule("Identifier", 9);
		TraceIn("Identifier", 9);
		try
		{
			int _type = Identifier;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:41:11: ( ( 'A' .. 'z' | '0' .. '9' | UScore )+ )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:41:13: ( 'A' .. 'z' | '0' .. '9' | UScore )+
			{
			DebugLocation(41, 13);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:41:13: ( 'A' .. 'z' | '0' .. '9' | UScore )+
			int cnt3=0;
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if (((LA3_0>='0' && LA3_0<='9')||(LA3_0>='A' && LA3_0<='z')))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch (alt3)
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:
					{
					DebugLocation(41, 13);
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
					if (cnt3 >= 1)
                                    {
                                        goto loop3;
                                    }

                                    EarlyExitException eee3 = new EarlyExitException( 3, input );
					DebugRecognitionException(eee3);
					throw eee3;
				}
				cnt3++;
			}
			loop3:
				;

			} finally { DebugExitSubRule(3); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Identifier", 9);
			LeaveRule("Identifier", 9);
			Leave_Identifier();
		}
	}
	// $ANTLR end "Identifier"

	partial void Enter_Value();
	partial void Leave_Value();

	// $ANTLR start "Value"
	[GrammarRule("Value")]
	private void mValue()
	{
		Enter_Value();
		EnterRule("Value", 10);
		TraceIn("Value", 10);
		try
		{
			int _type = Value;
			int _channel = DefaultTokenChannel;
            // D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:45:2: ( '\\'' ( 'A' .. 'z' | '0' .. '9' | '(' | ')' | '*' | '.' | ':' | ' ' | UScore )* '\\'' )
			DebugEnterAlt(1);
            // D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:45:4: '\\'' ( 'A' .. 'z' | '0' .. '9' | '(' | ')' | '*' | '.' | ':' | ' ' | UScore )* '\\''
			{
			DebugLocation(45, 4);
			Match('\''); 
			DebugLocation(45, 9);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:45:9: ( 'A' .. 'z' | '0' .. '9' | '(' | ')' | '*' | '.' | ':' | ' ' | UScore )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

                if ((LA4_0 == ' ' || (LA4_0 >= '(' && LA4_0 <= '*') || LA4_0 == '.' || LA4_0 == ':' || (LA4_0 >= '0' && LA4_0 <= '9') || (LA4_0 >= 'A' && LA4_0 <= 'z')))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:
					{
					DebugLocation(45, 9);
                    if (input.LA(1) == ' ' || (input.LA(1) >= '(' && input.LA(1) <= '*') || input.LA(1) == '.' || input.LA(1) == ':' || (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'z'))
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
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(45, 70);
			Match('\''); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Value", 10);
			LeaveRule("Value", 10);
			Leave_Value();
		}
	}
	// $ANTLR end "Value"

	partial void Enter_UScore();
	partial void Leave_UScore();

	// $ANTLR start "UScore"
	[GrammarRule("UScore")]
	private void mUScore()
	{
		Enter_UScore();
		EnterRule("UScore", 11);
		TraceIn("UScore", 11);
		try
		{
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:49:2: ( '_' )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:49:4: '_'
			{
			DebugLocation(49, 4);
			Match('_'); 

			}

		}
		finally
		{
			TraceOut("UScore", 11);
			LeaveRule("UScore", 11);
			Leave_UScore();
		}
	}
	// $ANTLR end "UScore"

	partial void Enter_Ws();
	partial void Leave_Ws();

	// $ANTLR start "Ws"
	[GrammarRule("Ws")]
	private void mWs()
	{
		Enter_Ws();
		EnterRule("Ws", 12);
		TraceIn("Ws", 12);
		try
		{
			int _type = Ws;
			int _channel = DefaultTokenChannel;
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:51:5: ( ( ' ' | '\\t' | '\\r' | '\\n' ) )
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:51:9: ( ' ' | '\\t' | '\\r' | '\\n' )
			{
			DebugLocation(51, 9);
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

			DebugLocation(55, 11);
			_channel=HIDDEN;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Ws", 12);
			LeaveRule("Ws", 12);
			Leave_Ws();
		}
	}
	// $ANTLR end "Ws"

	public override void mTokens()
	{
		// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:8: ( T__14 | T__15 | T__16 | T__17 | T__18 | NOT | And | Or | Identifier | Value | Ws )
		int alt5=11;
		try { DebugEnterDecision(5, decisionCanBacktrack[5]);
		switch (input.LA(1))
		{
		case ',':
			{
			alt5=1;
			}
			break;
		case ':':
			{
			alt5=2;
			}
			break;
		case '@':
			{
			alt5=3;
			}
			break;
		case '(':
			{
			alt5=4;
			}
			break;
		case ')':
			{
			alt5=5;
			}
			break;
		case '!':
			{
			alt5=6;
			}
			break;
		case '&':
			{
			alt5=7;
			}
			break;
		case '|':
			{
			alt5=8;
			}
			break;
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
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
		case '[':
		case '\\':
		case ']':
		case '^':
		case '_':
		case '`':
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
			alt5=9;
			}
			break;
		case '\'':
			{
			alt5=10;
			}
			break;
		case '\t':
		case '\n':
		case '\r':
		case ' ':
			{
			alt5=11;
			}
			break;
		default:
			{
				NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
		}

		} finally { DebugExitDecision(5); }
		switch (alt5)
		{
		case 1:
			DebugEnterAlt(1);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:10: T__14
			{
			DebugLocation(1, 10);
			mT__14(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:16: T__15
			{
			DebugLocation(1, 16);
			mT__15(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:22: T__16
			{
			DebugLocation(1, 22);
			mT__16(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:28: T__17
			{
			DebugLocation(1, 28);
			mT__17(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:34: T__18
			{
			DebugLocation(1, 34);
			mT__18(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:40: NOT
			{
			DebugLocation(1, 40);
			mNOT(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:44: And
			{
			DebugLocation(1, 44);
			mAnd(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:48: Or
			{
			DebugLocation(1, 48);
			mOr(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:51: Identifier
			{
			DebugLocation(1, 51);
			mIdentifier(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:62: Value
			{
			DebugLocation(1, 62);
			mValue(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// D:\\Dev\\Codeplex\\SheepAop\\SheepAspect\\Saql\\Ast\\Pointcut.g:1:68: Ws
			{
			DebugLocation(1, 68);
			mWs(); 

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

} // namespace  SheepAspect.Saql.Ast 
