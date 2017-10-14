﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    [RequireComponent(typeof(MovementComponent))]
    public class Iris : MonoBehaviour {

        private MovementComponent movement;
        new private Transform transform;
        Rigidbody2D rb;
        AlignToGroundComponent alignToGround;

        private void Awake() {
            movement = GetComponent<MovementComponent>();
            transform = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            EventManager.Trigger(EventManager.OnCameraTargetChanged, transform);
        }

        private void OnEnable() {
            EventManager.OnPlayerInput += HandleInputs;
        }

        private void OnDisable() {
            EventManager.OnPlayerInput -= HandleInputs;
        }

        private void Update() {
            EventManager.Trigger(EventManager.OnCameraTargetChanged, transform);
            
        }

        void HandleInputs(
            List<Tuple<Enums.PlayerAxisInput, float>> inputAxises,
            List<Tuple<Enums.PlayerButtonInput, Enums.ButtonEvent>> inputButtons
        ) {
            foreach (var pair in inputAxises) {
                if (pair.value1 == Enums.PlayerAxisInput.Horizontal) {
                    movement.MoveHorizontal(rb, transform, pair.value2);
                    print("Received input!");
                }
            }
        }
    }
}
