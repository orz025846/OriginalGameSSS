using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarGenerator : MonoBehaviour
{
    // smallStarのPrefab
    public GameObject smallStarPrefab;
    /// <summary>
    /// smallStarの生成位置
    /// </summary>
    [SerializeField]
    private float genPosY = 450;

    /// <summary>
    /// smallStarの生成個数の上限
    /// </summary>
    private int maxsSNum = 8;
    /// <summary>
    /// Terrainの位置を格納する変数 
    /// </summary>
    private Vector3 fieldPosition;
    /// <summary>
    /// 左下の位置 ~ 右上の位置 
    /// </summary>
    private float minPosX = 0.0f;
    private float maxPosX = 0.0f;
    private float minPosZ = 0.0f;
    private float maxPosZ = 0.0f;
    /// <summary>
    /// Trrainの一辺の長さ 
    /// </summary>
    private float terrainLength = 1500.0f;
    /// <summary>
    ///何秒に１度Starを出現させるか 
    /// </summary>
    private float timeInterval = 1.5f;
    /// <summary>
    /// 秒数をカウントするカウンター 
    /// </summary>
    private float timeCounter = 0;

    // Use this for initialization
    void Start()
    {

        //追記ぶん(Fieldオブジェクトの取り込み）
        GameObject field = GameObject.Find("Field") as GameObject;
        fieldPosition = field.transform.position;
        //端の位置を計算
        //左下のX座標
        minPosX = fieldPosition.x;
        //右上のX座標
        maxPosX = fieldPosition.x + terrainLength;
        //左下のZ座標
        minPosZ = fieldPosition.z;
        //右上のZ座標
        maxPosZ = fieldPosition.z + terrainLength;
    }

    // Update is called once per frame
    void Update()
    {
        //秒数をカウント
        timeCounter += Time.deltaTime;
        //一定秒数を超えたらtrueになる
        if (timeCounter > timeInterval)
        {
            //秒数カウンターを0で初期化
            timeCounter = 0;
            // 生成するPrefab数をランダムに決める
            int n = Random.Range(1, maxsSNum + 1);
            // 生成
            for (int i = 0; i < n; i++)
            {
                //星の生成
                GameObject smallStar = Instantiate(smallStarPrefab) as GameObject;
                //位置を指定
                smallStar.transform.position =
                    new Vector3(
                    Random.Range(minPosX, maxPosX),
                    genPosY,
                    Random.Range(minPosZ, maxPosZ)
                );
            }
        }
    }

}