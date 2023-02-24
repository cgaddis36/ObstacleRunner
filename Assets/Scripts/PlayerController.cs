using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float gravityModifier;
    public float jumpForce;
    public bool isOnGround;
    public bool gameOver = false;
    private Animator playerAnimation;
    public ParticleSystem explosion;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    private bool jumpable = false;
    public int score = 0;
    private bool running = false;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
     }

    // Update is called once per frame
    void Update()
    {  if(!running && Time.time > 1.5)
        {
            running = true;
            playerAnimation.SetFloat("Speed_f", 1.5f);
        }
        jumpable = (jumpCount < 2 || isOnGround);

        if (Input.GetKeyDown(KeyCode.Space) && jumpable && !gameOver)
        {
            jumpCount += 1;
            playerAnimation.SetTrigger("Jump_trig");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        Debug.Log($"Score: {score}");
    }
  
    private void OnCollisionEnter(Collision other) {
      Debug.Log(other.gameObject.name);
      if (other.gameObject.CompareTag("Obstacle")) {
        gameOver = true;
        explosion.Play();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        Debug.Log("Game Over!");
        playerAnimation.SetBool("Death_b", true);
        playerAnimation.SetInteger("DeathType_int", 1);
      } else if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            dirtSplatter.Play();
            isOnGround = true;
        }
    }
}
