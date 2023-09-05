using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelMenu, painelCreditos;
    public AudioSource jukebox;
    public AudioClip musica, efeito;
    private void Awake()
    {
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        jukebox.Play();
    }

    // Update is called once per frame
    public void MudarCreditos() 
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(false);
        painelCreditos.SetActive(true);
    }
    public void MudarMenu() 
    {
        jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void MinhaPagina() 
    {
        Application.OpenURL("https://bento.me/capoficial");
    }

    public void IrParaJogo() 
    {
        SceneManager.LoadScene(1);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
