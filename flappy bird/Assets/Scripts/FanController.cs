using UnityEngine;

public class FanController : MonoBehaviour
{
    public AudioClip fanSound;

    private bool isPlay;
    private AudioSource audioSource;
    private GameObject gameController;

    void Start()
    {
        isPlay = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fanSound;
        if (gameController == null) gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPlay)
            {
                isPlay = true;
                audioSource.Play();
            }
        }
        if (gameController.GetComponent<SwingController>().isEndGame)
        {
            audioSource.Stop();
        }
    }
}
