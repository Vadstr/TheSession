using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public IEnumerator CreatNewGame(GameObject allcomponent, GameObject panel)
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

    public IEnumerator ContinueGame(GameObject allcomponent, GameObject panel)
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(0.5f);
        var save = new SaveSerializable();
        var saves = save.GetAllSavesFile();
        if (saves.Count != 0)
        {
            allcomponent.gameObject.SetActive(true);
            var sortedListOfSave = new List<FileInfo>();
            for (int i = 0; i < saves.Count; i++)
            {
                FileInfo latestSave = null;
                for (int j = i; j < saves.Count; j++)
                {
                    if (latestSave == null)
                    {
                        latestSave = saves[j];
                    }
                    else if (File.GetLastWriteTime(latestSave.FullName) < File.GetLastWriteTime(saves[j].FullName)) 
                    {
                        latestSave = saves[j];
                    }
                }
                sortedListOfSave.Add(latestSave);
            }
            ShowSaves.ShowSavesAndData(sortedListOfSave);
        }
    }
}
