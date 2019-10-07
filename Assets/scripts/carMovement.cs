using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class carMovement : MonoBehaviour {

    public AudioSource source;

    public GameObject WallPanel, FuelPanel, fuel;

    

    public Stat currFuel;

    public Sprite Audi, Black, Orange, Police, Taxi, Mini;

    public roadMoving road;

   
    float speed = 10f, timerToStop;
    Vector3 target = new Vector3();
    bool isMoving = false;

    public string DataScore { get; set; }

    public bool is_walled { get; set; }

    public bool is_lack { get; set; }

    // Use this for initialization
    private void Awake()
    {
        currFuel.Initialize();
        is_walled = false;
        is_lack = false;

        
    }

    void Start()
    {
        SkinChange();
        if (PlayerPrefs.GetInt("SoundOff") == 1)
        {
            source.mute = true;
        }
        else if (PlayerPrefs.GetInt("SoundOff") == 0)
        {
            source.mute = false;
        }
    }


    // Update is called once per frame
    void Update () {

        int DataScoreInt = Int32.Parse(DataScore);

        if (DataScoreInt > 30)
            source.Stop();

        if (!is_walled && !is_lack)
            TouchMove();

        if (isMoving)
        {
            move(target);
        }

        if (!is_walled && !is_lack)
        {
            if (DataScoreInt > -1)
            {
                currFuel.CurrentVal -= Time.deltaTime * 2;

                if (DataScoreInt > 50)
                {
                    currFuel.CurrentVal -= Time.deltaTime * 3;

                    if (DataScoreInt > 230)
                    {
                        currFuel.CurrentVal -= Time.deltaTime * 4;

                        if (DataScoreInt > 330)
                        {
                            currFuel.CurrentVal -= Time.deltaTime * 5;

                            if (DataScoreInt > 630)
                            {
                                currFuel.CurrentVal -= Time.deltaTime * 6;
                            }
                        }
                    }
                }
            }
        }

        lackOfFuel();


        if (PlayerPrefs.GetInt("TopScore") < DataScoreInt)
        {
            PlayerPrefs.SetInt("TopScore", DataScoreInt);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            WallPanel.SetActive(true);
            is_walled = true;
        }
        if (col.gameObject.tag == "fuel")
        {
            fuel.transform.position = new Vector3(6.41f, 0.19f,fuel.transform.position.z);

            currFuel.CurrentVal += 40;
            if (currFuel.CurrentVal > 100)
                currFuel.CurrentVal = 100;
        }
    }

    void move(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        if (transform.position == targetPos)
        {
            isMoving = false;
        }
    }

    void get_movingLeft()
    {
        if (transform.position.x == 3.7f)
        {
            target = new Vector3(1.3f, transform.position.y, transform.position.z);
            isMoving = true;
        }
        else if (transform.position.x == 1.3f)
        {
            target = new Vector3(-1.3f, transform.position.y, transform.position.z);
            isMoving = true;
        }
        else if (transform.position.x == -1.3f)
        {
            target = new Vector3(-3.7f, transform.position.y, transform.position.z);
            isMoving = true;
        }
    }

    void get_movingRight()
    {
        if (transform.position.x == -3.7f)
        {
            target = new Vector3(-1.3f, transform.position.y, transform.position.z);
            isMoving = true;
        }
        else if (transform.position.x == -1.3f)
        {
            target = new Vector3(1.3f, transform.position.y, transform.position.z);
            isMoving = true;
        }
        else if (transform.position.x == 1.3f)
        {
            target = new Vector3(3.7f, transform.position.y, transform.position.z);
            isMoving = true;
        }
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float middle = Screen.width / 2;

            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                get_movingLeft();
            }

            if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                get_movingRight();
            }
        }
    }

    void lackOfFuel()
    {
        if (currFuel.CurrentVal < 0)
        {
            is_lack = true;
            FuelPanel.SetActive(true);
        }
    }

    void SkinChange()
    {
        if (PlayerPrefs.GetInt("ChosenCar") == 0)
            this.GetComponent<SpriteRenderer>().sprite =Audi;
        else if (PlayerPrefs.GetInt("ChosenCar") == 1)
            this.GetComponent<SpriteRenderer>().sprite = Black;
        else if (PlayerPrefs.GetInt("ChosenCar") == 2)
            this.GetComponent<SpriteRenderer>().sprite = Orange;
        else if (PlayerPrefs.GetInt("ChosenCar") == 3)
            this.GetComponent<SpriteRenderer>().sprite = Police;
        else if (PlayerPrefs.GetInt("ChosenCar") == 4)
            this.GetComponent<SpriteRenderer>().sprite = Taxi;
        else if (PlayerPrefs.GetInt("ChosenCar") == 5)
            this.GetComponent<SpriteRenderer>().sprite = Mini;
    }
}
