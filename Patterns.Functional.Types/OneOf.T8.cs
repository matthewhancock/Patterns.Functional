﻿using System;
using Patterns.Functional.Types.Exceptions;
using Patterns.Functional.Types.Interfaces;

namespace Patterns.Functional.Types {
    public struct OneOf<T1, T2, T3, T4, T5, T6, T7, T8> : IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>, IOneOf {
        public OneOf(T1 Value) {
            Value1 = Value;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Value5 = default;
            Value6 = default;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T1;
        }
        public OneOf(T2 Value) {
            Value1 = default;
            Value2 = Value;
            Value3 = default;
            Value4 = default;
            Value5 = default;
            Value6 = default;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T2;
        }
        public OneOf(T3 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = Value;
            Value4 = default;
            Value5 = default;
            Value6 = default;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T3;
        }
        public OneOf(T4 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = Value;
            Value5 = default;
            Value6 = default;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T4;
        }
        public OneOf(T5 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Value5 = Value;
            Value6 = default;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T5;
        }
        public OneOf(T6 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Value5 = default;
            Value6 = Value;
            Value7 = default;
            Value8 = default;
            Type = OneOfTypeEnum.T6;
        }
        public OneOf(T7 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Value5 = default;
            Value6 = default;
            Value7 = Value;
            Value8 = default;
            Type = OneOfTypeEnum.T7;
        }
        public OneOf(T8 Value) {
            Value1 = default;
            Value2 = default;
            Value3 = default;
            Value4 = default;
            Value5 = default;
            Value6 = default;
            Value7 = default;
            Value8 = Value;
            Type = OneOfTypeEnum.T8;
        }

        internal OneOfTypeEnum Type { get; private set; }
        internal T1 Value1 { get; private set; }
        internal T2 Value2 { get; private set; }
        internal T3 Value3 { get; private set; }
        internal T4 Value4 { get; private set; }
        internal T5 Value5 { get; private set; }
        internal T6 Value6 { get; private set; }
        internal T7 Value7 { get; private set; }
        internal T8 Value8 { get; private set; }

        OneOfTypeEnum IOneOf.Type => Type;
        T1 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value1 => Value1;
        T2 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value2 => Value2;
        T3 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value3 => Value3;
        T4 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value4 => Value4;
        T5 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value5 => Value5;
        T6 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value6 => Value6;
        T7 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value7 => Value7;
        T8 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value8 => Value8;

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
            } else if (typeof(TResult) == typeof(T5) && Type == OneOfTypeEnum.T5 && Value5 is TResult result5) {
                Result = result5;
                return true;
            } else if (typeof(TResult) == typeof(T6) && Type == OneOfTypeEnum.T6 && Value6 is TResult result6) {
                Result = result6;
                return true;
            } else if (typeof(TResult) == typeof(T7) && Type == OneOfTypeEnum.T7 && Value7 is TResult result7) {
                Result = result7;
                return true;
            } else if (typeof(TResult) == typeof(T8) && Type == OneOfTypeEnum.T8 && Value8 is TResult result8) {
                Result = result8;
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
            } else if (typeof(TResult) == typeof(T5) && Type == OneOfTypeEnum.T5 && Value5 is TResult result5) {
                return result5;
            } else if (typeof(TResult) == typeof(T6) && Type == OneOfTypeEnum.T6 && Value6 is TResult result6) {
                return result6;
            } else if (typeof(TResult) == typeof(T7) && Type == OneOfTypeEnum.T7 && Value7 is TResult result7) {
                return result7;
            } else if (typeof(TResult) == typeof(T8) && Type == OneOfTypeEnum.T8 && Value8 is TResult result8) {
                return result8;
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
            } else if (typeof(TResult) == typeof(T5) && Type == OneOfTypeEnum.T5 && Value5 is TResult result5) {
                return result5;
            } else if (typeof(TResult) == typeof(T6) && Type == OneOfTypeEnum.T6 && Value6 is TResult result6) {
                return result6;
            } else if (typeof(TResult) == typeof(T7) && Type == OneOfTypeEnum.T7 && Value7 is TResult result7) {
                return result7;
            } else if (typeof(TResult) == typeof(T8) && Type == OneOfTypeEnum.T8 && Value8 is TResult result8) {
                return result8;
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
        public void Set(T5 Value) {
            Value5 = Value;
            Type = OneOfTypeEnum.T5;
        }
        public void Set(T6 Value) {
            Value6 = Value;
            Type = OneOfTypeEnum.T6;
        }
        public void Set(T7 Value) {
            Value7 = Value;
            Type = OneOfTypeEnum.T7;
        }
        public void Set(T8 Value) {
            Value8 = Value;
            Type = OneOfTypeEnum.T8;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3,Action<T4> Action4, Action<T5> Action5, Action<T6> Action6, Action<T7> Action7, Action<T8> Action8)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4, Action5, Action6, Action7, Action8);

        public static implicit operator T1(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T1 ? OneOfValue.Value1 : throw new OneOfTypeMismatchException();
        public static implicit operator T2(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T2 ? OneOfValue.Value2 : throw new OneOfTypeMismatchException();
        public static implicit operator T3(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T3 ? OneOfValue.Value3 : throw new OneOfTypeMismatchException();
        public static implicit operator T4(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T4 ? OneOfValue.Value4 : throw new OneOfTypeMismatchException();
        public static implicit operator T5(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T5 ? OneOfValue.Value5 : throw new OneOfTypeMismatchException();
        public static implicit operator T6(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T6 ? OneOfValue.Value6 : throw new OneOfTypeMismatchException();
        public static implicit operator T7(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T7 ? OneOfValue.Value7 : throw new OneOfTypeMismatchException();
        public static implicit operator T8(OneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOfValue)
            => OneOfValue.Type == OneOfTypeEnum.T8 ? OneOfValue.Value8 : throw new OneOfTypeMismatchException();

        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T1 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T2 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T3 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T4 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T5 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T6 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T7 OneOfValue) => new(OneOfValue);
        public static implicit operator OneOf<T1, T2, T3, T4, T5, T6, T7, T8>(T8 OneOfValue) => new(OneOfValue);
    }
}
