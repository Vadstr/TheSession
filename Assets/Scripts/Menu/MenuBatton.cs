using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MenuBatton : MonoBehaviour
{
    public GameObject panel;

    public void NewGame()
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
    }

    public void ContinueGame() 
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
    }

    public void Authors()
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        PrintAutors();
        panel.GetComponent<Animator>().SetTrigger("Back");
    }

    public void Exit()
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        Application.Quit();
    }

    public void ChangeLanguage() 
    {
        LanguageID.languageID += 1;
    }

    private void PrintAutors()
    {
    }
}
