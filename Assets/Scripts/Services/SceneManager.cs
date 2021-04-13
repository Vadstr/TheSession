using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    static short currentScene;
    static short loadScene;

    public static void LoadSceneByNumber(int scenNumber,GameObject panel) 
    {
        SavePlayerData.LocationID = scenNumber;
        new SaveSerializable().SaveGame();
        panel.GetComponent<Animator>().SetTrigger("Transition");
        Debug.Log("Correct load scene");
        SceneManager.LoadScene(scenNumber);
    }
}
