using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mision : MonoBehaviour
{
    private List<string> objects_mision = new List<string>();
    [SerializeField]private int position_Text = 0;
    public TMP_Text Text;
    public TMP_Text Misiones_echas;
    public TMP_Text Espacio_Disponible;
    public GameObject Sin_espacio;
    public GameObject Muerte;
    public Transform caja;
    private string object_act = "";
    Car carro;
    [SerializeField] private AudioSource Obtener_objeto;
    [SerializeField] private ParticleSystem Punto;
    [SerializeField] private Player player;

    void Awake()
    {
        GameObject TMP = GameObject.Find("Mision_Actual");
        if (TMP != null)
            Text = TMP.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ParticleSystem.EmissionModule emission = Punto.emission;
        emission.enabled = false;
        if (objects_mision != null)
        {
            Set_Object(objects_mision);
            New_Text_In_TextMesh();
        }

        //carro = player.Get_Carro(transform);
        carro = player.Get_Carro();
        player.Init(carro);
        Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
    }
    public int Cantidad_Nivel()
    {
        int misiones = (int)(Nivel.nivel / 10);
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
            var emision = Punto.emission;
            emision.enabled = true;
            Obtener_objeto.Play();
            Punto.Play();
            Text.text = objects_mision[position_Text];
            object_act = objects_mision[position_Text];
            position_Text++;
            carro.objetos_actuales++;
            Misiones_echas.text =  Get_Position().ToString() + "/" + Cantidad_Nivel().ToString();
            Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
        }
        else if (obj == object_act && Cantidad_Nivel() == position_Text)
        {
            var emision = Punto.emission;
            emision.enabled = true;
            Obtener_objeto.Play();
            Punto.Play();
            carro.objetos_actuales++;
            position_Text++;
            Text.text = "";
            Misiones_echas.text = "Go to the checkout";
            Espacio_Disponible.text = carro.objetos_actuales.ToString() + "/" + carro.cant_limite_carga.ToString();
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

}
