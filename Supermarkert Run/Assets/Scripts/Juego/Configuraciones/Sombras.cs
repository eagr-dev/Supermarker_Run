using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sombras : MonoBehaviour
{
    public List<GameObject> Sombras_Lista;
    public List<MeshRenderer> Sombras_Modelos_Carrito;
    public SkinnedMeshRenderer Sombras_Modelo_Jugador;
    private void Awake()
    {
        foreach (GameObject sombra in Sombras_Lista)
        {
            sombra.SetActive(true);
        }
    }

    public void Verificacion()
    {
        Awake();
    }
}
