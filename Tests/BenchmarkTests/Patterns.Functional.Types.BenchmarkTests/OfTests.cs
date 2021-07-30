using BenchmarkDotNet.Attributes;

namespace Patterns.Functional.Types.BenchmarkTests {
    [MemoryDiagnoser]
    public class OfTests {
        [Benchmark]
        public bool UnwrappedValueComparison() {
            var value = "test";
            var ofValue = new UserID(value);

            return value == ofValue;
        }

        [Benchmark]
        public bool WrappedValueComparison() {
            var value = "test";
            var ofValueA = new UserID(value);
            var ofValueB = new ProfileID(value);

            // They're effectively the same value, but should not be considered equal
            return ofValueA != ofValueB;
        }

        [Benchmark]
        public bool HashCodeComparison() {
            var value = "test";
            var ofValueA = new UserID(value);
            var ofValueA2 = new UserID(value);
            var ofValueB = new ProfileID(value);

            return ofValueA.GetHashCode() == ofValueA2.GetHashCode()
                && ofValueA.GetHashCode() != ofValueB.GetHashCode();
        }

        private class UserID : Of<string> {
            public UserID(string Value) : base(Value) { }
        }
        private class ProfileID : Of<string> {
            public ProfileID(string Value) : base(Value) { }
        }
    }
}
