using System.Text;

namespace Omnishell.Core
{
    internal class File : IFile
    {
        public string ReadAllText(string path)
        {
            return System.IO.File.ReadAllText(path, Encoding.UTF8);
        }

        public void WriteAllText(string path, string configJson)
        {
            System.IO.File.WriteAllText(path, configJson, Encoding.UTF8);
        }
    }
}
