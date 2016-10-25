using UnityEngine;
using System.Collections;

public class CameraRotetion : MonoBehaviour {

    private Vector3 mPos; //マウスカーソルの位置
    private float cameraRot = 10.0f;  //カメラの移動量

	// Use this for initialization
	void Start () {

        Debug.Log(this.gameObject.transform.position);
        Debug.Log(Camera.main.transform.position);
	
	}
	
	// Update is called once per frame
	void Update () {
        // カーソルの位置座標
        mPos = Input.mousePosition;
        
            // カーソル位置が中心より右＞＞右に移動
       

            // カーソル位置が中心より左＞＞左に移動
        	
	}
}
