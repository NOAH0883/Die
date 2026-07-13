using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("ME SCENE", LoadSceneMode.Additive);
        SceneManager.LoadScene("Character", LoadSceneMode.Additive);
        SceneManager.LoadScene("ENVIRONMENT", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
