using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeController : MonoBehaviour
{
    public Collider2D collider;
    public Rigidbody2D body;
    public Transform transform;
    float horiz;
    public float speed;
    float ydistance = 5;
    float currentY;
    bool can_go_down = true;
    public float deathSpeed;
    public bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        currentY = 0;
    }

    // void OnCollisionEnter(Collision col){
    //                 Debug.Log(col.gameObject.name);

    //     if(col.gameObject.name == "RightWall" || col.gameObject.name == "LefttWall"){
    //         body.velocity = new Vector2(0, body.velocity.y * -2);
    //         Debug.Log(col.gameObject.name);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
       if(!dead){ 
        if(currentY <= 5){
            can_go_down = true;
        }else{
            can_go_down = false;
        }

        horiz = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0,0,1 * speed * 25 * Time.deltaTime));
            body.velocity = new Vector2(horiz * speed, body.velocity.y);
            if(can_go_down && currentY < 5){
                currentY = currentY + 1 * Time.deltaTime;
                transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
                //transform.position = new Vector2(transform.position.x, transform.position.y--);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0,0,-1 * speed * 25 * Time.deltaTime));
            body.velocity = new Vector2(horiz * speed, body.velocity.y);
            if(can_go_down && currentY < 5){
                currentY= currentY + 1 * Time.deltaTime;
                transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
                //transform.position = new Vector2(transform.position.x, transform.position.y--);
            }
        }else {
            body.velocity = new Vector2(0f, 0f);
            if(currentY < 5){
                can_go_down = true;
            }
            if(currentY > 0){
                currentY = currentY - 1 * Time.deltaTime * 2;
                transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
 //               transform.position = new Vector2(transform.position.x, transform.position.y++);
            }  
        }
     }
    }

    void OnCollisionEnter2D( Collision2D col ){
        dead = true;
        body.velocity = new Vector2(0f, -deathSpeed);
        Console.WriteLine("Here");
        collider.isTrigger = true;
    }      
}


