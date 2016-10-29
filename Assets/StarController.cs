using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarController : MonoBehaviour
{
    // ポイント加算用UIのアタッチ
    [SerializeField]
    public Image image;

    // Use this for initialization
    void Start()
    {

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


        
}