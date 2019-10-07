using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneinPlay : MonoBehaviour {

    public void SceneByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

}
