using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private MeshRenderer mr;
    public Color targetColor;
    private Rigidbody rb;
    bool isbomb_on = false;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isbomb_on)
            mr.material.color = Color.Lerp(mr.material.color, targetColor, 0.3f);

        if(mr.material.color == targetColor)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isbomb_on = true;
            Destroy(gameObject, 2);
        }
    }
}
