using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mision : MonoBehaviour
{
    private List<string> objects_mision = new List<string>();
    [SerializeField]private int position_Text = 0;
    public TMP_Text Text;
    private string object_act = "";


    void Awake()
    {
        GameObject TMP = GameObject.Find("Mision_Actual");
        if (TMP != null)
            Text = TMP.GetComponent<TMP_Text>();
        if (objects_mision != null)
        {
            Set_Object(objects_mision);
            New_Text_In_TextMesh();
        }
    }

    public int Cantidad_Nivel()
    {
        int misiones = (int)(FindObjectOfType<Nivel>().nivel / 10);
        misiones = misiones != 0 ? misiones : 10;
        return misiones;
    }

    private void Set_Object(List<string> obj_m)
    {
        int i = 0;
        while (obj_m.Count < Cantidad_Nivel())
        {
            int area = Random.Range(0,7);
            string obj = Areas.Objetos[area][Random.Range(0, 9)];
            if (!Is_Repeat_Object(obj))
            {
                obj_m.Add(obj);
                i++;
            }
            if (i >= 3) return;
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
        if((position_Text < Cantidad_Nivel() && obj == object_act) && Text != null)
        {
            Text.text = objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
        }
    }

    private void New_Text_In_TextMesh()
    {
        if(objects_mision != null && Text != null)
        {
            Text.text = objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
        }
    }

    public int Get_Position() => position_Text - 1;

}
