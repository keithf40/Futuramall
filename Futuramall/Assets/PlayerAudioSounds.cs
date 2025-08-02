using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootstepAudio : MonoBehaviour
{
    [Header("Footstep Clips")]
    public AudioClip walkLeftClip;
    public AudioClip walkRightClip;
    public AudioClip runLeftClip;
    public AudioClip runRightClip;

    [Header("Jump Clips")]
    public AudioClip jumpStartClip;
    public AudioClip jumpLandClip;

    [Header("Step Timing")]
    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.3f;

    private AudioSource audioSource;
    private bool isGrounded = true;
    private bool isLeftFoot = true;
    private float stepTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleFootsteps();
        HandleJumpStart();
    }

    void HandleFootsteps()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (isMoving && isGrounded)
        {
            stepTimer += Time.deltaTime;
            float interval = isSprinting ? runStepInterval : walkStepInterval;

            if (stepTimer >= interval)
            {
                PlayFootstep(isSprinting);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void HandleJumpStart()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            audioSource.PlayOneShot(jumpStartClip);
        }
    }

    void PlayFootstep(bool isSprinting)
    {
        AudioClip clip = null;

        if (isSprinting)
            clip = isLeftFoot ? runLeftClip : runRightClip;
        else
            clip = isLeftFoot ? walkLeftClip : walkRightClip;

        audioSource.PlayOneShot(clip);
        isLeftFoot = !isLeftFoot;
    }

    void OnCollisionStay(Collision collision)
    {
        if (!isGrounded)
        {
            isGrounded = true;
            audioSource.PlayOneShot(jumpLandClip);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
