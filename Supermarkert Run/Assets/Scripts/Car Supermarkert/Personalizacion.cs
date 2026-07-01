using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personalizacion : MonoBehaviour
{
    [SerializeField] TMP_Text Precio;
    [SerializeField] TMP_Text Peso;
    [SerializeField] TMP_Text Velocidad;
    [SerializeField] TMP_Text Carga;
    [SerializeField] TMP_Text Choque;
    [SerializeField] TMP_Text NoMoney;

    [SerializeField] Button BTN_peso;
    [SerializeField] Button BTN_velocidad;
    [SerializeField] Button BTN_carga;
    [SerializeField] Button BTN_choque;
    [SerializeField] Button BTN_agarre;

    private void Start()
    {
        if (false)
        {
            NoMoney.gameObject.SetActive(false);
            BTN_peso.onClick.AddListener(BTNPeso);
            BTN_velocidad.onClick.AddListener(BTNVelocidad);
            BTN_carga.onClick.AddListener(BTNCarga);
            BTN_choque.onClick.AddListener(BTNBlindaje);
            BTN_agarre.onClick.AddListener(BTNAgarre);
        }
    }

    IEnumerator AnimacionNoDinero()
    {
        NoMoney.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        NoMoney.gameObject.SetActive(false);
    }

    void BTNPeso()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioPeso()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.DisminuirPeso();
    }

    void BTNVelocidad()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioVelocidad()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarVelocidad();
    }

    void BTNCarga()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioCapacidad()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarCapacidad();
    }

    void BTNBlindaje()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioBlindaje()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarBlindaje();
    }

    void BTNAgarre()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioAgarre()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarAgarre();
    }
}
