using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject UI_MAIN;
    [SerializeField] GameObject UI_PAUSA;
    [SerializeField] GameObject UI_MISIONES;
    [SerializeField] AudioSource my_audio;
    Anuncios anuncios;

    private void Start()
    {
        anuncios = FindFirstObjectByType<Anuncios>();
    }

    public void BTN_PAUSA()
    {
        my_audio.Play();
        Time.timeScale = 0;
        UI_PAUSA.SetActive(true);
        UI_MAIN.SetActive(false);
    }

    public void BTN_SIN_PAUSA()
    {
        my_audio.Play();
        Time.timeScale = 1;
        UI_PAUSA.SetActive(false);
        UI_MAIN.SetActive(true);
    }

    public void BTN_REGRESAR()
    {
        anuncios.MostrarAnuncioIntersticial(() =>
        {
            my_audio.Play();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });
    }

    public void BTN_Misiones()
    {
        Time.timeScale = 0;
        UI_MISIONES.SetActive(true);
        UI_MAIN.SetActive(false);
    }

    public void BTN_RETORNO_UI()
    {
        Time.timeScale = 1;
        UI_MISIONES.SetActive(false);
        UI_MAIN.SetActive(true);
    }
    
}
