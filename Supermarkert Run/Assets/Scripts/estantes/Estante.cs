using UnityEngine;

public class Estante : MonoBehaviour
{
    [SerializeField]private string objeto;

    public Areas.Area_product Tag;

    public int count_obj = 0;

    public void Set_Product(Areas.Area_product tag, int producto)
    {
        objeto = Areas.Objetos[(int)tag][producto];
        count_obj = producto;
        Tag = tag;
    }

    public string Get_Object() => objeto;
}
