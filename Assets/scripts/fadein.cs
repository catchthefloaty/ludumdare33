using UnityEngine;
using System.Collections;

public class fadein : MonoBehaviour {
    public float speed;
    float alpha = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(alpha > 0)
        {
            alpha -= speed * Time.deltaTime;
            GetComponent<UnityEngine.UI.RawImage>().color = new Color(0,0,0,alpha);
        }
        else
        {
            enabled = false;
        }
	}
}
