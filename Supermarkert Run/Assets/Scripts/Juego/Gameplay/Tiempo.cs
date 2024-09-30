using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    private const uint tiempo = 11;
    private int minutos, segundos = 60;
    private float contador;
    [SerializeField] private TMP_Text Texto;
    void Start()
    {
        minutos = (int)(tiempo - FindObjectOfType<Nivel>().nivel);
        string minutoss = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
        string segundoss = segundos < 10 ? "0" + segundos.ToString() : segundos.ToString();
        Texto.text = "Tiempo : " + minutoss + " : " + segundoss;
    }

    void Update()
    {
        contador += Time.deltaTime;
        if(contador > 1)
        {
            Contador();
            contador = 0.0f;
        }
    }

    private void Contador()
    {
        string minutoss, segundoss;
        segundos--;
        if(segundos <= 0)
        {
            minutos--;
            segundos = 60;
        }
        minutoss = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
        segundoss = segundos < 10 ? "0" + segundos.ToString() : segundos.ToString();
        Texto.text = "Tiempo : " + minutoss + " : " + segundoss;
    }

    public int Get_Minutos() => minutos;

    public int Get_Segundos() => segundos;
}
