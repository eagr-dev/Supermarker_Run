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


    private List<int> Get_List_Rand()
    {
        List<int> list_return = new List<int>();
        int count = 0;

        while(count < 7)
        {
            int r = Random.Range(0, 7);
            if(!Find(r,list_return))
            {
                list_return.Add(r);
                count++;
            }
        }
        
        return list_return;
    }

    private bool Find(int number, List<int> list_number)
    {
        foreach(int i in list_number)
        {
            if (i == number)
                return true;
        }
        return false;
    }

    private void Awake()
    {
        int count = 0;
        foreach (Transform child_area in transform)
        {
            child_area.SetSiblingIndex(Get_List_Rand()[count++]);
        }
        count = 0;
        foreach (Transform child_area in transform)
        {
            child_area.GetComponent<Area>().Tag = (Area_product)count++;
        }

    }
}
