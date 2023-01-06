using UnityEngine;
using UnityEngine.UI;

public class Tern
{
    public static void display(int tern)
    {
        if(tern>=2)
        {
            Debug.Log($"残り{tern}ターン");
            Sprite.obj.text = $"残り{tern}ターン";
        }   
        else if(tern == 1)
        {
            Debug.Log("ラストターン");
            Sprite.obj.text = "ラストターン";
        }
    }

    public static void banish()
    {
        Sprite.obj.text = null;
    }
}
