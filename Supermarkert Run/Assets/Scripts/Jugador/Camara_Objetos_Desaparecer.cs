using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Objetos_Desaparecer : MonoBehaviour
{
    private RaycastHit laser;
    private Ray ray;
    private Collider objeto;
    private Area area = null;
    [SerializeField] private Transform personaje;
    [SerializeField] private float distanciaRayo = 10f;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    private void FixedUpdate()
    {
        Vector3 camaraPos = transform.position;
        Vector3 playerPos = personaje.position;

        Vector3 origen = new Vector3(playerPos.x, playerPos.y + 0.5f, playerPos.z);

        // Forward de la cámara aplanado = dirección real hacia donde mira en horizontal
        Vector3 direction = new Vector3(transform.forward.x, 0f, -transform.forward.z).normalized;

        ray = new Ray(origen, direction);


        if (Physics.Raycast(ray, out laser, distanciaRayo) && laser.collider.CompareTag("Area"))
        {
            Debug.Log("Es un area al que apunta");
            objeto = laser.collider;
            ComportamientoEstante(objeto.GetComponent<Area>());
        }
        else if(Physics.Raycast(ray, out laser, distanciaRayo) && laser.collider.CompareTag("Estante"))
        {
            //Obtener al padre del estante para obtener el id y su area
            Debug.Log("Es un estante al que apunta");
            objeto = laser.collider;
            ComportamientoEstante(objeto.transform.parent.GetComponent<Area>());
        }
        else
        {
            if (area is not null)
            {
                area.VisibilizarEstante();
                area = null;
            }
        }
    }

    private void ComportamientoEstante(Area _area2)
    {
        if(area is not null && !IsID(area, _area2))
        {
            area.VisibilizarEstante();
            _area2.OcultarEstante();
            area = _area2;
        }
        else if(area is null)
        {
            area = _area2;
            area.OcultarEstante();
        }
    }

    [System.Obsolete("Nuevo sistema para detectar areas")]
    private bool IsID(Collider hit1, Collider hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetInstanceID() == hit2.GetInstanceID();
    }

    private bool IsID(Area hit1, Area hit2)
    {
        if (hit1 == null || hit2 == null) return false;
        return hit1.GetInstanceID() == hit2.GetInstanceID();
    }
}