
Console.WriteLine("Please enter the first operand:");
int op1 = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Please enter the second operand:");
int op2 = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Please enter the operator:\n" +
  "[A]ddition\n" +
  "[S]ubtraction\n" +
  "[M]ultiplication");

char op = char.Parse(Console.ReadLine() ?? " ");

int result;
if (op == 'A' || op == 'a') {
    result = op1 + op2;
} else if (op == 'S' || op == 's') {
    result = op1 - op2;
} else if (op == 'M' || op == 'm') {
    result = op1 * op2;
} else {
    Console.WriteLine("Invalid operator.");
    return;
}

Console.WriteLine("The result of " + op1 + " " + op + " " + op2 + " is: " + result);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
