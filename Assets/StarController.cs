using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
    // 移動速度のランダム変数用配列
    static public float[] speed = { -20.0f, -5.0f };

    // 小星の移動速度
    static public float[] speedSs = { Random.Range(speed[0], speed[1]), Random.Range(speed[0], speed[1]), Random.Range(speed[0], speed[1]) };
    
    // オブジェクトの消滅位置
    public float deadLine = -175;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // 小星を移動させる
        transform.Translate(speedSs[0], speedSs[1], speedSs[2]);

        // feldを透過したらオブジェクト消滅
        if (transform.position.y < this.deadLine)
        {
            Destroy(gameObject);
        } 
	}
}
