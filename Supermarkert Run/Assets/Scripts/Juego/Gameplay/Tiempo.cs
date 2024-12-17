using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    private const uint tiempo = 10;
    private int minutos, segundos = 0;
    private float contador;
    [SerializeField] private TMP_Text Texto;
    public GameObject Muerte;
    void Start()
    {
        if(Nivel.nivel < 1000)
        {
            minutos = (int)(tiempo - Resta());
            string minutoss = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
            string segundoss = segundos < 10 ? "0" + segundos.ToString() : segundos.ToString();
            Texto.text = minutoss + " : " + segundoss;
        }
    }

    void Update()
    {
        Actualizacion();
    }

    private uint Resta()
    {
        uint nivel = Nivel.nivel;
        uint resultado = (nivel / 100);
        return resultado;
    }
    private void Actualizacion()
    {
        if (Nivel.nivel < 1000)
        {
            contador += Time.deltaTime;
            if (contador > 1)
            {
                Contador();
                contador = 0.0f;
            }
        }
    }

    private void Contador()
    {
        string minutoss, segundoss;
        if (segundos <= 0)
        {
            minutos--;
            segundos = 60;
        }
        segundos--;
        minutoss = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
        segundoss = segundos < 10 ? "0" + segundos.ToString() : segundos.ToString();
        Texto.text = minutoss + " : " + segundoss;
        if (minutos <= 0 && segundos <= 0)
        {
            Muerte.GetComponent<Transform>().GetChild(2).gameObject.SetActive(true);
            Muerte.SetActive(true);
        }
    }

    public int Get_Minutos() => minutos;

    public int Get_Segundos() => segundos;
}
