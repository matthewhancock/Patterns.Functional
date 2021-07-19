using System;
using Patterns.Functional.Types.Interfaces;

namespace Patterns.Functional.Types.Util {
    internal static class OneOf {
        internal static void Switch<T1, T2>(IOneOf<T1, T2> OneOf, Action<T1> Action1, Action<T2> Action2) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            }
        }

        internal static void Switch<T1, T2, T3>(IOneOf<T1, T2, T3> OneOf, Action<T1> Action1, Action<T2> Action2, Action<T3> Action3) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            }
        }

        internal static void Switch<T1, T2, T3, T4>(IOneOf<T1, T2, T3, T4> OneOf,
            Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            } else if (OneOf.Type == OneOfTypeEnum.T4) {
                Action4(OneOf.Value4);
            }
        }

        internal static void Switch<T1, T2, T3, T4, T5>(IOneOf<T1, T2, T3, T4, T5> OneOf,
            Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            } else if (OneOf.Type == OneOfTypeEnum.T4) {
                Action4(OneOf.Value4);
            } else if (OneOf.Type == OneOfTypeEnum.T5) {
                Action5(OneOf.Value5);
            }
        }

        internal static void Switch<T1, T2, T3, T4, T5, T6>(IOneOf<T1, T2, T3, T4, T5, T6> OneOf,
            Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            } else if (OneOf.Type == OneOfTypeEnum.T4) {
                Action4(OneOf.Value4);
            } else if (OneOf.Type == OneOfTypeEnum.T5) {
                Action5(OneOf.Value5);
            } else if (OneOf.Type == OneOfTypeEnum.T6) {
                Action6(OneOf.Value6);
            }
        }

        internal static void Switch<T1, T2, T3, T4, T5, T6, T7>(IOneOf<T1, T2, T3, T4, T5, T6, T7> OneOf,
            Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6, Action<T7> Action7) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            } else if (OneOf.Type == OneOfTypeEnum.T4) {
                Action4(OneOf.Value4);
            } else if (OneOf.Type == OneOfTypeEnum.T5) {
                Action5(OneOf.Value5);
            } else if (OneOf.Type == OneOfTypeEnum.T6) {
                Action6(OneOf.Value6);
            } else if (OneOf.Type == OneOfTypeEnum.T7) {
                Action7(OneOf.Value7);
            }
        }

        internal static void Switch<T1, T2, T3, T4, T5, T6, T7, T8>(IOneOf<T1, T2, T3, T4, T5, T6, T7, T8> OneOf,
            Action<T1> Action1, Action<T2> Action2, Action<T3> Action3, Action<T4> Action4, Action<T5> Action5, Action<T6> Action6, Action<T7> Action7, Action<T8> Action8) {
            if (OneOf.Type == OneOfTypeEnum.T1) {
                Action1(OneOf.Value1);
            } else if (OneOf.Type == OneOfTypeEnum.T2) {
                Action2(OneOf.Value2);
            } else if (OneOf.Type == OneOfTypeEnum.T3) {
                Action3(OneOf.Value3);
            } else if (OneOf.Type == OneOfTypeEnum.T4) {
                Action4(OneOf.Value4);
            } else if (OneOf.Type == OneOfTypeEnum.T5) {
                Action5(OneOf.Value5);
            } else if (OneOf.Type == OneOfTypeEnum.T6) {
                Action6(OneOf.Value6);
            } else if (OneOf.Type == OneOfTypeEnum.T7) {
                Action7(OneOf.Value7);
            } else if (OneOf.Type == OneOfTypeEnum.T8) {
                Action8(OneOf.Value8);
            }
        }
    }
}
