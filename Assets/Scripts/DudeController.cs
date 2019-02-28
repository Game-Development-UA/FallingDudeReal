using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeController : MonoBehaviour
{
    public AudioClip deathClip;
    public AudioSource deathSoundSource;
    public AudioClip fallingClip;
    public AudioSource fallingSoundSource;
    public Collider2D collider;
    public Rigidbody2D body;
    public Transform transform;
    float horiz;
    public float speed;
    float currentY;
    bool can_go_down = true;
    public float deathSpeed;
    public bool dead = false;
    public ScoreKeeper scoreKeeper;
    private int scoreMod = 0;
    private int score = 0;
    private float fallDist = 0;
    public bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        can_go_down = false;
        currentY = 0;
        deathSoundSource.clip = deathClip;
        fallingSoundSource.clip = fallingClip;
    }

    void endGame(){


    }

    // Update is called once per frame
    void Update()
    {
        if(fallDist <= 65 && hasFallen == false){
            fallDist += 1f;
            body.velocity = new Vector2(0f, -deathSpeed);

        }

        if(fallDist >= 65 ){
            hasFallen = true;
        }

        if(hasFallen == true){
            scoreKeeper.UpdateScore(score);
            scoreMod++;

        if(dead == false){ 

        if(currentY <= 4){
            can_go_down = true;
        }else{
            can_go_down = false;
        }

        horiz = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0,0,1 * speed * 25 * Time.deltaTime * 2));
            body.velocity = new Vector2(horiz * speed, body.velocity.y);
            // if(can_go_down && currentY < 5){
            //     currentY = currentY + 1 * Time.deltaTime * 2;
            //     transform.Translate(-Vector3.up * Time.deltaTime * 2, Space.World);
            // }
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0,0,-1 * speed * 25 * Time.deltaTime * 2));
            body.velocity = new Vector2(horiz * speed, body.velocity.y);

            // if(can_go_down && currentY < 5){
            //     currentY= currentY + 1 * Time.deltaTime;
            //     transform.Translate(-Vector3.up * Time.deltaTime * 2, Space.World);
            // }
        }else {
             body.velocity = new Vector2(0f, 0f);
            // if(currentY < 4){
            //     can_go_down = true;
            // }
            // if(currentY > 0){
            //     currentY = currentY - 1 * Time.deltaTime * 2;
            //     transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
            // }  
        }
     }
        if(scoreMod % 10 == 0 && dead == false){
            score += ((int) currentY) + 1;
        }
     }
    }

    void OnCollisionEnter2D( Collision2D col ){
        dead = true;
        body.velocity = new Vector2(0f, -deathSpeed);
        Console.WriteLine("Here");
        collider.isTrigger = true;
        deathSoundSource.Play();
    }      
}


