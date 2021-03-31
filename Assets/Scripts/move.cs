using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class variable
{
    static public int score = 0;
    static public int power = 0;
    static public bool startgame = false;
    static public string text ="彈珠台";
}
public class move : MonoBehaviour
{
    public int high = 100;
    public float force = 20;
    public AudioClip start, audio1, audio2, audio3, end;
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.UpArrow)& !variable.startgame & variable.power<=100){
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
                variable.power++;
        }else if(Input.GetKeyUp(KeyCode.UpArrow)){
            variable.startgame = true;
            AudioSource.PlayClipAtPoint(start,Vector3.zero);
            
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
            AudioSource.PlayClipAtPoint(end,Vector3.zero);
            this.transform.position = new Vector3(22.879f,-11.78f,-48.06f);
            variable.startgame = false; variable.text = "彈珠台\n按↑鍵開始";
            AudioSource.PlayClipAtPoint(end,Vector3.zero);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "wall":
                AudioSource.PlayClipAtPoint(audio1, Vector3.zero);
                variable.score+=10;
                break;
            case "stick":
                AudioSource.PlayClipAtPoint(audio2,Vector3.zero);
                variable.score+=10;
                //this.GetComponent<Rigidbody>().AddForce(new Vector3(-1000, 0, 0));
                break;
            case "ground":
            break;
            case "Flipper":
                variable.score+=10;
                break;
            case "specialZone":
                variable.score+=100;
                break;
            case "AddScoreZone":
                variable.score+=5;
                break;
            case "endboard":
                variable.text = "遊戲結束";
                AudioSource.PlayClipAtPoint(end,Vector3.zero);
                this.transform.position = new Vector3(22.879f,-11.78f,-48.06f);
                variable.startgame = false;
                variable.score = 0;
                variable.text = "彈珠台\n按↑鍵開始";
                break;
            default:
                break;
        }
       
    }

}
