using System;

List<string> digits = new List<string>() {"0","1","2","3","4","5","6","7","8","9"};
List<string> operators = new List<string>() {"/","-","*","+"};
List<string> paranthesis = new List<string>() {"(",")"};
List<string> separators = new List<string>() {" "};

var union = digits.Concat(operators).Concat(paranthesis).Concat(separators).ToList();

string? arithmetic_expression = "";
int i_unn;

/*
arithmetic_expression = Console.Readline();
foreach (char s in arithmetic expression)
{
Console.WriteLine(s);
}
*/
