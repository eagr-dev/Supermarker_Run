using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pase_Conexion_Menu_Gameplay : MonoBehaviour
{
    static Pase_Conexion_Menu_Gameplay conector;
    int sel, ele;

    private void Awake()
    {
        if (Pase_Conexion_Menu_Gameplay.conector != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Pase_Conexion_Menu_Gameplay.conector = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int Get_Seleccion() => sel;

    public int Get_Eleccion() => ele;

    public void Set_Seleccion(int new_value) => sel = new_value;
    public void Set_Eleccion(int new_value) => ele = new_value;
}
