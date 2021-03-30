using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class variable
{
    static public int score = 0;
    static public int power = 0;
    static public bool startgame = false;
    static public string text ="彈珠檯";
}
public class move : MonoBehaviour
{
    public int high = 100;
    public float force = 20;
    public AudioClip audio1, audio2;
    // Update is called once per frame
    private int stop = 0;
    void Update()
    {
        if ( Input.GetKey(KeyCode.UpArrow)& !variable.startgame){
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
            if (variable.power <= 100) variable.power++;
            else variable.power=0;
        }else if(Input.GetKeyUp(KeyCode.UpArrow)){
            // this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 100*variable.power));
            variable.startgame = true;
            
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-force, 0, 0));
        }

        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -force));
        }

        if (Input.GetKey(KeyCode.D) )
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0, 0));
        }

        if (Input.GetKey(KeyCode.R) )
        {
            variable.text = "遊戲結束";
            this.transform.position = new Vector3(22.879f,-11.78f,-48.06f);
            variable.startgame = false;
            variable.text = "彈珠台\n按↑鍵開始";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "wall")
        {
            //this.GetComponent<AudioSource>().Play();
            AudioSource.PlayClipAtPoint(audio1, Vector3.zero);
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(-1000, 0, 0));
        }
        if (collision.gameObject.tag == "stick")
        {
            //this.GetComponent<AudioSource>().Play();
            AudioSource.PlayClipAtPoint(audio2,Vector3.zero);
            variable.score++;
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(-1000, 0, 0));
        }

        if (collision.gameObject.tag == "ground"){
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(0, high, 0));
            high = high - 20;  
        }

        if(collision.gameObject.tag == "Flipper"){
            variable.score+=10;
        }

        if(collision.gameObject.tag == "specialZone"){
            variable.score+=100;
        }

        if(collision.gameObject.tag == "AddScoreZone"){
            variable.score+=5;
        }

        if(collision.gameObject.tag == "endboard"){
            variable.text = "遊戲結束";
            this.transform.position = new Vector3(22.879f,-11.78f,-48.06f);
            variable.startgame = false;
            variable.score = 0;
            variable.text = "彈珠台\n按↑鍵開始";
        }
    }

}
