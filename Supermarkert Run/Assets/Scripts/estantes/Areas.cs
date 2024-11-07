using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour
{
    public enum Area_product { Limpieza_Hogar = 0, Comida, Electrodomesticos, Bebidas, Carros, Articulos_Escolares, Higiene_Personal, Fruta_Verdura, NINGUNO };

    public static readonly string[][] Objetos = new string[8][]
    {
        new string[] { "Detergent", "Bleach", "Broom", "Mop", "Glass cleaner", "Sponge", "Cleaning gloves", "Cloth", "Disinfectant", "Toilet paper" }, // House cleaning
        new string[] { "Eggs", "Sausage", "Ham", "Bread", "Milk", "Pasta", "Rice", "Meat", "Yogurt", "Cereal" }, // Food
        new string[] { "Microwave", "Stove", "Television", "Radio", "Refrigerator", "Washing machine", "Blender", "Electric oven", "Vacuum cleaner", "Coffee maker" }, // Appliances
        new string[] { "Water", "Juice", "Fruit juice", "Soda", "Sprite", "Energy drink", "Flavored water", "Pepsi", "Mineral water", "Oral rehydration solution" }, // Drinks and juices
        new string[] { "Tires", "Upholstery", "Engine oil", "Coolant", "Brake fluid", "Battery", "Hydraulic jack", "Mirrors", "Tools", "Decorations" }, // Car parts
        new string[] { "Pencil", "Notebook", "Book", "Pencil sharpener", "Eraser", "Pens", "Ballpoint pen", "Crayons", "Ruler", "Markers" }, // School supplies
        new string[] { "Soap", "Shampoo", "Toothpaste", "Toothbrush", "Dental floss", "Towels", "Razors", "Deodorant", "Gel", "Shaving foam" }, // Personal hygiene
        new string[] { "Apple", "Banana", "Orange", "Strawberry", "Grape", "Carrot", "Tomato", "Lettuce", "Broccoli", "Cucumber" } // Fruits and vegetables
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
