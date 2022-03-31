using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resume()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().resume();
    }

    public void menu()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().resume();
        SceneManager.LoadScene("Menu");
    }
}
