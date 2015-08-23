using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {
    public UnityEngine.UI.RawImage black;
    float alpha;
    public float speed;
    public string next;
    public bool fade = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        alpha += speed * Time.deltaTime;
        if (alpha >= 1)
        {
            //
            Application.LoadLevel(next);
        }
        if (Input.anyKeyDown)
        {
            fade = true;
        }

        if (!fade)
        {
            alpha = 0;
        }
        black.color = new Color(black.color.r, black.color.g, black.color.b, alpha);
	}
}
