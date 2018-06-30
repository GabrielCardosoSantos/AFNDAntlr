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


expr: LETRA '=('alf ',' est ',' func ',' inicial',' finais')' tab # VExpr;
alf:'{'LETRA (',' LETRA)* '}'   # VAlf;
est:'{'ESTADO (',' ESTADO)* '}'   # VEst;
func:'T'                        # VFunc ;
inicial: ESTADO                 # VInicial;
finais: '{'ESTADO (','ESTADO)*'}' # VFinais;

tab: 'T=''{'regra (';' regra)* '}'                        # VTab;
regra: ESTADO ',' LETRA '=' ESTADO                        # Det
	   | ESTADO ',' LETRA '=' '{'ESTADO (',' ESTADO)* '}' # Ndet
	   ;


/*
 * Lexer Rules
 */

ESTADO: 'q' NUM;
NUM: [0-9]+;
LETRA: [A-Za-z] | [0-9];

WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
	;
