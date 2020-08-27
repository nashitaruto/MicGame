using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicVolume : MonoBehaviour
{
    private float[] waveData_ = new float[1024];
    private GameObject volumeText;
    public float m_volumeRate;
    [SerializeField] float m_gain = 10f;
    void Start()
    {
        this.volumeText = GameObject.Find("VolumeText");
        var audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null, true, 2, 44100);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) <= 0)) { }             // マイクが取れるまで待つ
        audio.Play();
    }
    void Update()
    {
        var aud = GetComponent<AudioSource>();
        aud.GetOutputData(waveData_, 1);
        float sum = 0f;
        for (int i = 0; i < waveData_.Length; ++i)
        {
            sum += Mathf.Abs(waveData_[i]);
        }
        m_volumeRate = sum * 10 / waveData_.Length;
        volumeText.GetComponent<Text>().text = "Volume " + m_volumeRate.ToString("f2");
    }

    /*
    void Start()
    {
        this.volumeText = GameObject.Find("VolumeText");
        AudioSource aud = GetComponent<AudioSource>();
        if ((aud != null) && (Microphone.devices.Length > 0)) // オーディオソースとマイクがある
        {
            string devName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
            int minFreq, maxFreq;
            Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る
            aud.clip = Microphone.Start(devName, true, 999, minFreq); // 音の大きさを取るだけなので最小サンプリングで十分
            aud.Play(); //マイクをオーディオソースとして実行(Play)開始
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.volumeText.GetComponent<Text>().text = "Volume " + m_volumeRate.ToString("f2");
    }

    // オーディオが読まれるたびに実行される
    private void OnAudioFilterRead(float[] data, int channels)
    {
        float sum = 0f;
        for (int i = 0; i < data.Length; ++i)
        {
            sum += Mathf.Abs(data[i]); // データ（波形）の絶対値を足す
        }
        Debug.Log(sum);
        // データ数で割ったものに倍率をかけて音量とする
        m_volumeRate = Mathf.Clamp01(sum * m_gain / (float)data.Length);
    }
    */
}