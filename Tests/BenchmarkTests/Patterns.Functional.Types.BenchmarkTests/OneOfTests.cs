using BenchmarkDotNet.Attributes;

namespace Patterns.Functional.Types.BenchmarkTests {
    /*
    |                   Method |       Mean |     Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------------------- |-----------:|----------:|----------:|-----------:|-------:|------:|------:|----------:|
    |                ResolveT1 |  0.0037 ns | 0.0071 ns | 0.0118 ns |  0.0000 ns |      - |     - |     - |         - |
    |                ResolveT2 |  0.0526 ns | 0.0298 ns | 0.0649 ns |  0.0288 ns |      - |     - |     - |         - |
    |      ResolveAsT1 (TryAs) | 10.8846 ns | 0.2620 ns | 0.5468 ns | 10.8728 ns |      - |     - |     - |         - |
    |      ResolveAsT2 (TryAs) | 20.6410 ns | 0.4563 ns | 0.8792 ns | 20.7533 ns |      - |     - |     - |         - |
    |    ResolveT1_ImplicitSet |  0.0055 ns | 0.0111 ns | 0.0327 ns |  0.0000 ns |      - |     - |     - |         - |
    |    ResolveT2_ImplicitSet |  0.0211 ns | 0.0196 ns | 0.0576 ns |  0.0000 ns |      - |     - |     - |         - |
    | External_OneOf_ResolveT1 |  4.1650 ns | 0.0882 ns | 0.2588 ns |  4.1284 ns |      - |     - |     - |         - |
    | External_OneOf_ResolveT2 |  5.4281 ns | 0.1945 ns | 0.5736 ns |  5.3840 ns | 0.0057 |     - |     - |      24 B |
    */

    /*
    |                   Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
    |                ResolveT1 | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |      - |     - |     - |         - |
    |                ResolveT2 | 0.0164 ns | 0.0157 ns | 0.0331 ns | 0.0000 ns |      - |     - |     - |         - |
    |              ResolveAsT1 | 8.5133 ns | 0.2107 ns | 0.4668 ns | 8.4970 ns |      - |     - |     - |         - |
    |              ResolveAsT2 | 5.7923 ns | 0.1604 ns | 0.3347 ns | 5.7810 ns |      - |     - |     - |         - |
    |    ResolveT1_ImplicitSet | 0.0400 ns | 0.0274 ns | 0.0687 ns | 0.0000 ns |      - |     - |     - |         - |
    |    ResolveT2_ImplicitSet | 1.1122 ns | 0.4958 ns | 1.4618 ns | 0.0777 ns |      - |     - |     - |         - |
    | External_OneOf_ResolveT1 | 4.1291 ns | 0.0904 ns | 0.2302 ns | 4.1052 ns |      - |     - |     - |         - |
    | External_OneOf_ResolveT2 | 4.6866 ns | 0.4405 ns | 1.2850 ns | 5.0906 ns | 0.0057 |     - |     - |      24 B |
    */

    /*
    |                                 Method |       Mean |     Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |--------------------------------------- |-----------:|----------:|----------:|-----------:|-------:|------:|------:|----------:|
    |                              ResolveT1 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |     - |     - |         - |
    |                              ResolveT2 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |     - |     - |         - |
    |                            ResolveAsT1 |  6.1968 ns | 0.1344 ns | 0.1192 ns |  6.1987 ns |      - |     - |     - |         - |
    |                            ResolveAsT2 |  4.3489 ns | 0.1175 ns | 0.1486 ns |  4.3570 ns |      - |     - |     - |         - |
    |                  ResolveT1_ImplicitSet |  0.0164 ns | 0.0203 ns | 0.0226 ns |  0.0015 ns |      - |     - |     - |         - |
    |                  ResolveT2_ImplicitSet |  0.0079 ns | 0.0131 ns | 0.0116 ns |  0.0000 ns |      - |     - |     - |         - |
    |                SwitchResolveT1 (Local) | 10.2616 ns | 0.1642 ns | 0.1371 ns | 10.2827 ns | 0.0210 |     - |     - |      88 B |
    |                SwitchResolveT2 (Local) |  9.5118 ns | 0.2159 ns | 0.2120 ns |  9.4391 ns | 0.0210 |     - |     - |      88 B |
    |               External_OneOf_ResolveT1 |  2.4454 ns | 0.0375 ns | 0.0351 ns |  2.4338 ns |      - |     - |     - |         - |
    |               External_OneOf_ResolveT2 |  3.5538 ns | 0.0908 ns | 0.0849 ns |  3.5621 ns | 0.0057 |     - |     - |      24 B |
    | External_OneOf_SwitchResolveT1 (Local) | 10.4033 ns | 0.1897 ns | 0.1774 ns | 10.4137 ns | 0.0210 |     - |     - |      88 B |
    | External_OneOf_SwitchResolveT2 (Local) | 13.7701 ns | 0.3032 ns | 0.4631 ns | 13.5941 ns | 0.0268 |     - |     - |     112 B |
    */

