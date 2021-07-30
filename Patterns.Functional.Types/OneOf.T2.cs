using System;
using Patterns.Functional.Types.Exceptions;

namespace Patterns.Functional.Types {
    public struct OneOf<T1, T2> {
        public OneOf(T1 Value) {
            Value1 = Value;
            Value2 = default;
            Type = OneOfTypeEnum.T1;
        }

        public OneOf(T2 Value) {
            Value1 = default;
            Value2 = Value;
            Type = OneOfTypeEnum.T2;
        }

        internal OneOfTypeEnum Type { get; private set; }

        internal T1 Value1 { get; private set; }
        internal T2 Value2 { get; private set; }

        public bool TryAs<TResult>(out TResult Result) {
            if (typeof(TResult) == typeof(T1) && Type == OneOfTypeEnum.T1 && Value1 is TResult result1) {
                Result = result1;
                return true;
            } else if (typeof(TResult) == typeof(T2) && Type == OneOfTypeEnum.T2 && Value2 is TResult result2) {
                Result = result2;
                return true;
            }

            Result = default;
            return false;
        }

        public TResult As<TResult>() {
            if (typeof(TResult) == typeof(T1) && Type == OneOfTypeEnum.T1 && Value1 is TResult result1) {
                return result1;
            } else if (typeof(TResult) == typeof(T2) && Type == OneOfTypeEnum.T2 && Value2 is TResult result2) {
                return result2;
            }

            throw new OneOfTypeMismatchException();
        }

        public TResult AsOrDefault<TResult>(TResult Default = default) {
            if (typeof(TResult) == typeof(T1) && Type == OneOfTypeEnum.T1 && Value1 is TResult result1) {
                return result1;
            } else if (typeof(TResult) == typeof(T2) && Type == OneOfTypeEnum.T2 && Value2 is TResult result2) {
                return result2;
            }

            return Default;
        }
        public void Set(T1 Value) {
            Value1 = Value;
            Type = OneOfTypeEnum.T1;
        }

        public void Set(T2 Value) {
            Value2 = Value;
            Type = OneOfTypeEnum.T2;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                _ => default
            };

        public object AsObject()
            => Type switch {
                OneOfTypeEnum.T1 => Value1,
                OneOfTypeEnum.T2 => Value2,
                _ => default
            };

        public static implicit operator T1(OneOf<T1, T2> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T1 ? OneOfValue.Value1 : throw GetTypeMismatchException();
        public static implicit operator T2(OneOf<T1, T2> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T2 ? OneOfValue.Value2 : throw GetTypeMismatchException();

        public static implicit operator OneOf<T1, T2>(T1 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2>(T2 OneOfValue) => new(OneOfValue);

        private static Exception GetTypeMismatchException() => new OneOfTypeMismatchException();
    }
}
