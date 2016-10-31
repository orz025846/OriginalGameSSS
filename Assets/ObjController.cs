using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjController : MonoBehaviour
{
    // ポイント加算用UIのアタッチ
    [SerializeField]
    public Image image;
    // ゲームクリア表示用テキスト
    public GameObject clearText;

    // Use this for initialization
    void Start()
    {
        // バーの初期化
        this.image.fillAmount = 0;
        // クリア表示用テキストの取得（TimeUPTextレンタル）
        this.clearText = GameObject.Find("TimeUPText");
    }

    // Update is called once per frame
    void Update()
    {
        // Raycastの実装
        if (Input.GetMouseButtonDown(0))  // マウス左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //Ray発射
            RaycastHit hit;  //Rayが当たったオブジェクト情報取得用
            float maxDistance = 2000;  //Ray軌跡の長さ

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                image.fillAmount += 0.3f;
                Destroy(hit.collider.gameObject, 0.1f);

            }

            if (image.fillAmount >= 1)  //バーが満杯
            {
                this.clearText.GetComponent<Text>().text = "Full Charge!!";
                StartCoroutine(SegueGameClearScene()); //クリア画面に遷移
            }


            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 5, false);
        }
    }

    // Scean遷移用コルーチンより呼び出し（待機時間の制御）
    private IEnumerator SegueGameClearScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Clear");
    }

        
}