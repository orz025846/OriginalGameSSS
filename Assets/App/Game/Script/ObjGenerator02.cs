using UnityEngine;
using System.Collections;

public class ObjGenerator02 : MonoBehaviour {

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
    /// SmallPumpkinの生成個数の初期値maxと画面上個数の下限min
    /// </summary>
    private int maxsSNum = 20;
    private int minsSNum = 8;
    private int maxPkNum = 3;
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
    
    /// <summary>
    /// 秒数をカウントするカウンター 
    /// </summary>
    private float timeCounter = 0;
    private float timeCounterPk = 0;

    private bool _isStart = false;

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

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        Initialize();


        // SmallPumpkinPrefabを生成する
        int n = maxsSNum;
        // 生成
        for (int i = 0; i < n + 1; i++)
        {
            //SmallPumpkinの生成
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

    // Update is called once per frame
    void Update()
    {

    }

}