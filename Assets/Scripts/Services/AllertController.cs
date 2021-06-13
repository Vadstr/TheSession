using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllertController : MonoBehaviour
{
    public static IEnumerator ShowAllert(Text allertText, string alertText)
    {
        allertText.gameObject.SetActive(true);
        allertText.text = alertText;
        allertText.gameObject.SetActive(true);
        allertText.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.5f);
        while (allertText.color.a >= 0.05)
        {
            allertText.color = new Color(1, 0, 0, allertText.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        allertText.gameObject.SetActive(false);
        yield break;
    }
}
