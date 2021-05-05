using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour
{
    public GameObject hallway;
    void Start()
    {
        if (SavePlayerData.CoordinateOnScene.y > 0 && SavePlayerData.CoordinateOnScene.x > 0)
        {
            StartCoroutine("StartFromRoom");
        }
        else if (SavePlayerData.CoordinateOnScene.y > 0 && SavePlayerData.CoordinateOnScene.x < 0)
        {
            StartCoroutine("StartFromHallway");
        }
    }

    public IEnumerator StartFromRoom() 
    {
        Camera.main.GetComponent<Animator>().SetBool("Toroom", true);
        hallway.GetComponent<Animator>().SetBool("FromHallway", true);
        yield return new WaitForSeconds(0.1f);
        Camera.main.GetComponent<Animator>().SetBool("Toroom", false);
    }
    public IEnumerator StartFromHallway()
    {
        Camera.main.GetComponent<Animator>().SetBool("Tokitchen", true);
        hallway.GetComponent<Animator>().SetBool("FromHallway", true);
        yield return new WaitForSeconds(0.1f);
        Camera.main.GetComponent<Animator>().SetBool("Tokitchen", false);
    }
}
