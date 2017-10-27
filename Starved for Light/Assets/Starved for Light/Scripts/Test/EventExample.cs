using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Test {
    public class EventExample : MonoBehaviour {

        void OnEnable() {
            //Subscribe to event by adding a function to the event.
            EventManager.OnPlayerInput += PrintText;
        }

        void OnDisable() {
            //Always remember to unsubscribe from the event.
            EventManager.OnPlayerInput -= PrintText;
        }

        /* PrintText function triggers when event is triggered.
         * The event gives the function the parameter values,
         * therefore the parameter types must be the same as in the event
         * even though the function may not need them.
        */
        void PrintText(
            List<Tuple<Enums.PlayerAxisInput, float>> par1,
            List<Tuple<Enums.PlayerButtonInput, Enums.ButtonEvent>> par2
        ) {

            /* Tuples always use .value1 for the first value of the pair
             * (in this case AxisInput)
             * and .value2 for the second value (in this case float)
            */
            print("OnPlayerInput was triggered. Horizontal axis value: " + 
                par1[0].value2.ToString());
        }
    }
}
