using Nito.AsyncEx;
using Nito.AsyncEx.Synchronous;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Module3Hw4
{
   public class Program
    {
       public static async Task<string> ReadHelloAsync(string path)
        {
            var hello = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                     hello = await sr.ReadToEndAsync();
                     return hello;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message.ToString();
            }
            
        }
       public  static async Task<string> ReadWorldAsync(string path)
        {
            var hello = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    hello = await sr.ReadToEndAsync();
                    return hello;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message.ToString();
            }

        }
        public static async Task<string> Ran(string path, string path2)
        {
            var a = await ReadHelloAsync(path);
            var b = await ReadWorldAsync(path2);
            return a+b;
        }
            static async Task Main()
        {
            var task = Task.Run(async () => await Ran("Hello.txt", "World.txt"));
            var result = task.WaitAndUnwrapException();
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
