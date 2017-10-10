using System;
using UnityEngine;
using System.Collections.Generic;
using S4L.Enums;

namespace S4L {
    public static class EventManager {

        /// <summary>
        /// List of axis inputs, 
        /// List of active button inputs
        /// </summary>
        public static Action<List<Tuple<PlayerAxisInput, float>>, 
            List<Tuple<PlayerButtonInput, ButtonEvent>>> OnPlayerInput = null;
        /// <summary>
        /// When triggered, the camera will focus on inputted transform. 
        /// Will return to last followed transform if sent value is null;
        /// </summary>
        public static Action<Transform> OnCameraTargetChanged = null;

        public static void Trigger(
            Action action
        ) {
            if (action != null) {
                action();
            }
        }

        public static void Trigger<T1>(
            Action<T1> action, T1 par1
        ) {
            if (action != null) {
                action(par1);
            }
        }

        public static void Trigger<T1, T2>(
            Action<T1, T2> action, T1 par1, T2 par2
        ) {
            if (action != null) {
                action(par1, par2);
            }
        }

        public static void Trigger<T1, T2, T3>(
            Action<T1, T2, T3> action, T1 par1, T2 par2, T3 par3
        ) {
            if (action != null) {
                action(par1, par2, par3);
            }
        }

        public static void Trigger<T1, T2, T3, T4>(
            Action<T1, T2, T3, T4> action,
            T1 par1, T2 par2, T3 par3, T4 par4
        ) {
            if (action != null) {
                action(par1, par2, par3, par4);
            }
        }
    }
}