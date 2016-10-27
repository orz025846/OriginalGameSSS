using UnityEngine;
using System.Collections;

public class CameraRotetion : MonoBehaviour
{

    private Vector3 mPos;
    //マウスカーソルの位置
    //private float cameraRot = 10.0f;
    //1フレーム前のポジション
    Vector3 lastPosition;
    //カメラの動くスピード
    private float speed = 5f;

    // Use this for initialization
    void Start()
    {

        Debug.Log(this.gameObject.transform.position);
        Debug.Log(Camera.main.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // カーソルの位置座標
            mPos = Input.mousePosition;
            //１フレーム前マウス位置とのの差分
            Vector3 deltaPosition = Input.mousePosition - lastPosition;
            //マウスポジションが動いていないなら
            if (deltaPosition == Vector3.zero)
            {
                return;
            }
            //前フレームのタッチ位置より右なら
            if (deltaPosition.x > 0)
            {
                transform.localEulerAngles += new Vector3(0, speed, 0);
            }
            else
            {
                transform.localEulerAngles += new Vector3(0, -speed, 0);
            }

            lastPosition = mPos;
        }
    }
}