using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida_extra : Interfaz_PowerUp
{
    private int vidas = 2;
    public override void Efecto(params object[] parametros)
    {
        if(vidas != 0)
        {
            vidas--;
        }
        else
        {
            //Al menu
            Debug.Log("muerto");
        }

    }

    public override void Set_Descripcion_Nombre()
    {
        descripcion.Add("Vida Extra, solamente reinicia el nivel evitando regresar al menu");
        descripcion.Add("Tienes una vida extra para seguir jugando.");
        descripcion.Add("Este power Up se activa viendo un anuncio.");
        nombre = "Vidas Extras";
    }

    public override object Get_Efecto() => vidas;
}
