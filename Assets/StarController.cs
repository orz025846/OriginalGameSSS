using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StarController : MonoBehaviour
{
    // 移動速度のランダム変数用配列
    public float[] speed = { -100.0f, -50.0f };

    // 小星の移動速度
    public float[] speedSs;

    // オブジェクトの消滅位置
    public float deadLine = -175;

    // Use this for initialization
    void Start()
    {
        float aaa = Time.deltaTime;
        float bbb = Time.deltaTime + 0.1f;
        speedSs = new float[] {
            Random.Range (speed [0] * bbb, speed [1] * bbb),
            Random.Range (speed [0] * aaa, speed [1] * aaa),
            Random.Range (speed [0] * aaa, speed [1] * aaa)
        };
    }

    // Update is called once per frame
    void Update()
    {        
        // feldを透過したらオブジェクト消滅
        if (transform.position.y < this.deadLine)
        {
            //１秒後にDestroy
            Destroy(gameObject, 1.0f);
        }        
            // 小星を移動させる
            transform.Translate(speedSs[0], speedSs[1], speedSs[2]);
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