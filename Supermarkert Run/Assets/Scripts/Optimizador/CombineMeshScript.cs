using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMeshScript : MonoBehaviour
{
    [SerializeField] List<Material> materialsToSearch;

    private void Awake()
    {
        CombineMesh();
    }

    void CombineMesh()
    {
        MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
        List<Mesh> meshes = new();
        List<Material> materials = new();

        // NO muevas el transform, usa matrices relativas
        Matrix4x4 parentWorldToLocal = transform.worldToLocalMatrix;

        foreach (Material material in materialsToSearch)
        {
            List<CombineInstance> combineInstances = new();
            foreach (MeshFilter meshFilter in meshFilters)
            {
                Renderer renderer = meshFilter.GetComponent<MeshRenderer>();
                Material[] _materials = renderer.sharedMaterials;

                for (int i = 0; i < _materials.Length; i++)
                {
                    if (_materials[i] != material) continue;
                    if (!materials.Contains(_materials[i]))
                        materials.Add(material);

                    CombineInstance combine = new();
                    combine.mesh = meshFilter.sharedMesh;
                    combine.subMeshIndex = i;
                    // Transforma desde el espacio del hijo al espacio local del padre
                    combine.transform = parentWorldToLocal * meshFilter.transform.localToWorldMatrix;
                    combineInstances.Add(combine);
                }
            }

            if (combineInstances.Count > 0)
            {
                Mesh mesh = new();
                mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
                mesh.CombineMeshes(combineInstances.ToArray(), true);
                meshes.Add(mesh);
            }
        }

        List<CombineInstance> combineFinal = new();
        foreach (Mesh m in meshes)
        {
            CombineInstance c = new();
            c.mesh = m;
            c.subMeshIndex = 0;
            c.transform = Matrix4x4.identity;
            combineFinal.Add(c);
        }

        Mesh meshFinal = new();
        meshFinal.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        meshFinal.CombineMeshes(combineFinal.ToArray(), false);

        transform.GetComponent<MeshFilter>().sharedMesh = meshFinal;
        transform.GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}