using UnityEngine;
using System.Collections;

public class PersonAI : MonoBehaviour {
    public Sprite[] faces;
    public GameObject player;
    public int state = 0;
    public float rundistance = 1000;
    GameObject Target;
    CharacterController c;
    public AudioClip[] scared;
    // Use this for initialization
    AIFollow ai;
	void Start () {
        c = GetComponent<CharacterController>();
        ai = GetComponent<AIFollow>();
        ai.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        Target = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1)
        {
            ai.enabled = true;
            Vector3 dir = player.transform.position - transform.position;
            Target.transform.position = (-dir * rundistance) + Target.transform.position ;
            ai.target = Target.transform;
            GameObject face = transform.FindChild("Face").gameObject;
            face.GetComponent<SpriteRenderer>().sprite = faces[1];
            GetComponent<AudioSource>().PlayOneShot(scared[Random.Range(0,scared.Length)]);
            state = 2;
        }


        if (!c.isGrounded)
        {
            c.Move(new Vector3(0,-1*ai.speed* Time.deltaTime,0));
        }


	}
}
