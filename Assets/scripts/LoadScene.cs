using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public GameObject Toggle;
    public void SceneByIndex(int SceneIndex)
    {
        checks();
        SceneManager.LoadScene(SceneIndex);
    }

    void checks()
    {
        if (Toggle.GetComponent<Toggle>().isOn == false)
        {
            PlayerPrefs.SetInt("SoundOff", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SoundOff", 0);
        }
    }

}
