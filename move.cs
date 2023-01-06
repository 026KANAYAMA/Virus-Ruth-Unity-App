using UnityEngine;
using System;

public class move
{
    //コンストラクタ
    public move(){}

    //クラスメソッド
    public static void excute(string directionNum, string moveObj){

        Debug.Log($"{directionNum}はmove.excuteに送られました");
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
        
        //Virusのポジションを変更
        if(moveObj == "Virus"){
            Vector3 v = Entry.vPos.position;
            v.x += xPos;
            v.y += yPos;
            Entry.vPos.position = new Vector3(v.x, v.y, -1);
        }
        //Peopleのポジションを変更
        else if(moveObj == "People"){
            Vector3 p = Entry.pPos.position;
            p.x += xPos;
            p.y += yPos;
            Entry.pPos.position = new Vector3(p.x, p.y, -1);
        }
    }

}
