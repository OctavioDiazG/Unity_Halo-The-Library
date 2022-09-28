using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Extension para manejar escenas

public class SceneLoader : MonoBehaviour
{ 
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void LevelChanger(string _levelToLoad)
    {
        SceneManager.LoadScene(_levelToLoad);
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() 
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Final");
        if(other.tag == "Player")
            LevelChanger("final");
    }
}
