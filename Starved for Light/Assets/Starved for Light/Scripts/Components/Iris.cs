using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Greeting from Bleson:
 * Hey, the player character's class works as a communication piece between
 * the listened events (includes the player's inputs) and the functionality
 * that come from the components.
 * This way we can use same components for multiple characters and different
 * kinds of AI.
 * Character could use a states with combination of events to determine what to do.
 * 
 * Example components:
 * Movement, Jump, Hover, IlluminationCircleSpell, IlluminationConeSpell,
 * AlignToGround etc.
 * 
 * In ideal situation, all of the data would be stored in Serialized classes
 * which can be edited from Iris class and the instance of the class would be sent
 * to the function whenever needed.
 * I made a few examples on components and how their functions could be triggered
 * from Iris class.
 * 
 * This means one character would not have multiple copies of same data
 * in multiple components (like transform)
 * 
 * 
 * Additional notes:
 * To make things easier for designer and for testing, 
 * I would suggest to make a scriptable object
 * instance for different settings in order to test balance, 
 * or just have a drag-and-drop debug mode.
 * That will take some time to implement and it most likely won't be
 * worth the time it takes to learn the most effective way to use it, 
 * but it would be useful if programming team gets bigger.
 * 
 * You could call this a half-assed way of doing functional programming with
 * dataoriented design (FUDO), as it doesn't complete either of these areas, but has
 * some similarities.
 * I can provide you a source to a project that uses FUDO if you want, but I don't see
 * much gains in using FUDO in this type of game. FUDO also differs a lot from
 * OOP so it wouldn't be wise to spend too much time learning so trivial.
 * 
 * Do not use GameObject.transform, make a new private Transform transform instead.
 * Reason for this is that in Unity3D GameObject.transform == GetComponent<Transform>,
 * which is slow to operate each time you need to use the transform.
 * 
 * 
 * 
 * With love and wish for your great success,
 * Bleson
 */

namespace S4L {
    [RequireComponent(typeof(MovementComponent), 
        typeof(AlignToGroundComponent)/*, 
        typeof(JumpComponent)*/)]
    public class Iris : MonoBehaviour {

        //Unity components & structs
        new private Transform transform;
        private Rigidbody2D rb;
        
        //S4L components & structs
        private MovementComponent movement;
        private AlignToGroundComponent alignToGround;
        //private JumpComponent jump;

        private void Awake() {
            //movement = GetComponent<MovementComponent>();
            //jump = GetComponent<JumpComponent>();
            transform = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
            alignToGround = GetComponent<AlignToGroundComponent>();
        }

        private void Start() {
            EventManager.Trigger(EventManager.OnCameraTargetChanged, transform);
        }

        private void OnEnable() {
            //Add events to listen
            EventManager.OnPlayerInput += HandleInputs;
        }

        private void OnDisable() {
            // There always needs to be an unsubscribing for events or things 
            // will sooner or later get bucked up
            EventManager.OnPlayerInput -= HandleInputs;
        }

        private void Update() {
            //RECODE: Never do anything like this. Make it so that it only
            // triggers once the level starts (in GameManager or something)
            EventManager.Trigger(EventManager.OnCameraTargetChanged, transform);

            alignToGround.Align(transform);
        }

        void HandleInputs(
            List<Tuple<Enums.PlayerAxisInput, float>> inputAxises,
            List<Tuple<Enums.PlayerButtonInput, Enums.ButtonEvent>> inputButtons
        ) {
            foreach (var pair in inputAxises) {
                if (pair.value1 == Enums.PlayerAxisInput.Horizontal) {
                    Move(pair.value2);
                    //print("Received input!");
                }
            }
            foreach (var pair in inputButtons) {
                if (pair.value1 == Enums.PlayerButtonInput.Jump) {
                    Jump(pair.value2);
                }
            }
        }

        #region Actions
        void Jump(Enums.ButtonEvent buttonEvent) {
            if (buttonEvent == Enums.ButtonEvent.Down) {
                //jump.ButtonDown();
            } else if (buttonEvent == Enums.ButtonEvent.Hold) {
                //jump.ButtonHold();
            } else { // ButtonEvent.Up
                //jump.ButtonUp();
            }
        }

        void Move(float direction) {
            //movement.MoveHorizontal(rb, transform, pair.value2);
        }
        #endregion
    }
}
