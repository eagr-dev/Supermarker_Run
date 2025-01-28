using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    [SerializeField] private GameObject Menu_Canvas;
    [SerializeField] private GameObject PowerUp_Canvas;
    [SerializeField] private GameObject Mapas_Canvas;
    [SerializeField] private GameObject Carritos_Canvas;
    [SerializeField] private GameObject Configuracion_Canvas;
    
    [SerializeField] private GameObject PU;
    [SerializeField] private GameObject Animacion;
    [SerializeField] private Transform Posicion_Original;
    [SerializeField] private Transform Posicion_Ir;
    [SerializeField] private float Tiempo_Animacion;
    [SerializeField] private Animacion_Carga AnimacionSP;
    [SerializeField] private AudioSource Menu;
    [SerializeField] private AudioSource Click_Botones;
    [SerializeField] private Animacion_NPC Animacion_Npc;
    [SerializeField] private List<Animacion_Carrito> animacion_carrito;
    [SerializeField] private Camera camara;
    [SerializeField] private Animator animcion_jugar;
    [SerializeField] private AnimationClip tiempo_animacion_jugar;
    const float FOV = 60, FOVAC = 50;
    public void BTN_Regreso()
    {
        if((int)(camara.fieldOfView - FOV) != 0)
            StartCoroutine(Animacion_Acercar(FOVAC, FOV));
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
                        i.Iniciar_Animacion();
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
        StartCoroutine(Animacion_Acercar(FOV, FOVAC));
        Click_Botones.Play();
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        foreach (var i in animacion_carrito)
        {
            if (i.gameObject.activeInHierarchy)
                i.Iniciar_Animacion();
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
        StartCoroutine(Animacion_Acercar(FOV,FOVAC));
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
        Menu.Pause();
        StartCoroutine(Jugar());

    }



    IEnumerator Jugar()
    {
        Animacion_Npc.Caminar(Tiempo_Animacion, Posicion_Ir);
        foreach (var i in animacion_carrito)
        {
            if (i.gameObject.activeInHierarchy)
                i.Iniciar_Animacion();
        }

        yield return new WaitForSeconds(0.5f);
        animcion_jugar.Play("PANEL");
        yield return new WaitForSeconds((tiempo_animacion_jugar.length / 2) + 0.10f);
        Animacion.SetActive(true);
        string pos = FindObjectOfType<Seleccion_Mapa>().Get_Seleccion().nombre;
        AnimacionSP.Cambiar_Escena(pos);
        Menu_Canvas.SetActive(false);
    }

    public void BTN_Salida()
    {
        Click_Botones.Play();
        FindObjectOfType<Sistema_Guardado>().Guardar();
        Application.Quit(0);
    }

    private IEnumerator Animacion_Acercar(float FOVA,float FOVB)
    {
        float tiempo = 1, timer = 0;

        while(timer < tiempo)
        {
            camara.fieldOfView = Mathf.Lerp(FOVA, FOVB, timer / tiempo);
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
