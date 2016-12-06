using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // 制限時間に関する変数
    private float startTime = 20.00f;  //制限時間
    private float time;  //残り時間
    private float overTime = 0;  //オーバータイムの設定
    private float timeflat;  //経過時間（deltaTime）代入用変数

    // UIオブジェクトのアタッチ
    [SerializeField]
    private GameObject countDounText;  //カウントダウンStart！！ 
    [SerializeField]
    private GameObject timeWatchText; //制限時間の表示
    [SerializeField]
    private GameObject timeUPText; //TimeUPの表示
    [SerializeField]
    private Button _button; //オーバータイムまでStart画面に戻るためのbutton

    // コルーチン用ブーリアン
    private bool _isStart = false;

    // Use this for initialization
    IEnumerator Start()
    {
        //ボタンを押した時の処理
        _button.onClick.AddListener(() => {
            SceneManager.LoadScene("Start");
        });

        this.timeWatchText.GetComponent<Text>().text = startTime.ToString("F2");  //0.00表示

        yield return new WaitForSeconds(3.0f);
        this.timeWatchText.GetComponent<Text>().text = 0.ToString("F2");
        Initialize();
    }

    public void Initialize()
    {
        this.time = 0;
        this.timeflat = 0;
        _isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart == false)
        {
            return;
        }
        // TimeOverになった場合の処理
        if (time < overTime)
        {
            this.timeWatchText.GetComponent<Text>().text = 0.ToString("F2");  //0.00表示
            this.timeUPText.GetComponent<Text>().text = "TimeUP";  //TimeUPTextUI呼び出し
            StartCoroutine(SegueGameOverScene());
        }
        else
        {
            // タイムカウント
            this.timeflat += Time.deltaTime;  //経過時間（フラット）
            this.time = startTime - timeflat;  //残り時間
            this.timeWatchText.GetComponent<Text>().text = time.ToString("F2");  //残り時間表示
        }
    }

    private IEnumerator SegueGameOverScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Over");
    }
}