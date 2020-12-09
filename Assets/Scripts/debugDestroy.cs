using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugDestroy : MonoBehaviour
{

    Level level;
    SceneLoader sceneloader;

    // Start is called before the first frame update
    void Start()
    {

        level = FindObjectOfType<Level>();
        sceneloader = FindObjectOfType<SceneLoader>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void debugDestroyAll()
    {
        sceneloader.LoadNextScene();
    }
}
