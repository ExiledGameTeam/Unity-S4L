using System;

namespace S4L {
    [Serializable]
    public struct Tuple<T1, T2> {
        public Tuple(T1 arg1, T2 arg2) {
            value1 = arg1;
            value2 = arg2;
        }
        public T1 value1;
        public T2 value2;
    }

    [Serializable]
    public struct Tuple<T1, T2, T3> {
        public Tuple(T1 arg1, T2 arg2, T3 arg3) {
            value1 = arg1;
            value2 = arg2;
            value3 = arg3;
        }
        public T1 value1;
        public T2 value2;
        public T3 value3;
    }

    [Serializable]
    public struct Tuple<T1, T2, T3, T4> {
        public Tuple(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
            value1 = arg1;
            value2 = arg2;
            value3 = arg3;
            value4 = arg4;
        }
        public T1 value1;
        public T2 value2;
        public T3 value3;
        public T4 value4;
    }
}
