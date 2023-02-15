using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    private Animator anim;
    public CharacterController cc;
    public float speed;
    Vector3 movedirection;
    public float rotationspeed;
    public FixedJoystick stick;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //movedirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movedirection = new Vector3(stick.Horizontal, 0, stick.Vertical);
        movedirection.Normalize();

        transform.Translate(movedirection * speed * Time.deltaTime, Space.World);

        if (stick.Horizontal != 0 && stick.Vertical != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(movedirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);
        }

        cc.Move(movedirection * speed * Time.deltaTime);
        movedirection.y -= 10 * Time.deltaTime;


        if (movedirection.sqrMagnitude >= 0.1)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
        //###############################################
    

    }
    private void FixedUpdate()
    {
        
    }


}
