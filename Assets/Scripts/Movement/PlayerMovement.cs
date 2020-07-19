using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runspeed = 40f;
    public bool playerrod = false;
    public bool fishing = false;

    bool collided = false;
    float horizontalMove = 0f;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;

        if (fishing)
            horizontalMove = 0;

        if (!collided)
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (collided)
            animator.SetFloat("Speed", 0);

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonUp(0) && !fishing)
        {
            if (playerrod)
            {
                animator.SetTrigger("MouseClick");
                gm.clickedleft = true;
                animator.ResetTrigger("MouseClickRight");
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (playerrod)
            {
                animator.SetTrigger("MouseClickRight");
                gm.clickedrigt = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            return;

        collided = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            return;

        collided = false;
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }
}
