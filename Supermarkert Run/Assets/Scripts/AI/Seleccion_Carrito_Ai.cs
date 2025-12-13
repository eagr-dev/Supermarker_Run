using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Seleccion_Carrito_Ai : MonoBehaviour
{
    public GameObject[] Carritos = new GameObject[3];
    [SerializeField] private RigBuilder rigid_animaciones;
    private int index = 0;
    private void Awake()
    {
        index = Random.Range(0, 2);
        Carritos[index].SetActive(true);
        rigid_animaciones.layers[index].active = true;
        int posmat = Random.Range(0, Carritos[index].GetComponent<Get_Content_Car>().Get_Counts_Car() - 1);
        Carritos[index].GetComponent<Get_Content_Car>().Set_Car(posmat);
    }

    public int GetIndex() => index;
}
