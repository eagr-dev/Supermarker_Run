using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Objetos_Desaparecer : MonoBehaviour
{
    private RaycastHit laser;
    private Ray ray;
    private Collider objeto;
    private Area area;
    [SerializeField] private Transform personaje;

    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 origin = transform.position; 
        Vector3 direction = (personaje.position - origin).normalized;
        ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out laser) && laser.collider.CompareTag("Area"))
        {
            
            if (objeto is not null && !IsID(laser.collider, objeto))
            {
                area = objeto.GetComponent<Area>();
                area.VisibilizarEstante();
                objeto = null;
            }
            else
            {
                objeto = laser.collider;
                area = objeto.GetComponent<Area>();
                area.OcultarEstante();
            }

        }
        else if(objeto is not null)
        {
            area = objeto.GetComponent<Area>();
            area.VisibilizarEstante();
            objeto = null;
        }
    }

    private bool IsID(Collider hit1, Collider hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetInstanceID() == hit2.GetInstanceID();
    }
}
