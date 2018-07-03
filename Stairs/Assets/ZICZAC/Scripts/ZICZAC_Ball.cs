using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZICZAC_Ball : MonoBehaviour {
	public static ZICZAC_Ball instance;
	public GameObject particle,textScore;
	public AudioClip gemSound;
	public bool isDead,isDirection;
	public float speed;
	public Rigidbody myRig;
	public Vector3 startPos;
	public int deadCount;
	private float timer=5;
	
	private int nextScore=100;
	private AudioSource myAudio;
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
		startPos=transform.position;
		myRig=GetComponent<Rigidbody>();
		myAudio=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ZICZAC_Manger.instance.isPlaying)
		{
			if (!isDead)
			{
				if (ZICZAC_Manger.mScore>nextScore)
				{
					nextScore+=100;
					if (speed>20)
					{
						speed=20;
					}
					else
					{
						speed+=2;
					}	
				}
				myRig.isKinematic=false;
				Movement();
			}
			else
			{
				
				timer-=Time.deltaTime;
				if (timer<0)
				{
					myRig.isKinematic=true;
				}
			}
		}
		
	}
	void Movement()
	{
		/* if (Input.touchCount>0)
		{
			Touch touch=Input.GetTouch(0);
			switch (touch.phase)
			{
				case TouchPhase.Ended:
				 	isDirection=!isDirection;
					ZICZAC_Manger.mScore++;
				break;
			}
		} */
		if (Input.GetMouseButtonDown(0))
		{
			isDirection=!isDirection;
			ZICZAC_Manger.mScore++;
		}
		if (isDirection)
		{
			transform.Translate(Vector3.forward*speed*Time.deltaTime);
			/* myRig.velocity=new Vector3(myRig.velocity.x,
				myRig.velocity.y,speed); */
		}
		else
		{
			transform.Translate(Vector3.left*speed*Time.deltaTime);
			/* myRig.velocity=new Vector3(-speed,
				myRig.velocity.y,
				myRig.velocity.z); */
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag=="box")
		{
			isDead=false;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag=="box")
		{
			isDead=true;
			
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Gem")
		{
			//tang diem
			ZICZAC_Manger.mScore+=2;
			other.gameObject.SetActive(false);
			Instantiate(particle,transform.position,Quaternion.identity);
			Instantiate(textScore,transform.position,Quaternion.identity);
			myAudio.clip=gemSound;
			myAudio.Play();
			ZICZAC_CreateCube.instance.gemCount++;	
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag=="Start")
		{
			speed=10;
		}
	}
}
