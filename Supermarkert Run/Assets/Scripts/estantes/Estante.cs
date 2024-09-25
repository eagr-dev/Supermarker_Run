using UnityEngine;

public class Estante : MonoBehaviour
{
    public readonly string[] Objetos = new string[8]
    { "Producto_Limpieza", "Jabon", "Shampoo", "Pasta_Dientes", "Articulos_Escolares", "Cuadernos", "LLantas", "Tapiceria"};

    public string objeto;

    // Start is called before the first frame update
    void Awake()
    {
        objeto = Objetos[Random.Range(0, 7)];
    }
}
