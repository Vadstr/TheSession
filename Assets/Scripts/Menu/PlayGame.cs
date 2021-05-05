using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public static IEnumerator CreatNewGame(GameObject allcomponent)
    {
        SavePlayerData.NameOfSave = null;
        Transition.TransitionAnimationFrom();
        yield return new WaitForSeconds(0.5f);
        allcomponent.gameObject.SetActive(true);
        while (SavePlayerData.NameOfSave == null) 
        {
            yield return new WaitForSeconds(0.01f);
        }
        var save = new SaveSerializable();
        allcomponent.gameObject.SetActive(false);

        save.SaveGame();
        Transition.TransitionAnimationBack();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public static IEnumerator ContinueGame(GameObject allcomponent)
    {
        Transition.TransitionAnimationFrom();
        var continuePanel = allcomponent.transform.Find("ContinuePanel");
        yield return new WaitForSeconds(0.7f);
        var saves = SaveSerializable.GetAllSavesFile();
        var sortedListOfSave = new List<FileInfo>();
        if (saves.Count != 0)
        {
            allcomponent.gameObject.SetActive(true); 
            for (int i = saves.Count; i > 0 ; i--)
            {
                FileInfo latestSave = null;
                for (int j = 0; j < saves.Count; j++)
                {
                    if (latestSave == null)
                    {
                        latestSave = saves[j];
                    }
                    else if (latestSave.LastWriteTime < saves[j].LastWriteTime) 
                    {
                        latestSave = saves[j];
                    }
                }

                for (int j = 0; j < saves.Count; j++) 
                {
                    if (latestSave.Name == saves[j].Name)
                        saves.Remove(saves[j]);
                } 
                sortedListOfSave.Add(latestSave);
            }
            ShowSaves.ShowSavesAndData(sortedListOfSave);
            continuePanel.GetComponent<Animator>().SetTrigger("Show");
            yield return new WaitForSeconds(0.7f);
            continuePanel.gameObject.SetActive(false);
            while (SavePlayerData.NameOfSave == null) 
            {
                yield return new WaitForSeconds(0.05f);
            }
            continuePanel.gameObject.SetActive(true);
            continuePanel.GetComponent<Animator>().SetTrigger("hight");
            yield return new WaitForSeconds(0.7f);
            allcomponent.gameObject.SetActive(false);
            SceneManager.LoadScene(SavePlayerData.LocationID);
        }
        yield return new WaitForSeconds(0.5f);
    }
}