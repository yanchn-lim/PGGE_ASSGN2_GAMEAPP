using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PGGE;
public class PauseHandler : MonoBehaviour
{
    [SerializeField]
    string[] pathReference;

    [SerializeField]
    string[] charName;

    [SerializeField]
    TMP_Text text;

    int currIndex;

    [SerializeField]
    GameObject pauseMenu;

    private void Start()
    {
        text.text = charName[GameConstant.CurrentIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(GameApp.GamePaused);

            if (GameApp.GamePaused) 
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ChangeCharacter_InGame(int i)
    {
        //checks for the minimum and maximum and cycles it around
        if (currIndex == 0 && i == -1)
        {
            currIndex = pathReference.Length - 1;
            text.text = charName[currIndex];
            GameConstant.Character = pathReference[currIndex];
            return;
        }

        if (currIndex == pathReference.Length - 1 && i == 1)
        {
            currIndex = 0;
            text.text = charName[currIndex];
            GameConstant.Character = pathReference[currIndex];
            return;
        }


        currIndex += i;
        text.text = charName[currIndex];
        GameConstant.Character = pathReference[currIndex];
        GameConstant.CurrentIndex = currIndex;
    }
}
