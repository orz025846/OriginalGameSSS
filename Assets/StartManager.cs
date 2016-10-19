using UnityEngine;
using System.Collections;
// スタート画面用
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    [SerializeField]
    private Button _button;

    // Use this for initialization
    void Start () {

        //ボタンを押した時の処理
        _button.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene");
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
