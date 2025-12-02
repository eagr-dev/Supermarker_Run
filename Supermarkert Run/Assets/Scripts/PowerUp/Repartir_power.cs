using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartir_power : MonoBehaviour
{
    public enum Power_Up { VELOCIDAD, PROTECCION, MANOS_RAPIDAS, NINGUNO};
    [SerializeField]Power_Up PU;
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

    public Interfaz_PowerUp Get_Power_Up_Class()
    {
        
        switch(PU)
        {
            case Power_Up.VELOCIDAD:
                clase = GetComponent<Velocidad>();
                break;
            case Power_Up.PROTECCION:
                clase = GetComponent<Proteccion>();
                break;
            case Power_Up.MANOS_RAPIDAS:
                clase = GetComponent<Manos_Rapidas>();
                break;
        }

        return clase;
    }

    public int Get_Enum_Count() => (int)Power_Up.NINGUNO;

    public void Set_Enum(int posicion)
    {
        PU = (Power_Up)posicion;
    }

    public void Set_Enum(Power_Up pu) => PU = pu; 



    public Power_Up Get_Power_Up() => PU;

    public static int NULLENUM = 4;
}
