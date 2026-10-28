using System.Collections;
using UnityEngine;

public interface IBackgroundAnimation
{
    bool ShouldRun();       // Valida si la animación debe ejecutarse (ej. lógica de 1 vez al día)
    void Initialize();      // Prepara el estado inicial (o carga posición final si ya pasó)
    IEnumerator PlayAnimation(); // La corrutina con la lógica visual de la animación
    void DesactivarRegaloEnRuntime();
}