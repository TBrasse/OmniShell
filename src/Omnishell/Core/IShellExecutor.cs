namespace Core
{
    public interface IShellExecutor
    {
        string Execute(string expression);
        string Execute(string[] expressions);
    }
}
