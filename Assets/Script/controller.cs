using UnityEngine;

public class controller : MonoBehaviour
{

	private Animator anim;

	private Rigidbody rb;
	public FixedJoystick stick;
	public float speed,jumpspeed;
	bool isGround = true;
	Vector3 movement;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

		float x = stick.Horizontal;
		float y = stick.Vertical;

		//transform.position += new Vector3(0,0,y/10);
		//transform.position += new Vector3(x/10,0,0);

		movement = new Vector3(x, 0.0f, y);
		movement.Normalize();


		//enter trumps speed here!!!
		//rb.velocity = movement * 4f;

		if (x != 0 && y != 0)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}

		if (x != 0 || y!=0)
		{
			anim.SetBool("isWalking", true);
		}
		else
		{
			anim.SetBool("isWalking", false);
		}

		if(Input.GetButtonDown("Jump") && isGround==true)
        {
			jump();
        }
	}

    private void FixedUpdate()
    {
		transform.Translate(movement * speed * Time.deltaTime, Space.World);


	}
	public void jump()
    {
		rb.AddForce(new Vector3(0, jumpspeed, 0), ForceMode.Impulse);
		isGround = false;
		anim.SetBool("isJumping", true);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor")
        {
			isGround = true;
			anim.SetBool("isJumping", false);
		}
    }
}