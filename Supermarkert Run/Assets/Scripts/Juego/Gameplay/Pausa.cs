using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject UI_PAUSA;
    [SerializeField] new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void BTN_PAUSA()
    {
        audio.Play();
        Time.timeScale = 0;
        UI_PAUSA.SetActive(true);
    }

    public void BTN_SIN_PAUSA()
    {
        audio.Play();
        Time.timeScale = 1;
        UI_PAUSA.SetActive(false);
    }

    public void BTN_REGRESAR()
    {
        audio.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
}
