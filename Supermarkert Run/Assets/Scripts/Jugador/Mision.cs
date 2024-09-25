using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mision : MonoBehaviour
{
    private string[] objects_mision = new string[3];
    private int position_Text = 0;
    public TMP_Text Text;
    private string object_act = "";

    // Start is called before the first frame update
    private void Awake()
    {
        Set_Object();
    }
    void Start()
    {
        Text = GetComponent<TMP_Text>();
        New_Text_In_TextMesh();
    }

    private void Set_Object()
    {
        string obj = "";
        Estante estante = FindObjectOfType<Estante>();
        int i = 0;
        while(objects_mision[2] != "")
        {
            obj = estante.Objetos[Random.Range(0, 8)];

            if(!Is_Repeat_Object(obj))
            {
                objects_mision[i] = obj;
                i++;
            }
        }
    }

    private bool Is_Repeat_Object(string obj_compare)
    {
        foreach(string obj in objects_mision)
        {
            if (obj == obj_compare)
                return true;
        }
        return false;
    }

    public void New_Text_In_TextMesh(string obj)
    {
        if(position_Text < 3 && obj == object_act)
        {
            Text.text += objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
        }
    }

    private void New_Text_In_TextMesh()
    {
        Text.text += objects_mision[position_Text];
        object_act = objects_mision[position_Text];
        position_Text++;
    }

}
