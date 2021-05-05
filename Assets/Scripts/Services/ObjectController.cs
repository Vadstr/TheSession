using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject objectForMoov;
    public int speed = 500;
    public bool horizontalAcces;
    public bool verticalAcces;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = objectForMoov.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (PlayerMoov.lockPlayerControl)
        {
            var horizontal = 0f;
            var vertical = 0f;

            if (horizontalAcces)
            {
                horizontal = PlayerMoov.horizontal;
            }
            if (verticalAcces)
            {
                vertical = PlayerMoov.vertical;
            }

            rb.velocity = new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        }
    }
}
