using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoov : MonoBehaviour
{
    public GameObject Hint;
    public GameObject Player;
    public int speedH = 450;
    public int speedV = 250;

    private Rigidbody2D rb;
    private GameObject hint;
    private bool animate = false;
    private float yPozFromPrevFrame;
    public static float horizontal;
    public static float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        yPozFromPrevFrame = Player.transform.position.y;
        loadPosition(); 
        Application.targetFrameRate = 200;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        var position = Player.transform.position;/*
        Player.transform.position = new Vector3(horizontal * speed * Time.deltaTime + position.x, vertical * speed * Time.deltaTime + position.y, 90);*/

        rb.velocity = new Vector3(horizontal * speedH * Time.deltaTime, vertical * speedV * Time.deltaTime);
        Player.transform.position = new Vector3(position.x, position.y, position.y + 83.5f);
        yPozFromPrevFrame = position.y;
        if (Input.GetAxis("Save") != 0 )
        {
            savePosition();
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

    private void OnTriggerEnter2D(Collider2D Other)
    {
        hint = Instantiate(Hint, GetComponent<Transform>());
        hint.transform.localScale = new Vector3(0.001f,0.001f,0.001f);
        var yPoz = Player.transform.position.y + 1.5f;
        var xPoz = Player.transform.position.x;
        if (Camera.main.transform.position.x > xPoz)
        {
            xPoz += 3f;
        }
        else 
        {
            xPoz -= 3f;
        }

        hint.transform.position = new Vector3(xPoz, yPoz, Player.transform.position.z);
        var textHintButton = hint.GetComponentInChildren<Text>();
        var textHintText = hint.transform.Find("HintText").GetComponent<Text>();
        var textTrigger = Other.GetComponent<Text>().text.Split('.');

        int index;
        if (Other.transform.position.y > GetComponent<Transform>().position.y)
        {
            index = 0;
        }
        else 
        {
            index = 1;
        }
        textHintButton.text = textTrigger[index].Substring(0,1);
        textHintText.text = textTrigger[index].Substring(3);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Accept") != 0 && animate == false)
        {
            animate = true;
            Destroy(hint);
            StartCoroutine(RoomsTransition.OpenNearestDoor(collision));

            if (collision.transform.position.y < GetComponent<Transform>().position.y)
            {
                var textTrigger = collision.GetComponent<Text>().text.Split('.');
                var locationName = textTrigger[1].Substring(9);
                StartCoroutine(RoomsTransition.HideAndShowHallway(locationName));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(RoomsTransition.CloseDoor(collision));

        int index;
        if (collision.transform.position.y < GetComponent<Transform>().position.y)
        {
            index = 0;
        }
        else
        {
            index = 1;
        }

        var textTrigger = collision.GetComponent<Text>().text.Split('.');
        var locationName = textTrigger[index].Substring(9);
        StartCoroutine(RoomsTransition.MoovCamera(locationName));
        if (locationName != "hallway")
        {
            StartCoroutine(RoomsTransition.HideAndShowHallway(locationName));
        }

        animate = false;
        try
        {
            Destroy(hint);
        }
        catch { }
    }
}
