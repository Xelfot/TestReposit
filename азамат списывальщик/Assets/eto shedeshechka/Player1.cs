using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    [SerializeField] private AudioSource JUMPSOUND;
    public Vector2 moveVector;
    public int hp;
    public int maxhp;
    public GameObject[] Batary;
    public Joystick joy;
    public void Takehit(int damage)
        
    {
        if (hp > 0)
        {
            Batary[3 - hp].SetActive(false);
           

           
        }

         hp -= damage;
            

        if (hp > 0)
        {
            Batary[3 - hp].SetActive(true);
            


        }

        if (hp <= 0)
        {
            panel.SetActive(true);

        }
    }
    [SerializeField]
    GameObject attackPos;


    Rigidbody2D rb;
    public float speed;
    public Animator animator;

    public GameObject panel;

    public bool IsAttacking;
    bool FaceRight = true;

    public float jumpHeigt;
    public Transform groundCheck;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        for (int i = 0; i < Batary.Length; i++)
        {
            if (i == 0)
            {
                Batary[i].SetActive(true);
            }
            else
            {
                Batary[i].SetActive(false);
            }

        }
        attackPos.SetActive(false);
    }

    void Update()
    {

        Walk();
        Attack();
        Stay();
        Dash();
        Jump();
        GroundCheck();
        if (FaceRight && Input.GetAxis("Horizontal") < 0)
        {
            Flip();
        }
        else if (!FaceRight && Input.GetAxis("Horizontal") > 0)
        {
            Flip();

        }

        
    }
    void FixedUpdate()
    {
    }

    void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 A = transform.localScale;
        A.x *= -1;
        transform.localScale = A;
    }




    public void Jump()
    {

        if (isGrounded && !IsAttacking)
        {
            rb.velocity = Vector2.up * jumpHeigt;
            print(true);
            JUMPSOUND.Play();
        }


    }


    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
        {
            animator.SetInteger("State", 2);
        }

    }
    void Stay()
    {
        if (Input.GetAxis("Horizontal") == 0 && isGrounded && !IsAttacking)
        {
            animator.SetInteger("State", 1);
        }
        else
        {

            if (isGrounded && ! IsAttacking)
            {
                animator.SetInteger("State", 3);
            }
        }






    }



    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsAttacking == false)
        {
            IsAttacking = true;

            animator.SetInteger("State", 7);


            StartCoroutine(DoAttack());
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator DoAttack()
    {
        attackPos.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attackPos.SetActive(false);

        IsAttacking = false;

    }
    bool IsDash = false;
    public int DashHeigh;
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.E) && !IsDash)
        {
            if (FaceRight)
            {
                animator.SetInteger("State", 8);
                IsDash = true;
                rb.velocity = Vector2.right * DashHeigh;
                StartCoroutine(WaitForDash());
            }
            else
            {
                animator.SetInteger("State", 8);
                IsDash = true;
                rb.velocity = Vector2.left * DashHeigh;
                StartCoroutine(WaitForDash());
            }


        }
    }

    IEnumerator WaitForDash() 
    {
      //  yield return new WaitUntil();
        yield return new WaitForSeconds(2f);
        IsDash = false;
        
    }
    private void Walk()
    {
        if (Mathf.Abs(moveVector.x) > 0.1 || Mathf.Abs(moveVector.y) > 0.1)
        {
            animator.SetInteger("idle", 1);

        }
      
        moveVector.x = joy.Horizontal;
        
        transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(moveVector.x, moveVector.y) * 4f, Time.deltaTime * 2);

    }




}

