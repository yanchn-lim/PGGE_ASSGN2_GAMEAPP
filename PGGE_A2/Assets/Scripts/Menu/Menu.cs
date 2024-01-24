using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickSinglePlayer()
    {
        //Debug.Log("Loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Menu");
    }

    //get the singleton audioplayer to play the sound
    public void ClickSound(int i)
    {
        AudioPlayer.Instance.PlayClickSound(i);
    }
}
