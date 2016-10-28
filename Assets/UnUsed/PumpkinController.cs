using UnityEngine;
using System.Collections;

public class PumpkinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //回転を開始する角度を設定
        this.transform.Rotate(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

        //回転
        this.transform.Rotate(0, 0, 1);

    }
}
