using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadoresCasilla : MonoBehaviour
{
    public GameObject pint, des, scripts;
    public int cas, posx,total,posy;
    public GameObject PintadosPrefab;
    public Transform Pintados;
    public List<GameObject> pintadasList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Crear();
    }

    // Update is called once per frame
    void Update()
    {
        pintadas();
    }

    public void estadoCasilla()
    {
       // pintar(cas);
        //desLeonn();
    }


    public void pintadas()
    {
        total = 200;
        
        for (int i = 0; i < total; i++)
        {
            if (GetComponent<CrearCasilla>().casillas[i].GetComponent<Casilla>().esPintada==true)
            {
                pintadasList[i].SetActive(true);
            }
            else
            {
                pintadasList[i].SetActive(false);
            }
        }
    }
    public void desLeonn()
    {

    }
    public void Crear()
    {
        total = 200;
        int cont = 1;
        posy = 1; posx = 5;
        for (int i = 0; i < total; i++)
        {

            GameObject casillaTemp = Instantiate(PintadosPrefab, new Vector3(posx, posy, 0), Quaternion.Euler(new Vector3(0, 180, 0)));
            pintadasList.Add(casillaTemp);
            casillaTemp.name = "" + i + "";
            //casillaTemp.GetComponent<Casilla>().idCasilla = cont;

            casillaTemp.transform.parent = Pintados;
            posx = posx + 2;
            casillaTemp.SetActive(false);
            cont++;

        }
    }
}
