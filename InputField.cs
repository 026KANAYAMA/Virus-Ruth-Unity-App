using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputField : MonoBehaviour
{
    //InputFieldを格納するための変数
    //InputField inputField;

    public static string ip;

    void Start()
    {
        //InputFieldコンポーネントを取得
        
    }

    public void GetIP(){
        Text FieldText = GameObject.Find("InputField/Text").GetComponent<Text>();
        //InputFieldからテキスト情報を取得する
        ip = FieldText.text;
        Debug.Log(ip);
        SceneManager.LoadScene("GameScenes");
    }
    
}
