using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;

    public void Awake()
    {
        canvas.SetActive(true);
    }

    public void SpawnPlayer()
    {
        canvas.SetActive(false);
        //aqui va lo del otro jugador
    } 
}
