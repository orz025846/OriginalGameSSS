using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour {

    [SerializeField]
    private Button _buttonOC;

    // Use this for initialization
    void Start () {
        
        _buttonOC.onClick.AddListener(() => {
            SceneManager.LoadScene("Start");
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
