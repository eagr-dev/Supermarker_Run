using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Seleccion_Menu_Carrito : MonoBehaviour
{
    Pase_Conexion_Menu_Gameplay.Tipo_Carro Seleccion = Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO;
    Pase_Conexion_Menu_Gameplay PCMG;
    GameObject carrito_Actual;

    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;

    [SerializeField] private GameObject Canvas_Eleccion;
    [SerializeField] private GameObject Canvas_Skin;
    [SerializeField] private GameObject Canvas_Personalizar;

    [SerializeField] private Button Skin, Personalizar, EleccionDeSkins, EleccionDePersonalizar, Pequeño, Mediano, Grande;
    [SerializeField] private Button comprar;

    [SerializeField] private AudioSource Click_Botones;

    // Referencia a la clase que ahora maneja toda la logica de skins
    [SerializeField] private Seleccion_Menu_Skin SkinMenu;
    [SerializeField] private Personalizacion personalizacion;

    [SerializeField] private TMP_Text NoMoney;
    [SerializeField] private Idioma idioma;

    CarritoComprado comprado = null;

    [Header("Scroll View de Skins (Optimizado)")]
    [SerializeField] private GameObject botonSkinPrefab;      // Tu Prefab con el script Button_Skin_Item
    [SerializeField] private Transform contenedorScrollView;  // El objeto 'Content' dentro del Scroll View
    [SerializeField] private ScrollRect miScrollRect; // Arrastra tu ScrollRect aquí
    [SerializeField] private RectTransform contentPanel;

    public void Inicializador()
    {
        PCMG = BuildStructs.PCMG;
        carrito_Actual = Get_Active();
        SkinMenu.Inicializador();
        GenerarBotonesSkins();
        Mostrar_Dinero();
        Pequeño.onClick.AddListener(BTN_Chico);
        Mediano.onClick.AddListener(BTN_Mediano);
        Grande.onClick.AddListener(BTN_Grande);
        Skin.onClick.AddListener(BTN_Skin);
        Personalizar.onClick.AddListener(BTN_Personalizar);
        EleccionDeSkins.onClick.AddListener(BTN_Eleccion);
        EleccionDePersonalizar.onClick.AddListener(BTN_Eleccion);
        comprar.onClick.AddListener(ComprarCarro);
    }

    public void GenerarBotonesSkins()
    {
        foreach (Transform hijo in contenedorScrollView)
        {
            Destroy(hijo.gameObject);
        }

        int totalSkins = PCMG.GetCountSkins();

        for (int i = 0; i < totalSkins; i++)
        {
            CarSkinData skinData = PCMG.GetSkin(i);
            skinData.id = i;
            BuildStructs.PCMG.SetSkin(i, skinData);

            GameObject nuevoBoton = Instantiate(botonSkinPrefab, contenedorScrollView);
            Button_Skin_Item scriptBoton = nuevoBoton.GetComponent<Button_Skin_Item>();
            scriptBoton.ConfigurarBoton(i, skinData, this);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel);
        miScrollRect.horizontalNormalizedPosition = 0f;
    }
    public void Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro New_TC) => Seleccion = New_TC;

    //BTN->Eleccion_Carrito
    private void BTN_Chico() => Cambiar_Carro(Carrito_pequeno, Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO);
    private void BTN_Mediano() => Cambiar_Carro(Carrito_mediano, Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO);
    private void BTN_Grande() => Cambiar_Carro(Carrito_grande, Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE);

    private void Cambiar_Carro(GameObject nuevo, Pase_Conexion_Menu_Gameplay.Tipo_Carro tipo)
    {
        Click_Botones.Play();

        Carrito_pequeno.SetActive(nuevo == Carrito_pequeno);
        Carrito_mediano.SetActive(nuevo == Carrito_mediano);
        Carrito_grande.SetActive(nuevo == Carrito_grande);

        comprado = BuildStructs.PCMG.GetComprado(tipo);
        SkinMenu.Refrescar_Carro_Activo(nuevo);

        Animacion(nuevo);


        if (!comprado.esComprado)
        {
            Personalizar.gameObject.SetActive(false);
            Skin.gameObject.SetActive(false);
            comprar.transform.GetComponentInChildren<TMP_Text>().text = $"${comprado.precio}";
            comprar.gameObject.SetActive(true);
            return;
        }
        else
        {
            Personalizar.gameObject.SetActive(true);
            Skin.gameObject.SetActive(true);
            comprar.gameObject.SetActive(false);
        }

        carrito_Actual = nuevo;

        Seleccion = tipo;
        PCMG.Set_Seleccion_Carro(Seleccion);
    }

    private void Animacion(GameObject objeto)
    {
        Transform padre = objeto.transform.parent;
        padre.position = new Vector3(padre.position.x, -1, padre.position.z);
    }

    //BTN->Canvas
    private void BTN_Skin()
    {
        Click_Botones.Play();
        Canvas_Eleccion.SetActive(false);
        Canvas_Skin.SetActive(true);
    }

    private void BTN_Eleccion()
    {
        Click_Botones.Play();
        SkinMenu.Aplicar_Eleccion_A(Carrito_pequeno, Carrito_mediano, Carrito_grande);
        Canvas_Eleccion.SetActive(true);
        Canvas_Skin.SetActive(false);
        Canvas_Personalizar.SetActive(false);
    }

    private void BTN_Personalizar()
    {
        Click_Botones.Play();
        Canvas_Eleccion.SetActive(false);
        Canvas_Personalizar.SetActive(true);
        personalizacion.MostrarUI();
    }

    public GameObject Get_Active()
    {
        if (Carrito_pequeno.activeInHierarchy) return Carrito_pequeno;
        if (Carrito_mediano.activeInHierarchy) return Carrito_mediano;
        if (Carrito_grande.activeInHierarchy) return Carrito_grande;

        Debug.LogWarning("Ningun carro activo, revisa el orden de inicializacion");
        return null;
    }

    // Usado por Sistema_Guardado al cargar la partida
    public void Set_Car_Menu(Pase_Conexion_Menu_Gameplay.Tipo_Carro TC, int posicion)
    {
        Seleccion = TC;
        Carrito_pequeno.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_grande.SetActive(false);

        GameObject objetivo = TC switch
        {
        Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO => Carrito_pequeno,
            Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO => Carrito_mediano,
            Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE => Carrito_grande,
            _ => null
        };

        if (objetivo == null) return;

        objetivo.SetActive(true);
        carrito_Actual = objetivo;
        Animacion(objetivo);
        SkinMenu.Set_Skin_Eleccion(objetivo, posicion);
    }

    private void Mostrar_Dinero()
    {
        Idioma idioma = FindFirstObjectByType<Idioma>();
        idioma.AsignarLenguajeATextos();
    }

    private void ComprarCarro()
    {
        if(!BuildStructs.Dinero.Set_Compra(comprado.precio))
        {
            StartCoroutine(AnimacionNoDinero());
        }
        comprado.precio = 0;
        Cambiar_Carro(Get_Active(), comprado.tipo_Carro);
        idioma.AsignarLenguajeATextos();
        Sistema_Guardado sg = FindFirstObjectByType<Sistema_Guardado>();
        sg.Guardar_Carros_Comprados();
    }

    public void RegresarUIASuEstadoActual()
    {
        Personalizar.gameObject.SetActive(true);
        Skin.gameObject.SetActive(true);
        comprar.gameObject.SetActive(false);
    }

    IEnumerator AnimacionNoDinero()
    {
        NoMoney.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        NoMoney.gameObject.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        Sistema_Guardado sistema_Guardado = FindFirstObjectByType<Sistema_Guardado>();
        sistema_Guardado.GuardarLocal();
        sistema_Guardado.Guardar_Personalizado();
    }

}