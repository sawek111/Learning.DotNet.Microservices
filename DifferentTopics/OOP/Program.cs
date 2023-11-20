// See https://aka.ms/new-console-template for more information

using OOP;

var actions = new A[] { new B(), new C() };

foreach (A action in actions)
{
    Console.WriteLine(action.GetType());
    action.MakeAction();
    action.MakeAbstractAction();
    action.MakeVirtualAction();
}
//
// OOP.B
//     Normal Action AAAAAAAA
// BBBBBBBB
//     Virtual action AAAAAAAA
// Virtual action BBBBBBBB
// OOP.C
//     Normal Action AAAAAAAA
// CCCCC
//     Virtual action AAAAAAAA
// Virtual action BBBBBBBB
//     Virtual action CCCCCCC