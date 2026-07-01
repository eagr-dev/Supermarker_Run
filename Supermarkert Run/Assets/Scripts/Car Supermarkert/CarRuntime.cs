using UnityEngine;

public class CarRuntime : MonoBehaviour
{
    [Header("Variables de la Partida Actual")]
    public int objetos_actuales = 0;

    [Header("Referencia al DTO de Datos (ScriptableObject)")]
    [SerializeField] private OrquestadorAumentadorNivelCarro datosCarro;

    //En caso de olvidar colocarle un Orquestador
    public void Inicializar(OrquestadorAumentadorNivelCarro orquestadorOrigen)
    {
        datosCarro = orquestadorOrigen;
        objetos_actuales = 0; // Reseteamos el carrito para la nueva partida
    }

    public int Capacidad => datosCarro != null ? datosCarro.StatsActuales.capacidad : 0;

    // Mapea 'peso'
    public float Peso => datosCarro != null ? datosCarro.StatsActuales.peso : 0f;

    // Mapea 'velocidad_adicional' a 'velocidad'
    public float VelocidadAdicional => datosCarro != null ? datosCarro.StatsActuales.velocidad : 0f;

    // Mapea 'resistencia_choque' a 'blindaje'
    public int Blindaje => datosCarro != null ? datosCarro.StatsActuales.blindaje : 0;

    // Agarre por si tus físicas lo necesitan en Player.cs
    public float Agarre => datosCarro != null ? datosCarro.StatsActuales.agarre : 0f;
}
