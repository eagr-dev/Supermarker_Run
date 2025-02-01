using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject UI_PAUSA;
    public void BTN_PAUSA()
    {
        Time.timeScale = 0;
        UI_PAUSA.SetActive(true);
    }

    public void BTN_SIN_PAUSA()
    {
        Time.timeScale = 1;
        UI_PAUSA.SetActive(false);
    }

    public void BTN_REGRESAR()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
