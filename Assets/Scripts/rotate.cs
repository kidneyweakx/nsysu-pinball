using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private bool flags = true;

    // Update is called once per frame
    private int rcount = 0;
    void Update()
    {
        //gameObject.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
        if (Input.GetKey(KeyCode.R) && flags)
        {
            this.GetComponent<Transform>().Rotate(Vector3.up, 0.1f);
            flags = !flags;
        }
        else
        {
            if (!Input.GetKey(KeyCode.R))
                flags = !flags;
        }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            this.GetComponent<Transform>().Rotate(Vector3.up, 0.5f);
            rcount++;
            if (rcount == 16) rcount = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            this.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(500*rcount, 0, 50*(16-rcount)));
        }

    }
}