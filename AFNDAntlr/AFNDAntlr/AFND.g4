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


expr: LETRA '=('alf ',' est ',' func ',' inicial',' finais')' # VExpr;
alf:'{'LETRA (',' LETRA)* '}'   # VAlf;
est:'{'ESTADO (',' ESTADO)* '}'   # VEst;
func:'{'                        # VFunc ;
inicial: ESTADO                 # VInicial;
finais: '{'ESTADO (','ESTADO)*'}' # VFinais;



/*
 * Lexer Rules
 */

ESTADO: 'Q' NUM;
NUM: [0-9]+;
LETRA: [A-Za-z] | [0-9];

WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
	;
