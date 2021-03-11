using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingGroundPlayer1 : MonoBehaviour
{
    GameObject Player1;

    void Start()
    {
        Player1 = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player1.GetComponent<Player1>().isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player1.GetComponent<Player1>().isTouchingGround = false;
        }
    }
}
