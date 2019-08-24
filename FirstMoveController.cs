using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstMoveController : MonoBehaviour
{
    

    void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Node node = new Node();
                node.grid = new Vector2(i, j);
                GameObject findstone = GameObject.Find(i.ToString() + "-" + j.ToString());
            }
        }
    }


    void Update()
    {
        
    }
    
}
