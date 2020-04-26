using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Person : MonoBehaviour
{
    private CircleCollider2D playerCollider;
    private GameObject otherPerson;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private Settings settingsScript;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private float movmentNorm;
    [SerializeField]
    private float sickTime;
    [SerializeField]
    private float isolationPorcet;
    [SerializeField]
    private float chanceToMove;
    public bool isHeath = true;
    public bool isSick;
    public bool wasSick;
    [SerializeField]
    private bool fist;
    [SerializeField]
    private bool movable;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("Settings");
        settingsScript = settings.GetComponent<Settings>();
        rb2d = GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if (Mathf.Abs(movement.x) < 0.2f)
        {
            movement.x = 1f * Mathf.Sign(movement.x);
        }
        if (Mathf.Abs(movement.y) < 0.2f)
        {
            movement.y = 1f * Mathf.Sign(movement.y);
        }
        movmentNorm = Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.y, 2));
        sickTime = settingsScript.sickTime;
        isolationPorcet = settingsScript.isolationPorcet;
        chanceToMove = Random.Range(0f, 1f);
        if (fist)
        {
            chanceToMove = 2;
            GetSick();
        }
        if (isolationPorcet > chanceToMove)
        {
            movable = false;
            settingsScript.stoppedPeople++;
        }
        else
        {
            movable = true;
            settingsScript.movingPeople++;
        }
        if (movable)
        {
            rb2d.AddForce(new Vector2(movement.x * 100, movement.y * 100));
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.magnitude < 2f)
        {
            rb2d.AddForce(rb2d.velocity);
        }
        if (isSick)
        {
            sickTime -= Time.deltaTime;
            if (sickTime < 0)
            {
                GetBetter();
            }
        }
    }
    void GetSick()
    {
        float myInfectionChance = Random.Range(0f, 1f);
        if (isHeath)
        {
            if (settingsScript.chanceToGetSick > myInfectionChance)
            {
                settingsScript.sickPeople++;
                settingsScript.healthPeople--;
                isHeath = false;
                isSick = true;
                SpriteRenderer color = GetComponent<SpriteRenderer>();
                color.color = new Color32(219, 166, 55, 255);
            }
        }
    }
    void GetBetter()
    {
        if (isSick)
        {
            settingsScript.sickPeople--;
            settingsScript.curedPeople++;
            isSick = false;
            wasSick = true;
            SpriteRenderer color = GetComponent<SpriteRenderer>();
            color.color = new Color32(248, 141, 210, 255);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Person>().isSick)
            {
                GetSick();
            }
        }
    }
}