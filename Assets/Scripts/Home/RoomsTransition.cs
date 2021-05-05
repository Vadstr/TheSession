using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsTransition : MonoBehaviour
{
    public GameObject player;
    public GameObject hallway;
    public GameObject kitchen;
    public GameObject room;
    public GameObject[] minigames;
    public GameObject[] doors;
    public AnimationClip openDoor;
    public static AnimationClip OpenDoor;
    public static GameObject[] Doors;
    public static GameObject[] Minigames;
    public static GameObject Hallway;

    private void Start()
    {
        Doors = doors;
        Hallway = hallway;
        Minigames = minigames;
    }

    public static void OpenNearestDoor(Collider2D doorPlace)
    {
        if (Doors[NearestObjectByTag(doorPlace, Doors)].tag == "Face")
        {
            Doors[NearestObjectByTag(doorPlace, Doors)].GetComponent<Animator>().SetBool("open door", true);
        }
        else if (Doors[NearestObjectByTag(doorPlace, Doors)].tag == "From side") 
        {
            Doors[NearestObjectByTag(doorPlace, Doors)].GetComponent<Animator>().SetBool("open door bathroom", true);
        }
    }

    public static void CloseDoor(Collider2D doorPlace)
    {
        if (Doors[NearestObjectByTag(doorPlace, Doors)].tag == "Face")
        {
            Doors[NearestObjectByTag(doorPlace, Doors)].GetComponent<Animator>().SetBool("open door", false);
        }
        else if (Doors[NearestObjectByTag(doorPlace, Doors)].tag == "From side") 
        {
            Doors[NearestObjectByTag(doorPlace, Doors)].GetComponent<Animator>().SetBool("open door bathroom", false);
        }
    }

    public static IEnumerator MoovCamera(string locationName)
    {
        var trigerName = "To" + locationName;
        if (locationName != "bathroom")
        {
            Camera.main.GetComponent<Animator>().SetBool(trigerName, true);
            yield return new WaitForSeconds(0.5f);
            Camera.main.GetComponent<Animator>().SetBool(trigerName, false);
        }
    }

    public static IEnumerator HideAndShowHallway(string locationName) 
    {
        var trigerName = "To" + locationName;
        if (trigerName != "Tohallway")
        {
            Hallway.GetComponent<Animator>().SetBool("FromHallway", true);
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Hallway.GetComponent<Animator>().SetBool("ToHallway", true);
            yield return new WaitForSeconds(0.5f);
        }
        Hallway.GetComponent<Animator>().SetBool("FromHallway", false);
        Hallway.GetComponent<Animator>().SetBool("ToHallway", false);
    }


    public static int NearestObjectByTag(Collider2D Other, GameObject[] objects)
    {
        var nearestObjectIndex = new int();
        var shortestDistance = float.MaxValue;
        for (int i = 0; i < objects.Length; i++)
        {
            var xDifPosition = Mathf.Abs(objects[i].transform.position.x - Other.transform.position.x);
            var yDifPosition = Mathf.Abs(Doors[i].transform.position.y - Other.transform.position.y);
            var distance = Mathf.Sqrt(Mathf.Pow(xDifPosition, 2) + Mathf.Pow(yDifPosition, 2));
            if (distance < shortestDistance)
            {
                nearestObjectIndex = i;
                shortestDistance = distance;
            }
        }
        return nearestObjectIndex;
    }
}
