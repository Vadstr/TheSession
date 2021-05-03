using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoov : MonoBehaviour
{
    public GameObject Player;
    public int speedH = 450;
    public int speedV = 250;
    public string Playertag;
    private Rigidbody2D rb;

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

    private void OnTriggerStay2D(Collider2D Other)
    {
        Debug.Log("On triger");
    }
}
