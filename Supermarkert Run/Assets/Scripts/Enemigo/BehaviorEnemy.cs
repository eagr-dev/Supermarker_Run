using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorEnemy : MonoBehaviour
{
    // ============================================================
    // COLISIÓN CON EL JUGADOR - Cada enemigo implementa su lógica
    // ============================================================
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Player player = collision.gameObject.GetComponent<Player>();

        if (player.Esta_Protegido()) 
            return;

        OnColisionConJugador(collision);
    }
    protected abstract void OnColisionConJugador(Collision collision);
}
