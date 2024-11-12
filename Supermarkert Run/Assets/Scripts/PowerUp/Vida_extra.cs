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
        descripcion = "Just restart the level without returning to the menu, you have an extra life to continue playing.";
        nombre = "Extra Lives";
    }

    public override object Get_Efecto() => vidas;

    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
        {
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x,0, GetComponent<Transform>().localPosition.z);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, -0.72f, GetComponent<Transform>().localPosition.z);
        }
        
    }
}
