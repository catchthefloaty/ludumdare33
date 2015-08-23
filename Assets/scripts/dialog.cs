using UnityEngine;
using System.Collections;

public class dialog : MonoBehaviour {
    public float curTime;
    public float lifeTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
	if(curTime > lifeTime)
        {
            curTime = 0;
            
            gameObject.SetActive(false);
        }
	}
}
