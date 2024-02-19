using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class FlyScript : MonoBehaviour
{
    public static event Action deathEvent;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotation = 10f;

    private Rigidbody2D _rb;
    private bool _flapped = false;
    private bool canFlap = true;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioDie;
    [SerializeField] private AudioClip audioFall;
    [SerializeField] private AudioClip audioFlap;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlap)
        {
            if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
                Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!_flapped)
                {
                    _flapped = true;
                    _rb.gravityScale = 0.8f;
                    GameManagerScript.Instance.StartFlapping();
                    PipeManagerScript.Instance.BeginSpawnCycle();
                }

                _rb.velocity -= _rb.velocity;
                _rb.velocity += Vector2.up * speed;
                audioSource.PlayOneShot(audioFlap);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * rotation);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        deathEvent();
        if (canFlap)
        {
            audioSource.PlayOneShot(audioFall);
            audioSource.PlayOneShot(audioDie);
            canFlap = false;
            GameManagerScript.Instance.GameOver();
        }
    }
}