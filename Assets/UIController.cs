using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private float startTime = 15.00f;  // 制限時間
    private float time; // 残り時間
    private float overTime = 0; // オーバータイムの設定
    private float timeflat; // 経過時間（deltaTime）代入用変数

    [SerializeField]
    private GameObject timeWatchText;

    [SerializeField]
    private GameObject timeUPText;

    [SerializeField]
    private Button _button;


    // Use this for initialization
    void Start()
    {
        this.time = 0;
        this.timeflat = 0;
        //ボタンを押した時の処理
        _button.onClick.AddListener(() => {
            SceneManager.LoadScene("Start");
        });

    }

    // Update is called once per frame
    void Update()
    {
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
        SceneManager.LoadScene("GameOver");
    }
}