using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
        SavePlayerData.NameOfSave = null;
    }

    public void FixedUpdate()
    {
        try
        {
            string nameButton = EventSystem.current.currentSelectedGameObject.name;
            if (nameButton.Contains("save"))
            {
                var nameOfSave = nameButton.Substring(4);
                if (!SaveSerializable.UniquiSaveName(nameOfSave))
                {
                    SaveSerializable.LoadGame(nameOfSave);
                    nameButton = null;
                }
            }
        }
        catch { }

        if (Input.GetAxis("Cancel") != 0) 
        {
            Transition.TransitionAnimationFrom();
            SceneManager.LoadScene(0);
        }
    }

    public void NewGame()
    {
        StartCoroutine(PlayGame.CreatNewGame(NewGamePanel));
    }

    public void ContinueGame()
    {
        var saves = SaveSerializable.GetAllSavesFile();
        var sortedListOfSave = new List<FileInfo>();
        if (saves.Count != 0)
        {
            StartCoroutine(PlayGame.ContinueGame(ContinueGamePanel, saves, sortedListOfSave));
        }
        else
        {
            StartCoroutine(AllertController.ShowAllert(allertText, "0 saves"));
        }
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
            SavePlayerData.CoordinateOnScene = new Vector3(0,0,0);
            SavePlayerData.LocationID = 1;
            SavePlayerData.StoryTrigger = 0;
            SavePlayerData.OtherCaracteristics = new Dictionary<float, string>();
            NewGameName.text = null;
        }
        else 
        {
            StartCoroutine(AllertController.ShowAllert(allertText, "Not unigue name"));
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
}
