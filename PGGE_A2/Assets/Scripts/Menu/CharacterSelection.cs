using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    GameObject[] modelPrefab;

    [SerializeField]
    string[] pathReference;

    GameObject currModel;
    int currIndex;
    private void Start()
    {
        currModel = Instantiate(modelPrefab[0]);
        currIndex = 0;
        GameConstant.Character = pathReference[0];
        GameConstant.CurrentIndex = 0;
    }

    public void ChangeModel(int i)
    {

        //checks for the minimum and maximum and cycles it around
        if(currIndex == 0 && i == -1)
        {
            currIndex = modelPrefab.Length - 1;
            ReplaceModel(currIndex);
            return;
        }

        if(currIndex == modelPrefab.Length - 1 && i == 1)
        {
            currIndex = 0;
            ReplaceModel(currIndex);
            return;
        }

        
        currIndex += i;
        ReplaceModel(currIndex);

    }

    void ReplaceModel(int index)
    {
        //remove the current model and replaces it with the new character
        Destroy(currModel);

        currModel = Instantiate(modelPrefab[index]);
        GameConstant.CurrentIndex = index;

        //setting the path reference
        GameConstant.Character = pathReference[index];
        
    }
}
