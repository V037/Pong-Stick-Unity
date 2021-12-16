using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credits: V.037_

public class Pongo : MonoBehaviour
{
    [SerializeField] private Transform pon; //add transform of your stick
    [SerializeField] private Rigidbody2D rb; //add rigidbody of your stick
    [SerializeField] private float sens = 10; //sensibility
    private bool Right; //booleans
    private bool Left;

    private Vector2 velo;

    private void Update()
    {
        if(pon.position.x < 8.5 && Input.GetKey(KeyCode.D))
        //pon.position.x is for bounds, go in your unity editor and check what distance you need to stop your pong stick
        {
            Right = true; //more easy way for make this compatible with mobile controls
        }
        else
        {
            Right = false;
        }

        if(pon.position.x > -8.5 && Input.GetKey(KeyCode.A))
        {
            Left = true;
        }
        else
        {
            Left = false;
        }
    }

    private void FixedUpdate()
    {
        chec();    //execute void chec()
    }

    private void chec()
    {
        if(Right)
        {
            velo = new Vector2(1, 0); //set direction to right
        }
        if(Left)
        {
            velo = new Vector2(-1, 0);
        }
        if(!Right && !Left || Right && Left)
        {
            velo = new Vector2(0, 0);
        }

        rb.velocity = velo * sens; //set velocity
    }
}
