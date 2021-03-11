using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public IEnumerator CreatNewGame(GameObject allcomponent, GameObject panel)
    {
        var transition = new Transition();
        panel.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(0.5f);
        allcomponent.gameObject.SetActive(true);
        var menuButton = new MenuBatton();
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

    public IEnumerator ContinueGame() 
    {
        return null;
    }
}
