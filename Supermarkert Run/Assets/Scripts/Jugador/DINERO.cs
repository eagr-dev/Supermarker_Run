using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DINERO : MonoBehaviour
{
    [SerializeField]private uint Dinero = 0;

    public uint Get_Dinero() => Dinero;

    public bool Set_Compra(uint dinero)
    {
        if (dinero > Dinero)
        {
            return false;
        }
        Dinero -= dinero;
        return true;
    }

    public void Set_Agregar(uint dinero)
    {
        Dinero += dinero;
        PlayerPrefs.SetString("Dinero", Dinero.ToString());
    }


    public void Set_Dinero(uint dinero) => Dinero = dinero;


}
