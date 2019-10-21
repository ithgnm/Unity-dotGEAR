using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speedMove;
    public float xPosition;
    public float yMin;
    public float yMax;

    public AudioClip pointSound;

    private bool isPlay;
    private AudioSource audioSource;

    void Start()
    {
        isPlay = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = pointSound;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isPlay = true;
        if (isPlay)
        {
            Vector3 vectorMove = new Vector3(speedMove * Time.deltaTime, 0, 0);
            transform.Translate(vectorMove);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Reset"))
            transform.position = new Vector3(xPosition, Random.Range(yMin, yMax + 1), 0);
        else audioSource.Play();
    }
}
