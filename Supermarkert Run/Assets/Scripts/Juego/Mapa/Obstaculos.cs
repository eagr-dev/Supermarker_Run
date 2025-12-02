using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] private GameObject Carro;
    [SerializeField] private GameObject Enemigo;
    [SerializeField] private GameObject Luz_Estatica;
    [SerializeField] private GameObject Luz_Dinamica;
    [SerializeField] private GameObject punto;
    /*[SerializeField]*/ int min_obj, max_obj, cant_enemigos, min_carros, max_carros;
    private Mapa mapa_content;
    private SpawnPointsData spawn;
    private List<SpawnPointsData.SpawnPoint> usados = new(); 

    private List<GameObject> obj_Seguir = new();

    private void Awake()
    {
        mapa_content = FindObjectOfType<Dinero_Obtenido>().Get_Mapa(SceneManager.GetActiveScene().name);
        spawn = mapa_content.spawn;

        Crear_Spawns();

        min_obj = mapa_content.cantidad_minima_obstaculos < mapa_content.cantidad_maxima_obstaculos ? mapa_content.cantidad_minima_obstaculos : 0;
        max_obj = mapa_content.cantidad_maxima_obstaculos < spawn.puntos.Count ? mapa_content.cantidad_maxima_obstaculos : spawn.puntos.Count - 1;

        cant_enemigos = mapa_content.cantidad_enemigos;

        min_carros = mapa_content.cantidad_minina_carritos < mapa_content.cantidad_maxima_carritos ? mapa_content.cantidad_minina_carritos : 0;
        max_carros = mapa_content.cantidad_maxima_carritos < spawn.puntos.Count ? mapa_content.cantidad_maxima_carritos : spawn.puntos.Count - 1;
        Crear_Carros_Aleatorios();
        Create_OBJ();
        Create_Objetos_Seguir();
        Create_Enemigos();
        Get_Dinamica();
    }

    private void Crear_Spawns()
    {
        foreach(var posicion in spawn.puntos)
        {
            Debug.Log($"colocando spawn en la posicion: {posicion.posicion}");
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
            Instantiate(Carro);
            Carro.transform.position = Posicion_Objetos(0.5f);
        }
    }

    private void Crear_Carros_Aleatorios()
    {
        int N_crear_Carros = Random.Range(min_carros, max_carros);
        for (int i = 0; i < N_crear_Carros; i++)
        {
            Instantiate(Obstaculo);
            Obstaculo.transform.position = Posicion_Objetos(0.5f);
        }
    }

    private void Create_Enemigos()
    {
        for(int i = 0;i < cant_enemigos;i++)
        {
            Instantiate(Enemigo);
            Enemigo.transform.position = Posicion_Enemigo(1);
            GameObject gameObject1 = obj_Seguir[i];
            Enemigo.GetComponent<IA>().objecto_seguir = gameObject1;
            Enemigo.name = "Enemigo " + i.ToString();
        }
    }

    private void Create_Objetos_Seguir()
    {
        for (int i = 0; i < cant_enemigos; i++)
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.position = Posicion_Enemigo(-2);
            obj_Seguir.Add(plane);
        }
    }

    private void Get_Dinamica()
    {
        if (!FindObjectOfType<Pase_Conexion_Menu_Gameplay>().dinamica)
            Luz_Estatica.SetActive(true);
        else
            Luz_Dinamica.SetActive(true);
    }

}
