using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;
    [Header("Ajustes de Adaptación a la Cabeza")]
    [SerializeField] Vector3 positionOffset = Vector3.zero; // Desplazamiento local respecto a la cabeza
    [SerializeField] Vector3 rotationOffset = Vector3.zero; // Rotación extra si el sombrero mira hacia otro lado
    [SerializeField] Vector3 customScale = Vector3.one;
    const int NO_ELECCION = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var PCMG = BuildStructs.PCMG;
        int eleccion = PCMG.Get_Eleccion_Sombrero();
        if (eleccion == NO_ELECCION) return;
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
