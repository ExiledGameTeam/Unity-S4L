using System;
using UnityEngine;
using System.Collections.Generic;
using S4L.Enums;

/*
 * Greeting from Bleson:
 * 
 * In order to learn how to use events in Unity, check out
 * EventExample in Test folder and check out how they are 
 * used in Iris.
 * 
 * I have commented out an example how to add a new event below.
*/


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

        //New event examples:
        //public static Action<TYPES_OF_PARAMETERS, THAT_LISTENING_FUNCTION_TAKES_IN> OnSomething = null;
        //public static Action<float, float, float> OnHealthChanged = null;

        #region Event triggers
        /* 
         * These triggering functions are just a failsafe measure 
         * so you can't trigger the event when it is null 
         * (otherwise errors or other problems)
        */
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
        #endregion
    }
}