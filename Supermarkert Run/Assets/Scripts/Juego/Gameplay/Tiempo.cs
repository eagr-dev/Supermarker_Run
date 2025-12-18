using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    private const uint tiempo = 5;
    private int minutos, segundos = 0;
    private float contador;
    [SerializeField] private TMP_Text Texto;
    [SerializeField] private GameObject Perdiste;
    private bool perdio = false;
    public bool gano = false;
    [SerializeField] private Player jugador;
    void Start()
    {
        minutos = (int)tiempo;//(int)(tiempo - Resta());
        AsignarTiempoUI();
    }

    void Update()
    {
        Actualizacion();
    }

    /*private uint Resta()
    {
        uint nivel = Nivel.nivel;
        uint resultado = (nivel / 100);
        return resultado;
    }*/

    void AsignarTiempoUI()
    {
        string minutoss = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
        string segundoss = segundos < 10 ? "0" + segundos.ToString() : segundos.ToString();
        Texto.text = minutoss + " : " + segundoss;
    }

    private void Actualizacion()
    {
        contador += Time.deltaTime;
        if (contador > 1)
        {
            Contador();
            contador = 0.0f;
        }
    }

    private void Contador()
    {
        if (perdio || gano) return;

        if (segundos <= 0)
        {
            minutos--;
            segundos = 60;
        }
        segundos--;
        AsignarTiempoUI();
        if (minutos <= 0 && segundos <= 0)
        {
            jugador.SetDeadZoneJoystick(1000);
            perdio = true;
            Perdiste.GetComponent<Transform>().GetChild(2).gameObject.SetActive(true);
            Perdiste.SetActive(true);
        }
    }

    public int Get_Minutos() => minutos;

    public int Get_Segundos() => segundos;
}
