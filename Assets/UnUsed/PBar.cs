using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PBar : MonoBehaviour
{
    Image image;
    public GameObject SmallStar;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        // シーン中のGameOverTextオブジェクトを取得
        SmallStar = GameObject.Find("SmallStarPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SmallStar.gameObject.tag == "SmallStarTag")
            {
                image.fillAmount += 0.02f;
                if (image.fillAmount >= 1)
                {
                    image.fillAmount = 0;
                }
            }

        }
            
    }


}