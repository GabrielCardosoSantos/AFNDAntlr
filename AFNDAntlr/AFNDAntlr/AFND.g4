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


expr: LETRA '=('alf ',' est  ',' inicial ',' finais')' # VExpr; 
alf:'{'LETRA (',' LETRA)* '}'  # VAlf;
est:'{Q' NUM (', Q' NUM)* '}' # VEst;
func:'{' # VFunc ;
inicial: 'Q' NUM # VInicial;
finais: '{Q' NUM (', Q'NUM)*'}' # VFinais;




/*
 * Lexer Rules
 */

NUM: [0-9]+;
LETRA: [A-Za-z] | [0-9];

WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
    ;