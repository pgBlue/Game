using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
	public static PlaneController instance;
	public GameObject particle,puff;
	public float planeSpeed,planeSpeedX,planeSpeedY;
	public bool isDead;
	public int stateAnimIndex;
	public Vector2 myGravity;
	public Vector2 startPos;
	public Rigidbody2D myRig2D;
	public AudioClip[] sounds;
	private AudioSource myAudio;
	public Animator myAnim;


	void Awake()
	{
		instance=this;
	}

	// Use this for initialization
	void Start () {
		myRig2D=GetComponent<Rigidbody2D>();
		myAudio=GetComponent<AudioSource>();
		myAnim=GetComponent<Animator>();
		startPos=transform.position;

		stateAnimIndex=1;
		myAnim.SetInteger("State",stateAnimIndex);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
		{

			Physics2D.gravity=myGravity;
			//myAnim.SetInteger("State",stateAnimIndex);
			//transform.GetChild(0).gameObject.SetActive(true);
			myRig2D.simulated=true;
			Movement();
		}
		else
		{
			myRig2D.simulated=false;
		}
	}
	void Movement()
	{
		myRig2D.velocity=new Vector2(planeSpeedX,myRig2D.velocity.y);
		if (Input.GetMouseButtonDown(0))
		{
			transform.rotation=Quaternion.Euler(0,0,5);
			myRig2D.AddForce(Vector2.up*planeSpeedY,ForceMode2D.Impulse);
			Instantiate(puff,new Vector3(transform.position.x-0.6f,transform.position.y),Quaternion.identity);

			myAudio.clip=sounds[0];
			myAudio.Play();
		}
		if (myRig2D.velocity.y<0)
		{
			transform.rotation=Quaternion.Euler(0,0,-10);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag=="Point")
		{
			//tang diem
			Manager.mscore++;
		}
		/* if (other.gameObject.tag=="Star")
		{
			//tang diem
			Manager.mGem++;
			other.gameObject.SetActive(false);

			myAudio.clip=sounds[1];
			myAudio.Play();
		} */
	}
	void OnTriggerExit2D(Collider2D other)
	{
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag=="Ground"||other.gameObject.tag=="Tile")
		{
			
			//die
			Manager.instance.deadCount++;
			isDead=true;
			myRig2D.simulated=false;
			transform.GetChild(0).gameObject.SetActive(false);
			Instantiate(particle,transform.position,Quaternion.identity);
			myAudio.clip=sounds[1];
			myAudio.Play();
		}
	}
}
