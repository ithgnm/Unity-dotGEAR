using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameResult;
    public GameObject gameMessage;

    public GameObject point1Object;
    public GameObject point2Object;

    public GameObject dayObject;
    public GameObject nightObject;

    public GameObject yellowBird;
    public GameObject blueBird;
    public GameObject redBird;

    public Sprite point0;
    public Sprite point1;
    public Sprite point2;
    public Sprite point3;
    public Sprite point4;
    public Sprite point5;
    public Sprite point6;
    public Sprite point7;
    public Sprite point8;
    public Sprite point9;

    public bool isEndGame;
    public AudioClip hitSound;

    private int point;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = hitSound;
        point = 0;
        gameMessage.SetActive(true);
        if (Random.Range(0, 2) == 0)
        {
            dayObject.SetActive(true);
            nightObject.SetActive(false);
        }
        else
        {
            dayObject.SetActive(false);
            nightObject.SetActive(true);
        }
        int colorBird = Random.Range(0, 3);
        if (colorBird == 0)
        {
            yellowBird.SetActive(true);
            blueBird.SetActive(false);
            redBird.SetActive(false);
        }
        else if (colorBird == 1)
        {
            yellowBird.SetActive(false);
            blueBird.SetActive(true);
            redBird.SetActive(false);
        }
        else
        {
            yellowBird.SetActive(false);
            blueBird.SetActive(false);
            redBird.SetActive(true);
        }
        isEndGame = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (!isEndGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameMessage.SetActive(false);
            }
            if (point >= 10)
            {
                Vector3 vectorMove = new Vector3(0.14f, point2Object.transform.position.y, 0);
                point2Object.transform.position = vectorMove;
                point1Object.SetActive(true);
            }
        }
    }

    public void GetPoint()
    {
        point++;
        switch (point % 10)
        {
            case 0:
                point2Object.GetComponent<SpriteRenderer>().sprite = point0;
                break;
            case 1:
                point2Object.GetComponent<SpriteRenderer>().sprite = point1;
                break;
            case 2:
                point2Object.GetComponent<SpriteRenderer>().sprite = point2;
                break;
            case 3:
                point2Object.GetComponent<SpriteRenderer>().sprite = point3;
                break;
            case 4:
                point2Object.GetComponent<SpriteRenderer>().sprite = point4;
                break;
            case 5:
                point2Object.GetComponent<SpriteRenderer>().sprite = point5;
                break;
            case 6:
                point2Object.GetComponent<SpriteRenderer>().sprite = point6;
                break;
            case 7:
                point2Object.GetComponent<SpriteRenderer>().sprite = point7;
                break;
            case 8:
                point2Object.GetComponent<SpriteRenderer>().sprite = point8;
                break;
            case 9:
                point2Object.GetComponent<SpriteRenderer>().sprite = point9;
                break;
        }
        switch (point / 10)
        {
            case 0:
                point1Object.GetComponent<SpriteRenderer>().sprite = point0;
                break;
            case 1:
                point1Object.GetComponent<SpriteRenderer>().sprite = point1;
                break;
            case 2:
                point1Object.GetComponent<SpriteRenderer>().sprite = point2;
                break;
            case 3:
                point1Object.GetComponent<SpriteRenderer>().sprite = point3;
                break;
            case 4:
                point1Object.GetComponent<SpriteRenderer>().sprite = point4;
                break;
            case 5:
                point1Object.GetComponent<SpriteRenderer>().sprite = point5;
                break;
            case 6:
                point1Object.GetComponent<SpriteRenderer>().sprite = point6;
                break;
            case 7:
                point1Object.GetComponent<SpriteRenderer>().sprite = point7;
                break;
            case 8:
                point1Object.GetComponent<SpriteRenderer>().sprite = point8;
                break;
            case 9:
                point1Object.GetComponent<SpriteRenderer>().sprite = point9;
                break;
        }
    }

    public void EndGame()
    {
        audioSource.Play();
        isEndGame = true;
        Time.timeScale = 0;
        gameResult.SetActive(true);
    }
}
