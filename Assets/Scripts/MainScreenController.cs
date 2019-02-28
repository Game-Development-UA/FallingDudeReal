using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScreenController : MonoBehaviour
{
	public string gameScene;
	public string mainScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void newGame(){
    	SceneManager.LoadScene(gameScene);
    }

    public void loadMain(){
    	SceneManager.LoadScene(mainScene);
    }
}
