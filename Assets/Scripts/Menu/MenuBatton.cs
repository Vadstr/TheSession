using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuBatton : MonoBehaviour
{
    public GameObject panel;
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

    public void NewGame()
    {
        StartCoroutine(PlayGame.CreatNewGame(NewGamePanel, panel));
    }

    public void ContinueGame()
    {
        StartCoroutine(PlayGame.ContinueGame(ContinueGamePanel, panel));
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
        var save = new SaveSerializable();
        if (save.UniquiSaveName(NewGameName.text))
        {
            SavePlayerData.NameOfSave = NewGameName.text;
            NewGameName.text = null;
        }
        else 
        {
            StartCoroutine(ShowAllert());
        }
    }

    public void ChoiseSave() 
    {
        
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
