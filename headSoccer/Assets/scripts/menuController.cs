﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class menuController : MonoBehaviour
{
    private static GameObject mainMenu, controls, selection;
    private static TextMeshProUGUI screenName;
    public static Stack selectionStack = new Stack();


    // Start is called before the first frame update
    void Start()
    {
       
        mainMenu = this.gameObject.transform.GetChild(0).gameObject;
        controls = this.gameObject.transform.GetChild(1).gameObject;
        selection = this.gameObject.transform.GetChild(2).gameObject;
        screenName = selection.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>();

        //default start
        mainMenu.SetActive(true);
        controls.SetActive(false);
        selection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick(string actionName)
    {
        switch (actionName)
        {
            case "controls":
                controls.SetActive(true);
                mainMenu.SetActive(false);
                selection.SetActive(false);
                break;
            case "playMenu":
                selection.SetActive(true);
                controls.SetActive(false);
                mainMenu.SetActive(false);

                selectionStack.Push(0); //default player1 es 0 index, argentinos
                break;
            case "backControls":
                mainMenu.SetActive(true);
                selection.SetActive(false);
                controls.SetActive(false);
                break;
            case "backSelection":
                if (selectionStack.Count == 1)
                {
                    mainMenu.SetActive(true);
                    selection.SetActive(false);
                    controls.SetActive(false);
                }
                else if(selectionStack.Count == 2)
                {
                    screenName.text = "PLAYER 1:";
                }
                else
                {
                    screenName.text = "PLAYER 2:";
                }
                selectionStack.Pop();
                break;
            case "nextSelection":
                if (selectionStack.Count == 1)
                {
                    screenName.text = "PLAYER 2:";
                    selectionStack.Push(0); //default player1 es 0 index, argentinos
                }
                else if (selectionStack.Count == 2)
                {
                    screenName.text = "STADIUM:";
                    selectionStack.Push(0); //default player1 es 0 index, argentinos
                }
                else
                {
                    CambiarEscena();
                }
                break;
            default:
                selectionStack.Pop();
                selectionStack.Push(actionName);
                break;
        }
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("Juego");
    }
}
