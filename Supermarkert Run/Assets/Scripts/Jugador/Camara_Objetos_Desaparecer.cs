using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Objetos_Desaparecer : MonoBehaviour
{
    private RaycastHit laser;
    private Ray ray;
    [SerializeField] private Material materia_Convertido;
    [SerializeField] private Material materia_Convertir;
    private Collider objeto;
    private Vector3 centro;
    private Transform Padre;
    private bool Is_Fila = false;
    // Start is called before the first frame update
    void Start()
    {
        centro = new Vector3(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ray = GetComponent<Camera>().ScreenPointToRay(centro);

        if (Physics.Raycast(ray, out laser) && laser.collider.CompareTag("Estante"))
        {
            
            if (objeto != null && !IsID(laser.collider, objeto))
            {
                Padre = objeto.GetComponent<Transform>();
                if (!Is_Fila)
                {
                    Padre.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertido;
                    Padre.GetChild(3).gameObject.SetActive(true);
                    Padre.GetChild(2).gameObject.SetActive(true);
                    Padre.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    VisibleFilas(Padre.parent);
                }
                objeto = null;
            }
            else
            {
                objeto = laser.collider;
                if (!Is_Not_Fila_0(Padre.parent.rotation))
                {
                    Padre.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertir;
                    Padre.GetChild(3).gameObject.SetActive(false);
                    Padre.GetChild(2).gameObject.SetActive(false);
                    Padre.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    OcultarFilas(Padre.parent);
                }
            }

        }
    }

    private void OcultarFilas(Transform Padre)
    {
        Is_Fila = true;
        foreach(Transform hijo in Padre)
        {
            hijo.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertir;
            hijo.GetChild(3).gameObject.SetActive(false);
            hijo.GetChild(2).gameObject.SetActive(false);
            hijo.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void VisibleFilas(Transform Padre)
    {
        Is_Fila = false;
        foreach (Transform hijo in Padre)
        {
            hijo.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertido;
            hijo.GetChild(3).gameObject.SetActive(true);
            hijo.GetChild(2).gameObject.SetActive(true);
            hijo.GetChild(1).gameObject.SetActive(true);
        }
    }

    private bool Is_Not_Fila_0(Quaternion rotacion_fila)
    {
        return (rotacion_fila == new Quaternion(0, 1, 0, 0) || rotacion_fila == new Quaternion(0, 0, 0, 1));
    }

    private bool IsID(Collider hit1, Collider hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetInstanceID() == hit2.GetInstanceID();
    }
}
