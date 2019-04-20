using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidades : MonoBehaviour
{
    public GameObject scripts, per;
    public float tiempo;
    public bool actTiempo = false;
    public bool esHab1 = false, esHab2 = false, esHab3 = false, usoHab = false;
    //zorem
    public bool verCasiHab1Zor = false, condiZor1 = false;
    //Ian
    //Austin
    public GameObject btnCasillas;
    public List<GameObject> botones = new List<GameObject>();
    public bool hayPint = false, presionado1, presionado2, condiHab1Aus;
    public int casillaAPintar, dif, verifCasilla, dif1, dif2;
    public float casRecorridas;
    //Rubi
    //Stella
    //Leonn
    public bool repite = false;
    //
    void Update()
    {
        if (actTiempo == true) { tiempo = Time.deltaTime + tiempo; }
        per = GameObject.FindGameObjectWithTag("PerPref");
        scripts = GameObject.Find("Scripts");
        terminarHabilidades();
    }

    public void habilidad1()
    {

        esHab1 = true;
        switch (GetComponent<CrearPersonaje>().idPersonaje)
        {
            case 0:
                hab1zorem();
                break;
            case 1:

                break;
            case 2:
                hab1austin();
                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 1;
        per.GetComponent<Personaje>().imprimePh();
        usoHab = true;
    }
    public void habilidad2()
    {
        esHab2 = true;
        switch (GetComponent<CrearPersonaje>().idPersonaje)
        {
            case 0:
                //hab2zorem();
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 2;
        per.GetComponent<Personaje>().imprimePh();
        usoHab = true;
    }
    public void habilidad3()
    {
        esHab3 = true;
        switch (GetComponent<CrearPersonaje>().idPersonaje)
        {
            case 0:
                hab3zorem();
                break;
            case 1:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:
                hab3leonn();
                break;
            default:
                break;
        }
        per.GetComponent<Personaje>().ph = per.GetComponent<Personaje>().ph - 3;
        per.GetComponent<Personaje>().imprimePh();
        usoHab = true;
    }

    //---------------------------------------------ZOREM---------------------------------------------
    public void hab1zorem()
    {
        verCasiHab1Zor = true;
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        per.GetComponent<Animator>().SetBool("hab1", true);
    }
    public void terhab1zor()
    {

        if (tiempo >= 2.5f)
        {

            if (tiempo >= 2f && condiZor1 == false)
            {
                GetComponent<CrearPersonaje>().posx = GetComponent<CrearPersonaje>().posx + 6;
                per.transform.localPosition = new Vector3(scripts.GetComponent<CrearPersonaje>().posx, scripts.GetComponent<CrearPersonaje>().posy);
                condiZor1 = true;
            }
            else
            {
                GetComponent<Dado>().btnHab1.SetActive(false);
            }
        }
        if (tiempo >= 3.5f)
        {

            per.GetComponent<Personaje>().casillaActual = per.GetComponent<Personaje>().casillaActual + 3;
            per.GetComponent<Animator>().SetBool("hab1", false);
            per.GetComponent<Personaje>().imprimeCasilla();
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            esHab1 = false;
        }
    }
    //---------------------hab3 Zorem---------------------
    public void hab3zorem()
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        per.GetComponent<Animator>().SetBool("hab3", true);
        per.GetComponent<Personaje>().esBuff = true;
    }
    public void terhab3zor()
    {
        if (tiempo >= 3.5f)
        {
            scripts.GetComponent<Dado>().valorMax = 12;
            per.GetComponent<Animator>().SetBool("hab3", false);
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            esHab3 = false;
        }
    }
    //----------------------------------------AUSTIN-----------------------------------------------------------------
    //---------------------hab1 Austin---------------------
    public void hab1austin()
    {
        btnCasillas.SetActive(true);
        GetComponent<Dado>().esTurno = false;
        per.GetComponent<Animator>().SetBool("hab1", true);
        per.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
        verifBotones();
    }

    public void verifBotones()
    {
        if(per.GetComponent<Personaje>().casillaActual <= 4)
        {
           dif = 6 - per.GetComponent<Personaje>().casillaActual;
            for(int i = 0; i<= dif-1; i++)
            {
                botones[i].SetActive(false);
            }
        }
        if (per.GetComponent<Personaje>().casillaActual >= 194)
        {
            dif = per.GetComponent<Personaje>().casillaActual - 194;
            dif = 9 - dif;
            for (int i = 9; i >= dif; i--)
            {
                botones[i].SetActive(false);
            }
        }
        if(per.GetComponent<Personaje>().casillaActual<=5) { dif1 = 5 - per.GetComponent<Personaje>().casillaActual; } else { dif1 = 0; }
       
        for (int x = dif1; x <= 4; x++)
        {
            verifCasilla = per.GetComponent<Personaje>().casillaActual - (5 - x);
            if (GetComponent<CrearCasilla>().casillas[verifCasilla].GetComponent<Casilla>().esOcupada == true)
            {
               botones[x].SetActive(false);
            }
        }
        if (per.GetComponent<Personaje>().casillaActual>=195) { dif2 = per.GetComponent<Personaje>().casillaActual - 190; } else { dif2 = 9; }
            
        for (int x = dif2; x >= 5; x--)
        {
            verifCasilla = per.GetComponent<Personaje>().casillaActual + (x - 4);
            if (GetComponent<CrearCasilla>().casillas[verifCasilla].GetComponent<Casilla>().esOcupada == true)
            {
                botones[x].SetActive(false);
            }
        }
    }
    public void terhab1austin()
    {
        if (presionado1 == true && condiHab1Aus == false)
        {
            btnCasillas.SetActive(false);
            per.GetComponent<Animator>().SetFloat("lanzoPintura", 1);
            actTiempo = true;
            if (tiempo >= 2)
            {
                GetComponent<CrearCasilla>().casillas[casillaAPintar].GetComponent<Casilla>().esPintada = true;
                per.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
                condiHab1Aus = true;
                btnCasillas.SetActive(true);
                actTiempo = false;
                tiempo = 0;
            }
            
        }
        if (presionado1 == true && presionado2 == true)
        {
            btnCasillas.SetActive(false);
            per.GetComponent<Animator>().SetFloat("lanzoPintura", 1);
            actTiempo = true;
            if (tiempo >= 2)
            {
                GetComponent<CrearCasilla>().casillas[casillaAPintar].GetComponent<Casilla>().esPintada = true;
                per.GetComponent<Animator>().SetFloat("lanzoPintura", 0);
            }
            if(tiempo>=3) { actTiempo = false; tiempo = 0; esHab1 = false; presionado1 = false; presionado2 = false; condiHab1Aus = false;
                GetComponent<Dado>().esTurno = true; per.GetComponent<Animator>().SetBool("hab1", false);
            }
        }
    }
    public void presiono()
    {
        if (presionado1 == false) { presionado1 = true; } else { presionado2 = true; }
    }
    public void pres1()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 5;
        presiono();
    }
    public void pres2()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 4;
        presiono();
    }
    public void pres3()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 3;
        presiono();
    }
    public void pres4()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 2;
        presiono();
    }
    public void pres5()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual - 1;
        presiono();
    }
    public void pres6()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual +1;
        presiono();
    }
    public void pres7()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual +2;
        presiono();
    }
    public void pres8()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual +3;
        presiono();
    }
    public void pres9()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual +4;
        presiono();
    }
    public void pres10()
    {
        casillaAPintar = per.GetComponent<Personaje>().casillaActual +5;
        presiono();
    }
   
    //---------------------hab3 Austin---------------------
    public void terhab3austin()
    {
        
        if (GetComponent<Dado>().caminando == false && GetComponent<Dado>().esTurno == false)
        {
            casRecorridas = GetComponent<Dado>().destino;
            for (int i = 0; i <= casRecorridas; i++)
            {
                GetComponent<CrearCasilla>().casillas[per.GetComponent<Personaje>().casillaActual - i].GetComponent<Casilla>().esPintada = true;
                hayPint = true;
                if(GetComponent<Dado>().caminando == false)
                {
                    esHab3 = false;
                }
            }
        }
    }
    //  -----------------------------------------LEONN---------------------------------------------------------
    public void hab3leonn()
    {
        actTiempo = true;
        GetComponent<Dado>().esTurno = false;
        per.GetComponent<Animator>().SetBool("hab3", true);
        per.GetComponent<Personaje>().esBuff = true;
        repite = true;
    }
    public void terhab3leonn()
    {
        if (tiempo >= 3.5f)
        {
            per.GetComponent<Animator>().SetBool("hab3", false);
            GetComponent<Dado>().esTurno = true;
            actTiempo = false;
            tiempo = 0;
            
        }
    }
    //------------------------------------------------------------------------------------------------------------
    public void terminarHabilidades()
    {
        if (esHab1 == true)
        {
           
            switch (GetComponent<CrearPersonaje>().idPersonaje)
            {
                case 0:
                    terhab1zor();
                    break;
                case 1:

                    break;
                case 2:
                    terhab1austin();
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    break;
            }
        }
        if (esHab2 == true)
        {
            
            switch (GetComponent<CrearPersonaje>().idPersonaje)
            {
                case 0:
                    //terhab2zor();
                    break;
                case 1:

                    break;
                case 2:
                   
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    break;
            }

        }
        if (esHab3 == true)
        {
           
            switch (GetComponent<CrearPersonaje>().idPersonaje)
            {
                case 0:
                    terhab3zor();
                    break;
                case 1:

                    break;
                case 2:
                    terhab3austin();
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    terhab3leonn();
                    break;
                default:
                    break;
            }
        }
        if(hayPint==true&& GetComponent<Dado>().esTurno == true)
        {
            for (int i = 0; i <= casRecorridas; i++)
            {
                GetComponent<CrearCasilla>().casillas[per.GetComponent<Personaje>().casillaActual - i].GetComponent<Casilla>().esPintada = false;
            }
        }
    }
}
