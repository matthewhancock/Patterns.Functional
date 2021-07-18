using Xunit;

namespace Patterns.Functional.Types.UnitTests {
    public class OfTests {
        [Fact]
        public void UnwrappedValueComparison() {
            var value = "test";
            var ofValue = new UserID(value);

            Assert.Equal(value, ofValue);
        }

        [Fact]
        public void WrappedValueComparison() {
            var value = "test";
            var ofValueA = new UserID(value);
            var ofValueB = new ProfileID(value);

            // They're effectively the same value, but should not be considered equal
            Assert.NotEqual((Of<string>)ofValueA, ofValueB);
        }

        [Fact]
        public void HashCodeComparison() {
            var value = "test";
            var ofValueA = new UserID(value);
            var ofValueA2 = new UserID(value);
            var ofValueB = new ProfileID(value);

            Assert.Equal(ofValueA.GetHashCode(), ofValueA2.GetHashCode());
            Assert.NotEqual(ofValueA.GetHashCode(), ofValueB.GetHashCode());
        }

        private class UserID : Of<string> {
            public UserID(string Value) : base(Value) { }
        }
        private class ProfileID : Of<string> {
            public ProfileID(string Value) : base(Value) { }
        }
    }
}
