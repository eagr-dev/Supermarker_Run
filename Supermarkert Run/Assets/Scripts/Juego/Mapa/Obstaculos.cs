using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] private GameObject Enemigo;
    [SerializeField] int min_obj, max_obj, cant_enemigos;
    private Mapa mapa_content;
    private List<GameObject> obj_Seguir = new();

    private void Awake()
    {
        mapa_content = FindObjectOfType<Dinero_Obtenido>().Get_Mapa(SceneManager.GetActiveScene().name);
        Create_OBJ();
        Create_Objetos_Seguir();
        Create_Enemigos();
    }

    private Vector3 Posicion(float altura)
    {
        
         float X = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
         float Y = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
         return new Vector3(X,altura,Y);
    }

    private void Create_OBJ()
    {
        int N_crear_OBJ = (int)Random.Range(min_obj, max_obj);
        for(int i = 0; i < N_crear_OBJ; i++)
        {
            Instantiate(Obstaculo);
            Obstaculo.transform.position = Posicion(0.2f);
        }
    }

    private void Create_Enemigos()
    {
        for(int i = 0;i < cant_enemigos;i++)
        {
            Instantiate(Enemigo);
            Enemigo.transform.position = Posicion(1);
            GameObject gameObject1 = obj_Seguir[i];
            Enemigo.GetComponent<IA>().objecto_seguir = gameObject1;
            Enemigo.name = "Enemigo " + i.ToString();
        }

        foreach (IA obj in FindObjectsOfType<IA>())
        {
            if (obj.name == "enemigo(Clone)") Destroy(obj.gameObject);
        }
            
    }

    private void Create_Objetos_Seguir()
    {
        for (int i = 0; i < cant_enemigos; i++)
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.position = Posicion(-2);
            obj_Seguir.Add(plane);
        }
    }
}
