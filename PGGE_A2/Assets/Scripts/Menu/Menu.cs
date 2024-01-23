using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSinglePlayer()
    {
        //Debug.Log("Loading singleplayer game");
        source.Play();
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        source.Play();
        SceneManager.LoadScene("Multiplayer_Launcher");
    }

    public void OnClickBack()
    {
        source.Play();
        SceneManager.LoadScene("Menu");
    }
}
