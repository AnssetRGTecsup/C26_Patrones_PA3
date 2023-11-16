using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Play;
    public GameObject Pausa;

    private bool _gameRunning = true;
    void Start()
    {
        
    }
    void Update()
    {
        CambiarEstadodeJuegoconESC();
    }
    public void CambiarEstadodeJuegoconESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CambiarEstadodeJuego();
        }
    }
    public void CargarEscena(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1f;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CambiarEstadodeJuego()
    {
        _gameRunning = !_gameRunning;

        if (_gameRunning == true)
        {
            Time.timeScale = 1f;
            Pause.SetActive(true);
            Play.SetActive(false);
            Pausa.SetActive(false);

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.UnPause();
            }
        }
        else
        {
            Time.timeScale = 0f;
            Pause.SetActive(false);
            Play.SetActive(true);
            Pausa.SetActive(true);

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
    }
    public void CambiarEstadodeJuego1()
    {
        _gameRunning = !_gameRunning;

        if (_gameRunning == true)
        {
            Time.timeScale = 1f;
            Pause.SetActive(true);
            Play.SetActive(false);
            Pausa.SetActive(false);

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.UnPause();
            }
        }
        else
        {
            Time.timeScale = 0f;
            Pause.SetActive(false);
            Play.SetActive(true);
            

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
    }
}
