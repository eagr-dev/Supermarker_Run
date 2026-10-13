using UnityEngine;

public class HatVisualCopierEnemy : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;
    [Header("Ajustes de Adaptación a la Cabeza")]
    [SerializeField] Vector3 positionOffset = Vector3.zero; // Desplazamiento local respecto a la cabeza
    [SerializeField] Vector3 rotationOffset = Vector3.zero; // Rotación extra si el sombrero mira hacia otro lado
    [SerializeField] Vector3 customScale = Vector3.one;
    const int NO_ELECCION = 33;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sombreroOrNot = Random.Range(0, 100);
        if (sombreroOrNot > NO_ELECCION) return;

        var PCMG = BuildStructs.PCMG;
        int eleccion = Random.Range(0, BuildStructs.PCMG.GetCountSombreros() - 1);
        var data = PCMG.GetSombrero(eleccion);

        MeshFilter sourceFilter = data.mesh.GetComponent<MeshFilter>();
        meshFilter.sharedMesh = sourceFilter.sharedMesh;
        meshRenderer.material = data.material;
        Transform sourceTransform = data.mesh.transform;
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        transform.localScale = customScale != Vector3.zero ? customScale : sourceTransform.localScale;
    }
}
