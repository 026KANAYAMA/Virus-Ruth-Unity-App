using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    //画像を変更するスプライトオブジェクト
    //public SpriteRenderer targetSprite_five;   //5の画像
    //public SpriteRenderer targetSprite_four;   //4の画像
    //public SpriteRenderer targetSprite_three;   //3の画像
    //public SpriteRenderer targetSprite_two;   //2の画像
    //public SpriteRenderer targetSprite_one;   //1の画像

    public SpriteRenderer baseSprite;
    public SpriteRenderer[] targetSprite = new SpriteRenderer[5];

    private int cnt=0;
    private int cntDown = 7;

    // Start is called before the first frame update
    void Start()
    {
        //カウントダウンの数字
        baseSprite = GetComponent<SpriteRenderer>();
        //targetSprite_five.sprite = targetSprite_four.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;
        
        if(cnt % 60 == 0 ){
            if(cntDown >= 1 && cntDown <= 5){
                //var spriteRenderer = targetSprite_five.GetComponent<spriteRenderer>();
                Debug.Log(cntDown);
                baseSprite.sprite = targetSprite[cntDown-1].sprite; 
            }

            if(cntDown == 7 || cntDown == 6 || cntDown == 0){
                baseSprite.sprite = null;
            }

            cntDown--;
            
            if(cntDown == -1){
                cntDown = 7;
            }
            
        }
    }
}
