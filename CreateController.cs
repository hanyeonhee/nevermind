using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateController : MonoBehaviour
{
    public static CreateController cc;

    int x = 6;
    int y = 6;
    public int turn=1;

    public Node[,] nodes;

    public GameObject selectButtons;
    public GameObject popupObject;

    public Sprite sprPlayer;
    public Sprite sprNode;
    public Sprite sprLove;
    public Sprite sprFriendship;
    public Sprite sprBusiness;
    public Sprite sprFamily;
    public Sprite sprImage;

    public Node playerNode;

    private void Awake()
    {
        cc = this;
    }

    void Start()
    {

        popupObject = GameObject.FindWithTag("Pop");
        popupObject.SetActive(false);
        //GameObject popupObject = new GameObject();
        //popupObject = GameObject.FindWithTag("Pop");
        //popupObject.SetActive(false);


        nodes = new Node[x, y];

        for (int i = 1; i <=5; i++)
        {
            for (int j = 1; j <=5; j++)
            {
                Node node = new Node();
                node.grid = new Vector2(i,j);
                node.stone = transform.Find(i.ToString() + "-" + j.ToString()).gameObject;
                node.button = transform.Find(i.ToString() + "-" + j.ToString()).GetComponent<Button>();
                nodes[i, j] = node;
                nodes[i, j].button.enabled = true;

                var selfImg = nodes[i, j].button.GetComponent<Image>();

                

                if (i == 5 && j == 3)
                {
                    nodes[i, j].isPlayer = true;
                    playerNode = nodes[i, j];
                }

                //Add Component -> 컴포넌트추가
                nodes[i, j].stone.AddComponent<StoneController>();

                var sc = nodes[i, j].stone.GetComponent<StoneController>();
                sc.selfNode = node;

                nodes[i, j].button.onClick.AddListener(delegate { sc.Move(node); });
                //nodes[i, j].button.onClick.AddListener(delegate { sc.ChangeTile(PawnType.Love); });
            }
        }

        SetTileButtons();
        selectButtons.SetActive(false);
    }


    void Update()
    {
        for(int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if(i < playerNode.grid.x - 1)
                {
                    nodes[i, j].button.interactable = false;
                }
                else if(i > playerNode.grid.x + 1)
                {
                    nodes[i, j].button.interactable = false;
                }
                else if (j < playerNode.grid.y - 1)
                {
                    nodes[i, j].button.interactable = false;
                }
                else if (j > playerNode.grid.y + 1)
                {
                    nodes[i, j].button.interactable = false;
                }
                else
                {
                    if(!selectButtons.activeSelf)
                        nodes[i, j].button.interactable = true;
                    else
                        nodes[i, j].button.interactable = false;
                }

            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Love, playerNode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Friendship, playerNode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Business, playerNode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Family, playerNode);
        }
    }


    void SetTileButtons()
    {
        var love = selectButtons.transform.Find("Love").GetComponent<Button>();
        var friendship = selectButtons.transform.Find("Friendship").GetComponent<Button>();
        var business = selectButtons.transform.Find("Business").GetComponent<Button>();
        var family = selectButtons.transform.Find("Family").GetComponent<Button>();

        love.onClick.AddListener(delegate { playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Love, playerNode); });
        friendship.onClick.AddListener(delegate { playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Friendship, playerNode); });
        business.onClick.AddListener(delegate { playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Business, playerNode); });
        family.onClick.AddListener(delegate { playerNode.button.GetComponent<StoneController>().ChangeTile(PawnType.Family, playerNode); });

        selectButtons.SetActive(false);
    }
    

}

public enum PawnType
{
    Stone = 0,

    Love = 1,
    Friendship = 2,
    Business = 3,
    Family = 4
}

public class Node
{
    public Vector2 grid;
    public GameObject stone;
    public Button button;
    public PawnType pawnType;
    public bool isPlayer;
}
