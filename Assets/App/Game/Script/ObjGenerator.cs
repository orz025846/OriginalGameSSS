using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjGenerator : MonoBehaviour
{
    // 生成オブジェクトのPrefab
    public GameObject smallPumpkinPrefab;
    public GameObject Pumpkin_02Prefab;
    /// <summary>
    /// SmallPumpkinの生成位置
    /// </summary>
    [SerializeField]
    private float gensSPosY = 500;
    [SerializeField]
    private float genPkPosY = 900;

    /// <summary>
    /// SmallPumpkinの生成個数の上限
    /// </summary>
    private int maxsSNum = 8;
    private int maxPkNum = 1;
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
    ///何秒に１度オブジェクトを出現させるか 
    /// </summary>
    private float timeInterval = 2.0f;
    private float timeInterval_Pk = 5.0f;
    /// <summary>
    /// 秒数をカウントするカウンター 
    /// </summary>
    private float timeCounter = 0;
    private float timeCounterPk = 0;

    private bool _isStart = false;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        Initialize();
    }

    /// <summary>
    /// Initialize this instance.
    /// </summary>
    public void Initialize()
    {
        //Fieldオブジェクトの取り込み
        GameObject field = GameObject.Find("Field") as GameObject;
        //Fieldの端の位置を計算
        fieldPosition = field.transform.position;
        minPosX = fieldPosition.x;  //左下のx座標
        maxPosX = fieldPosition.x + terrainLength;  //右上のx座標
        minPosZ = fieldPosition.z;  // 左下のz座標
        maxPosZ = fieldPosition.z + terrainLength;  //右上のz座標
        _isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart == false)
        {
            return;
        }
        //秒数をカウント
        timeCounter += Time.deltaTime;
        //一定秒数を超えたらtrueになる
        if (timeCounter > timeInterval)
        {
            //秒数カウンターを0で初期化
            timeCounter = 0;

            // 生成するSmallPumpkinPrefab数をランダムに決める
            int n = Random.Range(1, maxsSNum + 1);
            // 生成
            for (int i = 0; i < n; i++)
            {
                //星の生成
                GameObject SmallPumpkin = Instantiate(smallPumpkinPrefab) as GameObject;
                //位置を指定
                SmallPumpkin.transform.position =
                    new Vector3(
                    Random.Range(minPosX, maxPosX),
                    gensSPosY,
                    Random.Range(minPosZ, maxPosZ)
                );
            }
        }


        timeCounterPk += Time.deltaTime * 2;
        if (timeCounterPk > timeInterval_Pk)
        {
            timeCounterPk = 0;

            // 生成するPumpkin_02Prefab数をランダムに決める
            int p = Random.Range(0, maxPkNum + 1);
            // 生成
            for (int m = 0; m < p; m++)
            {
                //Pumpkin_02Prefabの生成
                GameObject Pumpkin_02 = Instantiate(Pumpkin_02Prefab) as GameObject;
                //位置を指定
                Pumpkin_02.transform.position =
                    new Vector3(
                    Random.Range(minPosX, maxPosX),
                    genPkPosY,
                    Random.Range(minPosZ, maxPosZ)
                );
            }
        }
    }

}