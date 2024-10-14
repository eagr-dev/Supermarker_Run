using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Personalizacion : MonoBehaviour
{
    private float rojo, verde, azul, alfa;
    private float Grojo, Gverde, Gazul, Galfa;
    private const float Max = 255;
    [SerializeField] TMP_Text Precio;
    [SerializeField] TMP_Text Peso;
    [SerializeField] TMP_Text Velocidad;
    [SerializeField] TMP_Text Carga;
    [SerializeField] TMP_Text Choque;
    private Seleccion_Menu_Carrito SMC;
    private Car carro;

    private void Awake()
    {
        SMC = FindObjectOfType<Seleccion_Menu_Carrito>();
    }

    private void Start()
    {
        carro = SMC.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
    }
    public void Rojo(float valor) 
    {
        rojo = valor;
        Calculo();
    }
    public void Verde(float valor) 
    {
        verde = valor;
        Calculo();
    }
    public void Azul(float valor) 
    {
        azul = valor;
        Calculo();
    }
    public void Alfa(float valor) 
    {
        alfa = valor;
        Calculo();
    }
    private void Calculo()
    {
        carro.skin_car.color = new Color(rojo, verde, azul, alfa);

        carro.peso = ((int)(rojo / 100) * carro.peso_maximo);
        carro.velocidad_adicional = ((int)(verde / 100) * carro.velocidad_maxima);
        carro.cant_limite_carga = (int)((int)(azul / 100) * carro.maximo_a_cargar);
        carro.resistencia_choque = ((int)(alfa / 100) * carro.maxima_resistencia);

        carro.precio = (uint)((rojo + verde + azul + alfa) * Max);


        Precio.text = "Precio: " + carro.precio.ToString() + ".";
        Peso.text = "Peso: " + carro.peso.ToString() + "Kg.";
        Velocidad.text = "Velocidad: " + carro.velocidad_adicional.ToString() + ".";
        Carga.text = "Carga: " + carro.cant_limite_carga.ToString() + "Kg.";
        Choque.text = "Choque Maximo: " + carro.resistencia_choque.ToString() + "%";
    }

    public void Guardado()
    {
        Grojo = rojo;
        Gazul = azul;
        Gverde = verde;
        Galfa = alfa;
    }

    public void Restar()
    {
        rojo = Grojo;
        verde = Gverde;
        azul = Gazul;
        alfa = Galfa;
        carro.skin_car.color = new Color(rojo, verde, azul, alfa);
    }

}
