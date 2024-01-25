using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon;
using PGGE;

public class PlayerManager : MonoBehaviourPunCallbacks,IPunInstantiateMagicCallback
{
    public string mPlayerPrefabName = "Prefabs/SciFiPlayer_Networked";
    public string mCarl = "Prefabs/CarlWheezer";
    public PlayerSpawnPoints mSpawnPoints;

    [HideInInspector]
    public GameObject mPlayerGameObject;
    [HideInInspector]
    private ThirdPersonCamera mThirdPersonCamera;

    private void Start()
    {
        Transform randomSpawnTransform = mSpawnPoints.GetSpawnPoint();
        mPlayerGameObject = PhotonNetwork.Instantiate(GameConstant.Character,
            randomSpawnTransform.position,
            randomSpawnTransform.rotation,
            0);


        mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();

        //mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
        mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
        mThirdPersonCamera.mDamping = 20.0f;
        mThirdPersonCamera.mRotationSpeed = 1.5f;
        mThirdPersonCamera.mCameraType = CameraType.Follow_Independent;
    }

    

    public void LeaveRoom()
    {
        Debug.LogFormat("LeaveRoom");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        //Debug.LogFormat("OnLeftRoom()");
        SceneManager.LoadScene("Menu");
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        info.Sender.TagObject = mPlayerGameObject;
    }
}
