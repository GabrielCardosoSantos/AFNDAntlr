Foi utilizado a linguagem C#. Decidimos usar ela pois demonstrou uma facilidade para utilizar o Antlr e era a de maior conhecimento do grupo.

Para compilar o projeto, é necessário instalar o Visual Studio 2017 Community.
Para executar, crie um arquivo txt "gramatica.txt" dentro da pasta do projeto, na pasta "bin/debug" com a gramatica desejada. 

Exemplo de gramática: M=({a, b}, {q0, q1, q2, q3}, T, q0, {q1, q2}) T={q0,a=q0; q1,b=q0; q2,c={q1,q2}}

* Caso haja algum erro de link de bibliotecas, é necessário instalar a biblioteca do Antlr4 pelo Nuget Package do Visual Studio, na "Solution  AFNDAntlr"