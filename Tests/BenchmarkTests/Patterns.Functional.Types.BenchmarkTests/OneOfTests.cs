using BenchmarkDotNet.Attributes;

namespace Patterns.Functional.Types.BenchmarkTests {
    /*
    |                         Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
    |                      ResolveT1 | 2.3516 ns | 0.0804 ns | 0.2372 ns | 2.3498 ns |      - |     - |     - |         - |
    |                      ResolveT2 | 0.0736 ns | 0.0331 ns | 0.0971 ns | 0.0114 ns |      - |     - |     - |         - |
    |                SwitchResolveT1 | 4.4350 ns | 0.1744 ns | 0.5142 ns | 4.4423 ns |      - |     - |     - |         - |
    |                SwitchResolveT2 | 3.4222 ns | 0.1779 ns | 0.5246 ns | 3.4716 ns |      - |     - |     - |         - |
    |       External_OneOf_ResolveT1 | 6.0841 ns | 0.1714 ns | 0.5027 ns | 6.1563 ns |      - |     - |     - |         - |
    |       External_OneOf_ResolveT2 | 6.1170 ns | 0.2727 ns | 0.8040 ns | 6.1293 ns | 0.0057 |     - |     - |      24 B |
    | External_OneOf_SwitchResolveT1 | 6.0534 ns | 0.2318 ns | 0.6836 ns | 6.0795 ns |      - |     - |     - |         - |
    | External_OneOf_SwitchResolveT2 | 5.9486 ns | 0.1870 ns | 0.5513 ns | 5.9095 ns |      - |     - |     - |         - |
    */

    [MemoryDiagnoser]
    public class OneOfTests {
        [Benchmark]
        public void ResolveT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            string resolved = result;
            //System.Console.WriteLine($"{nameof(ResolveT1)} - {resolved}");
        }

        [Benchmark]
        public void ResolveT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            int resolved = result;
            //System.Console.WriteLine($"{nameof(ResolveT2)} - {resolved}");
        }

        //[Benchmark]
        //public void ResolveAsT1() {
        //    var value = "test";

        //    var result = new OneOf<string, int>();
        //    result.Set(value);

        //    var resolved = result.As<string>();
        //}

        //[Benchmark]
        //public void ResolveAsT2() {
        //    var value = 123;

        //    var result = new OneOf<string, int>();
        //    result.Set(value);

        //    var resolved = result.As<int>();
        //}

        //[Benchmark]
        //public void ResolveT1_ImplicitSet() {
        //    var value = "test";

        //    var result = (OneOf<string, int>)value;

        //    string resolved = result;
        //    //System.Console.WriteLine($"{nameof(ResolveT1_ImplicitSet)} - {resolved}");
        //}

        //[Benchmark]
        //public void ResolveT2_ImplicitSet() {
        //    var value = 123;

        //    var result = (OneOf<string, int>)value;

        //    int resolved = result;
        //    //System.Console.WriteLine($"{nameof(ResolveT2_ImplicitSet)} - {resolved}");
        //}

        //[Benchmark]
        //public void SwitchResolveT1_LocalVariables() {
        //    var value = "test";

        //    var result = (OneOf<string, int>)value;

        //    string resolved;
        //    result.Switch(v => resolved = v, _ => { });
        //}

        //[Benchmark]
        //public void SwitchResolveT2_LocalVariables() {
        //    var value = 123;

        //    var result = (OneOf<string, int>)value;

        //    int resolved;
        //    result.Switch(_ => { }, v => resolved = v);
        //}

        [Benchmark]
        public void SwitchResolveT1() {
            var value = "test";

            var result = (OneOf<string, int>)value;

            result.Switch(v => { var resolved = v; }, _ => { });
        }

        [Benchmark]
        public void SwitchResolveT2() {
            var value = 123;

            var result = (OneOf<string, int>)value;

            result.Switch(_ => { }, v => { var resolved = v; });
        }

        [Benchmark]
        public void External_OneOf_ResolveT1() {
            var value = "test";

            var result = (global::OneOf.OneOf<string, int>)value;

            string resolved = (string)result.Value;
            //System.Console.WriteLine($"{nameof(External_OneOf_ResolveT1)} - {resolved}");
        }

        [Benchmark]
        public void External_OneOf_ResolveT2() {
            var value = 123;

            var result = (global::OneOf.OneOf<string, int>)value;

            int resolved = (int)result.Value;
            //System.Console.WriteLine($"{nameof(External_OneOf_ResolveT2)} - {resolved}");
        }

        //[Benchmark]
        //public void External_OneOf_SwitchResolveT1_LocalVariables() {
        //    var value = "test";

        //    var result = (global::OneOf.OneOf<string, int>)value;

        //    string resolved;
        //    result.Switch(v => resolved = v, _ => { });
        //}

        //[Benchmark]
        //public void External_OneOf_SwitchResolveT2_LocalVariables() {
        //    var value = 123;

        //    var result = (global::OneOf.OneOf<string, int>)value;

        //    int resolved = (int)result.Value;
        //    result.Switch(_ => { }, v => resolved = v);
        //}

        [Benchmark]
        public void External_OneOf_SwitchResolveT1() {
            var value = "test";

            var result = (global::OneOf.OneOf<string, int>)value;

            result.Switch(v => { var resolved = v; }, _ => { });
        }

        [Benchmark]
        public void External_OneOf_SwitchResolveT2() {
            var value = 123;

            var result = (global::OneOf.OneOf<string, int>)value;

            result.Switch(_ => { }, v => { var resolved = v; });
        }
    }
}
