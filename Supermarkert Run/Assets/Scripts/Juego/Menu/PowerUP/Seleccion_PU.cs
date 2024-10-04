using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seleccion_PU : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float limite, valor_ant;
    int valor_actual;
    [SerializeField] Transform objetos;
    List<Vector3> posiciones_iniciales = new List<Vector3>();
    Repartir_power RP;

    private void Awake()
    {
        RP = FindObjectOfType<Repartir_power>();
        slider.maxValue = RP.Get_Enum_Count();
        foreach (Transform obj in objetos)
            posiciones_iniciales.Add(obj.position);
    }

    public void Slider_Value(float value)
    {
        if (valor_ant > value) value = Mathf.Abs(value);
        else value *= -1;

        for(int i = 0; i < objetos.childCount; i++)
        {
            Vector3 targe = posiciones_iniciales[i] + new Vector3(value, 0, 0) * limite;
            objetos.GetChild(i).position = targe;
            objetos.GetChild(i).GetComponent<Interfaz_PowerUp>().Animacion();
        }

        valor_actual = (int)value;
        valor_ant = value;
    }

    public void BTN_Power()
    {
        Debug.Log(Mathf.Abs(valor_actual));
        RP.Set_Enum(Mathf.Abs(valor_actual));
    }
}
