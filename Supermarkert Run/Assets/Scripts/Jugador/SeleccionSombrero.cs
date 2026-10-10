using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionSombrero : MonoBehaviour
{
    [Header("Scroll View de Skins (Optimizado)")]
    [SerializeField] private GameObject botonSombreroPrefab;      // Tu Prefab con el script Button_Skin_Item
    [SerializeField] private Transform contenedorScrollView;  // El objeto 'Content' dentro del Scroll View
    [SerializeField] private ScrollRect miScrollRect; // Arrastra tu ScrollRect aquí
    [SerializeField] private RectTransform contentPanel;

    [Header("Datos de UI")]
    [SerializeField] private GameObject noMoney;
    [SerializeField] private TMP_Text nombre;
    [SerializeField] private TMP_Text precio;
    [SerializeField] private Button comprar;
    [SerializeField] private Button aceptar;
    [SerializeField] private Button salir;
    [SerializeField] private Button quitar;

    [Header("Datos jugador")]
    [SerializeField] private MeshFilter sombreroUV;
    [SerializeField] private MeshRenderer sombreroTexture;

    private int eleccion_actual = 0, eleccion_principio = -1;

    static public int SIN_ELEGIR = -1; 

    private void Start()
    {
        comprar.onClick.AddListener(BTN_Comprar);
        aceptar.onClick.AddListener(BTN_Aceptar);
        salir.onClick.AddListener(RegresarUISombreroOriginal);
        quitar.onClick.AddListener(BTN_Quitar);
        GenerarBotonesSombreros();
        aceptar.gameObject.SetActive(false);
        eleccion_actual = BuildStructs.PCMG.Get_Eleccion_Sombrero();
        eleccion_principio = eleccion_actual;
        if (eleccion_actual != SIN_ELEGIR)
            SetSombrero(eleccion_actual);
    }

    public void RegresarUISombreroOriginal()
    {
        BuildStructs.PCMG.Set_Eleccion_Sombrero(eleccion_principio);
        if (eleccion_principio != SIN_ELEGIR)
            SetSombrero(eleccion_principio);
        else
            sombreroUV.sharedMesh = null;
        Seleccion seleccion = FindAnyObjectByType<Seleccion>();
        seleccion.BTN_Regreso();
    }

    private void BTN_Comprar()
    {
        var PCMG = BuildStructs.PCMG;
        var data = PCMG.GetSombrero(eleccion_actual);
        var Dinero = BuildStructs.Dinero;
        if (Dinero.Get_Dinero() < data.precio)
        {
            StartCoroutine(Sin_Saldo());
            return;
        }

        Dinero.Set_Compra(data.precio);
        PCMG.SetSombreroComprado(eleccion_actual);
        comprar.gameObject.SetActive(false);
        aceptar.gameObject.SetActive(true);
    }

    private void BTN_Aceptar()
    {
        var PCMG = BuildStructs.PCMG;
        PCMG.Set_Eleccion_Sombrero(eleccion_actual);
        eleccion_principio = eleccion_actual;
    }

    private void BTN_Quitar()
    {
        sombreroUV.sharedMesh = null;
        var PCMG = BuildStructs.PCMG;
        PCMG.Set_Eleccion_Sombrero(SIN_ELEGIR);
        eleccion_actual = SIN_ELEGIR;
        eleccion_principio = SIN_ELEGIR;
    }

    public void GenerarBotonesSombreros()
    {
        var PCMG = BuildStructs.PCMG;
        foreach (Transform hijo in contenedorScrollView)
        {
            Destroy(hijo.gameObject);
        }

        int totalSkins = PCMG.GetCountSombreros();

        for (int i = 0; i < totalSkins; i++)
        {
            SombreroData sombreroData = PCMG.GetSombrero(i);
            sombreroData.id = i;
            BuildStructs.PCMG.SetSombrero(i, sombreroData);

            GameObject nuevoBoton = Instantiate(botonSombreroPrefab, contenedorScrollView);
            Button_Sombrero_Item scriptBoton = nuevoBoton.GetComponent<Button_Sombrero_Item>();
            scriptBoton.ConfigurarBoton(i, sombreroData, this);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel);
        miScrollRect.horizontalNormalizedPosition = 0f;
    }

    public void SetSombrero(int id)
    {
        eleccion_actual = id;
        var data = BuildStructs.PCMG.GetSombrero(id);
        sombreroUV.sharedMesh = data.mesh.GetComponent<MeshFilter>().sharedMesh;
        sombreroTexture.material = data.material; 
        
        comprar.gameObject.SetActive(data.precio != 0);
        aceptar.gameObject.SetActive(data.precio == 0);
        precio.text = data.precio.ToString();
        
        switch(Idioma.GetLengua())
        {
            case Idioma.Lengua.INGLES:
                nombre.text = data.nombre_ingles;
                break;
            case Idioma.Lengua.ESPANIOL:
                nombre.text = data.nombre_espaniol; 
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre.text = data.nombre_portugues;
                break;
        }
    }


    private IEnumerator Sin_Saldo()
    {
        noMoney.SetActive(true);
        yield return new WaitForSeconds(1);
        noMoney.SetActive(false);
    }
}
