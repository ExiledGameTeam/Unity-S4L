using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    public static class Consts {

        public static class LayerMasks {
            public static LayerMask Ground = 1 << LayerMask.NameToLayer("Ground");
        }

        public static class Tags {
            public static string Player = "Player";
        }
    }

}
