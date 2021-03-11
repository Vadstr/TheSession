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
    public GameObject NewGamePanel;
    public GameObject ContinueGamePanel;
    public InputField NewGameName;
    public Text autorsText;
    public int speed = 0;
    private LanguageIDAccessor languageIdAccessor;

    public void Start()
    {
        languageIdAccessor = new LanguageIDAccessor();
        languageIdAccessor.LoadLanguageID();
    }

    public void NewGame()
    {
        var game = new PlayGame();
        StartCoroutine(game.CreatNewGame(NewGamePanel, panel));
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

    public void CreatGame() 
    {
        SavePlayerData.NameOfSave = NewGameName.text;
    }

    public void ChangeLanguage() 
    {
        var ID = LanguageID.languageID;
        ID += 1;
        LanguageID.languageID = ID % 3;
        languageIdAccessor.SaveLanguageID();
    }

    public IEnumerator Autors(Transition transition, Autors autors) 
    {
        yield return StartCoroutine(transition.TransitionAnimationFrom(panel));
        yield return StartCoroutine(autors.ShowAutors(autorsText, panel, speed));
        yield return StartCoroutine(transition.TransitionAnimationBack(panel));
    }
}
