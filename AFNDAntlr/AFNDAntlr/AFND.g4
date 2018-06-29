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


expr: letra '=('alf ',' est ',' func ',' inicial ',' finais')';
alf:'{'letra (',' letra)*'}';
est:'{Q' NUM (',Q'NUM)*'}';
func:'{' ;
inicial: 'Q' NUM;
finais: '{Q' NUM (',Q'NUM)*'}';




/*
 * Lexer Rules
 */

NUM: [0-9]+;
LETRA: [A-Za-z] | [0-9];

WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
    ;