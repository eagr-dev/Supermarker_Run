using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Areas : MonoBehaviour
{
    public enum Area_product { Limpieza_Hogar = 0, Comida, Electrodomesticos, Bebidas, Carros, Articulos_Escolares, Higiene_Personal, Fruta_Verdura, NINGUNO };

    /*public static string[][] Objetos = new string[8][]
    {
        new string[] { "Detergent", "Bleach", "Broom", "Mop", "Glass cleaner", "Sponge", "Cleaning gloves", "Cloth", "Disinfectant", "Toilet paper" }, // House cleaning
        new string[] { "Eggs", "Sausage", "Ham", "Bread", "Milk", "Pasta", "Rice", "Meat", "Yogurt", "Cereal" }, // Food
        new string[] { "Microwave", "Stove", "Television", "Radio", "Refrigerator", "Washing machine", "Blender", "Electric oven", "Vacuum cleaner", "Coffee maker" }, // Appliances
        new string[] { "Water", "Juice", "Fruit juice", "Soda", "Sprite", "Energy drink", "Flavored water", "Pepsi", "Mineral water", "Oral rehydration solution" }, // Drinks and juices
        new string[] { "Tires", "Upholstery", "Engine oil", "Coolant", "Brake fluid", "Battery", "Hydraulic jack", "Mirrors", "Tools", "Decorations" }, // Car parts
        new string[] { "Pencil", "Notebook", "Book", "Pencil sharpener", "Eraser", "Pens", "Ballpoint pen", "Crayons", "Ruler", "Markers" }, // School supplies
        new string[] { "Soap", "Shampoo", "Toothpaste", "Toothbrush", "Dental floss", "Towels", "Razors", "Deodorant", "Gel", "Shaving foam" }, // Personal hygiene
        new string[] { "Apple", "Banana", "Orange", "Strawberry", "Grape", "Carrot", "Tomato", "Lettuce", "Broccoli", "Cucumber" } // Fruits and vegetables
    };*/
    public static string[][] Objetos = new string[8][];

    public List<GameObject> Limpieza_HogarG;
    public List<GameObject> ComidaG;
    public List<GameObject> ElectrodomesticosG;
    public List<GameObject> Bebidas_JugosG;
    public List<GameObject> CarrosG;
    public List<GameObject> Articulos_EscolaresG;
    public List<GameObject> Limpieza_PersonalG;
    public List<GameObject> Frutas_verdurasG;

    public static readonly List<List<GameObject>> Objetos_Visibles = new List<List<GameObject>>();

    private string URL_IDIOMA = "";


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
#if UNITY_EDITOR
        URL_IDIOMA = Application.dataPath;
#else
        URL_IDIOMA = "/storage/emulated/0/Documents";
#endif
        Leer_Archivo();

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

    private void Leer_Archivo()
    {
        int eleccion = PlayerPrefs.GetInt("idioma", 0);
        Debug.Log($"Eleccion: {eleccion}");
        string ruta = "";


        switch (eleccion)
        {
            case 0:
                ruta = URL_IDIOMA + "/Ingles.json"; 
                break;
            case 1:
                ruta = URL_IDIOMA + "/Español.json";
                break;
            case 2:
                ruta = URL_IDIOMA + "/Portugues.json";
                break;
        }

        if(File.Exists(ruta))
        {
            string leer = File.ReadAllText(ruta);
            Contenido_misiones CM = JsonUtility.FromJson<Contenido_misiones>(leer);
            Debug.Log(ruta);
            Asignar(CM);
        }
        else
        {
            Create_Files();
        }
    }

    private void Create_Files()
    {

        Contenido_misiones contenido_Ingles = new Contenido_misiones()
        {
                linea1 = new string[] { "Detergent", "Bleach", "Broom", "Mop", "Glass cleaner", "Sponge", "Cleaning gloves", "Cloth", "Disinfectant", "Toilet paper" }, // House cleaning
                linea2 = new string[] { "Eggs", "Sausage", "Ham", "Bread", "Milk", "Pasta", "Rice", "Meat", "Yogurt", "Cereal" }, // Food
                linea3 = new string[] { "Microwave", "Stove", "Television", "Radio", "Refrigerator", "Washing machine", "Blender", "Electric oven", "Vacuum cleaner", "Coffee maker" }, // Appliances
                linea4 = new string[] { "Water", "Juice", "Fruit juice", "Soda", "Sprite", "Energy drink", "Flavored water", "Pepsi", "Mineral water", "Oral rehydration solution" }, // Drinks and juices
                linea5 = new string[] { "Tires", "Upholstery", "Engine oil", "Coolant", "Brake fluid", "Battery", "Hydraulic jack", "Mirrors", "Tools", "Decorations" }, // Car parts
                linea6 = new string[] { "Pencil", "Notebook", "Book", "Pencil sharpener", "Eraser", "Pens", "Ballpoint pen", "Crayons", "Ruler", "Markers" }, // School supplies
                linea7 = new string[] { "Soap", "Shampoo", "Toothpaste", "Toothbrush", "Dental floss", "Towels", "Razors", "Deodorant", "Gel", "Shaving foam" }, // Personal hygiene
                linea8 = new string[] { "Apple", "Banana", "Orange", "Strawberry", "Grape", "Carrot", "Tomato", "Lettuce", "Broccoli", "Cucumber" } // Fruits and vegetables
            
    };

        Contenido_misiones contenido_Español = new Contenido_misiones()
        {
                linea1 = new string[] { "Detergente", "Blanqueador", "Escoba", "Mopa", "Limpiador de vidrios", "Esponja", "Guantes de limpieza", "Trapo", "Desinfectante", "Papel higiénico" }, // Limpieza Casa
                linea2 = new string[] { "Huevos", "Salchicha", "Jamón", "Pan", "Leche", "Pasta", "Arroz", "Carne", "Yogur", "Cereal" }, // Comida
                linea3 = new string[] { "Microondas", "Estufa", "Televisión", "Radio", "Refrigerador", "Lavadora", "Licuadora", "Horno eléctrico", "Aspiradora", "Cafetera" },
                linea4 = new string[] { "Agua", "Jugo", "Zumo de fruta", "Refresco", "Sprite", "Bebida energética", "Agua saborizada", "Pepsi", "Agua mineral", "Suero oral" }, // Bebidas
                linea5 = new string[] { "Llantas", "Tapicería", "Aceite de motor", "Refrigerante", "Líquido de frenos", "Batería", "Gato hidráulico", "Espejos", "Herramientas", "Decoraciones" }, // Partes carros
                linea6 = new string[] { "Lápiz", "Cuaderno", "Libro", "Sacapuntas", "Borrador", "Plumas", "Bolígrafo", "Crayones", "Regla", "Marcadores" }, // Escuela
                linea7 = new string[] { "Jabón", "Champú", "Pasta dental", "Cepillo de dientes", "Hilo dental", "Toallas", "Rastrillos", "Desodorante", "Gel", "Espuma de afeitar" }, // Higiene Personal
                linea8 = new string[] { "Manzana", "Banana", "Naranja", "Fresa", "Uva", "Zanahoria", "Tomate", "Lechuga", "Brócoli", "Pepino" } // Frutas y verduras
        };

        Contenido_misiones contenido_Portugues = new Contenido_misiones()
        {
                linea1 = new string[] { "Detergente", "Alvejante", "Vassoura", "Esfregão", "Limpador de vidros", "Esponja", "Luvas de limpeza", "Pano", "Desinfetante", "Papel higiênico" }, // House cleaning
                linea2 = new string[] { "Ovos", "Linguiça", "Presunto", "Pão", "Leite", "Massa", "Arroz", "Carne", "Iogurte", "Cereal" }, // Food
                linea3 = new string[] { "Micro-ondas", "Fogão", "Televisão", "Rádio", "Geladeira", "Máquina de lavar", "Liquidificador", "Forno elétrico", "Aspirador de pó", "Cafeteira" }, // Appliances
                linea4 = new string[] { "Água", "Suco", "Suco de frutas", "Refrigerante", "Sprite", "Bebida energética", "Água saborizada", "Pepsi", "Água mineral", "Soro oral" }, // Drinks and juices
                linea5 = new string[] { "Pneus", "Estofamento", "Óleo de motor", "Refrigerante", "Fluido de freio", "Bateria", "Macaco hidráulico", "Espelhos", "Ferramentas", "Decorações" }, // Car parts
                linea6 = new string[] { "Lápis", "Caderno", "Livro", "Apontador", "Borracha", "Canetas", "Caneta esferográfica", "Giz de cera", "Régua", "Marcadores" }, // School supplies
                linea7 = new string[] { "Sabão", "Shampoo", "Pasta de dente", "Escova de dentes", "Fio dental", "Toalhas", "Lâminas de barbear", "Desodorante", "Gel", "Espuma de barbear" }, // Personal hygiene
                linea8 = new string[] { "Maçã", "Banana", "Laranja", "Morango", "Uva", "Cenoura", "Tomate", "Alface", "Brócolis", "Pepino" } // Fruits and vegetables
        };

        string conten_I = EditorJsonUtility.ToJson(contenido_Ingles);
        string conten_E = JsonUtility.ToJson(contenido_Español);
        string conten_P = JsonUtility.ToJson(contenido_Portugues);

        File.WriteAllText(URL_IDIOMA + "/Ingles.json", conten_I);
        File.WriteAllText(URL_IDIOMA + "/Español.json", conten_E);
        File.WriteAllText(URL_IDIOMA + "/Portugues.json", conten_P);
    }

    private static void Asignar(Contenido_misiones CM)
    {
        Objetos[0] = CM.linea1;
        Objetos[1] = CM.linea2;
        Objetos[2] = CM.linea3;
        Objetos[3] = CM.linea4;
        Objetos[4] = CM.linea5;
        Objetos[5] = CM.linea6;
        Objetos[6] = CM.linea7;
        Objetos[7] = CM.linea8;
        foreach(var i in Objetos[0])
        {
            Debug.Log(i);
        }
    }


}
