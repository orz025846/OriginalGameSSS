using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // カメラの移動速度
    public float rotaSpeed = 50.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        { 
            float rota = rotaSpeed * Time.deltaTime;  //移動
            transform.Rotate(0, rota, 0);  //回転
        }
    }

}