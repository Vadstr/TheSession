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

    private void Start()
    {
        Doors = doors;
    }

    public static IEnumerator TransitionAnimationBack(Collider2D doorPlace)
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

        Doors[nearestDoor].GetComponent<Animator>().SetTrigger("open door");
        doorPlace.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        doorPlace.gameObject.SetActive(true);
        Doors[nearestDoor].GetComponent<Animator>().SetTrigger("close door");

    }
}
