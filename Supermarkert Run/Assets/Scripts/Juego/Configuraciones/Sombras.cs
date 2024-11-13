using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sombras : MonoBehaviour
{
    public List<GameObject> Sombras_Lista;
    private void Awake()
    {
        bool Is_Active = !QualitySettings.shadows.Equals(ShadowQuality.All);
        foreach(GameObject sombra in Sombras_Lista)
        {
            sombra.SetActive(Is_Active);
        }
    }
}
