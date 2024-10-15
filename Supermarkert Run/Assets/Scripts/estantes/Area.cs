using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Areas.Area_product Tag;
    public List<GameObject> Lista_Objetos;

    private List<int> Get_List_Rand()
    {
        List<int> list_return = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for(int i = 0; i < 9;i++)
        {
            int random = Random.Range(0, 9);
            int aux = list_return[i];
            list_return[i] = list_return[random];
            list_return[random] = aux; 
        }

        return list_return;
    }

    public void Acomodar_Estantes()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            child.SetSiblingIndex(Get_List_Rand()[count++]);
        }

        count = 0;

        foreach (Transform child in transform)
        {
            child.GetComponent<Estante>().Set_Product(Tag, count, Lista_Objetos[count++]);
        }
    }

    private void Start()
    {
        Acomodar_Estantes();
    }
}
