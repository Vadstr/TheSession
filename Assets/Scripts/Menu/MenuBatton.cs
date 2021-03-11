using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MenuBatton : MonoBehaviour
{
    public GameObject panel;
    public Text autorsText;
    public int speed = 0;

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
        StartCoroutine(Autors(new Transition(),new Autors()));
    }

    public void Exit()
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        Application.Quit();
    }

    public void ChangeLanguage() 
    {
        var ID = LanguageID.languageID;
        ID += 1;
        LanguageID.languageID = ID % 3;
    }

    public IEnumerator Autors(Transition transition, Autors autors) 
    {
        yield return StartCoroutine(transition.TransitionAnimationFrom(panel));
        yield return StartCoroutine(autors.ShowAutors(autorsText, panel, speed));
        yield return StartCoroutine(transition.TransitionAnimationBack(panel));
    }
}
