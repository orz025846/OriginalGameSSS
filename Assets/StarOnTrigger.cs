using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StarOnTrigger : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}


    void OnTriggerEnter(Collider other)
    {
        //Field以外に衝突した場合
        if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "pumpkin_02Prefab")
        {
            return;
        }
        GetComponent<ParticleSystem>().Play();
    }

}
