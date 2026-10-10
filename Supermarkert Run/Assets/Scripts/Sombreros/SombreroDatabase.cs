using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public struct SombreroData
{
    public int id;
    public string nombre_ingles, nombre_espaniol, nombre_portugues;
    public Material material;
    public uint precio;
    public MeshRenderer mesh;
    public Sprite icon;
}

[CreateAssetMenu(fileName = "SombreroDatabase", menuName = "Scriptable Objects/SombreroDatabase")]
public class SombreroDatabase : ScriptableObject
{
    public List<SombreroData> sombreros;

    public SombreroData GetSombrero(int index)
    {
        if (index >= sombreros.Count) throw new System.ArgumentOutOfRangeException($"El indice es mas grande que la lista");
        return sombreros[index];
    }

    public List<SombreroData> GetComprados()
    {
        List<SombreroData> r = new();
        for(int i = 0; i < sombreros.Count; i++)
        {
            if (sombreros[i].precio == 0)
                r.Add(sombreros[i]);
        }
        return r;
    }

    public void SetComprar(int id)
    {
        SombreroData s = sombreros[id];
        s.precio = 0;
        sombreros[id] = s;
    }

}
