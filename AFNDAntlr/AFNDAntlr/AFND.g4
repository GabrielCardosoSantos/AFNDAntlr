grammar AFND;

@parser::members
{
    protected const int EOF = Eof;
}
 
@lexer::members
{
    protected const int EOF = Eof;
    protected const int HIDDEN = Hidden;
}
/*
 * Parser Rules
 */


expr: M = (alf, est);
alf:{letra (',' letra)*};
est:{letra (',')};

/*
 * Lexer Rules
 */


LETRA: [a-Z] | [0-9];

WS
	:	' ' -> channel(HIDDEN)
	;
