using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuBatton : MonoBehaviour
{
    public GameObject NewGamePanel;
    public GameObject ContinueGamePanel;
    public InputField NewGameName;
    public Text autorsText;
    public Text allertText;
    public int speed = 0;
    public GameObject showSavePanel;
    public GameObject content;
    private LanguageIDAccessor languageIdAccessor; 

    public void Start()
    {
        languageIdAccessor = new LanguageIDAccessor();
        languageIdAccessor.LoadLanguageID();
        ShowSaves.content = content;
        ShowSaves.showSavePanel = showSavePanel;
    }

    public void FixedUpdate()
    {
        try
        {
            string nameButton = EventSystem.current.currentSelectedGameObject.name;
            var nameOfSave = nameButton.Substring(4);
            if (!SaveSerializable.UniquiSaveName(nameOfSave)) 
            {
                SaveSerializable.LoadGame(nameOfSave);
                nameOfSave = null;
            }
        }
        catch { }
    }

    public void NewGame()
    {
        StartCoroutine(PlayGame.CreatNewGame(NewGamePanel));
    }

    public void ContinueGame()
    {
        StartCoroutine(PlayGame.ContinueGame(ContinueGamePanel));
    }

    public void Authors()
    {
        StartCoroutine(Autors(new Autors()));
    }

    public void Exit()
    {
        Transition.TransitionAnimationFrom();
        Application.Quit();
    }

    public void CreatGame()
    {
        if (SaveSerializable.UniquiSaveName(NewGameName.text))
        {
            SavePlayerData.NameOfSave = NewGameName.text;
            NewGameName.text = null;
        }
        else 
        {
            StartCoroutine(ShowAllert());
        }
    }

    public void ChangeLanguage() 
    {
        var ID = LanguageID.languageID;
        ID += 1;
        LanguageID.languageID = ID % 3;
        languageIdAccessor.SaveLanguageID();
    }

    public IEnumerator Autors(Autors autors) 
    {
        Transition.TransitionAnimationFrom();
        yield return StartCoroutine(autors.ShowAutors(autorsText, speed));
        yield return StartCoroutine(Transition.TransitionAnimationBack());
    }

    public IEnumerator ShowAllert() 
    {
        allertText.gameObject.SetActive(true);
        allertText.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.5f);
        while (allertText.color.a >= 0.05) 
        {
            allertText.color = new Color(1, 0, 0, allertText.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        allertText.gameObject.SetActive(false);
        yield break;
    }
}
