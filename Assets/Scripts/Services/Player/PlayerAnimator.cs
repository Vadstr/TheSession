using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    void Update()
    {
        if (!PlayerMoov.lockPlayerControl)
        {
            if (PlayerMoov.horizontal >= 0.1 && Math.Abs(PlayerMoov.horizontal) >= Math.Abs(PlayerMoov.vertical) * 0.7f)
            {
                GetComponent<Animator>().SetBool("Right", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Right", false);
            }

            if (PlayerMoov.horizontal <= -0.1 && Math.Abs(PlayerMoov.horizontal) >= Math.Abs(PlayerMoov.vertical) * 0.7f)
            {
                GetComponent<Animator>().SetBool("Left", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Left", false);
            }

            if (PlayerMoov.vertical >= 0.1 && Math.Abs(PlayerMoov.horizontal) <= Math.Abs(PlayerMoov.vertical) * 0.7f)
            {
                GetComponent<Animator>().SetBool("Up", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Up", false);
            }

            if (PlayerMoov.vertical <= -0.1 && Math.Abs(PlayerMoov.horizontal) <= Math.Abs(PlayerMoov.vertical) * 0.7f)
            {
                GetComponent<Animator>().SetBool("Down", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Down", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Right", false);
            GetComponent<Animator>().SetBool("Left", false);
            GetComponent<Animator>().SetBool("Up", false);
            GetComponent<Animator>().SetBool("Down", false);
        }
    }
}
