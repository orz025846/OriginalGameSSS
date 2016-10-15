using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour {
    // smallStarのPrefab
    public GameObject smallStarPrefab;

    // smallStarの生成位置
    //public Vector3 genPos = new Vector3(900.0f, 500.0f, 900.0f);
    public float genPosX = 900;
    public float genPosY = 500;
    public float genPosZ = 900;

    // smallStarの生成個数の上限
    private int maxsSNum = 8;

    // Use this for initialization
    void Start () {

        // 生成するPrefab数をランダムに決める
        int n = Random.Range(1, maxsSNum + 1);
        // 生成
        for (int i = 0; i < n; i++)
        {
            GameObject smallStar = Instantiate(smallStarPrefab) as GameObject;
            smallStar.transform.position = new Vector3(genPosX + i, genPosY * i, genPosZ * i);
        }
	}

    // Update is called once per frame
    void Update()
    {

    }
}
