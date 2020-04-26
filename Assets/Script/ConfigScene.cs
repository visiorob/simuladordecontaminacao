using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ConfigScene : MonoBehaviour
{
    [SerializeField]
    private Slider NPeopleSlider;
    [SerializeField]
    private Slider TSickSlider;
    [SerializeField]
    private Slider PIsolationSlider;
    [SerializeField]
    private Slider PInfection_Slider;

    public float people;
    public float sickTime;
    public float isolationPorcet;
    public float infectionChance;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene()
    {
        people = NPeopleSlider.value;
        sickTime = TSickSlider.value;
        isolationPorcet = PIsolationSlider.value;
        infectionChance = PInfection_Slider.value;
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }
}
