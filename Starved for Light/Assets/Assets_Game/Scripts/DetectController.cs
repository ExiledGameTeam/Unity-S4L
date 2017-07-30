using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class DetectController : MonoBehaviour {


    public int Controller = 0;
	// 0 = klawiatura + myszka
    // 1 = Gamepad
	void Start () {
		
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Backspace) ||
            Input.GetKeyDown(KeyCode.Delete) ||
            Input.GetKeyDown(KeyCode.Tab) ||
            Input.GetKeyDown(KeyCode.Clear) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.Pause) ||
            Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Keypad0) ||
            Input.GetKeyDown(KeyCode.Keypad1) ||
            Input.GetKeyDown(KeyCode.Keypad2) ||
            Input.GetKeyDown(KeyCode.Keypad3) ||
            Input.GetKeyDown(KeyCode.Keypad4) ||
            Input.GetKeyDown(KeyCode.Keypad5) ||
            Input.GetKeyDown(KeyCode.Keypad6) ||
            Input.GetKeyDown(KeyCode.Keypad7) ||
            Input.GetKeyDown(KeyCode.Keypad8) ||
            Input.GetKeyDown(KeyCode.Keypad9) ||
            Input.GetKeyDown(KeyCode.KeypadPeriod) ||
            Input.GetKeyDown(KeyCode.KeypadDivide) ||
            Input.GetKeyDown(KeyCode.KeypadMultiply) ||
            Input.GetKeyDown(KeyCode.KeypadMinus) ||
            Input.GetKeyDown(KeyCode.KeypadPlus) ||
            Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetKeyDown(KeyCode.KeypadEquals) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.Insert) ||
            Input.GetKeyDown(KeyCode.Home) ||
            Input.GetKeyDown(KeyCode.End) ||
            Input.GetKeyDown(KeyCode.PageUp) ||
            Input.GetKeyDown(KeyCode.PageDown) ||
            Input.GetKeyDown(KeyCode.F1) ||
            Input.GetKeyDown(KeyCode.F2) ||
            Input.GetKeyDown(KeyCode.F3) ||
            Input.GetKeyDown(KeyCode.F4) ||
            Input.GetKeyDown(KeyCode.F5) ||
            Input.GetKeyDown(KeyCode.F6) ||
            Input.GetKeyDown(KeyCode.F7) ||
            Input.GetKeyDown(KeyCode.F8) ||
            Input.GetKeyDown(KeyCode.F9) ||
            Input.GetKeyDown(KeyCode.F10) ||
            Input.GetKeyDown(KeyCode.F11) ||
            Input.GetKeyDown(KeyCode.F12) ||
            Input.GetKeyDown(KeyCode.F13) ||
            Input.GetKeyDown(KeyCode.F14) ||
            Input.GetKeyDown(KeyCode.F15) ||
            Input.GetKeyDown(KeyCode.Alpha0) ||
            Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Alpha8) ||
            Input.GetKeyDown(KeyCode.Alpha9) ||
            Input.GetKeyDown(KeyCode.Exclaim) ||
            Input.GetKeyDown(KeyCode.DoubleQuote) ||
            Input.GetKeyDown(KeyCode.Hash) ||
            Input.GetKeyDown(KeyCode.Dollar) ||
            Input.GetKeyDown(KeyCode.Ampersand) ||
            Input.GetKeyDown(KeyCode.Quote) ||
            Input.GetKeyDown(KeyCode.LeftParen) ||
            Input.GetKeyDown(KeyCode.RightParen) ||
            Input.GetKeyDown(KeyCode.Asterisk) ||
            Input.GetKeyDown(KeyCode.Plus) ||
            Input.GetKeyDown(KeyCode.Comma) ||
            Input.GetKeyDown(KeyCode.Minus) ||
            Input.GetKeyDown(KeyCode.Period) ||
            Input.GetKeyDown(KeyCode.Slash) ||
            Input.GetKeyDown(KeyCode.Colon) ||
            Input.GetKeyDown(KeyCode.Semicolon) ||
            Input.GetKeyDown(KeyCode.Less) ||
            Input.GetKeyDown(KeyCode.Equals) ||
            Input.GetKeyDown(KeyCode.Greater) ||
            Input.GetKeyDown(KeyCode.Question) ||
            Input.GetKeyDown(KeyCode.At) ||
            Input.GetKeyDown(KeyCode.LeftBracket) ||
            Input.GetKeyDown(KeyCode.Backslash) ||
            Input.GetKeyDown(KeyCode.RightBracket) ||
            Input.GetKeyDown(KeyCode.Caret) ||
            Input.GetKeyDown(KeyCode.Underscore) ||
            Input.GetKeyDown(KeyCode.BackQuote) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.B) ||
            Input.GetKeyDown(KeyCode.C) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.E) ||
            Input.GetKeyDown(KeyCode.F) ||
            Input.GetKeyDown(KeyCode.G) ||
            Input.GetKeyDown(KeyCode.H) ||
            Input.GetKeyDown(KeyCode.I) ||
            Input.GetKeyDown(KeyCode.J) ||
            Input.GetKeyDown(KeyCode.K) ||
            Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.M) ||
            Input.GetKeyDown(KeyCode.N) ||
            Input.GetKeyDown(KeyCode.O) ||
            Input.GetKeyDown(KeyCode.P) ||
            Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.R) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.T) ||
            Input.GetKeyDown(KeyCode.U) ||
            Input.GetKeyDown(KeyCode.V) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.X) ||
            Input.GetKeyDown(KeyCode.Y) ||
            Input.GetKeyDown(KeyCode.Z) ||
            Input.GetKeyDown(KeyCode.Numlock) ||
            Input.GetKeyDown(KeyCode.CapsLock) ||
            Input.GetKeyDown(KeyCode.ScrollLock) ||
            Input.GetKeyDown(KeyCode.RightShift) ||
            Input.GetKeyDown(KeyCode.LeftShift) ||
            Input.GetKeyDown(KeyCode.RightControl) ||
            Input.GetKeyDown(KeyCode.LeftControl) ||
            Input.GetKeyDown(KeyCode.RightAlt) ||
            Input.GetKeyDown(KeyCode.LeftAlt) ||
            Input.GetKeyDown(KeyCode.LeftCommand) ||
            Input.GetKeyDown(KeyCode.LeftApple) ||
            Input.GetKeyDown(KeyCode.LeftWindows) ||
            Input.GetKeyDown(KeyCode.RightCommand) ||
            Input.GetKeyDown(KeyCode.RightApple) ||
            Input.GetKeyDown(KeyCode.RightWindows) ||
            Input.GetKeyDown(KeyCode.AltGr) ||
            Input.GetKeyDown(KeyCode.Help) ||
            Input.GetKeyDown(KeyCode.Print) ||
            Input.GetKeyDown(KeyCode.SysReq) ||
            Input.GetKeyDown(KeyCode.Break) ||
            Input.GetKeyDown(KeyCode.Menu) ||
            Input.GetKeyDown(KeyCode.Mouse0) ||
            Input.GetKeyDown(KeyCode.Mouse1) ||
            Input.GetKeyDown(KeyCode.Mouse2) ||
            Input.GetKeyDown(KeyCode.Mouse3) ||
            Input.GetKeyDown(KeyCode.Mouse4) ||
            Input.GetKeyDown(KeyCode.Mouse5) ||
            Input.GetKeyDown(KeyCode.Mouse6) ||
            Input.GetAxis("Mouse X") <0 ||
            Input.GetAxis("Mouse X") >0
            )
        {
            print("Currently used: Keyboard");
            Controller = 0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) ||
            Input.GetKeyDown(KeyCode.Joystick1Button1) ||
            Input.GetKeyDown(KeyCode.Joystick1Button2) ||
            Input.GetKeyDown(KeyCode.Joystick1Button3) ||
            Input.GetKeyDown(KeyCode.Joystick1Button4) ||
            Input.GetKeyDown(KeyCode.Joystick1Button5) ||
            Input.GetKeyDown(KeyCode.Joystick1Button6) ||
            Input.GetKeyDown(KeyCode.Joystick1Button7) ||
            Input.GetKeyDown(KeyCode.Joystick1Button8) ||
            Input.GetKeyDown(KeyCode.Joystick1Button9) ||
            Input.GetKeyDown(KeyCode.Joystick1Button10) ||
            Input.GetKeyDown(KeyCode.Joystick1Button11) ||
            Input.GetKeyDown(KeyCode.Joystick1Button12) ||
            Input.GetKeyDown(KeyCode.Joystick1Button13) ||
            Input.GetKeyDown(KeyCode.Joystick1Button14) ||
            Input.GetKeyDown(KeyCode.Joystick1Button15) ||
            Input.GetKeyDown(KeyCode.Joystick1Button16) ||
            Input.GetKeyDown(KeyCode.Joystick1Button17) ||
            Input.GetKeyDown(KeyCode.Joystick1Button18) ||
            Input.GetKeyDown(KeyCode.Joystick1Button19) ||
            Input.GetAxis("joy_1_axis_1") < -0.2 ||
            Input.GetAxis("joy_1_axis_1") > 0.2 ||
            Input.GetAxis("joy_1_axis_0") < -0.2 ||
            Input.GetAxis("joy_1_axis_0") > 0.2 ||
            Input.GetAxis("joy_1_axis_2") < -0.2 ||
            Input.GetAxis("joy_1_axis_2") > 0.2 ||
            Input.GetAxis("joy_1_axis_3") < -0.2 ||
            Input.GetAxis("joy_1_axis_3") > 0.2 ||
            Input.GetAxis("joy_1_axis_4") < -0.2 ||
            Input.GetAxis("joy_1_axis_4") > 0.2 ||
            Input.GetAxis("joy_1_axis_6") < -0.2 ||
            Input.GetAxis("joy_1_axis_6") > 0.2 ||
            Input.GetAxis("joy_1_axis_7") < -0.2 ||
            Input.GetAxis("joy_1_axis_7") > 0.2
            )
        {
            print("Currently used: Gamepad");
            Controller = 1;
        }

    }
}
