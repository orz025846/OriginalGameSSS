using DG.Tweening;
using UnityEngine;
using System.Collections;

public class RotateUI : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.DOBlendableRotateBy(new Vector3(-270, 0, 0), 1.0f).SetLoops(-1);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
