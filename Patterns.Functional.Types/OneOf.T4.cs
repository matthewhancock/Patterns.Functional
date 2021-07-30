﻿using System;
using Patterns.Functional.Types.Exceptions;

namespace Patterns.Functional.Types {
    public struct OneOf<T1, T2, T3, T4>  {
        public OneOf(T1 Value) {
            Value1 = Value;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Type = OneOfTypeEnum.T1;
        }
        public OneOf(T2 Value) {
            Value1 = default;
            Value2 = Value;
            Value3 = default;
            Value4 = default;
            Type = OneOfTypeEnum.T2;
        }
        public OneOf(T3 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = Value;
            Value4 = default;
            Type = OneOfTypeEnum.T3;
        }
        public OneOf(T4 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        internal OneOfTypeEnum Type { get; private set; }
        internal T1 Value1 { get; private set; }
        internal T2 Value2 { get; private set; }
        internal T3 Value3 { get; private set; }
        internal T4 Value4 { get; private set; }

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
            } else if (typeof(TResult) == typeof(T4) && Type == OneOfTypeEnum.T4 && Value4 is TResult result4) {
                Result = result4;
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
            } else if (typeof(TResult) == typeof(T4) && Type == OneOfTypeEnum.T4 && Value4 is TResult result4) {
                return result4;
            }

            throw new OneOfTypeMismatchException();
        }

        public TResult AsOrDefault<TResult>(TResult Default = default) {
            if (typeof(TResult) == typeof(T1) && Type == OneOfTypeEnum.T1 && Value1 is TResult result1) {
                return result1;
            } else if (typeof(TResult) == typeof(T2) && Type == OneOfTypeEnum.T2 && Value2 is TResult result2) {
                return result2;
            } else if (typeof(TResult) == typeof(T3) && Type == OneOfTypeEnum.T3 && Value3 is TResult result3) {
                return result3;
            } else if (typeof(TResult) == typeof(T4) && Type == OneOfTypeEnum.T4 && Value4 is TResult result4) {
                return result4;
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
        public void Set(T4 Value) {
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3,Action<T4> Action4) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            } else if (Type == OneOfTypeEnum.T4) {
                Action4(Value4);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3, Func<T4, TResult> Func4)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                OneOfTypeEnum.T4 => Func4(Value4),
                _ => default
            };

        public object AsObject()
            => Type switch {
                OneOfTypeEnum.T1 => Value1,
                OneOfTypeEnum.T2 => Value2,
                OneOfTypeEnum.T3 => Value3,
                OneOfTypeEnum.T4 => Value4,
                _ => default
            };

        public static implicit operator T1(OneOf<T1, T2, T3, T4> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T1 ? OneOfValue.Value1 : throw new OneOfTypeMismatchException();
        public static implicit operator T2(OneOf<T1, T2, T3, T4> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T2 ? OneOfValue.Value2 : throw new OneOfTypeMismatchException();
        public static implicit operator T3(OneOf<T1, T2, T3, T4> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T3 ? OneOfValue.Value3 : throw new OneOfTypeMismatchException();
        public static implicit operator T4(OneOf<T1, T2, T3, T4> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T4 ? OneOfValue.Value4 : throw new OneOfTypeMismatchException();

        public static implicit operator OneOf<T1, T2, T3, T4>(T1 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4>(T2 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4>(T3 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4>(T4 OneOfValue) => new(OneOfValue);
    }
}
