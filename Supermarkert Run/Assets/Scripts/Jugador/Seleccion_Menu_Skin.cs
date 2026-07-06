using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_Menu_Skin : MonoBehaviour
{
    // Referencia a la clase que maneja tamano de carro / canvases
    [SerializeField] private Seleccion_Menu_Carrito Carritos;

    private int eleccion = 0;
    private int eleccion_secundario = 0;

    [SerializeField] private TMP_Text Nombre;
    [SerializeField] private TMP_Text Precio;

    [SerializeField] private Button BTN_comprar;
    [SerializeField] private Button BTN_aceptar;
    [SerializeField] private GameObject Dinero_Insuficiente;

    [SerializeField] private AudioSource Click_Botones;

    [SerializeReference] Idioma idioma;

    public int Eleccion => eleccion;

    public void Inicializador()
    {
        eleccion = BuildStructs.PCMG.Get_Eleccion();
        BTN_aceptar.onClick.AddListener(BTN_Aceptar);
        BTN_comprar.onClick.AddListener(BTN_Comprar);
    }

    // Llamado por Seleccion_Menu_Carrito cuando el jugador cambia de tamano de carro,
    // para que la skin actual se re-aplique al nuevo carro visible
    public void Refrescar_Carro_Activo(GameObject nuevoCarrito)
    {
        Set_Skin_Eleccion(nuevoCarrito, eleccion);
    }


    //BTN->Skin
    public void BTN_Aceptar()
    {
        Click_Botones.Play();
        eleccion = eleccion_secundario;
        Set_Skin_Eleccion(Carritos.Get_Active(), eleccion);
        BuildStructs.PCMG.Set_Seleccion_Skin(eleccion);
    }

    //BTN->Compra
    public void BTN_Comprar()
    {
        Click_Botones.Play();
        DINERO dinero = BuildStructs.Dinero;
        CarSkinData carrito_comprar = BuildStructs.PCMG.GetSkin(eleccion_secundario);

        if (!dinero.Set_Compra(carrito_comprar.precio))
        {
            StartCoroutine(Tiempo_Vision());
        }
        else
        {
            carrito_comprar.precio = 0;
            BuildStructs.PCMG.SetSkin(eleccion_secundario, carrito_comprar);
            Precio.text = carrito_comprar.precio.ToString() + ".";
            BTN_comprar.gameObject.SetActive(false);
            BTN_aceptar.gameObject.SetActive(true);
            idioma.AsignarLenguajeATextos();
        }
    }

    private IEnumerator Tiempo_Vision()
    {
        Dinero_Insuficiente.SetActive(true);
        yield return new WaitForSeconds(1);
        Dinero_Insuficiente.SetActive(false);
    }


    // Aplica la skin ya confirmada (eleccion) a los 3 carros, para que quede
    // lista sin importar el tamano que se elija despues. Llamado desde BTN_Eleccion.
    public void Aplicar_Eleccion_A(GameObject pequeno, GameObject mediano, GameObject grande)
    {
        pequeno.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        mediano.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        grande.GetComponent<Get_Content_Car>().Set_Car(eleccion);
        if (BTN_comprar.gameObject.activeInHierarchy)
        {
            BTN_comprar.gameObject.SetActive(false);
            var data = pequeno.GetComponent<Get_Content_Car>().Get_Car_Skin();
            MostrarContenidoUI(data);
        }
    }

    public void Set_Skin_Eleccion(GameObject carritoActivo, int nuevaEleccion)
    {
        if (carritoActivo == null) return;

        eleccion_secundario = nuevaEleccion;
        carritoActivo.GetComponent<Get_Content_Car>().Set_Car(nuevaEleccion);
        CarSkinData Info_Car = carritoActivo.GetComponent<Get_Content_Car>().Get_Car_Skin();

        if (Info_Car.precio > 0)
        {
            BTN_comprar.transform.GetComponentInChildren<TMP_Text>().text = $"${Info_Car.precio}";
            BTN_comprar.gameObject.SetActive(true);
            BTN_aceptar.gameObject.SetActive(false);
        }
        else
        {
            BTN_comprar.gameObject.SetActive(false);
            BTN_aceptar.gameObject.SetActive(true);
        }

        MostrarContenidoUI(Info_Car);
    }

    private void MostrarContenidoUI(CarSkinData car)
    {
        Idioma.Lengua lengua = Idioma.GetLengua();
        switch (lengua)
        {
            case Idioma.Lengua.INGLES:
                Nombre.text = car.nombre_ingles;
                break;
            case Idioma.Lengua.ESPANIOL:
                Nombre.text = car.nombre_espaniol;
                break;
            case Idioma.Lengua.PORTUGUES:
                Nombre.text = car.nombre_portugues;
                break;
        }

        Precio.text = car.precio.ToString();
    }
}