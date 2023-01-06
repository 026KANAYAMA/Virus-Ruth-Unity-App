using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sprite : MonoBehaviour
{
    public SpriteRenderer baseSprite;
    public SpriteRenderer[] targetSprite = new SpriteRenderer[5];

    private int cnt=0;
    private int cntDown = 7;

    public int tern = 6;

    public GameObject ternText;
    public static Text obj;

    void Start()
    {
        //カウントダウンの数字
        baseSprite = GetComponent<SpriteRenderer>();

        ternText = GameObject.Find("Text");
        obj = ternText.GetComponent<Text>();
    }

    void Update()
    {
        cnt++;
        
        if(cnt % 60 == 0 ){
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
}
