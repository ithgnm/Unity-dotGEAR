using UnityEngine;

public class WormController : MonoBehaviour
{
    public float swingSpeed;
    public float currentSpeed;

    public AudioClip pointSound;
    public AudioClip dieSound;
    public AudioClip crashSound;

    private bool isLeft;
    private bool isPlay;
    private float direction;

    private GameObject gameController;
    private AudioSource audioSource;

    void Start()
    {
        isLeft = true;
        isPlay = false;
        direction = 1;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = pointSound;
        if (gameController == null) gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (!gameController.GetComponent<SwingController>().isEndGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isLeft = !isLeft;
                if (isLeft) transform.localScale = new Vector3(-1, 1, 1);
                else transform.localScale = new Vector3(1, 1, 1);
                if (!isPlay) isPlay = true;
                direction = transform.localScale.x;
                swingSpeed = -swingSpeed / 2;
            }
            if (isPlay)
            {
                swingSpeed += currentSpeed * Time.deltaTime;
                transform.Translate(Vector3.left * swingSpeed * direction * Time.deltaTime);
            }
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameController.GetComponent<SwingController>().EndGame();
        audioSource.PlayOneShot(crashSound);
        audioSource.clip = dieSound;
        audioSource.PlayDelayed(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<SwingController>().GetPoint();
        audioSource.Play();
    }
}
