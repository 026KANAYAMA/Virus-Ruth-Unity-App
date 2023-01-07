using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Net.Http;

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

    private string pNum = "0";
    private string vNum = "0";

    Task<string> peopleTask = null;
    Task<string> virusTask = null;
    int check = 0;

    public GameObject people;
    public static SpriteRenderer peopleSprite;
    public SpriteRenderer[] pSprite = new SpriteRenderer[2];

    public int peopleUsed = 0;
    public int allChecked = 0;

    void Awake(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;   //フレームレートを1/60秒に設定
    }

    void Start()
    {
        pObj= GameObject.Find("people");
        vObj= GameObject.Find("virus");
        
        //デフォルトのpeopleの位置は(-3.27, -3.27, -1)
        pPos = pObj.GetComponent<Transform>();
        vPos = vObj.GetComponent<Transform>();
        
        people = GameObject.Find("people");
        peopleSprite = people.GetComponent<SpriteRenderer>();
    }

    void Update()   //1秒あたり60フレーム
    {
        cnt++;
        if(cnt % 480 == 0){    //8秒ごとに実行

            if(Sprite.checkedUse == 1 && peopleUsed == 0){
                Sprite.wakutinEnd();
                peopleSprite.sprite = null;
                //Debug.Log("nullになりました？");
                peopleUsed = 1;
                allChecked = 0;
            }

            
            allChecked++;
        
            peopleTask = piping.htpAsync("People");
            virusTask = piping.htpAsync("Virus");
            check = 1;
            Debug.Log(allChecked);

        }
        
        try{
            if(peopleTask.IsCompleted && check == 1){

            pNum = peopleTask.Result;
            vNum = virusTask.Result;
            //Debug.Log(pNum);
            //Debug.Log(vNum);
        
            move.excute(pNum, "People");
            move.excute(vNum, "Virus");
            check = 0;
            }
        }
        catch(NullReferenceException){
            //Debug.Log("例外をスルーしました");
        }

        if(peopleUsed == 1 && allChecked == 2){
            peopleSprite.sprite = pSprite[0].sprite; 
        }
    }

}
