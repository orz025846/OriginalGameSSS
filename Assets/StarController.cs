using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarController : MonoBehaviour
{
    // 生成オブジェクトのアタッチ
    [SerializeField]
    private GameObject smallStarPrefab;
    [SerializeField]
    private GameObject pumpkin_02Prefab;

    // オブジェクトの移動速度
    public float[] speed = { -50.0f, -50.0f };  //ランダム変数
    public float[] speedSs;  //移動速度用

    // オブジェクトの消滅位置（y座標に設定）
    public float deadLine = -175;

    // ポイント加算用UIのアタッチ
    [SerializeField]
    public Image image;

    // Use this for initialization
    void Start()
    {
        float aaa = Time.deltaTime;
        float bbb = Time.deltaTime * 0.2f;
        //float ccc = Time.deltaTime - 0.2f;
        speedSs = new float[] {
            Random.Range (speed [0] * aaa, speed [1] * aaa),
            Random.Range (speed [0] * bbb, speed [1] * bbb),
            Random.Range (speed [0] * bbb, speed [1] * bbb)
        };

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
                image.fillAmount = 0;  //仮に0に戻る→CLEAR表示、Animetion画面に遷移
            }


            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 5, false);
        }


        // field（ｙ座標）を透過したらオブジェクト消滅
        if (transform.position.y < this.deadLine)
        {
            //１秒後にDestroy
            Destroy(gameObject, 1.0f);
        }
        // オブジェクトを移動させる
        transform.Translate(speedSs[0], speedSs[1], speedSs[2]);
    }

}