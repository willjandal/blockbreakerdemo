using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugDestroy : MonoBehaviour
{

    Level level;

    // Start is called before the first frame update
    void Start()
    {

        level = FindObjectOfType<Level>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void debugDestroyAll()
    {
        Destroy(gameObject);
        level.setBlockstoZero();
    }
}
