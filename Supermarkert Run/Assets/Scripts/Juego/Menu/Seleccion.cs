using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

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
    const float abierto = 0;
    const float cerrado = -1500;

    [Header("Animaciones")]

    [Header("Animaciones/Escena")]
    [SerializeField] private GameObject Animacion;
    [SerializeField] private Animacion_Carga AnimacionSP;
    [SerializeField] private Animator animcion_jugar;
    [SerializeField] private AnimationClip tiempo_animacion_jugar;

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

    public void BTN_Regreso()
    {
        bool rotar_camara = camara.transform.rotation.eulerAngles != new Vector3(0, 0, 0);
        if ((int)(camara.fieldOfView - FOV) != 0)
            StartCoroutine(Animacion_Acercar(FOVAC, FOV,rotacionOriginal,rotacion_carro, rotar_camara));
        Click_Botones.Play();
        Pase_Conexion_Menu_Gameplay conector = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        FindObjectOfType<Seleccion_Menu_Carrito>().Set_Car_Menu(conector.Get_Seleccion(),conector.Get_Eleccion());
        if((Animacion_Npc.transform.position - Posicion_Original.position).magnitude >= 3)
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

    /*public void BTN_Despliegue_CoPoCa() 
    {
        Click_Botones.Play();
        StartCoroutine(Animacion_Despliegue(abierto));
    }
    public void BTN_Salida_CoPoCa() 
    {
        Click_Botones.Play();
        StartCoroutine(Animacion_Despliegue(cerrado));
    }*/

    /*private IEnumerator Animacion_Despliegue(float posicion)
    {
        float tiempo = 0, duracion = 1;
        while(tiempo < duracion)
        {
            var posicion_P = PadreCoPoCa.position;
            posicion_P.x = Mathf.Lerp(posicion_P.x, posicion, tiempo / duracion);
            PadreCoPoCa.position = posicion_P;
            tiempo += Time.deltaTime;
            yield return null;
        }
    }*/

    public void BTN_Power_Up()
    {
        StartCoroutine(Animacion_Acercar(FOV, FOVAC,0,0,false));
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
        StartCoroutine(Animacion_Acercar(FOV,FOVAC,rotacionOriginal,rotacion_carro,true));
        Click_Botones.Play();
        Menu_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(true);
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO);
    }

    public void BTN_Configuraciones()
    {
        Click_Botones.Play();
        Menu_Canvas.SetActive(false);
        Configuracion_Canvas.SetActive(true);
    }

    public void BTN_Jugar()
    {
        Click_Botones.Play();
        string URL_IDIOMA = "";
#if UNITY_EDITOR
        URL_IDIOMA = Application.dataPath + "/SUPERMARKER/Ingles.json";
#else
        URL_IDIOMA = "/storage/emulated/0/Documents/SUPERMARKER/Ingles.json";
#endif
        string pos = FindObjectOfType<Seleccion_Mapa>().Get_Seleccion().nombre_espaniol;
        if (!File.Exists(URL_IDIOMA))
        {
            SceneManager.LoadScene(pos);
            return;
        }
        Menu.Pause();
        StartCoroutine(Jugar(pos));

    }

    IEnumerator Jugar(string escena)
    {
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        foreach (var i in animacion_carrito)
        {
            if (i.gameObject.activeInHierarchy)
                i.Iniciar_Animacion(false);
        }

        yield return new WaitForSeconds(0.5f);
        animcion_jugar.Play("PANEL");
        Menu_Canvas.SetActive(false);
        yield return new WaitForSeconds((tiempo_animacion_jugar.length / 2) - 0.10f);
        Animacion.SetActive(true);
        AnimacionSP.Cambiar_Escena(escena);
    }

    /*
    public void BTN_Salida()
    {
        Click_Botones.Play();
        FindObjectOfType<Sistema_Guardado>().Guardar();
        Application.Quit(0);
    }
    */
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
    }
    private void OnApplicationQuit()
    {
        if(Mapas_Canvas.activeInHierarchy || PowerUp_Canvas.activeInHierarchy || Configuracion_Canvas.activeInHierarchy)
        {
            Pase_Conexion_Menu_Gameplay conector = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
            FindObjectOfType<Seleccion_Menu_Carrito>().Set_Car_Menu(conector.Get_Seleccion(), conector.Get_Eleccion());
        }
        FindObjectOfType<Sistema_Guardado>().Guardar();
    }

}
