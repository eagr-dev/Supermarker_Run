using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mision : MonoBehaviour
{
    private List<string> objects_mision = new List<string>();
    private int columna_act = 0;
    [SerializeField]private int position_Text = 0;
    //List<List<Transform>> posicionesMision;
    //List<Transform> posicion_mas_cercana = new List<Transform>();
    List<Transform> posicionesMision = new List<Transform>();
    Transform posicion_mas_cercana;
    public TMP_Text Text;
    public TMP_Text Misiones_echas;
    public TMP_Text Espacio_Disponible;
    public GameObject Sin_espacio;
    public GameObject Muerte;
    private string object_act = "", mision_ant = "";
    Car carro;
    [SerializeField] GameObject Flecha;

    void Awake()
    {
        GameObject TMP = GameObject.Find("Mision_Actual");
        if (TMP != null)
            Text = TMP.GetComponent<TMP_Text>();
        if (objects_mision != null)
        {
            Set_Object(objects_mision);
            New_Text_In_TextMesh();
        }
    }

    private void Start()
    {
        carro = FindObjectOfType<Get_Content_Car>().Get_Car();
        Espacio_Disponible.text = "Available Space: " + carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        //posicionesMision = Positions_Misions();
        Positions_Misions();
    }

    private void Update()
    {
        Next_Position();
        Direccion_Apuntar();
    }

    public int Cantidad_Nivel()
    {
        int misiones = (int)(FindObjectOfType<Nivel>().nivel / 10);
        misiones = misiones != 0 ? misiones : 10;
        return misiones;
    }

    private void Set_Object(List<string> obj_m)
    {
        int i = 0;
        while (obj_m.Count < Cantidad_Nivel())
        {
            int area = Random.Range(0,7);
            string obj = Areas.Objetos[area][Random.Range(0, 9)];
            if (!Is_Repeat_Object(obj))
            {
                obj_m.Add(obj);
                i++;
            }
            if (i >= Cantidad_Nivel()) return;
        }
    }

    private bool Is_Repeat_Object(string obj_compare)
    {
        foreach(string obj in objects_mision)
        {
            if (obj == obj_compare)
                return true;
        }
        return false;
    }

    public void New_Text_In_TextMesh(string obj)
    {
        if ((position_Text < Cantidad_Nivel() && obj == object_act) && carro.objetos_actuales <= carro.cant_limite_carga)
        {
            Text.text = objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
            carro.objetos_actuales++;
            Misiones_echas.text = Get_Position().ToString() + "/" + Cantidad_Nivel().ToString();
            Espacio_Disponible.text = "Available Space: " + carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        }
        else if (obj == object_act && Cantidad_Nivel() == position_Text)
        {
            carro.objetos_actuales++;
            position_Text++;
            Text.text = "";
            Misiones_echas.text = "Go to the checkout";
            Espacio_Disponible.text = "Available Space: " + carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        }

        else if (carro.objetos_actuales > carro.cant_limite_carga)
            StartCoroutine(Tiempo_Aparicion());


    }

    private IEnumerator Tiempo_Aparicion()
    {
        Sin_espacio.SetActive(true);
        yield return new WaitForSeconds(1);
        carro.objetos_actuales = 0;
        Sin_espacio.SetActive(false);
        Muerte.SetActive(true);

    }

    private void New_Text_In_TextMesh()
    {
        if(objects_mision != null && Text != null)
        {
            Text.text = objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
            Misiones_echas.text = Get_Position().ToString() + "/" + Cantidad_Nivel().ToString();
        }
    }

    public int Get_Position() => position_Text - 1;

    void Positions_Misions()
    {
        Estante[] estantes = FindObjectsOfType<Estante>();
        int mision_next = 0;
        Debug.Log(objects_mision.Count);
        for(int i = 0;i < estantes.Length;i++)
        {
            for(int j = 0; j < Cantidad_Nivel() - 1; j++)
            {
                
                if(objects_mision[i] == objects_mision[mision_next])
                {
                    Debug.Log(mision_next + 1);
                    posicionesMision.Add(estantes[i].GetComponent<Transform>());
                    mision_next++;
                }
            }
        }

        for (int i = 0; i < posicionesMision.Count; i++) Debug.Log(posicionesMision[i].position);
    }

    void Next_Position()
    {
        if(mision_ant != objects_mision[position_Text])
        {
            Debug.Log(columna_act);
            posicion_mas_cercana = posicionesMision[columna_act];
            columna_act++;
            mision_ant = objects_mision[position_Text];
            Debug.Log(posicion_mas_cercana.position);
            Debug.Log(mision_ant);
        }
    }
    void Direccion_Apuntar()
    {
        Vector3 direccion = transform.position - posicion_mas_cercana.position;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        Flecha.transform.rotation = Quaternion.Slerp(Flecha.transform.rotation, rotacion, 20 * Time.deltaTime);
        Flecha.transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
    }

    /*
        private List<List<Transform>> Positions_Misions()
        {
            // Usamos una lista de listas para las posiciones de las misiones
            List<List<Transform>> posicionesMision = new List<List<Transform>>();
            Estante[] estantes = FindObjectsOfType<Estante>();
            int mision_next = 0;

            // Inicializa las listas para cada nivel
            for (int i = 0; i < Cantidad_Nivel(); i++)
            {
                posicionesMision.Add(new List<Transform>());
            }

            // Recorremos los estantes
            foreach (var estante in estantes)
            {
                if (mision_next >= objects_mision.Count) break; // Si no hay más misiones, salimos

                // Si el objeto del estante coincide con el objeto de misión actual
                if (estante.Get_Object() == objects_mision[mision_next])
                {
                    int nivelActual = mision_next / 7; // Determina el nivel basado en el índice
                    if (nivelActual < Cantidad_Nivel())
                    {
                        posicionesMision[nivelActual].Add(estante.gameObject.GetComponent<Transform>());
                        //Debug.Log($"Misión {mision_next} asignada a nivel {nivelActual}: {estante.gameObject.transform.position}");
                        mision_next++;
                    }
                }
            }

            return posicionesMision;
        }

    */


    /*private void Positions_Misions()
    {
        Estante[] estantes = FindObjectsOfType<Estante>();
        int mision_next = 0;

        for(int i = 0; i < estantes.Length;i++)
        {
            for(int j = 0; j < Cantidad_Nivel(); j++)
            {
                if(estantes[i].Get_Object() == objects_mision[mision_next])
                {
                    posicionesMision.Add(estantes[i].gameObject.GetComponent<Transform>());
                }
            }
        }


    }*/


    /*private void Next_Position()
    {
        if (objects_mision[position_Text] != mision_ant)
        {
            if (posicion_mas_cercana.Count > 0)
            {
                posicion_mas_cercana.Clear();
                columna_act++;
                Debug.Log("Limpiar");
            }
            
            Debug.Log(posicionesMision[columna_act].Count);
            Debug.Log(columna_act);

            for (int i = 0; i < posicionesMision[columna_act].Count; i++)
            {
                posicion_mas_cercana.Add(posicionesMision[columna_act][i]);
            }

            mision_ant = objects_mision[position_Text];
            columna_act++;
            Debug.Log("Nuevas asignaciones");
        }
        
    }

    private Vector3 Minima_Distancia()
    {
        Vector3 minimo = new Vector3(0,0,0);
        float minimo_magnitude = 999;
        for(int i = 0; i < posicion_mas_cercana.Count; i++)
        {
            if(posicion_mas_cercana[i].position != null)
                if(posicion_mas_cercana[i].position.magnitude < minimo_magnitude)
                {
                    minimo_magnitude = posicion_mas_cercana[i].position.magnitude;
                    minimo = posicion_mas_cercana[i].position;
                }
        }

        if(minimo == null)
        {
            Debug.Log("es null");
            posicionesMision = Positions_Misions();
            Next_Position();
            for (int i = 0; i < Positions_Misions().Count; i++)
                for (int j = 0; j < Positions_Misions()[i].Count; j++)
                    Debug.Log(Positions_Misions()[i][j].position);

            if (minimo == null)
                Debug.Log("Es null en posicion");
                
        }
        /*if (minimo.position == null)
            Flecha.gameObject.SetActive(false);*/

    /*   return minimo;
   }

   private void Direccion_Apuntar()
   {
       Vector3 direccion = Minima_Distancia() - camara.transform.position;
       Vector3 proyeccion = new Vector3(direccion.x, direccion.y, 0);
       float angulo = Mathf.Atan2(proyeccion.y, proyeccion.x) * Mathf.Rad2Deg;
       Flecha.rotation = Quaternion.Euler(0, 0, angulo);

   }*/

}
