using UnityEngine;
using UnityEngine.SceneManagement;

public class Sprite : MonoBehaviour
{
    public SpriteRenderer baseSprite;
    public SpriteRenderer[] targetSprite = new SpriteRenderer[5];

    private int cnt=0;
    private int cntDown = 7;

    public int tern = 6;

    void Start()
    {
        //カウントダウンの数字
        baseSprite = GetComponent<SpriteRenderer>();
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
                if(tern>=2){
                    Debug.Log($"残り{tern}ターン"); //仮
                }
                else if(tern == 1){
                    Debug.Log("ラストターン");
                }
                tern--;
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
