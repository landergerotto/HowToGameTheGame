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

    public void Start()
    {
        InputValid.EnableKey(KeyCode.W);
        InputValid.EnableKey(KeyCode.A);
        InputValid.EnableKey(KeyCode.S);
        InputValid.EnableKey(KeyCode.D);
    }

    public void Update()
    {
        //this.input.x = Input.GetAxisRaw("Horizontal");
        input.x = 0;
        if (InputValid.GetKey(KeyCode.A))
            input.x--;
        if (InputValid.GetKey(KeyCode.D))
            input.x++;

        //this.input.y = Input.GetAxisRaw("Vertical");
        input.y = 0;
        if (InputValid.GetKey(KeyCode.W))
            input.y++;
        if (InputValid.GetKey(KeyCode.S))
            input.y--;

        input = input.normalized;

        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);

        /*if (input.sqrMagnitude != 0)
            isMoving = true;
        else
            isMoving = false;*/
        isMoving = input.sqrMagnitude != 0;

        animator.SetBool("isMoving", isMoving);

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
