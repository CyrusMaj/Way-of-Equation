using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson_MovementController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] float sprintingSpeed = 3f;
    [SerializeField] float stamina = 10f;
    [SerializeField] float dashingMultiplyer = 20f;
    [SerializeField] float jumpFerocity = 10f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

    public Transform character;
    public Transform camera;

    public LayerMask groundLayers;

    private Rigidbody rb;

    bool sprinting = false;
    float originalSpeed;

    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterPosition = character.transform.position;
        Vector3 forwardDirection, rightDirection;
        characterPosition.y = camera.transform.position.y;
        forwardDirection = (characterPosition - camera.transform.position).normalized;
        rightDirection = (camera.transform.right).normalized;

        // Movement: Fast Mobile
        if (Input.GetKey(KeyCode.W))
        {
            character.transform.rotation = camera.transform.rotation;
            transform.Translate(forwardDirection * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            character.transform.rotation = camera.transform.rotation;
            transform.Translate(-forwardDirection * movementSpeed);

        }

        if (Input.GetKey(KeyCode.A))
        {
            character.transform.rotation = camera.transform.rotation;
            transform.Translate(-rightDirection * movementSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            character.transform.rotation = camera.transform.rotation;
            transform.Translate(rightDirection * movementSpeed);
        }

        //Sprinting.
        if (Input.GetKey(KeyCode.LeftShift) && (stamina > 0))
        {
            sprinting = true;
            stamina -= Time.deltaTime;
        }
        else
            sprinting = false;

        if (stamina <= 0)
        {
            sprinting = false;
        }

        if (sprinting == true)
        {
            originalSpeed = movementSpeed;
            movementSpeed = sprintingSpeed;
        }

        if ((sprinting == false) && (stamina <= 10))
        {
            movementSpeed = 0.1f;
            stamina += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            float camRotation = camera.transform.rotation.y;
            float charRotation = character.transform.rotation.y;


        }

        //Jumping

        /*
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpFerocity, ForceMode.Impulse);
        }
        */

        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("JumpingCoroutine");
            }
        }

        //Falling Acceleration
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Dodging and Lunging.
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartCoroutine("DashingCoroutine");
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            //movementSpeed = 0.01f;
        }

    }

    /*
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, 
        col.bounds.center.z), col.radius * .9f, groundLayers);
    }
    */

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

    }

    IEnumerator JumpingCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector3.up * jumpFerocity, ForceMode.Impulse);
        grounded = false;
        StopCoroutine("JumpingCoroutine");
    }

    IEnumerator DashingCoroutine()
    {
        float lungingSpeed = movementSpeed * dashingMultiplyer;
        //float originalSpeed = movementSpeed;
        movementSpeed = lungingSpeed;
        //PlaySound(1);
        yield return new WaitForSeconds(0.1f);
        movementSpeed = 0.1f;
        //StopCoroutine("DashingCoroutine");
    }
}
