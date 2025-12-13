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
    [SerializeField] private GameObject Sin_Dinero;
    [SerializeField] private Image Muestra;
    [SerializeField] private AudioSource Click_Botones;


    private Dinero_Obtenido DO;

    
    private int seleccion, seleccion_actual;

    private void Awake()
    {
        DO = FindObjectOfType<Dinero_Obtenido>();
    }

    private void Start()
    {
        Mostrar(DO.Get_Mapa(0));
    }

    public void BTN_Comprar()
    {
        Click_Botones.Play();
        DINERO di = FindObjectOfType<DINERO>();
        bool compra = di.Set_Compra((uint)DO.Get_Mapa(seleccion_actual).precio);
        if (!compra)
        {
            StartCoroutine(Sin_Saldo());
            return;
        }
            
        DO.Get_Mapa(seleccion_actual).precio = 0;
        Mostrar(DO.Get_Mapa(seleccion_actual));
        Precio.text = "$ " + DO.Get_Mapa(seleccion).precio.ToString();
        Comprar.SetActive(false);
        Aceptar.SetActive(true);
        Sistema_Guardado sg = FindObjectOfType<Sistema_Guardado>();
        sg.ADD_MAPA(DO.Get_Mapa(seleccion_actual).nombre_espaniol);
        sg.Guardar();
    }

    private IEnumerator Sin_Saldo()
    {
        Sin_Dinero.SetActive(true);
        yield return new WaitForSeconds(1);
        Sin_Dinero.SetActive(false);
    }

    public void BTN_Aceptar()
    {
        Click_Botones.Play();
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
        string nombre = "";
        string descripcion = "";
        NombreTraducido(mapa, ref nombre, ref descripcion);
        Nombre.text = nombre;
        Descripcion.text = descripcion;
        Precio.text = "$ " + mapa.precio.ToString();
        Cantidad_Dar.text = "$->: " + mapa.Valor_mapa.ToString();
        if(mapa.screen_map != null)
        Muestra.sprite = mapa.screen_map;
    }

    private void NombreTraducido(Mapa mapa, ref string nombre, ref string descripcion)
    {
        var lengua = Idioma.GetLengua();

        switch(lengua)
        {
            case Idioma.Lengua.ESPANIOL:
                nombre = mapa.nombre_espaniol;
                descripcion = mapa.descripcion_espaniol;
                break;
            case Idioma.Lengua.INGLES:
                nombre = mapa.nombre_ingles;
                descripcion = mapa.descripcion_ingles;
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre = mapa.nombre_portugues;
                descripcion = mapa.descripcion_portugues;
                break;
        }
    }
}
