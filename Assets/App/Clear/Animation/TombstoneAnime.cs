using DG.Tweening;
using UnityEngine;
using System.Collections;

public class TombstoneAnime : MonoBehaviour {

    

	// Use this for initialization
	void Start () {

        this.gameObject.transform.DOJump(new Vector3(0, 0,2f),
            30f,
            10,
            5f
            );
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
