using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public static GameObject darkPanelForTransition;
    public GameObject panel;

    private void Start()
    {
        try
        {
            darkPanelForTransition = panel;
        }
        catch { }

        TransitionAnimationBack();
    }

    public static void TransitionAnimationFrom() 
    {
        darkPanelForTransition.GetComponent<Animator>().SetTrigger("Transition");
    }

    public static IEnumerator TransitionAnimationBack()
    {
        darkPanelForTransition.GetComponent<Animator>().SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
    }
}
