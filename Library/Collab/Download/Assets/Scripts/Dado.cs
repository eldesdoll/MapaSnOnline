using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dado : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Marco;
    public TextMeshProUGUI contDado;
    public bool esTurno=false, seDetuvo=false;
    public float valorMax=6, tiempo;
    public int valorDado=1;
    public bool yaTiro = false;



    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime + tiempo;
        estado();
        contador();
        

    }

    public void contador()
    {
        if (seDetuvo == false)
        {
            contDado.color = Color.black;
            if (tiempo >= 0.08f)
            {
                tiempo = 0.0f;
                if (valorDado >= valorMax)
                {
                    valorDado = 1;
                }
                else
                {
                    valorDado++;
                    
                }
            }
        }
        else
        {
            contDado.color = Color.red;
            if (tiempo >= 1.5f)
            {
                GetComponent<Personaje>().casillaActual = GetComponent<Personaje>().casillaActual + valorDado;
                esTurno = false;
                seDetuvo = false;
                yaTiro = true;
            }
            
        }
        
        
    }

    public void estado()
    {
        if (esTurno == true)
        {
            Marco.SetActive(true);
            contDado.text = "" + valorDado;
        }
        else
        {
            Marco.SetActive(false);
            valorDado = 1;
        }
    }

    public void parar()
    {
        seDetuvo = true;
    }


}
