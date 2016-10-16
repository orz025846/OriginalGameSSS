using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour
{
    // smallStarのPrefab
    public GameObject smallStarPrefab;

    // smallStarの生成位置
    //>public Vector3 genPos = new Vector3(-690.0f, -170.0f, 259.0f);
    public float genPosZ = 259;

    // smallStarの生成個数の上限
    private int maxsSNum = 8;

    private Vector3 fieldPosition;
    private float minPosX = 0.0f;
    private float minPosY = 0.0f;
    private float terrainLength = 1500.0f;

    // Use this for initialization
    void Start()
    {

        //追記ぶん(Fieldオブジェクトの取り込み）
        GameObject field = GameObject.Find("Field") as GameObject;
        fieldPosition = field.transform.position;
        Debug.Log(fieldPosition);
        //端の位置を計算
        minPosX = fieldPosition.x + terrainLength / 2;
        //minPosY = fieldPosition.y - terrainLength / 2;

        //惑星が全て収まるように、最大個数のときの間隔を計算
        float interval = terrainLength / maxsSNum;

        // 生成するPrefab数をランダムに決める
        int n = Random.Range(1, maxsSNum + 1);
        // 生成
        for (int i = 0; i < n; i++)
        {
            //星の生成
            GameObject smallStar = Instantiate(smallStarPrefab) as GameObject;
            smallStar.transform.position = new Vector3(minPosX + interval * i, minPosY + interval * i, genPosZ * i);
            //変更ぶん
            //smallStar.transform.position = new Vector3(minPosX * interval * i, minPosY * interval * i, genPosZ * i);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}