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
        bool Is_Active = !QualitySettings.shadows.Equals(ShadowQuality.All);

        foreach (GameObject sombra in Sombras_Lista)
        {
            sombra.SetActive(Is_Active || QualitySettings.GetQualityLevel() == 0);
        }
        if (QualitySettings.GetQualityLevel() > 0)
        {

        foreach (var sombra in Sombras_Modelos_Carrito)
        {
            sombra.shadowCastingMode = !Is_Active ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
        }
        Sombras_Modelo_Jugador.shadowCastingMode = !Is_Active ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
        
        }
    }

    public void Verificacion()
    {
        Awake();
    }
}
