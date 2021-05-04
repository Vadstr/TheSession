using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static GameObject darkPanelForTransition;
    public GameObject panel;

    private void Start()
    {
        darkPanelForTransition = panel;
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
