using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

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
    public static string[][] Objetos = new string[8][]
{
    new string[10], // Limpieza_Hogar
    new string[10], // Comida
    new string[10], // Electrodomesticos
    new string[10], // Bebidas
    new string[10], // Carros
    new string[10], // Articulos_Escolares
    new string[10], // Higiene_Personal
    new string[10]  // Fruta_Verdura
};

    public List<GameObject> Limpieza_HogarG;
    public List<GameObject> ComidaG;
    public List<GameObject> ElectrodomesticosG;
    public List<GameObject> Bebidas_JugosG;
    public List<GameObject> CarrosG;
    public List<GameObject> Articulos_EscolaresG;
    public List<GameObject> Limpieza_PersonalG;
    public List<GameObject> Frutas_verdurasG;

    public static readonly List<List<GameObject>> Objetos_Visibles = new();

    //private string URL_IDIOMA = "";
#if UNITY_EDITOR
    readonly string URL_IDIOMA = (Application.dataPath + "/SUPERMARKER");
    //URL_IDIOMA = Application.dataPath + "/SUPERMARKER";
#else
        readonly string URL_IDIOMA = "/storage/emulated/0/Documents/SUPERMARKER";
#endif

    readonly Contenido_misiones contenido_Ingles = new()
    {
        Limpieza_Casa = new string[] { "Detergent", "Bleach", "Broom", "Mop", "Glass cleaner", "Sponge", "Cleaning gloves", "Cloth", "Disinfectant", "Toilet paper" }, // House cleaning
        Comida = new string[] { "Eggs", "Sausage", "Ham", "Bread", "Milk", "Pasta", "Rice", "Meat", "Yogurt", "Cereal" }, // Food
        Appliances = new string[] { "Microwave", "Stove", "Television", "Radio", "Refrigerator", "Washing machine", "Blender", "Electric oven", "Vacuum cleaner", "Coffee maker" }, // Appliances
        Bebidas = new string[] { "Water", "Juice", "Fruit juice", "Soda", "Sprite", "Energy drink", "Flavored water", "Pepsi", "Mineral water", "Oral rehydration solution" }, // Drinks and juices
        Partes_carros = new string[] { "Tires", "Upholstery", "Engine oil", "Coolant", "Brake fluid", "Battery", "Hydraulic jack", "Mirrors", "Tools", "Decorations" }, // Car parts
        Escuela = new string[] { "Pencil", "Notebook", "Book", "Pencil sharpener", "Eraser", "Pens", "Ballpoint pen", "Crayons", "Ruler", "Markers" }, // School supplies
        Higiene_Personal = new string[] { "Soap", "Shampoo", "Toothpaste", "Toothbrush", "Dental floss", "Towels", "Razors", "Deodorant", "Gel", "Shaving foam" }, // Personal hygiene
        Frutas_y_verduras = new string[] { "Apple", "Banana", "Orange", "Strawberry", "Grape", "Carrot", "Tomato", "Lettuce", "Broccoli", "Cucumber" } // Fruits and vegetables

    };

    readonly Contenido_misiones contenido_Español = new()
    {
        Limpieza_Casa = new string[] { "Detergente", "Blanqueador", "Escoba", "Mopa", "Limpiador de vidrios", "Esponja", "Guantes de limpieza", "Trapo", "Desinfectante", "Papel higiénico" }, // Limpieza Casa
        Comida = new string[] { "Huevos", "Salchicha", "Jamón", "Pan", "Leche", "Pasta", "Arroz", "Carne", "Yogur", "Cereal" }, // Comida
        Appliances = new string[] { "Microondas", "Estufa", "Televisión", "Radio", "Refrigerador", "Lavadora", "Licuadora", "Horno eléctrico", "Aspiradora", "Cafetera" },
        Bebidas = new string[] { "Agua", "Jugo", "Zumo de fruta", "Refresco", "Sprite", "Bebida energética", "Agua saborizada", "Pepsi", "Agua mineral", "Suero oral" }, // Bebidas
        Partes_carros = new string[] { "Llantas", "Tapicería", "Aceite de motor", "Refrigerante", "Líquido de frenos", "Batería", "Gato hidráulico", "Espejos", "Herramientas", "Decoraciones" }, // Partes carros
        Escuela = new string[] { "Lápiz", "Cuaderno", "Libro", "Sacapuntas", "Borrador", "Plumas", "Bolígrafo", "Crayones", "Regla", "Marcadores" }, // Escuela
        Higiene_Personal = new string[] { "Jabón", "Champú", "Pasta dental", "Cepillo de dientes", "Hilo dental", "Toallas", "Rastrillos", "Desodorante", "Gel", "Espuma de afeitar" }, // Higiene Personal
        Frutas_y_verduras = new string[] { "Manzana", "Banana", "Naranja", "Fresa", "Uva", "Zanahoria", "Tomate", "Lechuga", "Brócoli", "Pepino" } // Frutas y verduras
    };

    readonly Contenido_misiones contenido_Portugues = new()
    {
        Limpieza_Casa = new string[] { "Detergente", "Alvejante", "Vassoura", "Esfregão", "Limpador de vidros", "Esponja", "Luvas de limpeza", "Pano", "Desinfetante", "Papel higiênico" }, // House cleaning
        Comida = new string[] { "Ovos", "Linguiça", "Presunto", "Pão", "Leite", "Massa", "Arroz", "Carne", "Iogurte", "Cereal" }, // Food
        Appliances = new string[] { "Micro-ondas", "Fogão", "Televisão", "Rádio", "Geladeira", "Máquina de lavar", "Liquidificador", "Forno elétrico", "Aspirador de pó", "Cafeteira" }, // Appliances
        Bebidas = new string[] { "Água", "Suco", "Suco de frutas", "Refrigerante", "Sprite", "Bebida energética", "Água saborizada", "Pepsi", "Água mineral", "Soro oral" }, // Drinks and juices
        Partes_carros = new string[] { "Pneus", "Estofamento", "Óleo de motor", "Refrigerante", "Fluido de freio", "Bateria", "Macaco hidráulico", "Espelhos", "Ferramentas", "Decorações" }, // Car parts
        Escuela = new string[] { "Lápis", "Caderno", "Livro", "Apontador", "Borracha", "Canetas", "Caneta esferográfica", "Giz de cera", "Régua", "Marcadores" }, // School supplies
        Higiene_Personal = new string[] { "Sabão", "Shampoo", "Pasta de dente", "Escova de dentes", "Fio dental", "Toalhas", "Lâminas de barbear", "Desodorante", "Gel", "Espuma de barbear" }, // Personal hygiene
        Frutas_y_verduras = new string[] { "Maçã", "Banana", "Laranja", "Morango", "Uva", "Cenoura", "Tomate", "Alface", "Brócolis", "Pepino" } // Fruits and vegetables
    };


    private List<int> Get_List_Rand()
    {
        List<int> list_return = new();
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
        //Leer_Archivo();
        AsignarMedianteIdioma();

        if(!VerificarDatos())
        {
            //Create_Files();
            Debug.LogError("No se cargaron bien los datos");
            SceneManager.LoadScene(0);
        }

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

    [System.Obsolete("ya no se usan archivos.", true)]
    private void Leer_Archivo()
    {
        int eleccion = PlayerPrefs.GetInt("idioma", 0);
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
            Asignar(CM);
        }
        else
        {
            Create_Files();
            SceneManager.LoadScene(0);

        }
    }

    private void AsignarMedianteIdioma()
    {
        int eleccion = PlayerPrefs.GetInt("idioma", 0);

        switch (eleccion)
        {
            case 0:
                Asignar(contenido_Ingles);
                break;
            case 1:
                Asignar(contenido_Español);
                break;
            case 2:
                Asignar(contenido_Portugues);
                break;
        }
    }

    [System.Obsolete("Ya no se crearan archivos.", true)]
    private void Create_Files()
    {

        Contenido_misiones contenido_Ingles = new Contenido_misiones()
        {
                Limpieza_Casa = new string[] { "Detergent", "Bleach", "Broom", "Mop", "Glass cleaner", "Sponge", "Cleaning gloves", "Cloth", "Disinfectant", "Toilet paper" }, // House cleaning
                Comida = new string[] { "Eggs", "Sausage", "Ham", "Bread", "Milk", "Pasta", "Rice", "Meat", "Yogurt", "Cereal" }, // Food
                Appliances = new string[] { "Microwave", "Stove", "Television", "Radio", "Refrigerator", "Washing machine", "Blender", "Electric oven", "Vacuum cleaner", "Coffee maker" }, // Appliances
                Bebidas = new string[] { "Water", "Juice", "Fruit juice", "Soda", "Sprite", "Energy drink", "Flavored water", "Pepsi", "Mineral water", "Oral rehydration solution" }, // Drinks and juices
                Partes_carros = new string[] { "Tires", "Upholstery", "Engine oil", "Coolant", "Brake fluid", "Battery", "Hydraulic jack", "Mirrors", "Tools", "Decorations" }, // Car parts
                Escuela = new string[] { "Pencil", "Notebook", "Book", "Pencil sharpener", "Eraser", "Pens", "Ballpoint pen", "Crayons", "Ruler", "Markers" }, // School supplies
                Higiene_Personal = new string[] { "Soap", "Shampoo", "Toothpaste", "Toothbrush", "Dental floss", "Towels", "Razors", "Deodorant", "Gel", "Shaving foam" }, // Personal hygiene
                Frutas_y_verduras = new string[] { "Apple", "Banana", "Orange", "Strawberry", "Grape", "Carrot", "Tomato", "Lettuce", "Broccoli", "Cucumber" } // Fruits and vegetables
            
    };

        Contenido_misiones contenido_Español = new Contenido_misiones()
        {
                Limpieza_Casa = new string[] { "Detergente", "Blanqueador", "Escoba", "Mopa", "Limpiador de vidrios", "Esponja", "Guantes de limpieza", "Trapo", "Desinfectante", "Papel higiénico" }, // Limpieza Casa
                Comida = new string[] { "Huevos", "Salchicha", "Jamón", "Pan", "Leche", "Pasta", "Arroz", "Carne", "Yogur", "Cereal" }, // Comida
                Appliances = new string[] { "Microondas", "Estufa", "Televisión", "Radio", "Refrigerador", "Lavadora", "Licuadora", "Horno eléctrico", "Aspiradora", "Cafetera" },
                Bebidas = new string[] { "Agua", "Jugo", "Zumo de fruta", "Refresco", "Sprite", "Bebida energética", "Agua saborizada", "Pepsi", "Agua mineral", "Suero oral" }, // Bebidas
                Partes_carros = new string[] { "Llantas", "Tapicería", "Aceite de motor", "Refrigerante", "Líquido de frenos", "Batería", "Gato hidráulico", "Espejos", "Herramientas", "Decoraciones" }, // Partes carros
                Escuela = new string[] { "Lápiz", "Cuaderno", "Libro", "Sacapuntas", "Borrador", "Plumas", "Bolígrafo", "Crayones", "Regla", "Marcadores" }, // Escuela
                Higiene_Personal = new string[] { "Jabón", "Champú", "Pasta dental", "Cepillo de dientes", "Hilo dental", "Toallas", "Rastrillos", "Desodorante", "Gel", "Espuma de afeitar" }, // Higiene Personal
                Frutas_y_verduras = new string[] { "Manzana", "Banana", "Naranja", "Fresa", "Uva", "Zanahoria", "Tomate", "Lechuga", "Brócoli", "Pepino" } // Frutas y verduras
        };

        Contenido_misiones contenido_Portugues = new Contenido_misiones()
        {
                Limpieza_Casa = new string[] { "Detergente", "Alvejante", "Vassoura", "Esfregão", "Limpador de vidros", "Esponja", "Luvas de limpeza", "Pano", "Desinfetante", "Papel higiênico" }, // House cleaning
                Comida = new string[] { "Ovos", "Linguiça", "Presunto", "Pão", "Leite", "Massa", "Arroz", "Carne", "Iogurte", "Cereal" }, // Food
                Appliances = new string[] { "Micro-ondas", "Fogão", "Televisão", "Rádio", "Geladeira", "Máquina de lavar", "Liquidificador", "Forno elétrico", "Aspirador de pó", "Cafeteira" }, // Appliances
                Bebidas = new string[] { "Água", "Suco", "Suco de frutas", "Refrigerante", "Sprite", "Bebida energética", "Água saborizada", "Pepsi", "Água mineral", "Soro oral" }, // Drinks and juices
                Partes_carros = new string[] { "Pneus", "Estofamento", "Óleo de motor", "Refrigerante", "Fluido de freio", "Bateria", "Macaco hidráulico", "Espelhos", "Ferramentas", "Decorações" }, // Car parts
                Escuela = new string[] { "Lápis", "Caderno", "Livro", "Apontador", "Borracha", "Canetas", "Caneta esferográfica", "Giz de cera", "Régua", "Marcadores" }, // School supplies
                Higiene_Personal = new string[] { "Sabão", "Shampoo", "Pasta de dente", "Escova de dentes", "Fio dental", "Toalhas", "Lâminas de barbear", "Desodorante", "Gel", "Espuma de barbear" }, // Personal hygiene
                Frutas_y_verduras = new string[] { "Maçã", "Banana", "Laranja", "Morango", "Uva", "Cenoura", "Tomate", "Alface", "Brócolis", "Pepino" } // Fruits and vegetables
        };

        string conten_I = JsonUtility.ToJson(contenido_Ingles);
        string conten_E = JsonUtility.ToJson(contenido_Español);
        string conten_P = JsonUtility.ToJson(contenido_Portugues);

        File.WriteAllText(URL_IDIOMA + "/Ingles.json", conten_I);
        File.WriteAllText(URL_IDIOMA + "/Español.json", conten_E);
        File.WriteAllText(URL_IDIOMA + "/Portugues.json", conten_P);
    }

    private void Asignar(Contenido_misiones CM)
    {
        Debug.Log(CM);
        Objetos[0] = CM.Limpieza_Casa;
        Objetos[1] = CM.Comida;
        Objetos[2] = CM.Appliances;
        Objetos[3] = CM.Bebidas;
        Objetos[4] = CM.Partes_carros;
        Objetos[5] = CM.Escuela;
        Objetos[6] = CM.Higiene_Personal;
        Objetos[7] = CM.Frutas_y_verduras;
    }

    private bool VerificarDatos()
    {
        for (int i = 0; i < 8; i++)
        {
            if (Objetos[i] == null || Objetos[i].Length == 0)
            {
                Debug.LogError($"Objetos[{i}] está vacío o null");
                return false;
            }
        }
        return true;
    }



    public static GameObject Get_GameObject(string name)
    {
        for(int i = 0; i < 8;i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if (name != Objetos[i][j]) continue;
                return Objetos_Visibles[i][j];
            }
        }
        return null;
    }

}
