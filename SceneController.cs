using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Onclick()
    {
        gotoMain();
    }
    public void gotoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
