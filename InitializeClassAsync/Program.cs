using System;
using System.Threading.Tasks;

namespace InitializeClassAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstClass.UseFirstClassAsync();
            var second = new SecondClass();
            Console.Write("Press enter to exit...\n");
            Console.ReadLine();
        } 

    } // end class Program


    //////////////////// FIRST APPROACH ////////////////////
    public class FirstClass
    {
        public FirstClass()
        {
            
        }

        private async Task<FirstClass> InitializeAsync()
        {
            Console.Write("FirstClass Timer Started\n");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("FirstClass Timer Ended\n");
            return this;
        }

        public static Task<FirstClass> CreateAsync()
        {
            var result = new FirstClass();
            return result.InitializeAsync();
        }

        public static async Task UseFirstClassAsync()
        {
            FirstClass instance = await FirstClass.CreateAsync();
        }

    } // end class FirstClass

    //////////////////// SECOND APPROACH ////////////////////
    public interface IAsync
    {
        Task Initialization { get; }

    } // end interface IAsync

    public class SecondClass: IAsync
    {
        public SecondClass()
        {
            Initialization = InitializeAsync();
        }

        public Task Initialization { get; set; }

        async Task InitializeAsync()
        {
            Console.Write("SecondClass Timer Started\n");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.Write("SecondClass Timer Ended\n");
        }

    } // end class SecondClass: IAsync

} // end namespace InitializeClassAsync

