using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class barScript : MonoBehaviour {

    [SerializeField]
    private float fillAmmount;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmmount != content.fillAmount)
        {
            content.fillAmount = fillAmmount;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
