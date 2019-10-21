using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        //show animate out animation
        animator.SetBool("animateOut", true);
        yield return new WaitForSeconds(0.251f);
        SceneManager.LoadScene(sceneIndex);
    }
}