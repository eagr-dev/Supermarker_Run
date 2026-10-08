using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Get_Content_Car : MonoBehaviour
{
    private CarSkinData skin;
    [SerializeField]MeshRenderer r;
    [SerializeField]MeshFilter meshFilter;
    Mesh originalMesh;
    public Pase_Conexion_Menu_Gameplay.Tipo_Carro TC;
    public int posicion = 0;

    public CarSkinData Get_Car_Skin()
    {
        return skin;
    }

    //Este es de CarRuntime
    public void Set_Car(int new_posicion)
    {
        MaterialPropertyBlock propertyBlock = new();
        // Seguridad: Si 'r' es nulo, no podemos aplicar el propertyBlock
        if (r == null) return;

        propertyBlock.Clear();

        posicion = new_posicion;
        skin = BuildStructs.PCMG.GetSkin(posicion);

        // 1. Validamos el mesh primero
        if (skin.mesh != null && skin.mesh.TryGetComponent(out MeshFilter sourceMeshFilter))
        {
            meshFilter.sharedMesh = sourceMeshFilter.sharedMesh;
        }
        else if(originalMesh != null)
        {
            meshFilter.sharedMesh = originalMesh;
        }

        // 2. El truco está aquí: si no hay textura, hay que "limpiar" el propertyBlock
        if (skin.texture != null)
        {
            propertyBlock.SetTexture("_MainTex", skin.texture);
        }

        // 3. Aplicamos el color (si la skin no tiene color, será transparente/negro por defecto del struct)
        propertyBlock.SetColor("_Color", skin.color);

        // 4. Aplicamos los cambios al mesh renderer
        r.SetPropertyBlock(propertyBlock);
    }


    private void Awake()
    {
        originalMesh = meshFilter.sharedMesh;
        posicion = BuildStructs.PCMG.Get_Eleccion();
        Set_Car(posicion);
    }
}
