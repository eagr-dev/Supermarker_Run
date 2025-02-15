using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Objetos_Desaparecer : MonoBehaviour
{
    private RaycastHit laser;
    private Ray ray;
    [SerializeField] private Material materia_Convertido;
    [SerializeField] private Material materia_Convertir;
    [SerializeField] private Camera camara;
    [SerializeField] private Transform Jugador;
    private Collider objeto;
    private Transform Padre;

    private void FixedUpdate()
    {
        Vector3 Laser = (Posicion_Final() - Posicion_Inicial()).normalized;
        ray = new Ray(Posicion_Inicial(), Laser);


        if (Physics.Raycast(ray, out laser) && laser.collider.CompareTag("Estante"))
        {
            Padre = laser.collider.GetComponent<Transform>();
            if(!IsID(laser.collider,objeto))
            {
                OcultarFilas(Padre.parent);
                if(objeto != null)
                    VisibleFilas(objeto.GetComponent<Transform>().parent);
                objeto = laser.collider;
            }
           

        }
    }

    private void OcultarFilas(Transform Padre)
    {
        foreach (Transform hijo in Padre)
        {
            hijo.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertir;
            Material material = hijo.GetChild(1).GetComponent<MeshRenderer>().material;
            Color color = material.color;
            color.a = 0.1f;
            material.color = color;
            hijo.GetChild(1).GetComponent<MeshRenderer>().material = material;
            hijo.GetChild(2).GetComponent<MeshRenderer>().material = material;
            hijo.GetChild(3).GetComponent<MeshRenderer>().material = material;
        }
    }

    private void VisibleFilas(Transform Padre)
    {
        foreach(Transform hijo in Padre)
        {
            hijo.GetChild(0).GetComponent<MeshRenderer>().material = materia_Convertido;
            Material material = hijo.GetChild(1).GetComponent<MeshRenderer>().material;
            Color color = material.color;
            color.a = 1;
            material.color = color;
            hijo.GetChild(1).GetComponent<MeshRenderer>().material = material;
            hijo.GetChild(2).GetComponent<MeshRenderer>().material = material;
            hijo.GetChild(3).GetComponent<MeshRenderer>().material = material;
        }
    }
   
    private bool IsID(Collider hit1, Collider hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetComponent<Transform>().parent.GetInstanceID() == hit2.GetComponent<Transform>().parent.GetInstanceID();
    }

    private Vector3 Posicion_Final()
    {
        Vector3 ubicacion = camara.transform.position;
        ubicacion.y = 1;
        return ubicacion;
    }

    private Vector3 Posicion_Inicial()
    {
        Vector3 ubicacion = Jugador.position;
        ubicacion.y = 1;
        return ubicacion;
    }

}
