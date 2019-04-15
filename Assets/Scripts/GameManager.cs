using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject canvas;
    public GameObject scenenCam;

    public void Awake()
    {
        canvas.SetActive(true);
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-5, 5);
        PhotonNetwork.Instantiate(playerPrefab.name, 
            new Vector2(playerPrefab.transform.position.x * randomValue, 
            playerPrefab.transform.position.y), Quaternion.identity,0);  

        canvas.SetActive(false);
        scenenCam.SetActive(false);
    } 
}
