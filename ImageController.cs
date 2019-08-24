using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite sprImage;


    void Start()
    {
        GameObject popupObject = new GameObject();
        popupObject = GameObject.FindWithTag("Pop");
        popupObject.SetActive(false);
    }


    void Update()
    {
        
    }
}