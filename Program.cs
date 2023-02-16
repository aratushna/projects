using System;

List<string> digits = new List<string>() {"0","1","2","3","4","5","6","7","8","9"};
List<string> operators = new List<string>() {"/","-","*","+"};
List<string> paranthesis = new List<string>() {"(",")"};
List<string> separators = new List<string>() {" "};

List<string> union = digits.Concat(operators).Concat(paranthesis).Concat(separators).ToList(); //all lists put together

string? arithmetic_expression = "";
int i_unn == 0;

/*
arithmetic_expression = Console.Readline();
foreach (char s in arithmetic expression)
{
Console.WriteLine(s);
}
*/

do
{
  Console.Write ("Enter an arithmetic expression");
  arithmetic_expression = Console.ReadLine();
  foreach (char ch_exp in arithmetic expression)
  {
    i_unn = 0;
    foreach (string str_unn in union)
    {
      if (ch_exp != char.Parse(str_unn))
        i_unn = i_unn + 1;
      if (i_unn == union.Count)
      {
        Console.WriteLine("Error. Enter another arithmetic expression");
        arithmetic_expression = "";
      }
    }
  }
  
} while (arithmetic_expression == "")
