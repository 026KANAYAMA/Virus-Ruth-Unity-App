using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entry : MonoBehaviour
{
    public string directionNum; //1=左、2=上、3=右、4=下
    public string moveObj;  //virusかpeopleが格納される

    public GameObject pObj;
    public GameObject vObj;

    //Entryクラスのクラスフィールド
    public static Transform pPos;
    public static Transform vPos;

    private int cnt=0;
    private int cntDown = 7;


    void Awake(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;   //フレームレートを1/60秒に設定
    }

    void Start()
    {
        //var vi = new piping();
        //vi.firstName = "龍起";
        //Debug.Log(vi.firstName);

        pObj= GameObject.Find("people");
        vObj= GameObject.Find("virus");

        
        //デフォルトのpeopleの位置は(-3.27, -3.27, -1)
        pPos = pObj.GetComponent<Transform>();
        vPos = vObj.GetComponent<Transform>();
        
    }

    void Update()   //1秒あたり60フレーム
    {
        cnt++;
        if(cnt % 480 == 0){    //8秒ごとに実行
            //Debug.Log(cnt);
            directionNum = "4"; moveObj = "virus";
            move.excute(directionNum, moveObj);
            directionNum = "1"; moveObj = "people";
            move.excute(directionNum, moveObj);
            
        }

        
    }

    
}
