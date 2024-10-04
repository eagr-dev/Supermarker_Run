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

            SceneManager.LoadScene(0);
        }

    }

    public override void Set_Descripcion_Nombre()
    {
        descripcion = "Vida Extra, solamente reinicia el nivel evitando regresar al menu tienes una vida extra para seguir jugando.\nEste power Up se activa viendo un anuncio.";
        nombre = "Vidas Extras";
    }

    public override object Get_Efecto() => vidas;

    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
        else
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
    }
}
