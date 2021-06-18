using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private int scenNumber;
    public void LoadSceneByNumber(int sceneNumber) 
    {
        scenNumber = sceneNumber;
        Transition.TransitionAnimationFrom();
        Invoke("LoadScene", 0.5f);
    }

    private void LoadScene()
    {
        Debug.Log("Correct load scene");
        SceneManager.LoadScene(scenNumber);
    }
}
