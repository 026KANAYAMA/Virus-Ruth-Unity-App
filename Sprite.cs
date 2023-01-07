using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sprite : MonoBehaviour
{
    public SpriteRenderer baseSprite;
    public SpriteRenderer[] targetSprite = new SpriteRenderer[6];

    private int cnt=0;
    private int cntDown = 7;

    public int tern = 6;

    public GameObject ternText;
    public static Text obj;

    public GameObject wakutin;
    public static SpriteRenderer wakutin_base;
    public static int checkedUse = 0;


    void Start()
    {
        //カウントダウンの数字
        baseSprite = GetComponent<SpriteRenderer>();
        
        wakutin = GameObject.Find("wakutin");
        wakutin_base = wakutin.GetComponent<SpriteRenderer>();

        ternText = GameObject.Find("Text");
        obj = ternText.GetComponent<Text>();
    }

    void Update()
    {
        cnt++;
        
        if(cnt % 60 == 0 ){
            Debug.Log($"現在のvoie.maxは{Voice.max}");
            if(Voice.max >= 0.5f && checkedUse == 0){
                wakutin_base.sprite = targetSprite[5].sprite;
                checkedUse = 1;
            }

            if(cntDown >= 1 && cntDown <= 5){
                baseSprite.sprite = targetSprite[cntDown-1].sprite; 
            }
            else if(cntDown == 7 || cntDown == 0){
                baseSprite.sprite = null;
            }
            else if(cntDown == 6){
                Tern.display(tern);
                tern--;
            }
            //カウントダウンが終わり、次のカウントダウンの頭(7)の時、VirusとPeopleが同じマスにいるか判定する
            if(cntDown == 7){
                Judge.excute();
            }

            if(cntDown == 1){
                Tern.banish();
            }

            cntDown--;

            if(cntDown == 6 && tern == 0){
                //PeopleWinScenesに切り替え
                SceneManager.LoadScene("PeopleWinScenes");
            }
            
            if(cntDown == -1){
                cntDown = 7;
            }
            
        }
    }

    public static void wakutinEnd(){
        wakutin_base.sprite = null;
    }
    

}
