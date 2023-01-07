
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    float m_volumeRate; // 音量(0-1)
    public float m_gain = 10f; // 音量に掛ける倍率
    public static float max = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        AudioSource aud = GetComponent<AudioSource>();
        
        if ((aud != null)&&(Microphone.devices.Length>0)) // オーディオソースとマイクがある
        {
            string devName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
            int minFreq, maxFreq;
            Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る
            aud.clip = Microphone.Start(devName, true, 2, minFreq); // 音の大きさを取るだけなので最小サンプリングで十分
            aud.Play(); //マイクをオーディオソースとして実行(Play)開始
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_volumeRate);

        //Debug.Log(max);
    }

    // オーディオが読まれるたびに実行される
    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;
        for (int i = 0; i < data.Length; ++i)
        {
            sum += Mathf.Abs(data[i]); // データ（波形）の絶対値を足す
        }
        // データ数で割ったものに倍率をかけて音量とする
        m_volumeRate = Mathf.Clamp01(sum * m_gain/ (float)data.Length);

        if(m_volumeRate > max){
            max = m_volumeRate;
        }
    }
}
