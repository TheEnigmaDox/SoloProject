using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> m_treasureObjects;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;    
        }
        else if(Instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
