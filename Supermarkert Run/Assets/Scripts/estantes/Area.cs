using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Areas.Area_product Tag;

    private List<Transform> Get_List_Rand()
    {
        List<Transform> list_return = new List<Transform>();
        bool[] pos = { false, false, false, false, false, false, false, false, false ,false };
        foreach (Transform child_area in transform)
        {
            int pos_pos = Random.Range(0, 9);
            if (pos[pos_pos] != true)
            {
                list_return.Add(child_area);
                pos[pos_pos] = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (pos[i] != true)
                    {
                        list_return.Add(child_area);
                        pos[i] = true;
                    }
                }
            }

        }
        return list_return;
    }

    public void Acomodar_Estantes()
    {
        int count = 0;
        foreach (Transform child in Get_List_Rand())
        {
            child.GetComponent<Estante>().Tag = Tag;
            child.GetComponent<Estante>().count_obj = count;
            count++;
        }
    }

    private void Start()
    {
        Acomodar_Estantes();
    }
}
