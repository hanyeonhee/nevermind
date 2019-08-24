using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Addturn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addturn()
    {
        CreateController.cc.turn++;
    }
}
