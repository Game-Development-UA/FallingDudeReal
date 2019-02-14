﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	public Transform transform;
	public Collider2D collider;
	public DudeController dude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(!dude.dead)
        	transform.position += new Vector3(0f, Time.deltaTime, 0f);
    }

    void OnCollisionEnter2D( Collision2D col ){
        collider.isTrigger = true;
        transform.position += new Vector3(0f, 0f, 0f);
    }    
}
