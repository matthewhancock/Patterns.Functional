using System;
using Patterns.Functional.Types.Interfaces;

namespace Patterns.Functional.Types.Abstracts {
    public abstract class OneOf<T1, T2> : IOneOf<T1, T2> {
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

        OneOfTypeEnum IOneOf.Type => Type;
        T1 IOneOf<T1, T2>.Value1 => Value1;
        T2 IOneOf<T1, T2>.Value2 => Value2;

        public void Set(T1 Value) {
            Value1 = Value;
            Type = OneOfTypeEnum.T1;
        }

        public void Set(T2 Value) {
            Value2 = Value;
            Type = OneOfTypeEnum.T2;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2) => Util.OneOf.Switch(this, Action1, Action2);
    }

    public abstract class OneOfBase<T1, T2, T3> : OneOf<T1, T2>, IOneOf<T1, T2, T3> {
        protected OneOfBase() => Value3 = default;
        public OneOfBase(T1 Value) : base(Value) => Value3 = default;
        public OneOfBase(T2 Value) : base(Value) => Value3 = default;

        public OneOfBase(T3 Value) : base() {
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        internal T3 Value3 { get; private set; }

        T1 IOneOf<T1, T2, T3>.Value1 => Value1;
        T2 IOneOf<T1, T2, T3>.Value2 => Value2;
        T3 IOneOf<T1, T2, T3>.Value3 => Value3;

        public void Set(T3 Value) {
            Value3 = Value;
            Type = OneOfTypeEnum.T3;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3) => Util.OneOf.Switch(this, Action1, Action2, Action3);
    }

    public abstract class OneOfBase<T1, T2, T3, T4> : OneOfBase<T1, T2, T3>, IOneOf<T1, T2, T3, T4> {
        protected OneOfBase() => Value4 = default;
        public OneOfBase(T1 Value) : base(Value) => Value4 = default;
        public OneOfBase(T2 Value) : base(Value) => Value4 = default;
        public OneOfBase(T3 Value) : base(Value) => Value4 = default;

        public OneOfBase(T4 Value) : base() {
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        internal T4 Value4 { get; private set; }

        T1 IOneOf<T1, T2, T3, T4>.Value1 => Value1;
        T2 IOneOf<T1, T2, T3, T4>.Value2 => Value2;
        T3 IOneOf<T1, T2, T3, T4>.Value3 => Value3;
        T4 IOneOf<T1, T2, T3, T4>.Value4 => Value4;

        public void Set(T4 Value) {
            Value4 = Value;
            Type = OneOfTypeEnum.T4;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4);
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5> : OneOfBase<T1, T2, T3, T4>, IOneOf<T1, T2, T3, T4, T5> {
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

        T1 IOneOf<T1, T2, T3, T4, T5>.Value1 { get; }
        T2 IOneOf<T1, T2, T3, T4, T5>.Value2 { get; }
        T3 IOneOf<T1, T2, T3, T4, T5>.Value3 { get; }
        T4 IOneOf<T1, T2, T3, T4, T5>.Value4 { get; }
        T5 IOneOf<T1, T2, T3, T4, T5>.Value5 { get; }

        public void Set(T5 Value) {
            Value5 = Value;
            Type = OneOfTypeEnum.T5;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4, Action5);
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6> : OneOfBase<T1, T2, T3, T4, T5>, IOneOf<T1, T2, T3, T4, T5, T6> {
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

        T1 IOneOf<T1, T2, T3, T4, T5, T6>.Value1 { get; }
        T2 IOneOf<T1, T2, T3, T4, T5, T6>.Value2 { get; }
        T3 IOneOf<T1, T2, T3, T4, T5, T6>.Value3 { get; }
        T4 IOneOf<T1, T2, T3, T4, T5, T6>.Value4 { get; }
        T5 IOneOf<T1, T2, T3, T4, T5, T6>.Value5 { get; }
        T6 IOneOf<T1, T2, T3, T4, T5, T6>.Value6 { get; }

        public void Set(T6 Value) {
            Value6 = Value;
            Type = OneOfTypeEnum.T6;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4, Action5, Action6);
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6, T7> : OneOfBase<T1, T2, T3, T4, T5, T6>, IOneOf<T1, T2, T3, T4, T5, T6, T7> {
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

        T1 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value1 { get; }
        T2 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value2 { get; }
        T3 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value3 { get; }
        T4 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value4 { get; }
        T5 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value5 { get; }
        T6 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value6 { get; }
        T7 IOneOf<T1, T2, T3, T4, T5, T6, T7>.Value7 { get; }

        public void Set(T7 Value) {
            Value7 = Value;
            Type = OneOfTypeEnum.T7;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6, Action<T7> Action7)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4, Action5, Action6, Action7);
    }

    public abstract class OneOfBase<T1, T2, T3, T4, T5, T6, T7, T8> : OneOfBase<T1, T2, T3, T4, T5, T6, T7>, IOneOf<T1, T2, T3, T4, T5, T6, T7, T8> {
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

        T1 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value1 { get; }
        T2 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value2 { get; }
        T3 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value3 { get; }
        T4 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value4 { get; }
        T5 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value5 { get; }
        T6 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value6 { get; }
        T7 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value7 { get; }
        T8 IOneOf<T1, T2, T3, T4, T5, T6, T7, T8>.Value8 { get; }

        public void Set(T8 Value) {
            Value8 = Value;
            Type = OneOfTypeEnum.T8;
        }

        public void Switch(Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4,
            Action<T5> Action5, Action<T6> Action6, Action<T7> Action7, Action<T8> Action8)
            => Util.OneOf.Switch(this, Action1, Action2, Action3, Action4, Action5, Action6, Action7, Action8);
    }
}
