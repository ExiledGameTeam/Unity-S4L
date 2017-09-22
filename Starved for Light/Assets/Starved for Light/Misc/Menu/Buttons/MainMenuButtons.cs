using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TeamUtility.IO;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    //float time = 3.0f; //never used

    public EventSystem ES;
    private GameObject StoreSelected;
    public Button Quit;
    public Button Settings;
    public Button Extras;
    public Button Continue;
    public Button NewGame;
    public GameObject OptionPanel;
    public Animator options;
    public Animator White;

    public GameObject FadeObject;
    //TODO: Complete fade
    //private Animation fade;

    public bool Inoptions = false;

    public GameObject Soptions;
    public GameObject Main;

    public Button ToTest;


    // Use this for initialization
    void Start()
    {
        //fade = FadeObject.GetComponent<Animation>();
        StoreSelected = ES.firstSelectedGameObject;
        options = OptionPanel.GetComponent<Animator>();
        options.SetBool("InOptions", false);
    }

    void Update()
    {
        if (Input.anyKeyDown ||
            InputManager.GetAxis("Vertical") < -0.1 ||
            InputManager.GetAxis("Vertical") > 0.1 ||
            InputManager.GetAxis("Horizontal") < -0.1 ||
            InputManager.GetAxis("Horizontal") > 0.1 ||
            Input.GetAxis("joy_1_axis_6") < -0.2 ||
            Input.GetAxis("joy_1_axis_6") > 0.2 ||
            Input.GetAxis("joy_1_axis_7") < -0.2 ||
            Input.GetAxis("joy_1_axis_7") > 0.2)
        {
            if (ES.currentSelectedGameObject != StoreSelected)
            {
                print("1");
                if (ES.currentSelectedGameObject == null)
                {
                    ES.SetSelectedGameObject(StoreSelected);
                    print("2");
                }
                else
                    StoreSelected = ES.currentSelectedGameObject;
            }
        }
        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            ES.SetSelectedGameObject(null);
        }
        if (Inoptions == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Inoptions = false;
                options.SetBool("InOptions", false);
                ES.SetSelectedGameObject(null);
                StoreSelected = Main;
            }
        }
    }

    public void QuitClick()
    {
        Application.Quit();
        print("GameQuited");
    }
    public void SettingsClick()
    {
        options.SetBool("InOptions", true);
        Inoptions = true;
        options.SetBool("Check", true);
        Debug.Log("You have clicked the button!");
        StoreSelected = Soptions;
        ES.SetSelectedGameObject(Soptions);
    }
    public void ExtrasClick()
    {
        Debug.Log("Depr");
    }
    public void ContinueClick()
    {
        Debug.Log("Depr");
    }
    public void NewGameClick()
    {
        White.SetBool("WhiteOff", false);
        StartCoroutine(ExecuteAfterTime());
    }
    public void ToTestClick()
    {
        Debug.Log("Depr");
        SceneManager.LoadScene("Test Chamber");
    }
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadSceneAsync("DreamHub");
    }
}
