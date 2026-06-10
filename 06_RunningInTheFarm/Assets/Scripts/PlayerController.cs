using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityModifier = 1f;
    public bool gameOver = false;

    private bool isOnGround = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {   
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }

}
