using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoov : MonoBehaviour
{
    public GameObject Player;
    public Vector2 Vect;
    const int speed = 5;
    public string Playertag;


    private void Start()
    {
        loadPosition();
        Application.targetFrameRate = 60;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            savePosition();

        if (Input.GetKeyDown(KeyCode.L))
        {
            loadPosition();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Player.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Player.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void savePosition()
    {
        Vector3 CurrentPlayerPosition = Player.gameObject.transform.position;
        SavePlayerData.CoordinateOnScene = CurrentPlayerPosition;
    }

    public void loadPosition()
    {
        Transform CurrentPlayerPosition = Player.gameObject.transform;
        CurrentPlayerPosition.position = SavePlayerData.CoordinateOnScene;
    }

    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.tag == Playertag)
        {
            if (Input.GetKey(KeyCode.E))
            {
                savePosition();


            }
        }
    }
}
