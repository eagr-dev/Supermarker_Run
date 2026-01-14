using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMeshScript : MonoBehaviour
{
    [SerializeField] List<Material> materialsToSearch;
    [SerializeField] bool destroyChildrenAfterCombine = true;

    private void Awake()
    {
        CombineMesh();
    }

    // Copia rápida manual de mesh sin Instantiate
    Mesh CopyMesh(Mesh source)
    {
        Mesh copy = new Mesh();
        copy.vertices = source.vertices;
        copy.normals = source.normals;
        copy.tangents = source.tangents;
        copy.uv = source.uv;
        copy.uv2 = source.uv2;
        copy.colors = source.colors;
        copy.boneWeights = source.boneWeights;
        copy.bindposes = source.bindposes;

        copy.subMeshCount = source.subMeshCount;
        for (int i = 0; i < source.subMeshCount; i++)
        {
            copy.SetTriangles(source.GetTriangles(i), i);
        }

        copy.RecalculateBounds();
        return copy;
    }

    void CombineMesh()
    {
        MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
        List<CombineInstance> finalCombineList = new();
        List<Material> finalMaterials = new();
        Matrix4x4 parentWorldToLocal = transform.worldToLocalMatrix;

        foreach (Material material in materialsToSearch)
        {
            List<CombineInstance> combineInstances = new();

            foreach (MeshFilter meshFilter in meshFilters)
            {
                if (meshFilter.transform == transform) continue;

                Renderer renderer = meshFilter.GetComponent<MeshRenderer>();
                if (renderer == null || !renderer.enabled) continue;

                Mesh sourceMesh = meshFilter.sharedMesh;
                if (sourceMesh == null) continue;

                Material[] meshMaterials = renderer.sharedMaterials;

                for (int i = 0; i < meshMaterials.Length && i < sourceMesh.subMeshCount; i++)
                {
                    if (meshMaterials[i] == material)
                    {
                        // Copia manual rápida
                        Mesh meshCopy = CopyMesh(sourceMesh);

                        CombineInstance combine = new();
                        combine.mesh = meshCopy;
                        combine.subMeshIndex = i;
                        combine.transform = parentWorldToLocal * meshFilter.transform.localToWorldMatrix;
                        combineInstances.Add(combine);
                    }
                }
            }

            if (combineInstances.Count > 0)
            {
                Mesh combinedForMaterial = new Mesh();
                combinedForMaterial.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
                combinedForMaterial.CombineMeshes(combineInstances.ToArray(), true, true);

                CombineInstance finalCombine = new();
                finalCombine.mesh = combinedForMaterial;
                finalCombine.subMeshIndex = 0;
                finalCombine.transform = Matrix4x4.identity;
                finalCombineList.Add(finalCombine);

                finalMaterials.Add(material);
            }
        }

        if (finalCombineList.Count == 0)
        {
            Debug.LogWarning("No se encontraron meshes para combinar.");
            return;
        }

        Mesh finalMesh = new Mesh();
        finalMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        finalMesh.CombineMeshes(finalCombineList.ToArray(), false, false);
        finalMesh.RecalculateBounds();

        GetComponent<MeshFilter>().sharedMesh = finalMesh;
        GetComponent<MeshRenderer>().sharedMaterials = finalMaterials.ToArray();

        if (destroyChildrenAfterCombine)
        {
            List<GameObject> toDestroy = new();
            foreach (Transform child in transform)
            {
                toDestroy.Add(child.gameObject);
            }
            foreach (GameObject child in toDestroy)
            {
                Destroy(child);
            }
        }

        Debug.Log($"Combinados: {finalMaterials.Count} materiales, {finalMesh.vertexCount} vértices");
    }
}