using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Areas.Area_product Tag;

    private List<int> Get_List_Rand()
    {
        List<int> list_return = new List<int>();
        int count = 0;

        while (count < 9)
        {
            int r = Random.Range(0, 9);
            if (!Find(r, list_return))
            {
                list_return.Add(r);
                count++;
            }
        }

        return list_return;
    }

    private bool Find(int number, List<int> list_number)
    {
        foreach (int i in list_number)
        {
            if (i == number)
                return true;
        }
        return false;
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
            child.GetComponent<Estante>().Set_Product(Tag, count++);
        }
    }

    private void Start()
    {
        Acomodar_Estantes();
    }
}
