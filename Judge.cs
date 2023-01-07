using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Judge
{
    public static void excute()
    {
        Vector3 virus = Entry.vPos.position;
        Vector3 people = Entry.pPos.position;

        float x_abs = Math.Abs(virus.x - people.x);
        float y_abs = Math.Abs(virus.y - people.y);

        if(x_abs <= 1 && y_abs <= 1){
            SceneManager.LoadScene("VirusWinScenes");
        }

    }


}
