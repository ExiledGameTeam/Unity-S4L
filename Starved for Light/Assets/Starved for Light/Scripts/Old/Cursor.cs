using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Old {
    public class Cursor : MonoBehaviour {

        public Texture2D cursorTexture;

        void Start() {
            UnityEngine.Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}


