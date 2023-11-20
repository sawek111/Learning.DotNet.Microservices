namespace OOP;

public abstract class A
{
    static A()
    {
        Console.WriteLine(" Static constructor AAAAAAAAA");
    }
    
    protected A()
    {
        Console.WriteLine("A constructor");
        PrivateAction();
    }
    
    public void MakeAction()
    {
        Console.WriteLine(" Normal Action AAAAAAAA");
    }
    
    public abstract void MakeAbstractAction();
    public virtual void MakeVirtualAction()
    {
        Console.WriteLine("Virtual action AAAAAAAA");
    }
    
    private void PrivateAction()
    {
        Console.WriteLine("Private action AAAAAAAA");
    }
}

public class B : A
{
    public B()
    {
        Console.WriteLine("B constructor");
    }
    
    
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
    public C()
    {
        Console.WriteLine("C constructor");
    }

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

public class D : C
{
    static D()
    {
        Console.WriteLine(" Static constructor DDDDDDD");
    }
    public D()
    {
        Console.WriteLine("D constructor");
    }

    public override void MakeAbstractAction()
    {
        Console.WriteLine("DDDDDD");
    }
    
    public override void MakeVirtualAction()
    {
        base.MakeVirtualAction();
        Console.WriteLine("Virtual action DDDDDDD");
    } 
    
    public new void MakeAction()
    {
        Console.WriteLine("Normal Action DDDDDDD");
    }
}