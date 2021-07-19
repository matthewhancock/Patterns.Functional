using System;
using Patterns.Functional.Types.Exceptions;
using Xunit;

namespace Patterns.Functional.Types.UnitTests {
    public class OneOfTests {
        [Fact]
        public void ResolveT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, result);
        }

        [Fact]
        public void ResolveT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, (int)result);
        }

        [Fact]
        public void ResolveAsT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, result.As<string>());
        }

        [Fact]
        public void ResolveAsT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, result.As<int>());
        }

        [Fact]
        public void ResolveAsOrDefaultT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, result.AsOrDefault<string>());
        }

        [Fact]
        public void ResolveAsOrDefaultT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            Assert.Equal(value, result.AsOrDefault<int>());
        }

        [Fact]
        public void ResolveT1_ImplicitSet() {
            var value = "test";

            var result = (OneOf<string, int>)value;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ResolveT2_ImplicitSet() {
            var value = 123;

            var result = (OneOf<string, int>)value;

            Assert.Equal(value, (int)result);
        }

        [Fact]
        public void TestSet1Then2() {
            var valueString = "test";
            var valueInt = 123;

            var result = new OneOf<string, int>();
            result.Set(valueString);
            result.Set(valueInt);

            Assert.Equal(valueInt, (int)result);
            Assert.Throws<OneOfTypeMismatchException>(() => (string)result);
        }

        [Fact]
        public void TestSet2Then1() {
            var valueString = "test";
            var valueInt = 123;

            var result = new OneOf<string, int>();
            result.Set(valueInt);
            result.Set(valueString);

            Assert.Equal(valueString, result);
            Assert.Throws<OneOfTypeMismatchException>(() => (int)result);
        }

        [Fact]
        public void SwitchT1() {
            var value = "test";

            var result = new OneOf<string, int>();
            result.Set(value);

            var called = false;
            result.Switch(
                s => {
                    Assert.Equal(value, s);
                    called = true;
                },
                i => throw new Exception("Method shouldn't be called"));

            Assert.True(called);
        }

        [Fact]
        public void SwitchT2() {
            var value = 123;

            var result = new OneOf<string, int>();
            result.Set(value);

            var called = false;
            result.Switch(
                s => throw new Exception("Method shouldn't be called"),
                i => {
                    Assert.Equal(value, i);
                    called = true;
                });

            Assert.True(called);
        }
    }
}
