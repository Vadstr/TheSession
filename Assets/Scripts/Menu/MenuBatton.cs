using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBatton : MonoBehaviour
{
    public void NewGame()
    {
    }

    public void ContinueGame() 
    {
    }

    public void Authors()
    {
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeLanguage() 
    {
        LanguageID.languageID += 1;
    }
}
