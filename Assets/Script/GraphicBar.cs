using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicBar : MonoBehaviour
{
    public Component[] bars;

    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private Settings settingsScript;


    // Start is called before the first frame update
    void Start()
    {

        settings = GameObject.Find("Settings");
        settingsScript = settings.GetComponent<Settings>();

        int curedCounter = settingsScript.curedPeople;
        int healthCounter = settingsScript.healthPeople;
        int sickCounter = settingsScript.sickPeople;

        float sickBarSize = 33;
        float healthBarSize = 33;
        float curedBarSize = 34;

        sickBarSize = (100 * sickCounter) / (sickCounter + healthCounter + curedCounter);
        healthBarSize = (100 * healthCounter) / (sickCounter + healthCounter + curedCounter);
        curedBarSize = 100 - sickBarSize - healthBarSize;
        
        bars = gameObject.GetComponentsInChildren<RawImage>();
        if (bars != null)
        {
            foreach (RawImage bName in bars)
            {
                if (bName.name == "Cured_Counter")
                {
                    //print("curedBarSize = " + curedBarSize);
                    bName.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, curedBarSize);
                }

                if (bName.name == "Health_Counter")
                {
                    //print("healthBarSize = " + healthBarSize);
                    bName.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, healthBarSize);
                }

                if (bName.name == "Sick_Counter")
                {
                    //print("sickBarSize = " + sickBarSize);
                    bName.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sickBarSize);
                }
            }
        }
    }
}
