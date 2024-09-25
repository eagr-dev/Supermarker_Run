using UnityEngine;

public class Estante : MonoBehaviour
{
    private string objeto;

    public Areas.Area_product Tag;

    public int count_obj = 0;

    void Start()
    {
        objeto = Areas.Objetos[(int)Tag][count_obj];
    }

    public string Get_Object() => objeto;
}
