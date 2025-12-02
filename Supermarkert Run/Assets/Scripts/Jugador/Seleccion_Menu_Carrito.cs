using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Menu_Carrito : MonoBehaviour
{

    //static Seleccion_Menu_Carrito SMC;
    Pase_Conexion_Menu_Gameplay.Tipo_Carro Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO;
    Pase_Conexion_Menu_Gameplay PCMG;
    int eleccion = 0, eleccion_secundario = 0;
    GameObject carrito_Actual;
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;
    [SerializeField] private GameObject Canvas_Eleccion;
    [SerializeField] private GameObject Canvas_Skin;
    [SerializeField] private GameObject BTN_comprar;
    [SerializeField] private GameObject BTN_comprar_personalizar;
    [SerializeField] private GameObject BTN_aceptar;
    [SerializeField] private GameObject Dinero_Insuficiente;
    [SerializeField] private GameObject Canvas_Personalizar;

    [SerializeField] private Slider slider;

    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Descripcion;
    [SerializeField] private TMP_Text Peso;
    [SerializeField] private TMP_Text Velocidad;
    [SerializeField] private TMP_Text Limite_Carga;
    [SerializeField] private TMP_Text Resistencia_choque;
    [SerializeField] private TMP_Text Precio;
    [SerializeField] private TMP_Text Precio_personalizar;
    [SerializeField] private TMP_Text Requisitos;
    [SerializeField] private AudioSource Click_Botones;


    [SerializeField] private bool Comprar;
    [SerializeField] private bool Comprar_Skin;



    /*private void Awake()
    {
        //Pase_Conexion_Menu_Gameplay pinit = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        //Set_Car_Menu(pinit.Get_Seleccion(),pinit.Get_Eleccion());
        carrito_Actual = Get_Active();
        slider.maxValue = Carrito_pequeno.GetComponent<Get_Content_Car>().Get_Counts_Car();
        Set_Skin_Eleccion();
        Mostrar_Dinero();
    } */

    public void Inicializador()
    {
        PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        carrito_Actual = Get_Active();
        slider.maxValue = carrito_Actual.GetComponent<Get_Content_Car>().Get_Counts_Car();
        carrito_Actual.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Set_Skin_Eleccion(eleccion);
        Mostrar_Dinero();
    }

    public void Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro New_TC) => Seleccion = New_TC;

    //BTN
    //BTN->Eleccion_Carrito
    public void BTN_Chico()
    {
        Click_Botones.Play();
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO) slider.value = 0;
        else slider.value = eleccion;
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(true);
        Set_Skin_Eleccion(eleccion);
        slider.value = 0;
        Animacion(Carrito_pequeno);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO;
        PCMG.Set_Seleccion(Seleccion);
    }

    public void BTN_Mediante()
    {
        Click_Botones.Play();
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO) slider.value = 0;
        else slider.value = eleccion;
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(true);
        Carrito_pequeno.SetActive(false);
        Set_Skin_Eleccion(eleccion);
        slider.value = 0;
        Animacion(Carrito_mediano);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO;
        PCMG.Set_Seleccion(Seleccion);
    }

    public void BTN_Grande()
    {
        Click_Botones.Play();
        if (Seleccion != Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE) slider.value = 0;
        else slider.value = eleccion;
        Carrito_grande.SetActive(true);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(false);
        Set_Skin_Eleccion(eleccion);
        slider.value = 0;
        Animacion(Carrito_grande);
        Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE;
        PCMG.Set_Seleccion(Seleccion);
    }

    private void Animacion(GameObject objeto)
    {
        Transform padre = objeto.transform.parent;
        padre.position = new Vector3(padre.position.x,-1,padre.position.z);
    }

    //BTN->Canvas

    public void BTN_Skin()
    {
        Click_Botones.Play();
        Canvas_Eleccion.SetActive(false);
        Canvas_Skin.SetActive(true);
    }
    public void BTN_Eleccion()
    {
        Click_Botones.Play();
        Carrito_pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Canvas_Eleccion.SetActive(true);
        Canvas_Skin.SetActive(false);
        if (Comprar) slider.value = 0;
    }

    //BTN->Skin

    public void BTN_Aceptar()
    {
        Click_Botones.Play();
        eleccion = eleccion_secundario;
        Set_Skin_Eleccion(eleccion);
        Carrito_pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        Carrito_grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        PCMG.Set_Eleccion(eleccion);
    }

    //BTN->Compra

    public void BTN_Comprar()
    {
        Click_Botones.Play();
        DINERO dinero = FindObjectOfType<DINERO>();
        carrito_Actual = Get_Active();
        Car carrito_comprar = carrito_Actual.GetComponent<Get_Content_Car>().Get_Car();

        if (!dinero.Set_Compra(carrito_comprar.precio) || !carrito_comprar.Get_Requisito())
            StartCoroutine(Tiempo_Vision());
        else
        {
            carrito_comprar.Get_Requisito();
            carrito_comprar.precio = 0;
            Precio.text = "$ " + carrito_comprar.precio.ToString() + ".";
            Precio_personalizar.text = "$ " + carrito_comprar.precio.ToString() + ".";
            BTN_comprar.SetActive(false);
            BTN_comprar_personalizar.SetActive(false);

            if (Canvas_Personalizar.activeInHierarchy)
            {
                float[] retorno = FindObjectOfType<Personalizacion>().Get_RGB();
                FindObjectOfType<Sistema_Guardado>().Guardar_Personalizado(retorno[0], retorno[1], retorno[2], retorno[3]);
            }
            BTN_aceptar.SetActive(true);
        }
        Mostrar_Dinero();
    }

    private IEnumerator Tiempo_Vision()
    {
        Dinero_Insuficiente.SetActive(true);
        yield return new WaitForSeconds(1);
        Dinero_Insuficiente.SetActive(false);
    }

    //BTN->Personalizar

    public void BTN_Personalizar()
    {
        Debug.Log("Personalizar");
        Click_Botones.Play();
        Canvas_Eleccion.SetActive(false);
        Canvas_Personalizar.SetActive(true);
        eleccion = Get_Active().GetComponent<Get_Content_Car>().Get_Counts_Car() - 1;
        Set_Skin_Eleccion(eleccion);
        FindObjectOfType<Personalizacion>().Guardado();
    }

    public void BTN_Salida()
    {
        Click_Botones.Play();
        if (Get_Active().GetComponent<Get_Content_Car>().Get_Car().precio > 0)
        {
            Debug.Log("Personalizado");
            FindObjectOfType<Personalizacion>().Restar();
        }
        Canvas_Eleccion.SetActive(true);
        Canvas_Personalizar.SetActive(false);

    }

    //BTN_Fin

    //Slider
    //Slider->Skin
    public void Slider_Seleccion(float value)
    {
        eleccion_secundario = (int)(value != slider.maxValue ? value : value - 1);
        Set_Skin_Eleccion(eleccion_secundario);
        PCMG.Set_Eleccion(eleccion_secundario);
    }

    //Slider_Fin

    public void Set_Skin_Eleccion(int eleccion)
    {
        carrito_Actual = Get_Active();
        carrito_Actual.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        PCMG.Set_Eleccion(eleccion);
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
        Peso.text = Info_Car.peso.ToString() + "Kg.";
        Velocidad.text = Info_Car.velocidad_adicional.ToString() + ".";
        Limite_Carga.text = Info_Car.cant_limite_carga.ToString() + "Kg.";
        Resistencia_choque.text = Info_Car.resistencia_choque.ToString() + "%.";
        Precio.text = "$ " + Info_Car.precio.ToString() + ".";
        Requisitos.text = Info_Car.requisitos + ":" + Info_Car.Get_Juegos() + "/" + Info_Car.cantidad;
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
        Carrito_pequeno.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_grande.SetActive(false);


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

    private void Mostrar_Dinero()
    {
        Calidad calidad = FindObjectOfType<Calidad>();
        calidad.Modificacion_Idioma();
        
    }

    private void OnApplicationQuit()
    {
        if (Canvas_Personalizar.activeInHierarchy && BTN_comprar_personalizar.activeInHierarchy) 
            FindObjectOfType<Personalizacion>().Restar();
        FindObjectOfType<Sistema_Guardado>().Guardar();
    }
}
