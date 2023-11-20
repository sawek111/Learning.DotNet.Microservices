namespace OOP;

public abstract class A
{
    public void MakeAction()
    {
        Console.WriteLine(" Normal Action AAAAAAAA");
    }
    
    public abstract void MakeAbstractAction();
    public virtual void MakeVirtualAction()
    {
        Console.WriteLine("Virtual action AAAAAAAA");
    }
}

public class B : A
{
    public override void MakeAbstractAction()
    {
        Console.WriteLine("BBBBBBBB");
    }
    
    public override void MakeVirtualAction()
    {
        base.MakeVirtualAction();
        Console.WriteLine("Virtual action BBBBBBBB");
    } 
    
    public new void MakeAction()
    {
        Console.WriteLine("Normal Action BBBBBBBB");
    }
}

public class C : B
{
    public override void MakeAbstractAction()
    {
        Console.WriteLine("CCCCC");
    }
    
    public override void MakeVirtualAction()
    {
        base.MakeVirtualAction();
        Console.WriteLine("Virtual action CCCCCCC");
    } 
    
    public new void MakeAction()
    {
        Console.WriteLine("Normal Action CCCCCCC");
    }
}