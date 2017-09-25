using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TeamUtility.IO;

namespace S4L.Old.UI {
    public class MainMenuButtonsStart : MonoBehaviour {

        public EventSystem ES;
        private GameObject StoreSelected;
        public Button Quit;
        public Button Settings;
        public Button Extras;
        public Button Continue;
        public Button NewGame;
        public GameObject OptionPanel;
        public Animator options;

        public bool Inoptions = false;

        public GameObject Soptions;
        public GameObject Main;

        void Start() {

            StoreSelected = ES.firstSelectedGameObject;
            options = OptionPanel.GetComponent<Animator>();
            options.SetBool("InOptions", false);
        }

        void Update() {
            if (Input.anyKeyDown ||
                InputManager.GetAxis("Vertical") < -0.1 ||
                InputManager.GetAxis("Vertical") > 0.1 ||
                InputManager.GetAxis("Horizontal") < -0.1 ||
                InputManager.GetAxis("Horizontal") > 0.1 ||
                Input.GetAxis("joy_1_axis_6") < -0.2 ||
                Input.GetAxis("joy_1_axis_6") > 0.2 ||
                Input.GetAxis("joy_1_axis_7") < -0.2 ||
                Input.GetAxis("joy_1_axis_7") > 0.2) {
                if (ES.currentSelectedGameObject != StoreSelected) {
                    print("1");
                    if (ES.currentSelectedGameObject == null) {
                        ES.SetSelectedGameObject(StoreSelected);
                        print("2");
                    } else
                        StoreSelected = ES.currentSelectedGameObject;
                }
            }
            if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0) {
                ES.SetSelectedGameObject(null);
            }
            if (Inoptions == true) {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1)) {
                    Inoptions = false;
                    options.SetBool("InOptions", false);
                    ES.SetSelectedGameObject(null);
                    StoreSelected = Main;
                }
            }
        }

        public void QuitClick() {
            Application.Quit();
            print("GameQuited");
        }
        public void SettingsClick() {

        }
        public void ExtrasClick() {

        }
        public void ContinueClick() {

        }
        public void NewGameClick() {

        }
    }
}