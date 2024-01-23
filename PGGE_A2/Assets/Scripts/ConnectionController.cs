using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace PGGE
{
    namespace Multiplayer
    {
        public class ConnectionController : MonoBehaviourPunCallbacks
        {
            const string gameVersion = "1";

            public byte maxPlayersPerRoom = 3;

            public GameObject mConnectionProgress;
            public GameObject mBtnJoinRoom;
            public GameObject mInpPlayerName;
            public InputField mInpRoomName;
            public InputField mInpRoomMaxPlayer;

            public Transform mRoomListParent;
            public GameObject mRoomPrefab;

            public GameObject mCreateRoomPanel;

            bool isConnecting = false;

            List<RoomInfo> roomsCreated = new();


            void Awake()
            {
                // this makes sure we can use PhotonNetwork.LoadLevel() on 
                // the master client and all clients in the same 
                // room sync their level automatically
                PhotonNetwork.AutomaticallySyncScene = true;
            }

            // Start is called before the first frame update
            void Start()
            {
                mConnectionProgress.SetActive(false);

                if (!PhotonNetwork.IsConnected)
                {
                    isConnecting = PhotonNetwork.ConnectUsingSettings();
                    PhotonNetwork.GameVersion = gameVersion;
                }
                
            }

            #region Creating Room
            public void CreateRoom()
            {
                string name = mInpRoomName.text;
                byte maxP = (byte)int.Parse(mInpRoomMaxPlayer.text);
                RoomOptions roomOptions = new RoomOptions
                {
                    MaxPlayers = maxP,
                    IsOpen = true,
                    IsVisible = true,                          
                };

                if (PhotonNetwork.IsConnected)
                {
                    // Attempt joining a random Room. 
                    // If it fails, we'll get notified in 
                    // OnJoinRandomFailed() and we'll create one.
                    PhotonNetwork.JoinOrCreateRoom(name, roomOptions,TypedLobby.Default);
                }
                else
                {
                    // Connect to Photon Online Server.
                    isConnecting = PhotonNetwork.ConnectUsingSettings();
                    PhotonNetwork.GameVersion = gameVersion;
                }
            }

            public override void OnCreatedRoom()
            {
                Debug.Log("Room created");
                Instantiate(mRoomPrefab, mRoomListParent);
            }

            public override void OnRoomListUpdate(List<RoomInfo> roomList)
            {
                Debug.Log("Room list retrieved");
                //retrieve the room list everything the list is updated
                roomsCreated = roomList;
                foreach (var item in roomsCreated)
                {
                    Debug.Log(item.Name);
                }
            }

            public override void OnCreateRoomFailed(short returnCode, string message)
            {
                Debug.Log("Failed in creating room");
                isConnecting = false;
            }

            #endregion

            #region Join Room
            public override void OnJoinRoomFailed(short returnCode, string message)
            {
                Debug.Log("Failed to join room");
                isConnecting = false;
            }

            public override void OnJoinRandomFailed(short returnCode, string message)
            {
                Debug.Log("OnJoinRandomFailed() was called by PUN. " +
                    "No random room available" +
                    ", so we create one by Calling: " +
                    "PhotonNetwork.CreateRoom");

                // Failed to join a random room.
                // This may happen if no room exists or 
                // they are all full. In either case, we create a new room.
                //PhotonNetwork.CreateRoom(null,
                //    new RoomOptions
                //    {
                //        MaxPlayers = maxPlayersPerRoom
                //    });
            }
            #endregion

            public void Connect()
            {
                mBtnJoinRoom.SetActive(false);
                mInpPlayerName.SetActive(false);
                mConnectionProgress.SetActive(true);

                // we check if we are connected or not, we join if we are, 
                // else we initiate the connection to the server.
                if (PhotonNetwork.IsConnected)
                {
                    // Attempt joining a random Room. 
                    // If it fails, we'll get notified in 
                    // OnJoinRandomFailed() and we'll create one.
                    PhotonNetwork.JoinRandomRoom();
                }
                else
                {
                    // Connect to Photon Online Server.
                    isConnecting = PhotonNetwork.ConnectUsingSettings();
                    PhotonNetwork.GameVersion = gameVersion;
                }
            }
            
            public override void OnConnectedToMaster()
            {
                if (isConnecting)
                {
                    Debug.Log("OnConnectedToMaster() was called by PUN");
                    PhotonNetwork.JoinLobby();
                    //PhotonNetwork.JoinRandomRoom();
                }
            }

            public override void OnDisconnected(DisconnectCause cause)
            {
                Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
                isConnecting = false;
            }

            public override void OnJoinedRoom()
            {
                //Debug.Log("OnJoinedRoom() called by PUN. Client is in a room.");
                //if (PhotonNetwork.IsMasterClient)
                //{
                //    Debug.Log("We load the default room for multiplayer");
                //    //PhotonNetwork.LoadLevel("MultiplayerMap00");
                //}
            }

            public override void OnJoinedLobby()
            {
                Debug.Log("lobby joined");
            }

            #region UI Methods

            public void OpenCreateRoomPanel()
            {
                mCreateRoomPanel.SetActive(true);
            }
            #endregion
        }
    }
}
