using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{

    

    // Use this for initialization
    void Start()
    {

        this.transform.Rotate(0, (Input.GetAxis("Horizontal") * 1), 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}