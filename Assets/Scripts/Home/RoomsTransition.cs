using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rooms 
{
    Hallway,
    Kitchen,
    Room
}

public class RoomsTransition : MonoBehaviour
{
    public GameObject player;
    public GameObject hallway;
    public GameObject kitchen;
    public GameObject room;
    public GameObject[] doors;
    public AnimationClip openDoor;
    public static AnimationClip OpenDoor;
    public static GameObject[] Doors;
    public static GameObject Hallway;

    private void Start()
    {
        Doors = doors;
        Hallway = hallway;
    }

    public static IEnumerator OpenNearestDoor(Collider2D doorPlace)
    {
        Doors[NearestDoor(doorPlace)].GetComponent<Animator>().SetBool("open door", true);
        yield return new WaitForEndOfFrame();
    }

    public static IEnumerator CloseDoor(Collider2D doorPlace)
    {
        Doors[NearestDoor(doorPlace)].GetComponent<Animator>().SetBool("open door", false);
        yield return new WaitForEndOfFrame();
    }

    public static IEnumerator MoovCamera(string locationName) 
    {
        var trigerName = "To" + locationName;
        Camera.main.GetComponent<Animator>().SetBool(trigerName, true);
        yield return new WaitForSeconds(0.5f);
        Camera.main.GetComponent<Animator>().SetBool(trigerName, false);
    }

    public static IEnumerator HideAndShowHallway(string locationName) 
    {
        var trigerName = "To" + locationName;
        if (trigerName != "Tohallway")
        {
            Hallway.GetComponent<Animator>().SetBool("FromHallway", true);
            yield return new WaitForSeconds(0.5f);
            Hallway.GetComponent<Animator>().SetBool("FromHallway", false);
        }
        else
        {
            Hallway.GetComponent<Animator>().SetBool("ToHallway", true);
            yield return new WaitForSeconds(0.5f);
            Hallway.GetComponent<Animator>().SetBool("ToHallway", false);
        }
    }


    public static int NearestDoor(Collider2D doorPlace)
    {
        var nearestDoor = new int();
        var shortestDistance = float.MaxValue;
        for (int i = 0; i < Doors.Length; i++)
        {
            var xDifPosition = Mathf.Abs(Doors[i].transform.position.x - doorPlace.transform.position.x);
            var yDifPosition = Mathf.Abs(Doors[i].transform.position.y - doorPlace.transform.position.y);
            var distance = Mathf.Sqrt(Mathf.Pow(xDifPosition, 2) + Mathf.Pow(yDifPosition, 2));
            if (distance < shortestDistance)
            {
                nearestDoor = i;
                shortestDistance = distance;
            }
        }
        return nearestDoor;
    }
}
