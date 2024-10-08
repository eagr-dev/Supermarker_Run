using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Mapa : MonoBehaviour
{
    [SerializeField] private GameObject Comprar;
    [SerializeField] private GameObject Aceptar;
    [SerializeField] private Slider slider;
    
    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Descripcion;
    [SerializeField] private TMP_Text Precio;
    [SerializeField] private TMP_Text Cantidad_Dar;
    [SerializeField] private TMP_Text Dinero;
    [SerializeField] private GameObject Sin_Dinero;
    [SerializeField] private Image Muestra;

    
    private Dinero_Obtenido DO;

    
    private int seleccion, seleccion_actual;

    private void Awake()
    {
        DO = FindObjectOfType<Dinero_Obtenido>();
    }

    public void BTN_Comprar()
    {
        if (!FindObjectOfType<DINERO>().Set_Compra((uint)DO.Get_Mapa(seleccion_actual).precio))
        {
            StartCoroutine(Sin_Saldo());
        }
        else
        {
            DO.Get_Mapa(seleccion_actual).precio = 0;
            Mostrar(DO.Get_Mapa(seleccion_actual));
            Dinero.text = "Dinero: " + FindObjectOfType<DINERO>().Get_Dinero();
            Precio.text = "Precio: " + DO.Get_Mapa(seleccion).precio.ToString();
            Comprar.SetActive(false);
            Aceptar.SetActive(true);

        }
    }

    private IEnumerator Sin_Saldo()
    {
        Sin_Dinero.SetActive(true);
        yield return new WaitForSeconds(1);
        Sin_Dinero.SetActive(false);
    }

    public void BTN_Aceptar()
    {
        seleccion = seleccion_actual;
    }

    public void Slider(float value)
    {
        seleccion_actual = value != slider.maxValue ? (int)value : (int)value - 1;

        if(DO.Get_Mapa(seleccion_actual).precio != 0)
        {
            Comprar.SetActive(true);
            Aceptar.SetActive(false);
        }
        else
        {
            Comprar.SetActive(false);
            Aceptar.SetActive(true);
        }
        Mostrar(DO.Get_Mapa(seleccion_actual));
    }

    public Mapa Get_Seleccion() => DO.Get_Mapa(seleccion);

    private void Mostrar(Mapa mapa)
    {
        Nombre.text = mapa.nombre;
        Descripcion.text = mapa.descripcion;
        Precio.text = "Precio: " + mapa.precio.ToString();
        Cantidad_Dar.text = "Extra: " + mapa.Valor_mapa.ToString();
        if(mapa.screen_map != null)
        Muestra.sprite = mapa.screen_map;
    }

}
