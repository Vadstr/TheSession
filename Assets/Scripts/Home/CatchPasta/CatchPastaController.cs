using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchPastaController : MonoBehaviour
{
    public Text scoreText;
    public Text Allert;
    public int howMuchPasta;
    public GameObject pasta;
    public GameObject catchPastaPanel;
    public static int catchedPasta;
    public static int allDropedPasta;

    private void Update()
    {
        scoreText.text = catchedPasta + "/" + allDropedPasta;
    }

    public void PlayGame() 
    {
        catchedPasta = 0;
        allDropedPasta = 0;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(AllertController.ShowAllert(Allert, "Try to catch pasta"));
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < howMuchPasta; i++)
        {
            var spavnetPasta = Instantiate( pasta, catchPastaPanel.transform );
            spavnetPasta.transform.localPosition = new Vector3(Random.Range(-5, 6), 6f, -2f);
            yield return new WaitForSeconds(1.5f);
        }

        if (catchedPasta > 0 && catchedPasta <= 5)
        {
            StartCoroutine(AllertController.ShowAllert(Allert, "Very bad, you can better"));
        }
        else if (catchedPasta > 5 && catchedPasta <= 10)
        {
            StartCoroutine(AllertController.ShowAllert(Allert, "Normal? but not very good"));
        }
        else if (catchedPasta > 10 && catchedPasta <= 15)
        {
            StartCoroutine(AllertController.ShowAllert(Allert, "Nice work"));
        }
        else 
        {
            StartCoroutine(AllertController.ShowAllert(Allert, "Excelent! you`re amazing"));
        }

        yield return new WaitForSeconds(3f);

        PlayerMoov.lockPlayerControl = !PlayerMoov.lockPlayerControl;
        StartCoroutine(RoomsTransition.MoovCamera("kitchen"));
        var player = FindObjectOfType<PlayerMoov>();
        GetComponent<Animator>().SetBool("Show", false);
        player.GetComponent<Animator>().SetBool("Hight", false);

    }
}
