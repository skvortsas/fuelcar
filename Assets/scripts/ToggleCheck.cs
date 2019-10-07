using UnityEngine;
using System.Collections;

public class ToggleCheck : MonoBehaviour
{
    public void Checks(bool True)
    {
        if (True)
            PlayerPrefs.SetInt("SoundOff", 1);
        else
            PlayerPrefs.SetInt("SoundOff", 0);
    }
}
