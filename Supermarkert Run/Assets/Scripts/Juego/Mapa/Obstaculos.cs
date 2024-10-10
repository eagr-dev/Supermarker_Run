using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private GameObject Obstaculo;
    private readonly List<GameObject> OBJS;
    [SerializeField] int min_obj, max_obj;
    private Mapa mapa_content;

    private void Awake()
    {
        mapa_content = FindObjectOfType<Mapa>();
        Create_OBJ();
    }

    private void Posicion()
    {
        foreach(GameObject obj in OBJS)
        {
            float X = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
            float Y = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
            obj.transform.position = new Vector3(X,0.2f,Y);
        }
    }

    private void Create_OBJ()
    {
        int N_crear_OBJ = (int)Random.Range(min_obj, max_obj);
        Debug.Log(N_crear_OBJ);
        for(int i = 0; i < N_crear_OBJ; i++)
        {
            Instantiate(Obstaculo);
            OBJS.Add(Obstaculo);
        }
        Posicion();
    }
}
