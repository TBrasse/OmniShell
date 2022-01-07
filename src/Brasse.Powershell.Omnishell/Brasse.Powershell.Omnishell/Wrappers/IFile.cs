namespace Omnishell.Core
{
    internal interface IFile
    {
        string ReadAllText(string path);
        void WriteAllText(string path, string configJson);
    }
}
