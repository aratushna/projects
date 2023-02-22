using System.Cellections;

//making a list of all symbols used

List<string> digits = new List<string>() {"0","1","2","3","4","5","6","7","8","9"};
List<string> operators = new List<string>() {"/","-","*","+"};
List<string> paranthesis = new List<string>() {"(",")"};
List<string> separators = new List<string>() {" "};

//making a dictionary of operators and their priorities

Dictionary<string, int> operators_priorities = new Dictionary<string, int>()
{
    {"^", 3},
    {"*", 2},
    {"/", 2},
    {"+", 1},
    {"-", 1}
} ;

List<string> operators = operators_priorities.Keys.ToList();  //keys comes fist, so it's operators

List<string> operators_paranthesis = operators.Concat(paranthesis).ToList();  //putting 2 lists together

  List<string> union = digits.Concat(operators_paranthesis).ToList(); //all lists put together

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
