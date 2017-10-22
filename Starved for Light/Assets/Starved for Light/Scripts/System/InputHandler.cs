﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using TeamUtility.IO;
using S4L.Enums;

namespace S4L {
    public class InputHandler : MonoBehaviour {

        #region Input names
        static readonly IList<Tuple<PlayerAxisInput, string>> axises =
        new ReadOnlyCollection<Tuple<PlayerAxisInput, string>>
            (new List<Tuple<PlayerAxisInput, string>> {
                new Tuple<PlayerAxisInput, string>(PlayerAxisInput.Horizontal, "Horizontal"),
                new Tuple<PlayerAxisInput, string>(PlayerAxisInput.Vertical, "Vertical"),
                new Tuple<PlayerAxisInput, string>(PlayerAxisInput.LookHorizontal, "LookHorizontal"),
                new Tuple<PlayerAxisInput, string>(PlayerAxisInput.LookVertical, "LookVertical")
        });

        static readonly IList<Tuple<PlayerButtonInput, string>> buttons =
        new ReadOnlyCollection<Tuple<PlayerButtonInput, string>>
            (new List<Tuple<PlayerButtonInput, string>> {
                new Tuple<PlayerButtonInput, string>(PlayerButtonInput.Jump, "Jump"),
                new Tuple<PlayerButtonInput, string>(PlayerButtonInput.Submit, "Submit"),
                new Tuple<PlayerButtonInput, string>(PlayerButtonInput.Cancel, "Cancel"),
                new Tuple<PlayerButtonInput, string>(PlayerButtonInput.Gallop, "Gallop")
        });
        #endregion

        //Containers
        private List<Tuple<PlayerAxisInput, float>> axisEvents = 
            new List<Tuple<PlayerAxisInput,float>>();
        private List<Tuple<PlayerButtonInput, ButtonEvent>> buttonEvents =
            new List<Tuple<PlayerButtonInput, ButtonEvent>>();

        void Update() {
            foreach (Tuple<PlayerAxisInput, string> item in axises) {
                axisEvents.Add(new Tuple<PlayerAxisInput, float>(
                    item.value1, InputManager.GetAxis(item.value2)));
            }

            foreach (var item in buttons) {
                if (InputManager.GetButton(item.value2)) {
                    buttonEvents.Add(new Tuple<PlayerButtonInput, ButtonEvent>(item.value1, ButtonEvent.Hold));
                } else if (InputManager.GetButtonDown(item.value2)) {
                    buttonEvents.Add(new Tuple<PlayerButtonInput, ButtonEvent>(item.value1, ButtonEvent.Down));
                } else if (InputManager.GetButtonUp(item.value2)) {
                    buttonEvents.Add(new Tuple<PlayerButtonInput, ButtonEvent>(item.value1, ButtonEvent.Up));
                }
            }

#if false
            string s = "Axis events: ";
            foreach (var item in AxisEvents) {
                s += " " + item.value2.ToString();
            }

            print(s);
#endif
            EventManager.Trigger(EventManager.OnPlayerInput, axisEvents, buttonEvents);
            axisEvents.Clear();
            buttonEvents.Clear();
	    }
    }
}