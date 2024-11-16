using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pase_Conexion_Menu_Gameplay : MonoBehaviour
{
    static Pase_Conexion_Menu_Gameplay conector;
    public bool dinamica;
    public enum Tipo_Carro { PEQUEÑO, MEDIANO, GRANDE }
    Tipo_Carro sel;
    int ele;
    public List<Car> cars_Peq;
    public List<Car> cars_Med;
    public List<Car> cars_Gra;

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

        for(int i = 0; i < cars_Peq.Count; i++)
        {
            cars_Peq[i].objetos_actuales = 0;
            cars_Med[i].objetos_actuales = 0;
            cars_Gra[i].objetos_actuales = 0;
        }
    }

    public Tipo_Carro Get_Seleccion() => sel;

    public int Get_Eleccion() => ele;

    public void Set_Seleccion(Tipo_Carro new_value) => sel = new_value;
    public void Set_Eleccion(int new_value) => ele = new_value;

    public void Set_List_All(List<Car> list_Car, Tipo_Carro TC)
    {
        switch(TC)
        {
            case Tipo_Carro.PEQUEÑO:
                foreach (Car car in cars_Peq)
                {
                    list_Car.Add(car);
                }
                break;
            case Tipo_Carro.MEDIANO:
                foreach (Car car in cars_Med)
                {
                    list_Car.Add(car);
                }
                break;
            case Tipo_Carro.GRANDE:
                foreach (Car car in cars_Gra)
                {
                    list_Car.Add(car);
                }
                break;
        }
    }
}
