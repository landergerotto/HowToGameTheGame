using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseSpeed;
    public Rigidbody2D body;
    public bool isMoving;

    private Vector2 axisInput;
    private Animator animator;

    private List<KeyCode> allowesKeys;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
    }

    public void Update()
    {
        axisInput.x = Input.GetAxisRaw("Horizontal");
        axisInput.y = Input.GetAxisRaw("Vertical");
        axisInput = axisInput.normalized;

        animator.SetFloat("MoveX", axisInput.x);
        animator.SetFloat("MoveY", axisInput.y);

        isMoving = (axisInput.sqrMagnitude != 0);

        animator.SetBool("isMoving", isMoving);

        UpdateCommands();
    }


    void FixedUpdate()
    {
        body.MovePosition(body.position + baseSpeed * Time.deltaTime * axisInput);
    }

    private void UpdateCommands()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && allowesKeys.Contains(KeyCode.Escape))
            EscapeCommand();

        if (Input.GetKeyDown(KeyCode.Mouse0) && allowesKeys.Contains(KeyCode.Mouse0))
            ClickCommand();

        if (Input.GetKeyDown(KeyCode.Space) && allowesKeys.Contains(KeyCode.Space))
            SpaceCommand();
    }

    private void EscapeCommand()
    {
        Debug.Log("Escape allowed and used!");
    }

    private void ClickCommand()
    {
        Debug.Log("Mouse click allowed and used!");
    }

    private void SpaceCommand()
    {
        Debug.Log("Space allowed and used!");
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
