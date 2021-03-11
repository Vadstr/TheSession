using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public IEnumerator TransitionAnimationFrom(GameObject panel) 
    {
        panel.GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator TransitionToScene(GameObject panel, int scennum)
    {
        if (!panel.GetComponent<AnimatorStateInfo>().IsName("TransitionFromMainMenu"))
        {
            yield return StartCoroutine(TransitionAnimationFrom(panel));
        }
        SceneManager.LoadScene(scennum);
    }

    public IEnumerator TransitionAnimationBack(GameObject panel)
    {
        panel.GetComponent<Animator>().SetTrigger("Back");
        yield return new WaitForSeconds(0.5f);
    }
}
