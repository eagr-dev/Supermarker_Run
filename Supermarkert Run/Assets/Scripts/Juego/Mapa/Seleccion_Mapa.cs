using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Mapa : MonoBehaviour
{
    [SerializeField] private GameObject Comprar;
    [SerializeField] private GameObject Aceptar;
    
    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Descripcion;
    [SerializeField] private TMP_Text Precio;
    [SerializeField] private TMP_Text Cantidad_Dar;
    [SerializeField] private GameObject Sin_Dinero;
    [SerializeField] private Image Muestra;
    [SerializeField] private AudioSource Click_Botones;


    private Dinero_Obtenido DO;

    
    private int seleccion, seleccion_actual = 0;

    private void OnEnable()
    {
        Idioma.OnLenguaChanged += RefrescarIdioma;
    }

    private void OnDisable()
    {
        Idioma.OnLenguaChanged -= RefrescarIdioma;
    }

    private void RefrescarIdioma()
    {
        Mostrar(DO.Get_Mapa(seleccion_actual));
    }

    private void Start()
    {
        DO = BuildStructs.Dinero_Obtenido;
        seleccion_actual = DO.Get_Seleccion();
        Mostrar(DO.Get_Mapa(seleccion_actual));
    }

    public void BTN_Comprar()
    {
        Click_Botones.Play();
        DINERO di = BuildStructs.Dinero;
        bool compra = di.Set_Compra((uint)DO.Get_Mapa(seleccion_actual).precio);
        if (!compra)
        {
            StartCoroutine(Sin_Saldo());
            return;
        }
            
        DO.Get_Mapa(seleccion_actual).precio = 0;
        Mostrar(DO.Get_Mapa(seleccion_actual));
        Comprar.SetActive(false);
        Aceptar.SetActive(true);
        Sistema_Guardado sg = FindFirstObjectByType<Sistema_Guardado>();
        sg.AgregarMapa(DO.Get_Mapa(seleccion_actual).nombre_espaniol);
        sg.GuardarLocal();
    }

    public void BTN_SIG()
    {
        Click_Botones.Play();
        Mapa mapa = DO.Get_Mapa(seleccion_actual + 1);
        if (mapa == null) return;
        seleccion_actual++;
        MostrarSiSeVendio(mapa);
    }

    public void BTN_ANT()
    {
        Click_Botones.Play();
        Mapa mapa = DO.Get_Mapa(seleccion_actual - 1);
        if (mapa == null) return;
        seleccion_actual--;
        MostrarSiSeVendio(mapa);
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

    void MostrarSiSeVendio(Mapa mapa)
    {
        bool seVendio = mapa.precio != 0;
        Comprar.SetActive(seVendio);
        Aceptar.SetActive(!seVendio);
        Mostrar(mapa);
    }

    public Mapa Get_Seleccion() => DO.Get_Mapa(seleccion);

    private void Mostrar(Mapa mapa)
    {
        string nombre = "";
        string descripcion = "";
        NombreTraducido(mapa, ref nombre, ref descripcion);
        Nombre.text = nombre;
        Descripcion.text = descripcion;
        if(mapa.screen_map != null)
            Muestra.sprite = mapa.screen_map;
    }

    private void NombreTraducido(Mapa mapa, ref string nombre, ref string descripcion)
    {
        var lengua = Idioma.GetLengua();

        Debug.Log($"Asignar textos mapas en {lengua}");

        switch (lengua)
        {
            case Idioma.Lengua.ESPANIOL:
                nombre = mapa.nombre_espaniol;
                descripcion = mapa.descripcion_espaniol;
                Precio.text = $"Precio: {mapa.precio}";
                Cantidad_Dar.text = $"Obtendras: {mapa.Valor_mapa}";
                break;
            case Idioma.Lengua.INGLES:
                nombre = mapa.nombre_ingles;
                descripcion = mapa.descripcion_ingles;
                Precio.text = $"Price: {mapa.precio}";
                Cantidad_Dar.text = $"You will get: {mapa.Valor_mapa}";
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre = mapa.nombre_portugues;
                descripcion = mapa.descripcion_portugues;
                Precio.text = $"Preço: {mapa.precio}";
                Cantidad_Dar.text = $"Você vai conseguir: {mapa.Valor_mapa}";
                break;
        }
    }
}
