using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScreenController : MonoBehaviour
{
	public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void newGame(){
    	SceneManager.LoadScene(sceneName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
