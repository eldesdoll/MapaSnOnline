using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public float MoveSpeed = 5;
    public GameObject playerCam;
    public SpriteRenderer sprite;

    public void Awake()
    {
        if (photonView.IsMine)
        {
            playerCam.SetActive(true);
        }
    }

    public void Update()
    {
        if (photonView.IsMine)
        {
            chcecktInputs();
        }
    }

    private void chcecktInputs()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal "), 0);
        transform.position += movement * MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
        }
    }
}
