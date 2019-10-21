using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
	public int indexScene;
	
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(indexScene);
    }
}
