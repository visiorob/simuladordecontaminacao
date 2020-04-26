using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public float sickTime = 20f;
    public float isolationPorcet = 0.90f;
    public float chanceToGetSick = 1f;

    public int stoppedPeople = 0;
    public int movingPeople = 0;

    public int healthPeople = 1;
    public int sickPeople = 0;
    public int curedPeople = 0;

    [SerializeField]
    private TextMeshProUGUI nHealth;
    [SerializeField]
    private TextMeshProUGUI nSick;
    [SerializeField]
    private TextMeshProUGUI nCured;

    [SerializeField]
    private GameObject person;
    [SerializeField]
    private GameObject leftWall;
    [SerializeField]
    private GameObject rigthWall;
    [SerializeField]
    private GameObject topWall;
    [SerializeField]
    private GameObject bottonWall;

    [SerializeField]
    private GameObject graphicColumn;
    [SerializeField]
    private Transform graphicViewer;
    private GameObject element;

    [SerializeField]
    private GameObject config;
    [SerializeField]
    private Settings configScript;

    [SerializeField]
    private Button restarButtom;

    public float people = 10;

    void Start()
    {
        config = GameObject.Find("Simulation Config");
//        configScript = config.GetComponent<ConfigScene>();

        people = config.GetComponent<ConfigScene>().people;
        isolationPorcet = config.GetComponent<ConfigScene>().isolationPorcet;
        sickTime = config.GetComponent<ConfigScene>().sickTime;
        chanceToGetSick = config.GetComponent<ConfigScene>().infectionChance;

        float spanXMin = leftWall.transform.position.x + 0.5f;
        float spanXMax = rigthWall.transform.position.x - 0.5f;
        float spanYMin = bottonWall.transform.position.y + 0.5f;
        float spanYMax = topWall.transform.position.y - 0.5f;

        healthPeople = 0;

        for (int i = 1; i< people; i++)
        {
            Vector2 position = new Vector2(Random.Range(spanXMin, spanXMax), Random.Range(spanYMin, spanYMax));
            Instantiate(person, position, Quaternion.identity);
            healthPeople++;
        }
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (healthPeople < 0)
        {
            healthPeople = 0;
        }
        if (sickPeople < 0)
        {
            sickPeople = 0;
        }
        if (curedPeople < 0)
        {
            curedPeople = 0;
        }
        nHealth.text = healthPeople.ToString();
        nSick.text = sickPeople.ToString();
        nCured.text = curedPeople.ToString();
        if (sickPeople < 1)
        {
            restarButtom.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Reset()
    {
        Destroy(config);
        SceneManager.LoadScene("ConfigScene", LoadSceneMode.Single);
    }

}
