using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToUI : MonoBehaviour
{
    public void UIGo(){
        SceneManager.LoadScene("UIScenes");
    }
}
