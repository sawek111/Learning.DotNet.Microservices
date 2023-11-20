namespace Net8._0Features.FileScope;

public class PublicClass
{
    // Cannot be field of class
    // private static MyFileTestClass field = new MyFileTestClass(2, 4);
}

file class FileClass()
{
    private static MyFileTestClass field = new MyFileTestClass(2, 4);
}


file record MyFileTestClass(int X, int Y);
