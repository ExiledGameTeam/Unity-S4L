using UnityEngine;

namespace S4L {
    /*
     * Consts are used to prevent typos in code.
     * If values need to be changed later, chaging only the const is enough.
    */
    /// <summary>
    /// S4L's constant values.
    /// </summary>
    public static class Consts {

        public static class LayerMasks {
            public static LayerMask Ground = 1 << LayerMask.NameToLayer("Ground");
        }

        public static class Tags {
            public static string Player = "Player";
        }
    }
}
