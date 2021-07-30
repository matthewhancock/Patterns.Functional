using BenchmarkDotNet.Attributes;

namespace Patterns.Functional.Types.BenchmarkTests {
    /*
    |                         Method |       Mean |     Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------------------------- |-----------:|----------:|----------:|-----------:|-------:|------:|------:|----------:|
    |                      ResolveT1 |  2.3847 ns | 0.0477 ns | 0.0810 ns |  2.3675 ns |      - |     - |     - |         - |
    |                      ResolveT2 |  0.0295 ns | 0.0251 ns | 0.0447 ns |  0.0000 ns |      - |     - |     - |         - |
    |                SwitchResolveT1 |  3.8364 ns | 0.1127 ns | 0.1580 ns |  3.8385 ns |      - |     - |     - |         - |
    |                SwitchResolveT2 | 15.6131 ns | 0.1618 ns | 0.1514 ns | 15.6470 ns |      - |     - |     - |         - |
    |               SwitchExpression | 20.7905 ns | 0.4339 ns | 0.5166 ns | 20.6883 ns | 0.0057 |     - |     - |      24 B |
    |       External_OneOf_ResolveT1 | 12.8813 ns | 1.2897 ns | 3.8027 ns | 14.1356 ns |      - |     - |     - |         - |
    |       External_OneOf_ResolveT2 | 17.5337 ns | 0.8081 ns | 2.3826 ns | 17.9870 ns | 0.0057 |     - |     - |      24 B |
    | External_OneOf_SwitchResolveT1 | 16.4822 ns | 0.3161 ns | 0.2957 ns | 16.4892 ns |      - |     - |     - |         - |
    | External_OneOf_SwitchResolveT2 | 18.6922 ns | 0.4006 ns | 0.6692 ns | 18.8295 ns |      - |     - |     - |         - |
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
        public void SwitchExpression() {
            OneOf<string, int> result = 123;

            var test = result.AsObject() switch {
                int => true,
                _ => false
            };

            _ = test;
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
