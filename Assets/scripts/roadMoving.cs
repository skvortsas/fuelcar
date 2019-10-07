using UnityEngine;
using System.Collections;
using System;

public class roadMoving : MonoBehaviour {

    public carMovement car;

    public AudioSource source;

    float secondSpeed = -0.06f, firstSpeed = -0.05f, thirdSpeed = -0.07f, fourthSpeed = -0.08f, fifthSpeed = -0.09f, startSpeed = -0.02f, contSpeed = -0.04f;
    public GameObject wall;
    public GameObject fuel;

    private string carScore;

	// Use this for initialization

    void Awake()
    {
        if (PlayerPrefs.GetInt("SoundOff") == 1)
        {
            source.mute = true;
        }
        else
        {
            source.mute = false;
        }
    }

	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        carScore = car.DataScore;

        int DataScoreInt = Int32.Parse(carScore);

        if (DataScoreInt > 0)
            if (!source.isPlaying)
            {
                source.Play();
            }

        if (!car.is_walled && !car.is_lack)
        {
            if (DataScoreInt > -1)
            {
                transform.Translate(new Vector3(0f, startSpeed, 0f));

                if (DataScoreInt > 5)
                {
                    transform.Translate(new Vector3(0f, contSpeed, 0f));

                    if (DataScoreInt > 15)
                    {
                        transform.Translate(new Vector3(0f, firstSpeed, 0f));

                        if (DataScoreInt > 30)
                        {
                            transform.Translate(new Vector3(0f, secondSpeed, 0f));

                            if (DataScoreInt > 130)
                            {
                                transform.Translate(new Vector3(0f, thirdSpeed, 0f));

                                if (DataScoreInt > 230)
                                {
                                    transform.Translate(new Vector3(0f, fourthSpeed, 0f));

                                    if (DataScoreInt > 330)
                                        transform.Translate(new Vector3(0f, fifthSpeed, 0f));
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            transform.Translate(new Vector3(0f, 0f, 0f));
            source.Stop();
        }


        if (transform.position.y < -16.5f)
        {
            transform.position = new Vector3(transform.position.x, 16.45f, 1f);
            wall.transform.position = new Vector3(4.66f, 1.667f);
            fuel.transform.position = new Vector3(4.46f, 1.668f, fuel.transform.position.z);

            int rand = UnityEngine.Random.Range(0, 4);
            int randIF = UnityEngine.Random.Range(0, 2);
            int randWhere = UnityEngine.Random.Range(0,3);
            switch (rand)
            {
                case 0:
                    switch (randIF)
                    {
                        case 0:
                            fuel.transform.position = new Vector3(6f, 22f, fuel.transform.position.z);
                            break;
                        case 1:
                            switch (randWhere)
                            {
                                case 0:
                                    fuel.transform.position = new Vector3(1.3f, 22f, fuel.transform.position.z);
                                    break;
                                case 1:
                                    fuel.transform.position = new Vector3(-1.3f, 22f, fuel.transform.position.z);
                                    break;
                                case 2:
                                    fuel.transform.position = new Vector3(-3.7f, 22f, fuel.transform.position.z);
                                    break;
                            }
                            break;
                    }
                    wall.transform.position = new Vector3(3.7f, 22f);
                    break;

                case 1:
                    switch (randIF)
                    {
                        case 0:
                            fuel.transform.position = new Vector3(6f, 22f, fuel.transform.position.z);
                            break;
                        case 1:
                            switch (randWhere)
                            {
                                case 0:
                                    fuel.transform.position = new Vector3(3.7f, 22f, fuel.transform.position.z);
                                    break;
                                case 1:
                                    fuel.transform.position = new Vector3(-1.3f, 22f, fuel.transform.position.z);
                                    break;
                                case 2:
                                    fuel.transform.position = new Vector3(-3.7f, 22f, fuel.transform.position.z);
                                    break;
                            }
                            break;
                    }
                    wall.transform.position = new Vector3(1.3f, 22f);
                    break;

                case 2:
                    switch (randIF)
                    {
                        case 0:
                            fuel.transform.position = new Vector3(6f, 22f, -1f);
                            break;
                        case 1:
                            switch (randWhere)
                            {
                                case 0:
                                    fuel.transform.position = new Vector3(3.7f, 22f, fuel.transform.position.z);
                                    break;
                                case 1:
                                    fuel.transform.position = new Vector3(1.3f, 22f, fuel.transform.position.z);
                                    break;
                                case 2:
                                    fuel.transform.position = new Vector3(-3.7f, 22f, fuel.transform.position.z);
                                    break;
                            }
                            break;
                    }
                    wall.transform.position = new Vector3(-1.3f, 22f);
                    break;

                case 3:
                    switch (randIF)
                    {
                        case 0:
                            fuel.transform.position = new Vector3(6f, 22f, fuel.transform.position.z);
                            break;
                        case 1:
                            switch (randWhere)
                            {
                                case 0:
                                    fuel.transform.position = new Vector3(3.7f, 22f, fuel.transform.position.z);
                                    break;
                                case 1:
                                    fuel.transform.position = new Vector3(1.3f, 22f, fuel.transform.position.z);
                                    break;
                                case 2:
                                    fuel.transform.position = new Vector3(-1.3f, 22f, fuel.transform.position.z);
                                    break;
                            }
                            break;
                    }
                    wall.transform.position = new Vector3(-3.7f, 22f);
                    break;
            }
        }
	}
}
