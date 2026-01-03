using UnityEngine;

public class Estante : MonoBehaviour, IGuardarObjeto
{
    [SerializeField]private string objeto;

    public Areas.Area_product Tag;

    public int count_obj = 0;
    readonly int primer_hijo = 0, ultimo_hijo = 2;

    public void Set_Product(Areas.Area_product tag, int producto, GameObject ObjectCopy)
    {
        objeto = Areas.Objetos[(int)tag][producto];

        Transform fuenteChild = ObjectCopy.transform.GetChild(0);
        MeshFilter mfFuente = fuenteChild.GetComponent<MeshFilter>();
        MeshRenderer mrFuente = fuenteChild.GetComponent<MeshRenderer>();

        if (mfFuente == null || mrFuente == null)
        {
            Debug.LogError("ObjectCopy no tiene MeshFilter o MeshRenderer en su hijo");
            return;
        }

        // Aplicar a los hijos
        for (int i = primer_hijo; i <= ultimo_hijo; i++)
        {
            if (transform.childCount <= i)
            {
                Debug.LogWarning($"No existe hijo en índice {i}");
                break;
            }

            Transform hijo = transform.GetChild(i);
            MeshFilter mfDestino = hijo.GetComponent<MeshFilter>();
            MeshRenderer mrDestino = hijo.GetComponent<MeshRenderer>();

            if (mfDestino == null)
            {
                Debug.LogWarning($"Hijo {i} no tiene MeshFilter");
                continue;
            }

            if (mrDestino == null)
            {
                Debug.LogWarning($"Hijo {i} no tiene MeshRenderer");
                continue;
            }

            // Copiar mesh
            if (mfFuente.sharedMesh != null)
            {
                mfDestino.mesh = Instantiate(mfFuente.sharedMesh);
            }

            // Copiar TODOS los materiales
            if (mrFuente.sharedMaterials != null && mrFuente.sharedMaterials.Length > 0)
            {
                mrDestino.sharedMaterials = mrFuente.sharedMaterials;
            }
        }

        //transform.GetChild(1).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        //transform.GetChild(1).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        //transform.GetChild(1).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        //transform.GetChild(2).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        //transform.GetChild(2).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        //transform.GetChild(2).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        //transform.GetChild(3).GetComponent<MeshFilter>().mesh.vertices = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.vertices;
        //transform.GetChild(3).GetComponent<MeshFilter>().mesh.triangles = ObjectCopy.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.triangles;
        //transform.GetChild(3).GetComponent<MeshRenderer>().material = ObjectCopy.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;

        Tag = tag;

        if(tag == Areas.Area_product.Articulos_Escolares)
        {
            //6.35x -24.77
            transform.GetChild(0).localPosition = new Vector3(18.29f, -0.203f, -73.85f);
            transform.GetChild(1).localPosition = new Vector3(18.29f, 1f, -73.85f);
            transform.GetChild(2).localPosition = new Vector3(18.29f, 2f, -73.85f);
        }
    }

    string IGuardarObjeto.Get_Object() => objeto;
}
