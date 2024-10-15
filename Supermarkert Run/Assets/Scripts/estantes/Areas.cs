using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour
{
    public enum Area_product { Limpieza_Hogar = 0, Comida, Electrodomesticos, Bebidas, Carros, Articulos_Escolares, Higiene_Personal, Fruta_Verdura, NINGUNO };

    public static readonly string[][] Objetos = new string[8][]
    {
        new string[] { "Detergente", "Lejia", "Escoba", "Trapeador", "Limpiavidrios", "Esponja", "Guantes de limpieza", "Trapo", "Desinfectante", "Papel del baño"},//Limpieza de casa
        new string[] { "Huevos", "Salchicha", "Jamon", "Pan", "Leche", "Pasta", "Arroz", "Carne", "Yogur", "Cereal"},//Comida
        new string[] { "Microndas", "Estufa", "Television", "Radio", "Refrigerador", "Lavadora", "Licuadora", "Horno electrico", "Aspiradora", "Cafetera"},//Electrodomesticos
        new string[] { "Agua", "Juguito", "Jugo", "Cola", "Sprite", "Bebida energetica", "Agua de sabor", "Pesip", "Agua Mineral", "Suero"},//bebidas y jugos
        new string[] { "Llantas", "Tapiceria", "Aceite motor", "Liquido refrigerante", "Aceite para frenos", "Bateria", "Gato hidraulico", "Retrovisores", "Herramientas" , "Adornos"},//Carroceria
        new string[] { "Lapiz", "Cuaderno", "Libro", "Sacapuntas", "Borrador", "Plumas", "Lapicero", "Colores", "Regla", "Marcadores" },//Articulos Escolares
        new string[] { "Jabon", "Champu", "Pasta dientes", "Cepillo de dientes", "Hilo dental", "Toallas", "Rastrillos", "Desodorante", "Gel", "Espuma de afeitar"},//Limpieza Personal
        new string[] { "Manzana", "Platano", "Naranja", "Fresa", "Uva", "Zanahoria", "Tomate", "Lechuga", "Brocoli", "Pepino"}//Frutas y verduras
    };

    public List<GameObject> Limpieza_HogarG;
    public List<GameObject> ComidaG;
    public List<GameObject> ElectrodomesticosG;
    public List<GameObject> Bebidas_JugosG;
    public List<GameObject> CarrosG;
    public List<GameObject> Articulos_EscolaresG;
    public List<GameObject> Limpieza_PersonalG;
    public List<GameObject> Frutas_verdurasG;

    public static readonly List<List<GameObject>> Objetos_Visibles = new List<List<GameObject>>();


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
        Objetos_Visibles.Add(Limpieza_HogarG);
        Objetos_Visibles.Add(ComidaG);
        Objetos_Visibles.Add(ElectrodomesticosG);
        Objetos_Visibles.Add(Bebidas_JugosG);
        Objetos_Visibles.Add(CarrosG);
        Objetos_Visibles.Add(Articulos_EscolaresG);
        Objetos_Visibles.Add(Limpieza_PersonalG);
        Objetos_Visibles.Add(Frutas_verdurasG);



        int count = 0;
        foreach (Transform child_area in transform)
        {
            child_area.SetSiblingIndex(Get_List_Rand()[count++]);
        }
        count = 0;
        foreach (Transform child_area in transform)
        {
            child_area.GetComponent<Area>().Tag = (Area_product)count;
            child_area.GetComponent<Area>().Lista_Objetos = Objetos_Visibles[count++];
        }

    }
}
