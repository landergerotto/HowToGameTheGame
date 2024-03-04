using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BaseSpeed;
    public Rigidbody2D Collision; 
    public bool isMoving;

    private Vector2 input;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        this.input.x = Input.GetAxisRaw("Horizontal");
        this.input.y = Input.GetAxisRaw("Vertical");
        this.input = this.input.normalized;

        this.animator.SetFloat("MoveX", this.input.x);
        this.animator.SetFloat("MoveY", this.input.y);

        if (this.input.sqrMagnitude != 0)
            this.isMoving = true;
        else
            this.isMoving = false;

        this.animator.SetBool("isMoving", this.isMoving);
        
    }


    void FixedUpdate()
    {
        this.Collision.MovePosition(
            this.Collision.position 
            + this.input * this.BaseSpeed * Time.deltaTime
        );
    }

    /* 1 to 1 movement */

    // private void CheckInputAndMove()
    // {
    //     // if (this.isMoving)
    //     //     return;

    //     this.input.x = Input.GetAxisRaw("Horizontal");
    //     this.input.y = Input.GetAxisRaw("Vertical");

    //     if (this.input.x != 0) this.input.y = 0;

    //     if ( input != Vector2.zero)
    //     {
    //         var targetPos = transform.position;
    //         targetPos.x += input.x;
    //         targetPos.y += input.y;

    //         StartCoroutine(Move(targetPos));
    //     }
        
    // }
    // public IEnumerator Move(Vector3 targetPos)
    // {
    //     this.isMoving = true;
    //     while( (targetPos - transform.position).sqrMagnitude > Mathf.Epsilon )
    //     {
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, this.BaseSpeed * Time.deltaTime);
    //         yield return null;
    //     }
    //     transform.position = targetPos;
    //     this.isMoving = false;
    // }
}
