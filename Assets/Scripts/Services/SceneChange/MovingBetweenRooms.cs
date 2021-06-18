using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBetweenRooms : MonoBehaviour
{
    public GameObject door;
    public GameObject prompt;
    public Camera mainCamera;
    public int scenNumber;
    public string playertag;

    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.tag == playertag)
        {
            if (Input.GetKey(KeyCode.E))
            {
                var sceneManager = new GameObject();
                var manager = sceneManager.AddComponent<MySceneManager>();
                manager.LoadSceneByNumber(scenNumber);
            }
        }
    }
}
