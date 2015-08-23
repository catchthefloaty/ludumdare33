using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.anyKeyDown)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
