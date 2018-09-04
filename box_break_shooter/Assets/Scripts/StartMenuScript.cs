using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

    public string loadLevel;

    public void StartButton()
    {
        SceneManager.LoadScene(loadLevel);
    }

}
