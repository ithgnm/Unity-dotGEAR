using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower;
    public float smoothPower;

    public AudioClip wingSound;
    public AudioClip dieSound;

    private GameObject gameController;
    private AudioSource audioSource;

    private Rigidbody2D rigidbody;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private bool isPlay;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = wingSound;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.Sleep();
        downRotation = Quaternion.Euler(0, 0, -45);
        forwardRotation = Quaternion.Euler(0, 0, 25);
        isPlay = false;
        if (gameController == null) gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (!gameController.GetComponent<GameController>().isEndGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.rotation = forwardRotation;
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(Vector2.up * flyPower, ForceMode2D.Force);
                audioSource.Play();
                if (!isPlay)
                {
                    isPlay = true;
                    rigidbody.WakeUp();
                }
            }
            if (isPlay) transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, smoothPower * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameController.GetComponent<GameController>().EndGame();
        audioSource.clip = dieSound;
        audioSource.PlayDelayed(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }
}
