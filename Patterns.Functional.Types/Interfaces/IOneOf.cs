namespace Patterns.Functional.Types.Interfaces {
    internal interface IOneOf {
        OneOfTypeEnum Type { get; }
    }

    internal interface IOneOf<T1, T2> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
    }

    internal interface IOneOf<T1, T2, T3> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
    }

    internal interface IOneOf<T1, T2, T3, T4> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
        T4 Value4 { get; }
    }

    internal interface IOneOf<T1, T2, T3, T4, T5> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
        T4 Value4 { get; }
        T5 Value5 { get; }
    }

    internal interface IOneOf<T1, T2, T3, T4, T5, T6> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
        T4 Value4 { get; }
        T5 Value5 { get; }
        T6 Value6 { get; }
    }

    internal interface IOneOf<T1, T2, T3, T4, T5, T6, T7> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
        T4 Value4 { get; }
        T5 Value5 { get; }
        T6 Value6 { get; }
        T7 Value7 { get; }
    }

    internal interface IOneOf<T1, T2, T3, T4, T5, T6, T7, T8> : IOneOf {
        T1 Value1 { get; }
        T2 Value2 { get; }
        T3 Value3 { get; }
        T4 Value4 { get; }
        T5 Value5 { get; }
        T6 Value6 { get; }
        T7 Value7 { get; }
        T8 Value8 { get; }
    }
}
