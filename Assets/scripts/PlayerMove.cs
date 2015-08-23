using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public float speed = 1;
    public int talkcount;
    public int killcount;
    public int talkneeded;
    public int killneeded;


    public bool canKill = false;

    public float rotateSpeed = 1;
    GameObject Mycamera;
    public float interactdist = 1;


    public string[] playerdialogs;
    public int currentdialog = 0;
    public UnityEngine.UI.Text dialogText;


    public bool level2 = false;
    public bool level3 = false;

    public string nextlevel;
    public GameObject fade;
    public GameObject swipe;
    public GameObject fkey;

    public AudioClip[] growls;
	// Use this for initialization
	void Start () {
        
        Mycamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
           transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime),Space.Self);
            //transform.Translate(new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,Input.GetAxis("Vertical")*speed*Time.deltaTime));
        }
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            
            Mycamera.transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, 0, 0);
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime,0);
            //Mycamera.transform.rotation = Quaternion.Euler(Mycamera.transform.rotation.eulerAngles.x, Mycamera.transform.rotation.eulerAngles.y,0);
        }

        
        


        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0)),out hit);
            if (hit.collider)
            {
                if (hit.distance < interactdist)
                {
                    PersonAI p = hit.collider.GetComponent<PersonAI>();
                    if (p)
                    {
                        p.state = 1;
                    }

                    dialogText.text = playerdialogs[currentdialog];
                    currentdialog++;
                    if(currentdialog >= playerdialogs.Length)
                    {
                        currentdialog = 0;
                    }
                    dialogText.gameObject.SetActive(true);
                    dialogText.GetComponent<dialog>().curTime = 0;
                    AudioSource.PlayClipAtPoint(growls[Random.Range(0, growls.Length)], transform.position, 0.3f);
                    talkcount++;
                }
            }
            

        }

        if(talkcount > 2)
        {
            canKill = true;
        }
        if (canKill && (level2 || level3))
        {
            fkey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit);
                if (hit.collider)
                {
                    if (hit.distance < interactdist)
                    {
                        PersonAI p = hit.collider.GetComponent<PersonAI>();
                        if (p)
                        {
                            p.state = 1;
                        }
                        p.GetComponent<AudioSource>().enabled = false;
                        swipe.SetActive(true);
                        GetComponent<AudioSource>().Play();

                        killcount++;
                    }
                }

            }
        }




        if (talkcount >= talkneeded)
        {
            fade.GetComponent<fadeout>().enabled = true;
            if (fade.GetComponent<UnityEngine.UI.RawImage>().color.a >= 1)
            {
                Application.LoadLevel(nextlevel);
            }
        }
        if(killcount >= killneeded)
        {
            fade.GetComponent<fadeout>().enabled = true;
            if (fade.GetComponent<UnityEngine.UI.RawImage>().color.a >= 1)
            {
                Application.LoadLevel(nextlevel);
            }
        }
        




	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Person")
        {
            Application.LoadLevel("test 3");
        }
    }
}
