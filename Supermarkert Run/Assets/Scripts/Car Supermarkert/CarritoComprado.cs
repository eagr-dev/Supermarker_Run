using UnityEngine;

[CreateAssetMenu(fileName = "CarritoComprado", menuName = "Juego/CarritoComprado")]
public class CarritoComprado : ScriptableObject
{
    public uint precio = 250;
    public Pase_Conexion_Menu_Gameplay.Tipo_Carro tipo_Carro = Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO;

    public bool esComprado => precio == 0;
}
