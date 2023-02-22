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


/*
arithmetic_expression = Console.Readline();
foreach (char s in arithmetic expression)
{
Console.WriteLine(s);
}
*/

Console.WriteLine("");
Console.WriteLine("Enter an arithmetic expression");

string str_operators = string.Join("", operators);  //for later search putting the list into string
string str_digits = string.Join("", digits);

int i_unn;
int i_aexp;
char ch_old;
int dif_paran;

string arithmetic_expression = "";
char ch_err = '\0'; //an error in the arithmetic expression, C# doesn't have empty symbols, so we replace it with that

do
{
    i_unn = 0;
    i_aexp = 0;
    dif_paran = 0; //the quantity of opened and closed paranthesis has to be the same, so the differencehas to be 0
    ch_old = ch_err;
    Console.Write ("Enter an arithmetic expression");
    arithmetic_expression = Console.ReadLine();
    arithmetic_expression = arithmetic_expression.Replace(separators[0], ""); //deleting separators
    foreach (char ch_exp in arithmetic_expression)  //an algorithm parcing symbol by symbol    
    {
        i_aexp = i_aexp + 1;    //counting symbols in arithmetic_expression
        if (i_aexp == 1 & (ch_exp == ')' | -1 != str_operators.IndexOf(ch_exp))) ch_err = ch_exp;   //the first symbollcannot be an operator
        if (i_aexp == arithmetic_expression.Length & (ch_exp == '(' | -1 != str_operators.IndexOf(ch_exp))) ch_err = ch_exp; //the last symbol cannot be '(' or an operator
        if (-1 != str_operators.IndexOf(ch_old) & -1 != str_operators.IndexOf(ch_exp)) ch_err = ch_exp; //there can be 2 operators in a row
        
        //impossible combinations
        
        if ((ch_old == ')' | -1 != str_digits.IndexOf(ch_old)) & ch_exp == '(') ch_err = ch_exp;
        if ((ch_old == '(' | -1 != str_operators.IndexOf(ch_old)) & ch_exp == ')') ch_err = ch_exp;
        if (ch_old == '(' & -1 != str_operators.IndexOf(ch_exp)) ch_err = ch_exp;
        if (ch_old == ')' & -1 != str_digits.IndexOf(ch_exp)) ch_err = ch_exp;
        if (ch_exp == '(') dif_paran = dif_paran + 1;
        if (ch_exp == ')') dif_paran = dif_paran - 1;
        
        if (i_aexp == arithmetic_expression.Length & dif_paran != 0) 
            if (dif_paran > 0) ch_err = '(';
               else ch_err = ')';
/*
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
*/
