using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonInit : MonoBehaviour
{
    public static string version = "1.0";

    bool joinedLobby;

    private void Awake()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            Debug.Log("인터넷 연결이 되어 있지 않습니다!!");
        else if(!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings(version);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TryJoinLobby());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TryJoinLobby()
    {
        while(!joinedLobby)
        {
            PhotonNetwork.JoinLobby();
            yield return new WaitForSeconds(0.3f);
        }
            
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("play");
    }

    public void CreateRoom()
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.MaxPlayers = 2;
        ro.IsVisible = true;

        PhotonNetwork.CreateRoom("play", ro, TypedLobby.Default);
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joied Lobby");
        joinedLobby = true;

        
    }

    void OnJoinFailed()
    {
        Debug.Log("Join Failed!");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Joied room!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
