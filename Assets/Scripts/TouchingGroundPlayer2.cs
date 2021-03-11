using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingGroundPlayer2 : MonoBehaviour
{
    GameObject Player2;

    void Start()
    {
        Player2 = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player2.GetComponent<Player2>().isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player2.GetComponent<Player2>().isTouchingGround = false;
        }
    }
}