using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Seleccion_Carrito_Ai : MonoBehaviour
{
    public GameObject[] Carritos = new GameObject[3];
    [SerializeField] private RigBuilder rigid_animaciones;
    private void Awake()
    {
        int pos = Random.Range(0, 2);
        Carritos[pos].SetActive(true);
        rigid_animaciones.layers[pos].active = true;
        int posmat = Random.Range(0, Carritos[pos].GetComponent<Get_Content_Car>().Get_Counts_Car() - 1);
        Carritos[pos].GetComponent<Get_Content_Car>().Set_Car(posmat);
    }
}
