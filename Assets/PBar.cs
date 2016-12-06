using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PBar : MonoBehaviour
{
    [SerializeField]
    private Image progressImage;

    public float FillAmount
    {
        get
        {
            return progressImage.fillAmount;
        }
    }

    public void Initialize()
    {
        progressImage.fillAmount = 0;
    }

    /// <summary>
    /// Sets the value.
    /// </summary>
    /// <param name="value">Value.</param>
    public void AddValue(float value)
    {
        //ゲージを変化させる
        progressImage.fillAmount += value;
        //２０％以下の時
        if (FillAmount <= 0.2f)
        {
            progressImage.color = Color.red;
        }
        else if (0.2f <= FillAmount && FillAmount <= 0.4f)
        {
            progressImage.color = Color.yellow;
        }
    }
}