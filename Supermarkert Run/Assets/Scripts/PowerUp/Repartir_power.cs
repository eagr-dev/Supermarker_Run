using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartir_power : MonoBehaviour
{
    public enum Power_Up { VIDA, VELOCIDAD, PROTECCION, NINGUNO};
    public Power_Up PU;
    private Interfaz_PowerUp clase;
    static Repartir_power RP;
    //Funciones de cuando se vea un anuncio

    private void Awake()
    {
        if(Repartir_power.RP != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Repartir_power.RP = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public Interfaz_PowerUp Get_Power_Up()
    {
        
        switch(PU)
        {
            case Power_Up.VIDA:
                clase = GetComponent<Vida_extra>();
                break;
            case Power_Up.VELOCIDAD:
                clase = GetComponent<Velocidad>();
                break;
            case Power_Up.PROTECCION:
                clase = GetComponent<Proteccion>();
                break;
                
        }

        return clase;
    }
}
