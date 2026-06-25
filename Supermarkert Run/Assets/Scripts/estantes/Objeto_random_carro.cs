using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objeto_random_carro : MonoBehaviour, IGuardarObjeto
{
    [SerializeField] private string objeto;
    [SerializeField] private Areas.Area_product area_Product;
    [SerializeField] private GameObject UIRoullete;
    [SerializeField] private Image[] images = new Image[maxImage];
    [SerializeField] private Sprite[] sprites = new Sprite[maxSprite];
    [SerializeField] private float tiempo_animacion = 1;
    [SerializeField] private TMP_Text nombre_objeto;
    [SerializeField]private List<string> objetos = new();
    private readonly int maxObjectContains = 10;
    private int position = 0;
    [SerializeField]List<Areas.Area_product> areas_Product = new();
    const int maxImage = 5, maxSprite = 8;

    public string Get_Object() => objeto;

    // Start is called before the first frame update
    void Start()
    {
        HashSet<string> objetosSet = new();
        while (objetosSet.Count < maxObjectContains)
        {
            int producto = Random.Range(0, Areas._objetos_contiene - 1);
            int area = Random.Range(0, Areas._areas - 1);
            if (Areas.Objetos == null)
            {
                Debug.LogError("Objetos de areas esta en nulo");
                return;
            }
            if(objetosSet.Add(Areas.Objetos[area][producto]))
                areas_Product.Add((Areas.Area_product)area);
        }

        objetos = objetosSet.Distinct().ToList();
        objeto = objetos[position];
        area_Product = areas_Product[position];
    }


    public IEnumerator AnimacionUI()
    {
        UIRoullete.SetActive(true);
        yield return null; // Pequeña espera para asegurar que la UI se ha activado

        // --- Configuración de la Ruleta ---
        int numSteps = 30; // Cantidad fija de "giros" o cambios que hará la ruleta.
        int indexPointer = 2; // Supongamos que la imagen CENTRAL es la que tiene el puntero (índice 2 para 5 imágenes).
        int maxS = sprites.Length; // 7, la cantidad total de sprites.
        int indexTarget = (int)area_Product; // El índice del sprite que debe quedar al final (e.g. Manzana=0, Refri=1, etc.).

        // --- MATEMÁTICAS PARA EL ATERRIZAJE NATURAL ---
        // 1. Calculamos el offset final necesario para que el target sprite quede en el puntero.
        // La fórmula es: offsetFinal = (indexTarget - indexPointer) MOD maxSprites.
        // Esto asegura que la imagen en 'indexPointer' sea: sprites[(offsetFinal + indexPointer) % 7] -> sprites[indexTarget].
        // Usamos esta forma robusta del módulo para manejar resultados negativos.
        int finalOffset = ((indexTarget - indexPointer) % maxS + maxS) % maxS;

        // 2. Calculamos el offset inicial restando numSteps.
        // Esto nos da la posición inicial de "virtual" de la ruleta para que después de numSteps incrementos llegue a finalOffset.
        int currentOffset = ((finalOffset - numSteps) % maxS + maxS) % maxS;


        // --- Configuración de Desaceleración (Curva de frenado) ---
        float totalTime = tiempo_animacion;
        float T_min = 0.005f; // Tiempo inicial muy rápido (sincronizado con Time.deltaTime es buena opción)
                              // Calculamos un T_max para que la suma aproximada de tiempos sea tiempo_animacion, asumiendo una desaceleración lineal.
        float T_max = (2.0f * totalTime / numSteps) - T_min;
        if (T_max < T_min) T_max = T_min; // Seguridad

        float timeAccumulator = 0; // Para llevar la cuenta del tiempo total


        // --- BUCLE DE ANIMACIÓN (Los 'pasos') ---
        for (int step = 0; step < numSteps; step++)
        {
            // 1. Incrementamos el offset de forma circular para simular el giro
            currentOffset = (currentOffset + 1) % maxS;

            // 2. Actualizamos las 5 imágenes basándonos en el offset actual
            // Esto genera la ilusión de que todas las imágenes se mueven "en fila".
            for (int i = 0; i < maxImage; i++)
            {
                images[i].sprite = sprites[(currentOffset + i) % maxS];
            }

            // 3. Calculamos la duración de este paso específico (desaceleración lineal simple)
            float stepDuration = T_min + (float)step * (T_max - T_min) / (float)(numSteps - 1);
            timeAccumulator += stepDuration;

            // Opcional: Para evitar que el tiempo total se exceda, capamos la última espera.
            // float actualWait = stepDuration;
            // if(timeAccumulator > totalTime && step < numSteps - 1) actualWait = Math.Max(0.001f, actualWait - (timeAccumulator - totalTime));

            // Usamos WaitForSeconds para una temporización más predecible que FixedUpdate.
            nombre_objeto.text = objetos[Random.Range(0, maxObjectContains - 1)];
            yield return new WaitForSeconds(stepDuration);
        }

        // --- RESULTADO ---
        // Al salir del bucle después de numSteps pasadas, la lógica garantiza que en 'images[indexPointer]'
        // estará 'sprites[indexTarget]'. ¡Aterrizaje perfecto sin asignaciones extra!
        nombre_objeto.text = objeto;
        yield return new WaitForSeconds(1f);
        UIRoullete.SetActive(false);

        //Asignar nueva posicion
        position++;
        if (position > maxObjectContains) position = 0;
        objeto = objetos[position];
        area_Product = areas_Product[position];
    }

}
