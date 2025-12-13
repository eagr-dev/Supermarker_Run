using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoComun : IA
{
    protected override bool DebePuedeIrACaja()
    {
        return true; // El enemigo común SÍ puede ir a cajas
    }

    protected override void OnColisionConJugador(Collision collision)
    {
        Mision mision = collision.gameObject.GetComponent<Mision>();
        // Colisión simple: como chocar con cualquier persona
        mision.Eliminar_Al_Chocar();
        // Calcular dirección del empuje (enemigo se aleja del jugador)
        Vector3 direccionEmpuje = (transform.position - collision.transform.position).normalized;
        AplicarEmpuje(direccionEmpuje, 2f);

        // Después del choque, esperar y moverse a otro lugar
        StartCoroutine(EsperarYMoverse(0.5f, 2f, true));
    }
}
