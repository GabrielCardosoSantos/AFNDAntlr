Foi utilizado a linguagem C#. Decidimos usar ela pois demonstrou uma facilidade para utilizar o Antlr e era a de maior conhecimento do grupo.

Para compilar o projeto, � necess�rio instalar o Visual Studio Community.
Para executar, crie um arquivo txt "gramaticas.txt" dentro da pasta do projeto, na pasta "bin/debug" com a gramatica desejada. 

Exemplo de gram�tica: M=({a, b}, {q0, q1, q2, q3}, T, q0, {q1, q2}) T={q0,a=q0; q1,b=q0; q2,c={q1,q2}}