using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI textCont;
    public int puntos;

    private void Update()
    {
        actualizarUI();
    }

    public void actualizarUI()
    {
        textCont.text = "PUNTOS:" + puntos;
    }
}
