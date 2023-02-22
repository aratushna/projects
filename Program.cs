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
        i_unn = 0;
            foreach (string str_unn in union)
            {
                if (ch_exp != char.Parse(str_unn)) i_unn = i_unn + 1;
                if (i_unn == union.Count) ch_err = ch_exp;
            }
          
            if (ch_err != '\0')
            {
                Console.WriteLine("Wrong arithmetic expression")
                ch_err = '\0'; 
            }

            ch_old = ch_exp; 

        }
    } while (arithmetic_expression == "");

ArrayList tokens = new ArrayList();
str_digits = string.Join("",digits);
string str_oper_paran = string.Join("",operators_paranthesis);
string str_digit = "";

foreach (var ch_exp in arithmetic_expression.Select((value, index) => (value,index)))
{
    if (-1 != str_oper_paran.IndexOf(ch_exp.value))
{ 
    tokens.Add(ch_exp.value);
}
    else if (-1 != str_digits.IndexOf(ch_exp.value)) 
    {
       str_digit = str_digit + ch_exp.value.ToString();
       if (ch_exp.index == arithmetic_expression.Length - 1) 
       {
           tokens.Add(int.Parse(str_digit)); 
       }
          else if(-1 == str_digits.IndexOf(arithmetic_expression[ch_exp.index+1]))
          {
              tokens.Add(int.Parse(str_digit)); 
              str_digit = "";
          }

    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Error");
        return; 
    }
    }

    Console.WriteLine("Tokens recieved:");
    foreach(var tok in tokens) Console.Write(tok + "   "); 
    Console.WriteLine();

    str_operators = string.Join("", operators);
    string str_paranthesis = string.Join("", paranthesis);

    string type_def(object data)
    {
        string type_def;
        string str_data = Convert.ToString(data); 

        if (data is int) type_def = "digital"; // true, çíà÷èò òèï int, òî åñòü digital
          else if (-1 != str_operators.IndexOf(str_data)) type_def = "operator";
            else if (-1 != str_paranthesis.IndexOf(str_data)) type_def = "parenthesis"; 
              else type_def = "error"; 
        return type_def;
    }

    ArrayList result = new ArrayList();
    var stack_prn = new Stack();
    string str_tok;
    string str_type;

    foreach (var tok in tokens)
    {
        str_tok = Convert.ToString(tok); 
        str_type = type_def(tok); 

        switch (str_type) 
        {
            case "digital":
                result.Add(tok);
                break;

            case "operator":
                while ((stack_prn.Count != 0) && (type_def(stack_prn.Peek()) == str_type) &&
                       (operators_priorities[Convert.ToString(stack_prn.Peek())] >= operators_priorities[str_tok]))
                {
                    result.Add(stack_prn.Pop());
                }

                stack_prn.Push(tok); 
                break;

            case "parenthesis":
                if (str_tok == "(") stack_prn.Push(str_tok);
                if (str_tok == ")")
                {
                    var topstack_prn = stack_prn.Pop();
                    while (!(topstack_prn.Equals("(")));
                    {
                        result.Add(topstack_prn);
                        topstack_prn = stack_prn.Pop();
                    }
                }

                break;

            case "error":
                Console.WriteLine();
                Console.WriteLine("Errorì");
                return; 
                break;
        }
    }

    while (stack_prn.Count != 0) result.Add(stack_prn.Pop());

    Console.WriteLine(“Reverse Polish Notation:");
    foreach(var i_res in result) Console.Write(i_res + "   ");
    Console.WriteLine();

    var stack_calc = new Stack();
    string str_res;
    double calculation = 0;
    
    foreach (var res in result)
    {
        str_res = Convert.ToString(res);
        str_type = type_def(res);
        
        switch (str_type)
        {
            case "digital":
                stack_calc.Push(res); 
                break;
            
            case "operator":
                double digit_1 = Convert.ToDouble(stack_calc.Pop()); 
                double digit_2 = Convert.ToDouble(stack_calc.Pop());
        
                switch (str_res) 
                {
                    case "^":
                        calculation =Math.Pow(digit_2, digit_1);
                        break;
                    
                    case "*":
                        calculation = digit_2 * digit_1;
                        break;
                    
                    case "/":
                        calculation = digit_2 / digit_1;
                        break;
                    
                    case "+":
                        calculation = digit_2 + digit_1;
                        break;
                    
                    case "-":
                        calculation = digit_2 - digit_1;
                        break;
                }
                stack_calc.Push(calculation); 
                break;
            
            case "error":
                Console.WriteLine();
                Console.WriteLine("Error");
                return; 
                break;
        }
        
    }
 
 calculation = Convert.ToDouble(stack_calc.Pop()); 
    Console.WriteLine("Calculations result:  " + calculation);

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
