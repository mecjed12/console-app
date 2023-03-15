// See https://aka.ms/new-console-template for more information

// test 1



using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;
using System.Text;

ConsoleHelper consoleHelper = new ConsoleHelper();
Registring registring = new Registring(consoleHelper);
UserService userService = new UserService(registring, consoleHelper);
UserOptions userOptions = new UserOptions(consoleHelper);



//SomeTests.SomeExamples();
UserInterface userInterface = new UserSurface(consoleHelper, userService, userOptions);

userInterface.Main();

Environment.Exit(0);





int varA = 1;
int? varC;
bool? varD;
string str1;
MyClass test1;

ValueChanger.Change(varA, 5);

Console.WriteLine($"varA {varA}");


// test 1

string varB = "1";

ValueChanger.Change(ref varB, "5");

Console.WriteLine($"varA {varB}");

// test 2

var ref1 = new MyClass(1);

ValueChanger.Change(ref1, 10);

Console.WriteLine($"ref1 {ref1.id}");

var test = new StringBuilder("asdjflkajsdlökfjaslökdjflökasdjflkjasdlkjfsadklj");
test.AppendLine("");


Console.ReadLine();

class MyClass
{
    public MyClass(int id)
    {
        this.id = id;   
    }

    public int? id;
}



static class ValueChanger
{
   public static  int Change(int value, int newValue)
    {
        Console.WriteLine(value);

        value = newValue;

        Console.WriteLine(value);
        return value;
    }

    public static void Change(ref string value, string newValue)
    {
        Console.WriteLine(value);

        value = newValue;

        Console.WriteLine(value);
    }

    public static void Change(MyClass obj, int newValue)
    {
        Console.WriteLine(obj.id);

        obj.id = newValue;

        Console.WriteLine(obj.id);
    }

}


