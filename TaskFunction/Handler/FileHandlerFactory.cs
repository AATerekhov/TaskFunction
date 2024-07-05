using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFunction.Handler
{
    public delegate Task<int> HandlerFunction(string filePath);
    public class FileHandlerFunction
    {
        public static async Task<int> GetCountSpaceAsync(string filePath)
        {
           return await Task.FromResult(ReadFileeAsync(filePath).Result.Count(Char.IsWhiteSpace));
        }
        static async Task<string> ReadFileeAsync(string filePath)
        {
            using var source = new StreamReader(filePath);
            return  source.ReadToEnd();
        }
        public static Task<int> GetCountSpace(string filePath)
        {
            return Task.FromResult(ReadFile(filePath).Count(Char.IsWhiteSpace));
        }
        static  string ReadFile(string filePath)
        {
            using var source = new StreamReader(filePath);
            return source.ReadToEnd();
        }
    }
}
