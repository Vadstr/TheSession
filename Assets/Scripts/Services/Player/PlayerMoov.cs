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
    public string Playertag;

    private Rigidbody2D rb;
    private GameObject hint;
    private bool animate = false;
    private static float positionZ;
    public static float horizontal;
    public static float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        positionZ = 90;
        loadPosition();
        Application.targetFrameRate = 200;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        var position = Player.transform.position;/*
        Player.transform.position = new Vector3(horizontal * speed * Time.deltaTime + position.x, vertical * speed * Time.deltaTime + position.y, 90);*/
        Player.transform.position = new Vector3(position.x, position.y, positionZ);
        rb.velocity = new Vector3(horizontal * speedH * Time.deltaTime, vertical * speedV * Time.deltaTime);
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
        hint.transform.position = new Vector3(xPoz, yPoz, positionZ);
        var textHintButton = hint.GetComponentInChildren<Text>();
        var textHintText = hint.transform.Find("HintText").GetComponent<Text>();
        var textTrigger = Other.GetComponent<Text>();
        textHintButton.text = textTrigger.text.Substring(0,1);
        textHintText.text = textTrigger.text.Substring(3);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Accept") != 0 && animate == false)
        {
            animate = true;
            Debug.Log("maria loh");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(hint);
        animate = false;
    }
}
