using DG.Tweening;
using UnityEngine;
using System.Collections;

public class PumpkinController : MonoBehaviour {
    private Rigidbody pkRigidbody;
    private float upforce = 200.0f;

	// Use this for initialization
	void Start () {

        // pumpkin_02の回転を開始する角度を設定
        this.transform.Rotate(0, 0, 0);

        this.pkRigidbody = GetComponent<Rigidbody>();

        //transform.DOBlendableRotateBy(new Vector3(-270, 0, 0), 1.0f).SetLoops(-1);


    }

    // Update is called once per frame
    void Update () {
        //回転
        this.transform.Rotate(0, 0, 1);
        float up = 0;
        up += upforce;

        if (this.gameObject.tag == "PumpkinBombTag")
        {
            this.transform.Rotate(0, 0, 0);
            // 上方向に加速
            this.pkRigidbody.AddForce(this.transform.forward * up);
            if(this.gameObject.transform.position.y > 10000)
            {
                Destroy(this.gameObject);
            }
        }
        return;

    }

}
