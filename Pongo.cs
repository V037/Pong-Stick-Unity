using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //multiplayer

//credits: V.037_

public class Pongo : MonoBehaviour
{
    [SerializeField] private Transform pon;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float sens = 10;
    private bool Right;
    private bool Left;

    private Vector2 velo;
    
    PhotonView view; //multiplayer

    private void Start()
    {
        view = GetComponent<PhotonView>(); //multiplayer
    }

    private void Update()
    {
        if(pon.position.x < 8.5 && Input.GetKey(KeyCode.D))
        {
            Right = true;
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
        chec();    
    }

    private void chec()
    {
        if(Right)
        {
            velo = new Vector2(1, 0);
        }
        if(Left)
        {
            velo = new Vector2(-1, 0);
        }
        if(!Right && !Left || Right && Left)
        {
            velo = new Vector2(0, 0);
        }

        rb.velocity = velo * sens;
    }
}