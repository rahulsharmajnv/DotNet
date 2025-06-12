namespace DIExampleProject.Delegates;
public class DelegateType
{
    public delegate string GreetingDelegate(string name);
    public delegate void LoggerDelegate(string message);
    public delegate int MathOperation(int x, int y);
}