using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StarController : MonoBehaviour
{
    // 移動速度のランダム変数用配列
    public float[] speed = { -2.0f, -0.05f };

    // 小星の移動速度
    public float[] speedSs;

    // オブジェクトの消滅位置
    public float deadLine = -175;

    // Use this for initialization
    void Start()
    {
        speedSs = new float[] {
            Random.Range (speed [0], speed [1]),
            Random.Range (speed [0], speed [1]),
            Random.Range (speed [0], speed [1])
        };
    }

    // Update is called once per frame
    void Update()
    {
        // 小星を移動させる
        transform.Translate(speedSs[0], speedSs[1], speedSs[2]);

        // feldを透過したらオブジェクト消滅
        if (transform.position.y < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Field以外に衝突した場合
        if (other.gameObject.tag == "SmallStarTag")
        {
            return;
        }
        GetComponent<ParticleSystem>().Play();
    }

}