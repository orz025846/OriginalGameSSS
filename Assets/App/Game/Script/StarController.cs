﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StarController : MonoBehaviour {

    [SerializeField]
    private ParticleSystem _onTappedParticle;

    // オブジェクトの移動速度
    public float[] speed = { -50.0f, -50.0f };  //ランダム変数
    public float[] speedSs;  //移動速度用
    
    // オブジェクトの消滅位置（y座標に設定）
    public float deadLine = -175;

    // Use this for initialization
    void Start () {
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
	void Update () {
        // field（ｙ座標）を透過したらオブジェクト消滅
        if (this.transform.position.y < this.deadLine)
        {
            //１秒後にDestroy
            Destroy(this.gameObject, 1.0f);
        }
        // オブジェクトを移動させる
        this.transform.Translate(speedSs[0], speedSs[1], speedSs[2]);


    }
    /// <summary>
    /// Raises the tapped event.
    /// </summary>
    public void OnTapped()
    {
        //パーティクル再生
        _onTappedParticle.Play();
        //描画しない
        GetComponent<MeshRenderer>().enabled = false;
        //１秒後に削除
        //Destroy(gameObject, 1.0f);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //Field以外に衝突した場合
        if (other.gameObject.tag == "SmallPumpkinTag" || other.gameObject.tag == "PumpkinTag")
        {
            return;
        }
    }

}
