using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputField : MonoBehaviour
{

    public static string ip;

    

    public void GetIP(){
        Text FieldText = GameObject.Find("InputField/Text").GetComponent<Text>();
        //InputFieldからテキスト情報を取得する
        ip = FieldText.text;
        Debug.Log(ip);
        SceneManager.LoadScene("DescriptionScenes");
    }
    
}
