using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] int min_obj, max_obj;
    private Mapa mapa_content;

    private void Awake()
    {
        mapa_content = FindObjectOfType<Dinero_Obtenido>().Get_Mapa(SceneManager.GetActiveScene().buildIndex);
        Create_OBJ();
    }

    private Vector3 Posicion()
    {
        
         float X = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
         float Y = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
         return new Vector3(X,0.2f,Y);
    }

    private void Create_OBJ()
    {
        int N_crear_OBJ = (int)Random.Range(min_obj, max_obj);
        for(int i = 0; i < N_crear_OBJ; i++)
        {
            Instantiate(Obstaculo);
            Obstaculo.transform.position = Posicion();
        }
    }
}
