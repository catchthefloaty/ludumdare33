using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour {
    public float time;
    float curTime;
    int curSprite;

    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if (curTime > time)
        {
            curSprite++;
            if (curSprite >= sprites.Length)
            {
                curSprite = 0;
                curTime = 0;
                gameObject.SetActive(false);
            }
            GetComponent<SpriteRenderer>().sprite = sprites[curSprite];
            curTime = 0;
        }
	}
}
