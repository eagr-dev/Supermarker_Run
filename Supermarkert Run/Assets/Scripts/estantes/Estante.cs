using UnityEngine;

public class Estante : MonoBehaviour, IGuardarObjeto
{
    [SerializeField]private string objeto;

    public Areas.Area_product Tag;

    public int count_obj = 0;

    public void Set_Product(Areas.Area_product tag, int producto, GameObject ObjectCopy)
    {
        objeto = Areas.Objetos[(int)tag][producto];
        transform.GetChild(1).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(1).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(1).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        transform.GetChild(2).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(2).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(2).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        transform.GetChild(3).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        transform.GetChild(3).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        transform.GetChild(3).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        Tag = tag;

        if(tag == Areas.Area_product.Articulos_Escolares)
        {
            //6.35x -24.77
            transform.GetChild(1).localPosition = new Vector3(18.29f, -0.203f, -73.85f);
            transform.GetChild(2).localPosition = new Vector3(18.29f, 1f, -73.85f);
            transform.GetChild(3).localPosition = new Vector3(18.29f, 2f, -73.85f);
        }
    }

    string IGuardarObjeto.Get_Object() => objeto;
}
