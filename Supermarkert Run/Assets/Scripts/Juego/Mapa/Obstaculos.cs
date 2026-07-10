using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] private GameObject Carro;
    [SerializeField] private GameObject EnemigoComun;
    [SerializeField] private GameObject EnemigoRatero;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject punto;
    [SerializeField] List<GameObject> posicion_cajas;
    /*[SerializeField]*/
    int min_obj, max_obj, cant_enemigos, cant_rateros, min_carros, max_carros;
    private Mapa mapa_content;
    private SpawnPointsData spawn;
    private List<SpawnPointsData.SpawnPoint> usados = new(); 

    private List<GameObject> obj_Seguir = new();

    [SerializeField] private RateroManager rateroManager;

    private void Awake()
    {
        mapa_content = BuildStructs.Dinero_Obtenido.Get_Mapa(SceneManager.GetActiveScene().name);
        spawn = mapa_content.spawn;

        Crear_Spawns();

        min_obj = mapa_content.cantidad_minima_obstaculos < mapa_content.cantidad_maxima_obstaculos ? mapa_content.cantidad_minima_obstaculos : 0;
        max_obj = mapa_content.cantidad_maxima_obstaculos < spawn.puntos.Count ? mapa_content.cantidad_maxima_obstaculos : spawn.puntos.Count - 1;

        cant_enemigos = mapa_content.cantidad_enemigos;
        cant_rateros = mapa_content.cantidad_rateros;

        min_carros = mapa_content.cantidad_minina_carritos < mapa_content.cantidad_maxima_carritos ? mapa_content.cantidad_minina_carritos : 0;
        max_carros = mapa_content.cantidad_maxima_carritos < spawn.puntos.Count ? mapa_content.cantidad_maxima_carritos : spawn.puntos.Count - 1;

        Crear_Carros_Aleatorios();
        Create_OBJ();
        Create_Objetos_Seguir();
        Create_Enemigos();
    }

    private void Crear_Spawns()
    {
        foreach(var posicion in spawn.puntos)
        {
            posicion.posicion.y = 0;
            punto.transform.position = posicion.posicion;
            
            Instantiate(punto);
        }
    }

    private Vector3 Posicion_Objetos(float altura)
    {
        // Verificar si ya usamos todos los puntos disponibles
        if (usados.Count >= spawn.puntos.Count)
        {
            //Debug.LogWarning("Todos los spawn points están usados");
            Debug.LogWarning($"usados tiene {usados.Count} y spawn tiene {spawn.puntos.Count}");
            return Vector3.zero; // O podrías limpiar la lista: usados.Clear();
        }

        // Buscar un punto que no esté usado
        SpawnPointsData.SpawnPoint spawnPoint;
        int intentos = 0;
        const int maxIntentos = 100; // Prevenir loop infinito

        do
        {
            int index = Random.Range(0, spawn.puntos.Count);
            spawnPoint = spawn.puntos[index];
            intentos++;

            if (intentos >= maxIntentos)
            {
                Debug.LogError("No se pudo encontrar un punto libre después de muchos intentos");
                return Vector3.zero;
            }
        }
        while (PuntoYaUsado(spawnPoint));

        // Marcar como usado
        usados.Add(spawnPoint);

        // Crear nueva posición con la altura
        Vector3 nueva_posicion = spawnPoint.posicion;
        nueva_posicion.y = altura; // Asumiendo que quieres modificar Y (altura)

        return nueva_posicion;
    }


    private Vector3 Posicion_Enemigo(float altura)
    {
        float X = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
        float Y = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
        return new Vector3(X,altura,Y);
    }

    private bool PuntoYaUsado(SpawnPointsData.SpawnPoint punto)
    {
        return usados.Exists(p => p.posicion == punto.posicion);
    }

    private void Create_OBJ()
    {
        int N_crear_OBJ = Random.Range(min_obj, max_obj);

        for(int i = 0; i < N_crear_OBJ; i++)
        {
            Instantiate(Obstaculo);
            Obstaculo.transform.position = Posicion_Objetos(0.5f);
        }
    }

    private void Crear_Carros_Aleatorios()
    {
        int N_crear_Carros = Random.Range(min_carros, max_carros);
        for (int i = 0; i < N_crear_Carros; i++)
        {
            Instantiate(Carro);
            Carro.transform.position = Posicion_Objetos(1.3f);
        }
    }

    private void Create_Enemigos()
    {
        int index = 0;
        Debug.Log($"cantidad rateros {cant_rateros}");
        List<GameObject> raterosCreados = new();
        for (int i = 0; i < cant_rateros; i++)
        {
            GameObject nuevaInstancia = Instantiate(EnemigoRatero);
            Agregar_Informacion_Necesaria_Enemigo(ref nuevaInstancia, index);
            index++;
            raterosCreados.Add(nuevaInstancia);
        }
        rateroManager.Inicializar(raterosCreados, 600f);
        for (int i = 0; i < cant_enemigos; i++)
        {
            // 1. GUARDA la referencia de la nueva INSTANCIA
            GameObject nuevaInstancia = Instantiate(EnemigoComun);
            Agregar_Informacion_Necesaria_Enemigo(ref nuevaInstancia, index);
            index++;
        }
    }

    private void Agregar_Informacion_Necesaria_Enemigo(ref GameObject enemigo, int index)
    {
        GameObject gameObject1 = obj_Seguir[index];
        IA scriptIA = enemigo.GetComponent<IA>();
        scriptIA.Set(mapa_content, gameObject1, posicion_cajas, player);

        // 3. Mueve y nombra la instancia *nueva*
        enemigo.transform.position = Posicion_Enemigo(1);
        enemigo.name = "Enemigo " + index.ToString();
    }

    private void Create_Objetos_Seguir()
    {
        for (int i = 0; i < cant_enemigos + cant_rateros; i++)
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Destroy(plane.GetComponent<MeshCollider>());
            Destroy(plane.GetComponent<Renderer>());
            plane.transform.localScale = new(0.5f, 0.5f, 0.5f);
            plane.transform.position = Posicion_Enemigo(-2);
            obj_Seguir.Add(plane);
        }
    }

}
