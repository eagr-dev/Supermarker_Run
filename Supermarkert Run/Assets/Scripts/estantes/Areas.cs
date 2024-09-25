using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour
{
    public enum Area_product { Limpieza_Hogar = 0, Comida, Electrodomesticos, Bebidas, Carros, Articulos_Escolares, Higiene_Personal, Fruta_Verdura, NINGUNO };

    public static readonly string[][] Objetos = new string[8][]
    {
        new string[] { "Detergente", "Lejia", "Escoba", "Trapeador", "Limpiavidrios", "Esponja", "Guantes de limpieza", "Trapo", "Desinfectante", "Toallitas"},//Limpieza de casa
        new string[] { "Huevos", "Salchicha", "Jamon", "Pan", "Leche", "Pasta", "Arroz", "Carne", "Yogur", "Cereal"},//Comida
        new string[] { "Microndas", "Estufa", "Television", "Radio", "Refrigerador", "Lavadora", "Licuadora", "Horno electrico", "Aspiradora", "Cafetera"},//Electrodomesticos
        new string[] { "Agua", "Juguito", "Jugo", "Cola", "Sprite", "Bebida energetica", "Agua de sabor", "Pesip", "Agua Mineral", "Suero"},//bebidas y jugos
        new string[] { "Llantas", "Tapiceria", "Aceite motor", "Liquido refrigerante", "Aceite para frenos", "Bateria", "Gato hidraulico", "Retrovisores", "Herramientas" , "Adornos"},//Carroceria
        new string[] { "Lapiz", "Cuaderno", "Libro", "Sacapuntas", "Borrador", "Plumas", "Lapicero", "Colores", "Regla", "Marcadores" },//Articulos Escolares
        new string[] { "Jabon", "Champu", "Pasta dientes", "Cepillo de dientes", "Hilo dental", "Toallas", "Rastrillos", "Desodorante", "Gel", "Espuma de afeitar"},//Limpieza Personal
        new string[] { "Manzana", "Platano", "Naranja", "Fresa", "Uva", "Zanahoria", "Tomate", "Lechuga", "Brocoli", "Pepino"}//Frutas y verduras
    };


    private List<Transform> Get_List_Rand()
    {
        List<Transform> list_return = new List<Transform>();
        bool[] pos = { false, false, false, false, false, false, false, false };
        foreach (Transform child_area in transform)
        {
            int pos_pos = Random.Range(0, 7);
           if (pos[pos_pos] != true)
           {
                list_return.Add(child_area);
                pos[pos_pos] = true;
           }
           else
           {
                for(int i = 0;i < 8;i++)
                {
                    if(pos[i] != true)
                    {
                        list_return.Add(child_area);
                        pos[i] = true;
                    }
                }
           }

        }
        return list_return;
    }

    private void Awake()
    {
        int count = 0;
        foreach(Transform child_area in Get_List_Rand())
        {
            child_area.GetComponent<Area>().Tag = (Area_product)count;
            child_area.GetComponent<Area>().Acomodar_Estantes();
            count++;
        }
    }
}
