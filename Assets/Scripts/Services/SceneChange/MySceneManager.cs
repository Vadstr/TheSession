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
        UnityEngine.SceneManagement.SceneManager.LoadScene(scenNumber);
    }
}
