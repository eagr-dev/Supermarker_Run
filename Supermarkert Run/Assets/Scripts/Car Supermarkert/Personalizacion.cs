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
    [SerializeField] List<Car> carritos_personalizados;

    private void Start()
    {
        SMC = BuildStructs.SelCarro;
        StartCoroutine(EsperarCarroActivo());
    }

    private IEnumerator EsperarCarroActivo()
    {
        Get_Content_Car gcc = null;

        while (gcc == null)
        {
            var obj = SMC.Get_Active();
            if (obj != null)
                gcc = obj.GetComponent<Get_Content_Car>();

            yield return null; // espera un frame e intenta de nuevo
        }

        carro = gcc.Get_Car();
        foreach (Car carro in carritos_personalizados)
        {
            carro.peso = carro.skin_car.color.r * carro.peso_maximo;
            carro.velocidad_adicional = carro.skin_car.color.g * carro.velocidad_maxima;
            carro.cant_limite_carga = (int)carro.skin_car.color.b * carro.maximo_a_cargar;
            carro.resistencia_choque = (int)carro.skin_car.color.a * carro.maxima_resistencia;
        }

        Precio.text = carro.precio.ToString() + ".";
        Peso.text = carro.peso.ToString() + "Kg.";
        Velocidad.text = carro.velocidad_adicional.ToString() + ".";
        Carga.text = carro.cant_limite_carga.ToString() + "Kg.";
        Choque.text = carro.resistencia_choque.ToString() + "%";
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


        Precio.text = carro.precio.ToString();
        Peso.text = carro.peso.ToString() + "Kg.";
        Velocidad.text = carro.velocidad_adicional.ToString() + ".";
        Carga.text = carro.cant_limite_carga.ToString() + "Kg.";
        Choque.text = carro.resistencia_choque.ToString() + "%";
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
