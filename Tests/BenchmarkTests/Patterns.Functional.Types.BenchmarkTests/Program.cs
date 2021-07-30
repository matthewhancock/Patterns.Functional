using BenchmarkDotNet.Running;

namespace Patterns.Functional.Types.BenchmarkTests {
    class Program {
        static void Main(string[] args) {
            //BenchmarkRunner.Run(typeof(OfTests));
            BenchmarkRunner.Run(typeof(OneOfTests));
        }
    }
}
