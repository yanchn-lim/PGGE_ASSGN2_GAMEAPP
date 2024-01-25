using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NameTag : MonoBehaviourPun
{
    public GameObject myNameObject;
    public TMP_Text nameText;

    private void Start()
    {
        if (photonView.IsMine)
        {
            //set as inactive when it is the client's view
            myNameObject.SetActive(false);
            return;
        }

        //set the text to the name of the view
        nameText.text = photonView.Owner.NickName;
        
    }

}
