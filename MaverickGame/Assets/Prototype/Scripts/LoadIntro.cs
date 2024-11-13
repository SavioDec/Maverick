using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadIntro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void BtnLoadIntro(){
        SceneManager.LoadScene(0);
    }
}
