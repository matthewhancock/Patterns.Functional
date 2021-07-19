using System;
using Patterns.Functional.Types.Exceptions;
using Patterns.Functional.Types.Interfaces;

namespace Patterns.Functional.Types {
    public struct OneOf<T1, T2, T3> : IOneOf<T1, T2, T3>, IOneOf {
        public OneOf(T1 Value) {
            Value1 = Value;
            Value2 = default;
            Value3 = default;
            Type = OneOfTypeEnum.T1;
        }
        public OneOf(T2 Value) {
            Value1 = default;
            Value2 = Value;
            Value3 = default;
            Type = OneOfTypeEnum.T2;
        }
        public OneOf(T3 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        internal OneOfTypeEnum Type { get; private set; }
        internal T1 Value1 { get; private set; }
        internal T2 Value2 { get; private set; }
        internal T3 Value3 { get; private set; }

        OneOfTypeEnum IOneOf.Type => Type;
        T1 IOneOf<T1, T2, T3>.Value1 => Value1;
        T2 IOneOf<T1, T2, T3>.Value2 => Value2;
        T3 IOneOf<T1, T2, T3>.Value3 => Value3;

        public bool TryAs<TResult>(out TResult Result) {
            if (typeof(TResult) == typeof(T1) && Type == OneOfTypeEnum.T1 && Value1 is TResult result1) {
                Result = result1;
                return true;
            } else if (typeof(TResult) == typeof(T2) && Type == OneOfTypeEnum.T2 && Value2 is TResult result2) {
                Result = result2;
                return true;
            } else if (typeof(TResult) == typeof(T3) && Type == OneOfTypeEnum.T3 && Value3 is TResult result3) {
                Result = result3;
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
            } else if (typeof(TResult) == typeof(T3) && Type == OneOfTypeEnum.T3 && Value3 is TResult result3) {
                return result3;
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
        public void Set(T3 Value) {
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3) => Util.OneOf.Switch(this, Action1, Action2, Action3);

        public static implicit operator T1(OneOf<T1, T2, T3> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T1 ? OneOfValue.Value1 : throw new OneOfTypeMismatchException();
        public static implicit operator T2(OneOf<T1, T2, T3> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T2 ? OneOfValue.Value2 : throw new OneOfTypeMismatchException();
        public static implicit operator T3(OneOf<T1, T2, T3> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T3 ? OneOfValue.Value3 : throw new OneOfTypeMismatchException();

        public static implicit operator OneOf<T1, T2, T3>(T1 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3>(T2 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3>(T3 OneOfValue) => new(OneOfValue);
    }
}
