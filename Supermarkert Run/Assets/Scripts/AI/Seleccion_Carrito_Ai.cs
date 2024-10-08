using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion_Carrito_Ai : MonoBehaviour
{
    public GameObject[] Carritos = new GameObject[3];
    private void Awake()
    {
        int pos = Random.Range(0, 2);
        Carritos[pos].SetActive(true);
        int posmat = Random.Range(0, Carritos[pos].GetComponent<Get_Content_Car>().Get_Counts_Car());
        Carritos[pos].GetComponent<Get_Content_Car>().Set_Car(posmat);
        Debug.Log($"{pos}\n{posmat}");
    }
}
