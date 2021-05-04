using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MySceneManager
{
    public static void LoadSceneByNumber(int scenNumber) 
    {
        Transition.TransitionAnimationFrom();
        Debug.Log("Correct load scene");
        SceneManager.LoadScene(scenNumber);
    }

    public static void LoadScene()
    {
        SavePlayerData.LocationID = SceneManager.GetActiveScene().buildIndex;
        new SaveSerializable().SaveGame();
        Transition.TransitionAnimationBack();
    }
}
