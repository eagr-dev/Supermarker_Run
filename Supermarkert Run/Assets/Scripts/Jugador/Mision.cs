using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mision : MonoBehaviour
{
    //private List<string> objects_mision = new List<string>();
    private readonly List<System.Tuple<string, bool, bool>> objetos = new();
    [SerializeField]private int misiones_hechas = 0;
    int misiones_hacer = 0;
    public TMP_Text Espacio_Disponible;
    public GameObject Sin_espacio;
    public GameObject Muerte;
    public Transform caja;
    Car carro;
    [SerializeField] private AudioSource Obtener_objeto;
    [SerializeField] private ParticleSystem Punto;
    [SerializeField] private Player player;
    static readonly int misiones_default = 10, maximo_misiones = 100;

    [Header("UI Misiones")]
    [SerializeField] private TMP_Text[] text_misiones = new TMP_Text[10];
    [SerializeField] private TMP_Text posicion_texto;
    int inicio_lista = 0, final_lista = 10;
    Color no_tomado = new Color(0, 0, 0);
    Color tomado = new Color(1, 0, 0);
    Color en_caja = new Color(0, 1, 0);

    private void Start()
    {
        ParticleSystem.EmissionModule emission = Punto.emission;
        emission.enabled = false;
        misiones_hacer = Cantidad_Nivel();
        Set_objetos();
        carro = player.Get_Carro();
        player.Init(carro);
        carro.objetos_actuales = 0;
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        Limpiar_Textos();
        Mostrar();
    }
    public static int Cantidad_Nivel()
    {
        int misiones_obtenibles = (misiones_default + (int)(Nivel.nivel - 1));
        int misiones = misiones_obtenibles <= maximo_misiones ? misiones_obtenibles : maximo_misiones;
        return misiones;
    }

    private void Set_objetos()
    {
        bool defecto = false;
        int iterador = 0;
        int intentos = 0;
        const int maximo_intentos = 1000;


        while(objetos.Count < misiones_hacer && iterador < maximo_intentos)
        {
            int area = Random.Range(0, 7);
            int nombre_objeto = Random.Range(0, 9);
            string obj = Areas.Objetos[area][nombre_objeto];
            if (!Se_repite_objeto(obj))
            {
                objetos.Add(new System.Tuple<string, bool, bool>(obj, defecto, defecto));
                iterador++;
            }
            intentos++;
            if (iterador >= misiones_hacer) return;
            if (intentos >= maximo_intentos) return;
        }

        if (objetos.Count < misiones_hacer)
        {
            Debug.LogWarning($"No se pudieron generar suficientes objetos únicos. Se generaron {objetos.Count} de {misiones_hacer}");
        }

    }

    private bool Se_repite_objeto(string obj_comparar)
    {
        var version = new System.Tuple<string, bool, bool>(obj_comparar, false, false);
        return objetos.Contains(version);
    }

    private System.Tuple<int,bool> Se_repite_objeto_tomado(string obj_comparar)
    {
        var version = new System.Tuple<string, bool, bool>(obj_comparar, true, false);
        int index = objetos.FindIndex(new System.Predicate<System.Tuple<string, bool, bool>>(
        tupla => tupla.Item1 == obj_comparar
        ));
        return new System.Tuple<int, bool>(index, objetos.Contains(version));
    }

    public void Eliminar_Al_Chocar()
    {
        System.Tuple<string, bool, bool> tuple = new("",false, false);
        foreach (var objeto in objetos)
        {
            if (objeto.Item2 && !objeto.Item3) 
                tuple = objeto;
        }
        int index = objetos.FindIndex(new System.Predicate<System.Tuple<string, bool,bool>>(
        tupla => tupla == tuple
        ));
        objetos[index] = new System.Tuple<string, bool, bool>(tuple.Item1, false, false);
        Mostrar();
        misiones_hechas--;
        carro.objetos_actuales--;
        Debug.Log($"el objeto {tuple.Item1} se elimino de la lista de obtenidos");
        Debug.Log($"objetos actuales en el carro {carro.objetos_actuales}");
    }

    public void Verificar_Objeto_este_mision(string obj)
    {
        if (carro.objetos_actuales > carro.cant_limite_carga)
            StartCoroutine(Tiempo_Aparicion());

        var obj_tomo = Se_repite_objeto_tomado(obj);
        if (obj_tomo.Item2 || obj_tomo.Item1 < 0)
            return;
        if (objetos[obj_tomo.Item1].Item3) return;

        var emision = Punto.emission;
        emision.enabled = true;
        Obtener_objeto.Play();
        Punto.Play();
        carro.objetos_actuales++;
        objetos[obj_tomo.Item1] = new System.Tuple<string, bool, bool>(
        obj,
        true,
        false
        );
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        misiones_hechas++;
        Mostrar();
    }

    public void Volver_Objetos_Caja()
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            if (!objetos[i].Item2) continue;
            Debug.Log($"Se dejo al objeto {objetos[i].Item1} en la caja");
            objetos[i] = new System.Tuple<string, bool, bool>(
                objetos[i].Item1,
                false,
                true
            );
        }
        Mostrar();
    }

    private IEnumerator Tiempo_Aparicion()
    {
        Sin_espacio.SetActive(true);
        yield return new WaitForSeconds(1);
        carro.objetos_actuales = 0;
        Sin_espacio.SetActive(false);
        Muerte.SetActive(true);

    }

    private void Mostrar()
    {
        posicion_texto.text = inicio_lista.ToString() + " : " + final_lista.ToString();
        for(int iterador = inicio_lista; iterador < final_lista; iterador++)
        {
            text_misiones[iterador % misiones_default].text = objetos[iterador].Item1;
            if (objetos[iterador].Item2 && !objetos[iterador].Item3)
                text_misiones[iterador % misiones_default].color = tomado;
            else if(!objetos[iterador].Item2 && objetos[iterador].Item3)
                text_misiones[iterador % misiones_default].color = en_caja;
            else
                text_misiones[iterador % misiones_default].color = no_tomado;
        }
    }

    private void Limpiar_Textos()
    {
        posicion_texto.text = "";
        for (int i = 0; i < 10; i++)
        {
            text_misiones[i].text = "";
        }
    }

    public void BTN_Pag_Sig()
    {
        inicio_lista = final_lista >= objetos.Count ? inicio_lista : final_lista;
        final_lista = objetos.Count > (final_lista + misiones_default) ? (final_lista + misiones_default) : objetos.Count;
        Limpiar_Textos();
        Mostrar();
    }

    public void BTN_Pag_Ant()
    {
        final_lista = inicio_lista <= 0 ? final_lista : inicio_lista; 
        inicio_lista = objetos.Count < (inicio_lista - misiones_default) ? (inicio_lista - misiones_default) : 0;
        Limpiar_Textos();
        Mostrar();
    }

    private float Porcentaje() => (misiones_hechas / misiones_hacer);

    public bool Jugador_gano() => Porcentaje() == 1;
}
