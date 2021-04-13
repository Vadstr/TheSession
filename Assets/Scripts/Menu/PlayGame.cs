using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public static IEnumerator CreatNewGame(GameObject allcomponent, GameObject panel)
    {
        SavePlayerData.NameOfSave = null;
        var transition = new Transition();
        panel.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(0.5f);
        allcomponent.gameObject.SetActive(true);
        while (true) 
        {
            if (SavePlayerData.NameOfSave == null)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else 
            {
                break;
            }
        }
        var save = new SaveSerializable();
        allcomponent.gameObject.SetActive(false);
        save.SaveGame();
        panel.GetComponent<Animator>().SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
        transition.TransitionToScene(panel, 0);
    }

    public static IEnumerator ContinueGame(GameObject allcomponent, GameObject panel)
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        var continuePanel = allcomponent.transform.FindChild("ContinuePanel");
        yield return new WaitForSeconds(0.7f);
        var save = new SaveSerializable();
        var saves = save.GetAllSavesFile();
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
        }
        yield return new WaitForSeconds(0.5f);
    }
}