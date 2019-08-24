using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneController : MonoBehaviour
{
    public Node selfNode;

    void Start()
    {
        
    }
    void Update()
    {
        ChangeImage();

    }

    public void ChangeImage()
    {
        var img = GetComponent<Image>();
        try
        {
            if (selfNode.isPlayer)
            {
                img.sprite = CreateController.cc.sprPlayer;
            }
            else
            {
                switch (selfNode.pawnType)
                {
                    case PawnType.Stone:
                        img.sprite = CreateController.cc.sprNode;
                        break;
                    case PawnType.Love:
                        img.sprite = CreateController.cc.sprLove;
                        break;
                    case PawnType.Friendship:
                        img.sprite = CreateController.cc.sprFriendship;
                        break;
                    case PawnType.Business:
                        img.sprite = CreateController.cc.sprBusiness;
                        break;
                    case PawnType.Family:
                        img.sprite = CreateController.cc.sprFamily;
                        break;
                    default:
                        break;
                }
            }
        }
        catch
        {
            Debug.Log("에러유발" + gameObject.name);
        }
        
    }

    
    public void Move(Node n)
    {
        if (!CreateController.cc.isMyTurn)
            return;

        n.isPlayer = true;

        CreateController.cc.playerNode.isPlayer = false;
        CreateController.cc.playerNode = n;
        CreateController.cc.selectButtons.SetActive(true);
        CreateController.cc.popupObject.SetActive(true);
        CreateController.cc.isMyTurn = false;
        CreateController.cc.pv.RPC("CommunicateWithOther", PhotonTargets.Others, CreateController.cc.pv.owner.ID);
    }

    [PunRPC]
    public void CommunicateWithOther()
    {
        CreateController.cc.isMyTurn = true;
    }

    public void ChangeTile(PawnType pt, Node n)
    {
        selfNode.pawnType = pt;
        CreateController.cc.selectButtons.SetActive(false);
        CreateController.cc.popupObject.SetActive(false);
    }
}