    /*
    |                         Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |------------------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
    |                      ResolveT1 | 0.0082 ns | 0.0146 ns | 0.0137 ns | 0.0000 ns |      - |     - |     - |         - |
    |                      ResolveT2 | 0.0207 ns | 0.0155 ns | 0.0145 ns | 0.0248 ns |      - |     - |     - |         - |
    |                    ResolveAsT1 | 5.8677 ns | 0.1456 ns | 0.1558 ns | 5.9247 ns |      - |     - |     - |         - |
    |                    ResolveAsT2 | 4.3142 ns | 0.0814 ns | 0.0761 ns | 4.3259 ns |      - |     - |     - |         - |
    |          ResolveT1_ImplicitSet | 0.0043 ns | 0.0082 ns | 0.0077 ns | 0.0000 ns |      - |     - |     - |         - |
    |          ResolveT2_ImplicitSet | 0.0090 ns | 0.0094 ns | 0.0088 ns | 0.0069 ns |      - |     - |     - |         - |
    |                SwitchResolveT1 | 2.8752 ns | 0.0733 ns | 0.0685 ns | 2.8678 ns |      - |     - |     - |         - |
    |                SwitchResolveT2 | 2.8860 ns | 0.0789 ns | 0.0659 ns | 2.8852 ns |      - |     - |     - |         - |
    |       External_OneOf_ResolveT1 | 3.9285 ns | 0.0768 ns | 0.1077 ns | 3.9266 ns |      - |     - |     - |         - |
    |       External_OneOf_ResolveT2 | 3.6731 ns | 0.1026 ns | 0.2209 ns | 3.5840 ns | 0.0057 |     - |     - |      24 B |
    | External_OneOf_SwitchResolveT1 | 3.2903 ns | 0.0540 ns | 0.0505 ns | 3.2713 ns |      - |     - |     - |         - |
    | External_OneOf_SwitchResolveT2 | 3.6369 ns | 0.0968 ns | 0.1076 ns | 3.6531 ns |      - |     - |     - |         - |
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

        [Benchmark]
        public void ResolveAsT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            var resolved = result.As<string>();
        }

        [Benchmark]
        public void ResolveAsT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            var resolved = result.As<int>();
        }

        [Benchmark]
        public void ResolveT1_ImplicitSet() {
            var value = "test";

            var result = (OneOf<string, int>)value;

            string resolved = result;
            //System.Console.WriteLine($"{nameof(ResolveT1_ImplicitSet)} - {resolved}");
        }

        [Benchmark]
        public void ResolveT2_ImplicitSet() {
            var value = 123;

            var result = (OneOf<string, int>)value;

            int resolved = result;
            //System.Console.WriteLine($"{nameof(ResolveT2_ImplicitSet)} - {resolved}");
        }

        [Benchmark]
        public void SwitchResolveT1_LocalVariables() {
            var value = "test";

            var result = (OneOf<string, int>)value;

            string resolved;
            result.Switch(v => resolved = v, _ => { });
        }

        [Benchmark]
        public void SwitchResolveT2_LocalVariables() {
            var value = 123;

            var result = (OneOf<string, int>)value;

            int resolved;
            result.Switch(_ => { }, v => resolved = v);
        }

        [Benchmark]
        public void SwitchResolveT1() {
            var value = "test";

            var result = (OneOf<string, int>)value;

            result.Switch(v => { var resolved = v; }, _ => { });
        }

        [Benchmark]
        public void SwitchResolveT2_NoLocalVariables() {
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

        [Benchmark]
        public void External_OneOf_SwitchResolveT1_LocalVariables() {
            var value = "test";

            var result = (global::OneOf.OneOf<string, int>)value;

            string resolved;
            result.Switch(v => resolved = v, _ => { });
        }

        [Benchmark]
        public void External_OneOf_SwitchResolveT2_LocalVariables() {
            var value = 123;

            var result = (global::OneOf.OneOf<string, int>)value;

            int resolved = (int)result.Value;
            result.Switch(_ => { }, v => resolved = v);
        }

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
