using System;

namespace Patterns.Functional.Types.Abstracts {
    public abstract class OneOf<T1, T2> {
        protected OneOf() {
            Value1 = default;
            Value2 = default;
        }

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

        internal OneOfTypeEnum Type { get; set; }
        internal T1 Value1 { get; private set; }
        internal T2 Value2 { get; private set; }

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
    }

    public abstract class OneOfBase<T1, T2, T3> : OneOf<T1, T2> {
        protected OneOfBase() => Value3 = default;
        public OneOfBase(T1 Value) : base(Value) => Value3 = default;
        public OneOfBase(T2 Value) : base(Value) => Value3 = default;

        public OneOfBase(T3 Value) : base() {
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        internal T3 Value3 { get; private set; }

        public void Set(T3 Value) {
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                _ => default
            };

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T3 => Value3,
                _ => base.AsObject()
            };
    }

    public abstract class OneOfBase<T1, T2, T3, T4> : OneOfBase<T1, T2, T3> {
        protected OneOfBase() => Value4 = default;
        public OneOfBase(T1 Value) : base(Value) => Value4 = default;
        public OneOfBase(T2 Value) : base(Value) => Value4 = default;
        public OneOfBase(T3 Value) : base(Value) => Value4 = default;

        public OneOfBase(T4 Value) : base() {
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        internal T4 Value4 { get; private set; }

        public void Set(T4 Value) {
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4) {
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

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T4 => Value4,
                _ => base.AsObject()
            };
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5> : OneOfBase<T1, T2, T3, T4> {
        protected OneOfBase() => Value5 = default;
        public OneOfBase(T1 Value) : base(Value) => Value5 = default;
        public OneOfBase(T2 Value) : base(Value) => Value5 = default;
        public OneOfBase(T3 Value) : base(Value) => Value5 = default;
        public OneOfBase(T4 Value) : base(Value) => Value5 = default;

        public OneOfBase(T5 Value) : base() {
            Value5 = Value;
            Type = OneOfTypeEnum.T5;
        }

        internal T5 Value5 { get; private set; }

        public void Set(T5 Value) {
            Value5 = Value;
            Type = OneOfTypeEnum.T5;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            } else if (Type == OneOfTypeEnum.T4) {
                Action4(Value4);
            } else if (Type == OneOfTypeEnum.T5) {
                Action5(Value5);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3, Func<T4, TResult> Func4,
            Func<T5, TResult> Func5)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                OneOfTypeEnum.T4 => Func4(Value4),
                OneOfTypeEnum.T5 => Func5(Value5),
                _ => default
            };

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T5 => Value5,
                _ => base.AsObject()
            };
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6> : OneOfBase<T1, T2, T3, T4, T5> {
        protected OneOfBase() => Value6 = default;
        public OneOfBase(T1 Value) : base(Value) => Value6 = default;
        public OneOfBase(T2 Value) : base(Value) => Value6 = default;
        public OneOfBase(T3 Value) : base(Value) => Value6 = default;
        public OneOfBase(T4 Value) : base(Value) => Value6 = default;
        public OneOfBase(T5 Value) : base(Value) => Value6 = default;

        public OneOfBase(T6 Value) : base() {
            Value6 = Value;
            Type = OneOfTypeEnum.T6;
        }

        internal T6 Value6 { get; private set; }

        public void Set(T6 Value) {
            Value6 = Value;
            Type = OneOfTypeEnum.T6;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            } else if (Type == OneOfTypeEnum.T4) {
                Action4(Value4);
            } else if (Type == OneOfTypeEnum.T5) {
                Action5(Value5);
            } else if (Type == OneOfTypeEnum.T6) {
                Action6(Value6);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3, Func<T4, TResult> Func4,
            Func<T5, TResult> Func5, Func<T6, TResult> Func6)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                OneOfTypeEnum.T4 => Func4(Value4),
                OneOfTypeEnum.T5 => Func5(Value5),
                OneOfTypeEnum.T6 => Func6(Value6),
                _ => default
            };

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T6 => Value6,
                _ => base.AsObject()
            };
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6, T7> : OneOfBase<T1, T2, T3, T4, T5, T6> {
        protected OneOfBase() => Value7 = default;
        public OneOfBase(T1 Value) : base(Value) => Value7 = default;
        public OneOfBase(T2 Value) : base(Value) => Value7 = default;
        public OneOfBase(T3 Value) : base(Value) => Value7 = default;
        public OneOfBase(T4 Value) : base(Value) => Value7 = default;
        public OneOfBase(T5 Value) : base(Value) => Value7 = default;
        public OneOfBase(T6 Value) : base(Value) => Value7 = default;

        public OneOfBase(T7 Value) : base() {
            Value7 = Value;
            Type = OneOfTypeEnum.T7;
        }

        internal T7 Value7 { get; private set; }

        public void Set(T7 Value) {
            Value7 = Value;
            Type = OneOfTypeEnum.T7;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6, Action<T7> Action7) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            } else if (Type == OneOfTypeEnum.T4) {
                Action4(Value4);
            } else if (Type == OneOfTypeEnum.T5) {
                Action5(Value5);
            } else if (Type == OneOfTypeEnum.T6) {
                Action6(Value6);
            } else if (Type == OneOfTypeEnum.T7) {
                Action7(Value7);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3, Func<T4, TResult> Func4,
            Func<T5, TResult> Func5, Func<T6, TResult> Func6, Func<T7, TResult> Func7)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                OneOfTypeEnum.T4 => Func4(Value4),
                OneOfTypeEnum.T5 => Func5(Value5),
                OneOfTypeEnum.T6 => Func6(Value6),
                OneOfTypeEnum.T7 => Func7(Value7),
                _ => default
            };

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T7 => Value7,
                _ => base.AsObject()
            };
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6, T7, T8> : OneOfBase<T1, T2, T3, T4, T5, T6, T7> {
        protected OneOfBase() => Value8 = default;
        public OneOfBase(T1 Value) : base(Value) => Value8 = default;
        public OneOfBase(T2 Value) : base(Value) => Value8 = default;
        public OneOfBase(T3 Value) : base(Value) => Value8 = default;
        public OneOfBase(T4 Value) : base(Value) => Value8 = default;
        public OneOfBase(T5 Value) : base(Value) => Value8 = default;
        public OneOfBase(T6 Value) : base(Value) => Value8 = default;
        public OneOfBase(T7 Value) : base(Value) => Value8 = default;

        public OneOfBase(T8 Value) : base() {
            Value8 = Value;
            Type = OneOfTypeEnum.T8;
        }

        internal T8 Value8 { get; private set; }

        public void Set(T8 Value) {
            Value8 = Value;
            Type = OneOfTypeEnum.T8;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4,
            Action<T5> Action5, Action<T6> Action6, Action<T7> Action7, Action<T8> Action8) {
            if (Type == OneOfTypeEnum.T1) {
                Action1(Value1);
            } else if (Type == OneOfTypeEnum.T2) {
                Action2(Value2);
            } else if (Type == OneOfTypeEnum.T3) {
                Action3(Value3);
            } else if (Type == OneOfTypeEnum.T4) {
                Action4(Value4);
            } else if (Type == OneOfTypeEnum.T5) {
                Action5(Value5);
            } else if (Type == OneOfTypeEnum.T6) {
                Action6(Value6);
            } else if (Type == OneOfTypeEnum.T7) {
                Action7(Value7);
            } else if (Type == OneOfTypeEnum.T8) {
                Action8(Value8);
            }
        }
        public TResult Switch<TResult>(Func<T1, TResult> Func1, Func<T2, TResult> Func2, Func<T3, TResult> Func3, Func<T4, TResult> Func4,
            Func<T5, TResult> Func5, Func<T6, TResult> Func6, Func<T7, TResult> Func7, Func<T8, TResult> Func8)
            => Type switch {
                OneOfTypeEnum.T1 => Func1(Value1),
                OneOfTypeEnum.T2 => Func2(Value2),
                OneOfTypeEnum.T3 => Func3(Value3),
                OneOfTypeEnum.T4 => Func4(Value4),
                OneOfTypeEnum.T5 => Func5(Value5),
                OneOfTypeEnum.T6 => Func6(Value6),
                OneOfTypeEnum.T7 => Func7(Value7),
                OneOfTypeEnum.T8 => Func8(Value8),
                _ => default
            };

        public new object AsObject()
            => Type switch {
                OneOfTypeEnum.T8 => Value8,
                _ => base.AsObject()
            };
    }
}
