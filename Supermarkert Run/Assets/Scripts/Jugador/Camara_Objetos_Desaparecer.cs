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
                Padre.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertido;
                Padre.GetChild(3).gameObject.SetActive(true);
                objeto = null;
            }
            else
            {
                objeto = laser.collider;
                Padre = objeto.GetComponent<Transform>();
                Padre.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertir;
                Padre.GetChild(3).gameObject.SetActive(false);
            }

        }
    }

    private bool IsID(Collider hit1, Collider hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetInstanceID() == hit2.GetInstanceID();
    }
}
