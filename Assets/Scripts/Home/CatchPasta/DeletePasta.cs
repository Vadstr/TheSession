using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePasta : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.localPosition.y < -7)
        {
            Destroy(gameObject);
            CatchPastaController.allDropedPasta += 1;
        }
    }

    private void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.tag == "InsidePan")
        {
            Destroy(gameObject);
            CatchPastaController.catchedPasta += 1;
            CatchPastaController.allDropedPasta += 1;
        }
    }
}
