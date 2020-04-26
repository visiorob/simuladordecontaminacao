using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    [SerializeField]
    private Slider mySlider;
    private TextMeshProUGUI myText;
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private bool inter;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        if (inter)
            myText.text = (mySlider.value*multiplier).ToString();
        else
            myText.text = (mySlider.value * multiplier).ToString("F2");
    }

    public void OnValueChanged(float value)
    {
        if (inter)
            myText.text = (value*multiplier).ToString();
        else
            myText.text = (value * multiplier).ToString("F2");
    }
}
