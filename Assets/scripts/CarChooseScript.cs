using UnityEngine;
using System.Collections;

public class CarChooseScript : MonoBehaviour
{
    public void ChooseCar(int skinNumber)
    {
        PlayerPrefs.SetInt("ChosenCar", skinNumber);
    }
}
