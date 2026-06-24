using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Areas : MonoBehaviour
{
    public enum Area_product { Limpieza_Hogar = 0, Comida, Electrodomesticos, Bebidas, Carros, Articulos_Escolares, Higiene_Personal, Fruta_Verdura, NINGUNO };

    /*son 8 pero debo acomodar para evitar errores, debo modificar las areas de todos los mapas*/
    public const int areas = 8, objetos_contiene = 10;
    public static int _areas = areas, _objetos_contiene = objetos_contiene;

    public static string[][] Objetos = new string[areas][]
{
    new string[objetos_contiene], // Limpieza_Hogar
    new string[objetos_contiene], // Comida
    new string[objetos_contiene], // Electrodomesticos
    new string[objetos_contiene], // Bebidas
    new string[objetos_contiene], // Carros
    new string[objetos_contiene], // Articulos_Escolares
    new string[objetos_contiene], // Higiene_Personal
    new string[objetos_contiene]  // Fruta_Verdura
};


    [System.Obsolete("Ya no se copian objetos ahora solo se dice que tipo de area es")]
    public static readonly List<List<GameObject>> Objetos_Visibles = new();

    static readonly Contenido_misiones contenido_Ingles = new()
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

    static readonly Contenido_misiones contenido_Español = new()
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

    static readonly Contenido_misiones contenido_Portugues = new()
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

    static readonly List<string> prefabsResource = new() { 
        "escoba 1",
        "hamburguesa 1", 
        "microondas 1",
        "cajaJugo",
        "caja",
        "libro",
        "PepelHigienico 1",
        "manzana 1",
        };

    static readonly List<string> prefabsResourceRecogibles = new() {
        "escoba 1Recogible",
        "hamburguesa 1Recogible",
        "microondas 1Recogible",
        "cajaJugoRecogible",
        "cajaRecogible",
        "libroRecogible",
        "PepeHigienico 1Recogible",
        "manzana 1Recogible"
    };

    private List<int> Get_List_Rand()
    {
        List<int> list_return = new();
        int count = 0;

        while(count < areas)
        {
            int r = Random.Range(0, areas);
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
        return list_number.Contains(number);
    }

    private void Awake()
    {
        AsignarMedianteIdioma();

        if(!VerificarDatos())
        {
            Debug.LogError("No se cargaron bien los datos");
            SceneManager.LoadScene(0);
        }

        int count = 0;
        var list = Get_List_Rand();
        foreach (Transform child_area in transform)
            child_area.SetSiblingIndex(list[count++]);
        count = 0;
        foreach (Transform child_area in transform) 
            child_area.GetComponent<Area>().Tag = (Area_product)count++;

    }

    private void AsignarMedianteIdioma()
    {
        Idioma.Lengua eleccion = (Idioma.Lengua)PlayerPrefs.GetInt("idioma", (int)Idioma.Lengua.INGLES);

        switch (eleccion)
        {
            case Idioma.Lengua.INGLES:
                Asignar(contenido_Ingles);
                break;
            case Idioma.Lengua.ESPANIOL:
                Asignar(contenido_Español);
                break;
            case Idioma.Lengua.PORTUGUES:
                Asignar(contenido_Portugues);
                break;
        }
    }

    private void Asignar(Contenido_misiones CM)
    {
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
        for (int i = 0; i < areas; i++)
        {
            if (Objetos[i] == null || Objetos[i].Length == 0)
            {
                Debug.LogError($"Objetos[{i}] está vacío o null");
                return false;
            }
        }
        return true;
    }
    


    public static GameObject Get_GameObject(string name, bool esRecogible)
    {
        for(int i = 0; i < areas;i++)
        {
            for(int j = 0; j < objetos_contiene; j++)
            {
                if (name != Objetos[i][j]) continue;
                
                string nameObject = esRecogible ? prefabsResourceRecogibles[i] : prefabsResource[i];
                GameObject objeto = Resources.Load<GameObject>(nameObject);
                return objeto;
            }
        }
        return null;
    }

    public static Area_product Get_Tag_Area_Product(string name)
    {

        for (int i = 0; i < areas; i++)
        {
            for (int j = 0; j < objetos_contiene; j++)
            {
                if (name != Objetos[i][j]) continue;
                var tag = (Area_product)i;
                return tag;
            }
        }
        return Area_product.Carros;
    }

    public Area GetAreaByObjectName(string name)
    {
        for (int i = 0; i < areas; i++)
        {
            for (int j = 0; j < objetos_contiene; j++)
            {
                if (name != Objetos[i][j]) continue;
                return transform.GetChild(i).GetComponent<Area>();
            }
        }
        return null;
    }

}
