using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartir_power : MonoBehaviour
{
    enum Power_Up { VIDA, VELOCIDAD, PROTECCION, NINGUNO};
    Power_Up PU;
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

    public int Get_Enum_Count() => (int)Power_Up.NINGUNO;

    public void Set_Enum(int posicion) => PU = (Power_Up)posicion;
}
