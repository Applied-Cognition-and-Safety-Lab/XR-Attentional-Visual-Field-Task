using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public ExperimentSettings dataHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static GameManager Instance
    {
        get;
        private set;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.A))
       // {
           // SceneManager.LoadScene("PR2room");
        //}

    }


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        dataHolder = FindObjectOfType<ExperimentSettings>();

    }

    public void startStudy()
    {
            SceneManager.LoadScene("Task Room");

    }
}
