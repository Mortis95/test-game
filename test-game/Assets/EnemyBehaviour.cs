using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
     public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Vector2 movement;


    public GameObject target;

    Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {
        //Input
        float xToTarget = target.transform.position.x - rb.position.x;
        float yToTarget = target.transform.position.y - rb.position.y;
        
        if(xToTarget < -0.5){
            movement.x = -1;
        } else if (xToTarget > 0.5){
            movement.x = 1;
        }
        if(yToTarget < -0.5){
            movement.y = -1;
        } else if(yToTarget > 0.5){
            movement.y = 1;
        }

    }

    void FixedUpdate(){
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        /* transform.position = Vector3.MoveTowards(rb.position, targetPos, moveSpeed); */
    }

    private void OnCollisionEnter(Collision col){
    
    }
}
