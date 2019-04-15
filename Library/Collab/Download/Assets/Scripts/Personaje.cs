using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Personaje : MonoBehaviour
{
    public int casillaActual=0, ph=0;
    public TextMeshProUGUI textoCasillaActual;
    public TextMeshProUGUI textoPH;
   
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        imprimeCasilla();
        verificaCasilla();
        //GetComponent<Dado>().esTurno = true;
       
    }

    public void imprimeCasilla()
    {
        if (GetComponent<Dado>().esTurno == false)
        {
            if (casillaActual < 10)
            {
             textoCasillaActual.text = "0" + casillaActual;
            }
            else
            {
             textoCasillaActual.text = "" + casillaActual;
            }
            if (casillaActual >= 100)
            {
                textoCasillaActual.fontSize = 30;
            }
        }
    }

    public void imprimePh()
    {
        textoPH.text = "" + ph;
    }

    public void verificaCasilla()
    {
        if (casillaActual >0 && GetComponent<Dado>().yaTiro==true)
        {
            if (GetComponent<CrearCasilla>().casillas[casillaActual-1].GetComponent<Casilla>().esHabilidad == true)
            {
                if (ph >= 4)
                {
                    ph = 4;
                }
                else
                {
                    ph = ph + 1;
                }

            }
            else if (GetComponent<CrearCasilla>().casillas[casillaActual-1].GetComponent<Casilla>().esDeshabilidad == true)
            {
                if (ph <= 0)
                {
                    ph = 0;
                }
                else
                {
                    ph = ph - 1;
                }
            }
            else if (GetComponent<CrearCasilla>().casillas[casillaActual - 1].GetComponent<Casilla>().esNegra == true)
            {
                ph = 0;
            }
            imprimePh();
        }
        GetComponent<Dado>().yaTiro = false;
    }
}
