using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move
{
    //コンストラクタ
    public move(){}

    //クラスメソッド
    public static void excute(string directionNum, string moveObj){
        //メンバー変数
        float xPos = 0f;
        float yPos = 0f;
        int iNum = int.Parse(directionNum);
        const float MASS = 3.27f;
        switch (iNum)
        {
            case 1: xPos = -MASS; break;
            case 2: yPos = MASS; break;
            case 3: xPos = MASS; break;
            case 4: yPos = -MASS; break;
            default: break;
        }
        
        if(moveObj == "virus"){
            //Debug.Log("成功です。(virus)");
            //Entry.vPos.position = new Vector3(3.27f,3.27f,-1);
            Vector3 v = Entry.vPos.position;
            v.x += xPos;
            v.y += yPos;
            Entry.vPos.position = new Vector3(v.x, v.y, -1);
        }
        else if(moveObj == "people"){
            //Debug.Log("成功です。(people)");
            //Entry.pPos.position = new Vector3(3.27f,0,-1);
            Vector3 p = Entry.pPos.position;
            p.x += xPos;
            p.y += yPos;
            Entry.pPos.position = new Vector3(p.x, p.y, -1);
        }
    }

    

}
