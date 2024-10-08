using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Menu_Carrito : MonoBehaviour
{

    //static Seleccion_Menu_Carrito SMC;
    Pase_Conexion_Menu_Gameplay.Tipo_Carro Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO;
    int eleccion = 0;
    GameObject carrito_Actual;
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;
    [SerializeField] private GameObject Canvas_Eleccion;
    [SerializeField] private GameObject Canvas_Skin;
    [SerializeField] private GameObject BTN_comprar;
    [SerializeField] private GameObject BTN_aceptar;
    [SerializeField] private GameObject Dinero_Insuficiente;

    [SerializeField] private Slider slider;

    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Descripcion;
    [SerializeField] private TMP_Text Peso;
    [SerializeField] private TMP_Text Velocidad;
    [SerializeField] private TMP_Text Limite_Carga;
    [SerializeField] private TMP_Text Resistencia_choque;
    [SerializeField] private TMP_Text Precio;
    
    [SerializeField] private TMP_Text Dinero;
    [SerializeField] private bool Comprar;



    private void Awake()
    {
        Pase_Conexion_Menu_Gameplay pinit = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        Set_Car_Menu(pinit.Get_Seleccion(),pinit.Get_Eleccion());
        carrito_Actual = Get_Active();
        slider.maxValue = Carrito_pequeno.GetComponent<Get_Content_Car>().Get_Counts_Car();
        Set_Skin_Eleccion();
        Mostrar_Dinero();
    }

    public void Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro New_TC) => Seleccion = New_TC;

    //BTN
    //BTN->Eleccion_Carrito
    public void BTN_Chico()
    {
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO) slider.value = 0;
        else slider.value = eleccion;
        Set_Skin_Eleccion();
        slider.value = 0;
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(true);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO;
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Seleccion);
    }

    public void BTN_Mediante()
    {
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO) slider.value = 0;
        else slider.value = eleccion;
        Set_Skin_Eleccion();
        slider.value = 0;
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(true);
        Carrito_pequeno.SetActive(false);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO;
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Seleccion);
    }

    public void BTN_Grande()
    {
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE) slider.value = 0;
        else slider.value = eleccion;
        Set_Skin_Eleccion();
        slider.value = 0;
        Carrito_grande.SetActive(true);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(false);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE;
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Seleccion);
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
        if (Comprar) slider.value = 0;
    }

    //BTN->Skin

    public void BTN_Aceptar()
    {
        Set_Skin_Eleccion();
        Carrito_pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
    }

    //BTN->Compra

    public void BTN_Comprar()
    {
        DINERO dinero = FindObjectOfType<DINERO>();
        carrito_Actual = Get_Active();
        Car carrito_comprar = carrito_Actual.GetComponent<Get_Content_Car>().Get_Car();
        if (!dinero.Set_Compra(carrito_comprar.precio))
            StartCoroutine(Tiempo_Vision());
        carrito_comprar.precio = 0;
        Mostrar_Dinero();
    }

    private IEnumerator Tiempo_Vision()
    {
        Dinero_Insuficiente.SetActive(true);
        yield return new WaitForSeconds(1);
        Dinero_Insuficiente.SetActive(false);
    }

    //BTN_Fin

    //Slider
    //Slider->Skin
    public void Slider_Seleccion(float value)
    {
        eleccion = (int)(value != slider.maxValue ? value : value - 1);
        Set_Skin_Eleccion();
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Eleccion(eleccion);
    }

    //Slider_Fin

    private void Set_Skin_Eleccion()
    {
        carrito_Actual = Get_Active();
        carrito_Actual.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Car Info_Car = carrito_Actual.GetComponent<Get_Content_Car>().Get_Car();

        if (Info_Car.precio != 0)
        {
            BTN_comprar.SetActive(true);
            BTN_aceptar.SetActive(false);
            Comprar = true;
        }
        else
        {
            BTN_comprar.SetActive(false);
            BTN_aceptar.SetActive(true);
            Comprar = false;
        }

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

    public void Set_Car_Menu(Pase_Conexion_Menu_Gameplay.Tipo_Carro TC, int posicion)
    {
        eleccion = posicion;
        Seleccion = TC;
        switch(TC)
        {
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO:
                Carrito_pequeno.SetActive(true);
                Carrito_pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO:
                Carrito_mediano.SetActive(true);
                Carrito_mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE:
                Carrito_grande.SetActive(true);
                Carrito_grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
                break;
        }
    }

    private void Mostrar_Dinero() => Dinero.text = "Dinero: " + FindObjectOfType<DINERO>().Get_Dinero();
}
