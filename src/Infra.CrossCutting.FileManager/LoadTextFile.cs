using Infra.CrossCutting.FileManager.Interfaces;
using System.Reflection;

namespace Infra.CrossCutting.FileManager
{
    public class LoadTextFile : ILoadTextFile
    {
        private readonly string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\Triangle.txt");

        public async Task<List<string>> LoadFile()
        {
            var linesList = new List<string>();

            using (FileStream fStream = File.OpenRead(path))
            {
                using var sr = new StreamReader(fStream);
                while (!sr.EndOfStream)
                {
                    linesList.Add(await sr.ReadLineAsync());
                }
            }

            return linesList;
        }
    }
}
