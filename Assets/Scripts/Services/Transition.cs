using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static IEnumerator TransitionAnimationFrom(GameObject panel) 
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(0.5f);
    }

    public static IEnumerator TransitionAnimationBack(GameObject panel)
    {
        panel.GetComponent<Animator>().SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
    }
}
