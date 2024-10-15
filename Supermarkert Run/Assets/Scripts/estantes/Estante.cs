using UnityEngine;

public class Estante : MonoBehaviour
{
    [SerializeField]private string objeto;

    public Areas.Area_product Tag;

    public int count_obj = 0;

    public void Set_Product(Areas.Area_product tag, int producto, GameObject ObjectCopy)
    {
        objeto = Areas.Objetos[(int)tag][producto];
        transform.GetChild(1).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(1).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(1).GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));

        transform.GetChild(2).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(2).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(2).GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));

        transform.GetChild(3).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(3).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(3).GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));

        Tag = tag;
    }

    public string Get_Object() => objeto;
}
