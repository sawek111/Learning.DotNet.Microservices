// See https://aka.ms/new-console-template for more information

using OOP;

var actions = new A[] { new B(), new C() };
Console.WriteLine("--------------------");
foreach (A action in actions)
{
    Console.WriteLine(action.GetType());
    action.MakeAction();
    action.MakeAbstractAction();
    action.MakeVirtualAction();
}
Console.WriteLine("--------------------");

var actionD = new D();
