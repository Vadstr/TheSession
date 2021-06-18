using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMoov : MonoBehaviour
{
    public GameObject Hint;
    public GameObject Player;
    public int speedH = 800;
    public int speedV = 350;

    private Rigidbody2D rb;
    private GameObject hint;
    private bool animate = false;
    public static bool lockPlayerControl = false;
    public static float horizontal;
    public static float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        loadPosition();
        Application.targetFrameRate = 200;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        var position = Player.transform.position;
        if (!lockPlayerControl)
        {
            rb.velocity = new Vector3(horizontal * speedH * Time.deltaTime, vertical * speedV * Time.deltaTime);
            Player.transform.position = new Vector3(position.x, position.y, position.y * 2 + 83.5f);
            if (Input.GetAxis("Save") != 0)
            {
                savePosition();
            }
        }
        else 
        {
            rb.velocity = new Vector3(0,0);
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
        hint.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
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

        int index = GetTextHint(Other);

        textHintButton.text = textTrigger[index].Substring(0, 1);
        textHintText.text = textTrigger[index].Substring(3);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Accept") != 0 && animate == false)
        {
            animate = true;
            Destroy(hint);

            ActionTriggerStay(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D Other)
    {
        switch (Other.tag)
        {
            case "DoorTrigger":
                RoomsTransition.CloseDoor(Other);
                var textTrigger = Other.GetComponent<Text>().text.Split('.');
                string locationName;
                if (Other.transform.position.y < GetComponent<Transform>().position.y)
                {
                    locationName = textTrigger[0].Substring(9);
                    StartCoroutine(RoomsTransition.HideAndShowHallway(locationName));
                }
                else
                {
                    locationName = textTrigger[1].Substring(9);
                }

                StartCoroutine(RoomsTransition.MoovCamera(locationName));
                break;
        }

        animate = false;
        try
        {
            Destroy(hint);
        }
        catch { }
    }

    private int GetTextHint(Collider2D Other)
    {
        int index = 0;
        switch (Other.tag)
        {
            case "DoorTrigger":
                if (RoomsTransition.Doors[RoomsTransition.NearestObjectByTag(Other, RoomsTransition.Doors)].tag == "Face")
                {
                    if (Other.transform.position.y > GetComponent<Transform>().position.y)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                else if (RoomsTransition.Doors[RoomsTransition.NearestObjectByTag(Other, RoomsTransition.Doors)].tag == "From side")
                {
                    if (Other.transform.position.x < GetComponent<Transform>().position.x)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                break;
            case "MiniGameTrigger":
                index = 0;
                break;
        };
        return index;
    }

    private void ActionTriggerStay(Collider2D Other)
    {
        switch (Other.tag)
        {
            case "DoorTrigger":
                RoomsTransition.OpenNearestDoor(Other);

                if (Other.transform.position.y < GetComponent<Transform>().position.y)
                {
                    StartCoroutine(RoomsTransition.HideAndShowHallway(Other.GetComponent<Text>().text.Split('.')[1].Substring(9)));
                }
                break;
            case "MiniGameTrigger":
                StartCoroutine(RoomsTransition.MoovCamera("mini game"));
                GetComponent<Animator>().SetBool("Hight", true);
                var nearestMiniGame = RoomsTransition.Minigames[RoomsTransition.NearestObjectByTag(Other, RoomsTransition.Minigames)];
                nearestMiniGame.GetComponent<Animator>().SetBool("Show", true);
                MiniGameController.PlayMiniGame(nearestMiniGame);
                lockPlayerControl = !lockPlayerControl;
                break;
            default:
                var nameOfFather = Other.name;
                var father = GameObject.Find(nameOfFather);
                var childsCount = father.transform.GetChildCount();
                for (int i = 0; i < childsCount; i++) 
                {
                    var child = father.transform.GetChild(i);
                    child.gameObject.SetActive(!child.gameObject.activeSelf);
                }
                break;
        }
    }
}
