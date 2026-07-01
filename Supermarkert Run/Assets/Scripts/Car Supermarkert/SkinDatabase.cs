using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CarSkinData
{
    public string nombre_ingles, nombre_espaniol, nombre_portugues;
    public Texture2D texture;
    public Color color;
    public uint precio;
    public MeshRenderer mesh;
}

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Juego/Skin Database")]
public class SkinDatabase : ScriptableObject
{
    public List<CarSkinData> skins;

    public CarSkinData GetSkin(int index) 
    {
        if (index >= skins.Count) throw  new System.ArgumentOutOfRangeException($"El indice es mas grande que la lista");
        return skins[index]; 
    }
}
