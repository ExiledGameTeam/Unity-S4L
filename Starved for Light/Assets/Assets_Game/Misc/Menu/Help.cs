﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TeamUtility.IO;

public class Help : MonoBehaviour {

    public GameObject manager;
    private DetectController control;
    private MainMenuButtons menu;
    private int CurrentC;
    private bool InOptions;
    public GameObject text;
    public GameObject xbox;
    public GameObject Key;

	// Use this for initialization
	void Start () {

        control = manager.GetComponent<DetectController>();
        menu = manager.GetComponent<MainMenuButtons>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
        CurrentC = control.Controller;
        InOptions = menu.Inoptions;
        if (InOptions == true && CurrentC == 0)
        {
            xbox.SetActive(false);
            Key.SetActive(true);
            text.SetActive(true);
        }
        else if (InOptions == true && CurrentC == 1)
        {
            Key.SetActive(false);
            xbox.SetActive(true);
            text.SetActive(true);
        }
        else
        {
            Key.SetActive(false);
            xbox.SetActive(false);
            text.SetActive(false);
        }
    }
}
