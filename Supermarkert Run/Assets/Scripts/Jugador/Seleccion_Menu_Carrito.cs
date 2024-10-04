using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Menu_Carrito : MonoBehaviour
{

    static Seleccion_Menu_Carrito SMC;
    int Seleccion = 0, eleccion = 0;
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;
    [SerializeField] private GameObject Canvas_Eleccion;
    [SerializeField] private GameObject Canvas_Skin;

    [SerializeField] private Slider slider;

    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Descripcion;
    [SerializeField] private TMP_Text Peso;
    [SerializeField] private TMP_Text Velocidad;
    [SerializeField] private TMP_Text Limite_Carga;
    [SerializeField] private TMP_Text Resistencia_choque;
    [SerializeField] private TMP_Text Precio;



    private void Awake()
    {
        if (Seleccion_Menu_Carrito.SMC != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Seleccion_Menu_Carrito.SMC = this;
            DontDestroyOnLoad(this.gameObject);
        }
        slider.maxValue = Carrito_pequeno.GetComponent<Get_Content_Car>().Get_Counts_Car();
        Set_Skin_Eleccion();
    }

    public int Get_Seleccion() => Seleccion;

    public int Get_Eleccion() => eleccion;

    //BTN
    //BTN->Eleccion_Carrito
    public void BTN_Chico()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(true);
        Seleccion = 0;
    }

    public void BTN_Mediante()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(true);
        Carrito_pequeno.SetActive(false);
        Seleccion = 1;
    }

    public void BTN_Grande()
    {
        Carrito_grande.SetActive(true);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(false);
        Seleccion = 2;
    }

    //BTN->Canvas

    public void BTN_Skin()
    {
        Canvas_Eleccion.SetActive(false);
        Canvas_Skin.SetActive(true);
    }
    public void BTN_Eleccion()
    {
        Canvas_Eleccion.SetActive(true);
        Canvas_Skin.SetActive(false);
    }

    //BTN->Skin

    public void BTN_Aceptar()
    {
        Carrito_pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
    }

    //BTN_Fin

    //Slider
    //Slider->Skin
    public void Slider_Seleccion(float value)
    {
        eleccion = (int)(value != slider.maxValue ? value : value - 1);
        Set_Skin_Eleccion();
    }

    //Slider_Fin

    private void Set_Skin_Eleccion()
    {
        GameObject carrito_Actual = Get_Active();
        carrito_Actual.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Car Info_Car = carrito_Actual.GetComponent<Get_Content_Car>().Get_Car();

        Nombre.text = Info_Car.nombre;
        Descripcion.text = Info_Car.descripcion;
        Peso.text = "Peso: " + Info_Car.peso.ToString() + "Kg.";
        Velocidad.text = "Velocidad: " + Info_Car.velocidad_adicional.ToString() + ".";
        Limite_Carga.text = "Carga: " + Info_Car.cant_limite_carga.ToString() + "Kg.";
        Resistencia_choque.text = "Choque Maximo: " + Info_Car.resistencia_choque.ToString() + "%.";
        Precio.text = "Precio: " + Info_Car.precio.ToString() + ".";
    }
    public GameObject Get_Active()
    {
        GameObject retorno = Carrito_pequeno;

        if (Carrito_pequeno.activeInHierarchy) retorno = Carrito_pequeno;
        else if (Carrito_mediano.activeInHierarchy) retorno = Carrito_mediano;
        else if (Carrito_grande.activeInHierarchy) retorno = Carrito_grande;

        return retorno;
    }
}
