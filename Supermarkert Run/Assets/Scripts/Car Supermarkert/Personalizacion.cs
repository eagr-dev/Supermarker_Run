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
        carro = SMC.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
        carro.skin_car.color = new Color(rojo, verde, azul, alfa);

        carro.peso = ((int)(rojo * carro.peso_maximo) % 100);
        carro.velocidad_adicional = ((int)(verde * carro.velocidad_maxima) % 100);
        carro.cant_limite_carga = (int)((int)(azul * carro.maximo_a_cargar) % 100);
        carro.resistencia_choque = ((int)(alfa * carro.maxima_resistencia) % 100);

        carro.precio = (uint)((rojo + verde + azul + alfa) * Max);


        Precio.text = "Precio: " + carro.precio.ToString() + ".";
        Peso.text = "Peso: " + carro.peso.ToString() + "Kg.";
        Velocidad.text = "Velocidad: " + carro.velocidad_adicional.ToString() + ".";
        Carga.text = "Carga: " + carro.cant_limite_carga.ToString() + "Kg.";
        Choque.text = "Choque Maximo: " + carro.resistencia_choque.ToString() + "%";
    }

    public void Guardado()
    {
        carro = SMC.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
        Grojo = carro.skin_car.color.r;
        Gazul = carro.skin_car.color.b;
        Gverde = carro.skin_car.color.g;
        Galfa = carro.skin_car.color.a;
    }

    //Solucionar error de al salir con skin personalizada retornar al guardada
    public void Restar()
    {
        carro = SMC.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
        rojo = Grojo;
        verde = Gverde;
        azul = Gazul;
        alfa = Galfa;

        carro.peso = ((int)(rojo * carro.peso_maximo) % 100);
        carro.velocidad_adicional = ((int)(verde * carro.velocidad_maxima) % 100);
        carro.cant_limite_carga = (int)((int)(azul * carro.maximo_a_cargar) % 100);
        carro.resistencia_choque = ((int)(alfa * carro.maxima_resistencia) % 100);

        carro.skin_car.color = new Color(rojo, verde, azul, alfa);
        carro.precio = 0;
        
    }
    
    public float[] Get_RGB()
    {
        float[] retorno = { rojo, verde, azul, alfa };
        return retorno;
    }

}
