using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Vector2 movement;

    public bool attackReady = true;
    public int attackCooldown;
    public int damage = 15;


    public GameObject target;

    Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {


        target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(target);
        
        if (target != null){
            
            
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

            if (attackCooldown > 0){
                attackCooldown -= 1;
            } else if(attackCooldown <= 0){
                attackReady = true;
            }
        }


    }

    void FixedUpdate(){
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        /* transform.position = Vector3.MoveTowards(rb.position, targetPos, moveSpeed); */
    }

    
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Test lul");
        if(col.gameObject.tag == "Player" && attackReady){
            GameObject other = col.gameObject;
            PlayerBehaviour pl = other.GetComponent<PlayerBehaviour>();
            pl.takeDamage(damage);
            attackReady = false;
            attackCooldown = 60;
        }
    }
}
