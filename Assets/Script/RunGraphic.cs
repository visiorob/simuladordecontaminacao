using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGraphic : MonoBehaviour
{
    [SerializeField]
    private GameObject graphicColumn;
    [SerializeField]
    private Transform graphicViewer;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private Settings settingsScript;
    private float whenUpdate;
    private float updateTime;

    // Start is called before the first frame update
    void Start()
    {
        whenUpdate = 0.5f;
        updateTime = 0;
        settings = GameObject.Find("Settings");
        settingsScript = settings.GetComponent<Settings>();

    }

    // Update is called once per frame
    void Update()
    {
        if (settingsScript.sickPeople > 0)
        {
            updateTime -= Time.deltaTime;
            if (updateTime < 0)
            {
                //instantiate new colunm;
                GameObject element = Instantiate(graphicColumn, graphicViewer);
                //GameObject graphicBar = Instantiate(graphicColumn) as GameObject;
                //graphicBar.transform.SetParent(this.transform, false);
                updateTime = whenUpdate;
            }
        }
    }
}
