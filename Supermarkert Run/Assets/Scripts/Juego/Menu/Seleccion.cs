using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject Menu_Canvas;
    [SerializeField] private GameObject PowerUp_Canvas;
    [SerializeField] private GameObject Mapas_Canvas;
    [SerializeField] private GameObject Carritos_Canvas;
    [SerializeField] private GameObject Configuracion_Canvas;
    [SerializeField] private GameObject PU;
    [SerializeField] private RectTransform PadreCoPoCa;

    [Header("Animaciones")]

    [Header("Animaciones/Escena")]
    [SerializeField] private Animacion_Carga AnimacionSP;

    [Header("Animaciones/Carrito|Jugador")]
    [SerializeField] private Transform Posicion_Original;
    [SerializeField] private Transform Posicion_Ir;
    [SerializeField] private float Tiempo_Animacion;
    [SerializeField] private Animacion_NPC Animacion_Npc;
    [SerializeField] private List<Animacion_Carrito> animacion_carrito;

    [Header("Animaciones/Camara")]
    [SerializeField] private Camera camara;
    const float FOV = 60, FOVAC = 50;
    const float rotacionOriginal = 0, rotacion_carro = 8;

    [Header("Audio")]
    [SerializeField] private AudioSource Click_Botones;
    [SerializeField] private AudioSource Menu;

    static Pase_Conexion_Menu_Gameplay conector;

    private void Start()
    {
        conector = BuildStructs.PCMG;
    }

    public void BTN_Regreso()
    {
        bool rotar_camara = camara.transform.rotation.eulerAngles != new Vector3(0, 0, 0);
        if ((int)(camara.fieldOfView - FOV) != 0)
            IniciarAnimacion(FOVAC, FOV, camara.transform.rotation.x, rotacionOriginal, rotar_camara);

        Click_Botones.Play();
        
        BuildStructs.SelCarro.Set_Car_Menu(conector.Get_Seleccion(),conector.Get_Eleccion());

        //if((Animacion_Npc.transform.position - Posicion_Original.position).magnitude >= 3)
        if (Animacion_Npc.DestinoActual != Posicion_Original)
        {
            Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Original);
            if(!Carritos_Canvas.activeInHierarchy)
                foreach (var i in animacion_carrito)
                {
                    if (i.gameObject.activeInHierarchy)
                        i.Iniciar_Animacion(true);
                }
        }

        PowerUp_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);
        PU.SetActive(false);
        Configuracion_Canvas.SetActive(false);
    }

    public void BTN_Power_Up()
    {

        IniciarAnimacion(FOV, FOVAC, camara.transform.rotation.eulerAngles.x, rotacionOriginal, false);
        Click_Botones.Play();
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        foreach (var i in animacion_carrito)
        {
            if (i.gameObject.activeInHierarchy)
                i.Iniciar_Animacion(false);
        } 
        Menu_Canvas.SetActive(false);
        PowerUp_Canvas.SetActive(true);
        PU.SetActive(true);
    }

    public void BTN_Mapa()
    {
        Click_Botones.Play();
        Menu_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(true);
    }

    public void BTN_Carro()
    {

        IniciarAnimacion(FOV, FOVAC, rotacionOriginal, rotacion_carro, true);
        Click_Botones.Play();
        Menu_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(true);
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        conector.Set_Seleccion(BuildStructs.PCMG.Get_Seleccion());
    }

    public void BTN_Configuraciones()
    {
        Click_Botones.Play();
        Menu_Canvas.SetActive(false);
        Configuracion_Canvas.SetActive(true);
    }

    public void BTN_Jugar()
    {
        StopAllCoroutines();
        Click_Botones.Play();
        string pos = FindFirstObjectByType<Seleccion_Mapa>().Get_Seleccion().nombre_espaniol;
        Menu.Pause();
        StartCoroutine(Jugar(pos));

    }


    public void BTN_Privacidad()
    {
        Application.OpenURL("https://Gatoprogramador888.github.io");
    }


    private Coroutine animacionActual;

    private void IniciarAnimacion(float FOVA, float FOVB, float rotaciona, float rotacionb, bool rotar_camara)
    {
        // Detener la anterior si sigue corriendo
        if (animacionActual != null)
        {
            StopCoroutine(animacionActual);
            animacionActual = null;
        }

        animacionActual = StartCoroutine(Animacion_Acercar(FOVA, FOVB, rotaciona, rotacionb, rotar_camara));

        AplicarEstadoFinal(FOVB, rotacionb, rotar_camara);
    }

    private void AplicarEstadoFinal(float FOVB, float rotacionb, bool rotar_camara)
    {
        camara.fieldOfView = FOVB;
        if (rotar_camara)
        {
            Quaternion rotacion = new();
            rotacion.eulerAngles = new Vector3(rotacionb, 0, 0);
            camara.transform.rotation = rotacion;
        }
    }

    private IEnumerator Animacion_Acercar(float FOVA,float FOVB, float rotaciona, float rotacionb,bool rotar_camara)
    {
        float tiempo = 1, timer = 0;

        while(timer < tiempo)
        {
            camara.fieldOfView = Mathf.Lerp(FOVA, FOVB, timer / tiempo);
            var rotacion = camara.transform.rotation;
            if(rotar_camara)
            {
                rotacion.eulerAngles = Vector3.Lerp(new Vector3(rotaciona, 0, 0), new Vector3(rotacionb, 0, 0), timer / tiempo);
                camara.transform.rotation = rotacion;
            }
            timer += Time.deltaTime;
            yield return null;
        }

        AplicarEstadoFinal(FOVB, rotacionb, rotar_camara);
    }

    IEnumerator Jugar(string escena)
    {
        //Anuncios.Instancia.OcultarBanner();
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        foreach (var i in animacion_carrito)
        {
            if (i.gameObject.activeInHierarchy)
                i.Iniciar_Animacion(false);
        }

        yield return new WaitForSeconds(0.5f);
        Menu_Canvas.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        AnimacionSP.Cambiar_Escena(escena);
    }


    private void OnApplicationQuit()
    {
        if(Mapas_Canvas.activeInHierarchy || PowerUp_Canvas.activeInHierarchy || Configuracion_Canvas.activeInHierarchy)
        {
            BuildStructs.SelCarro.Set_Car_Menu(conector.Get_Seleccion(), conector.Get_Eleccion());
        }
        FindFirstObjectByType<Sistema_Guardado>().GuardarLocal();
    }

}
