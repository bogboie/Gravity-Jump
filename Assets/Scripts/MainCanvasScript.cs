using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject Find(string search)
    {
    var scene = SceneManager.GetActiveScene();
    var sceneRoots = scene.GetRootGameObjects();

    GameObject result = null;
    foreach(var root in sceneRoots)
    {
        if(root.name.Equals(search)) return root;

        result = FindRecursive(root, search);

        if(result) break;
    }

    return result;
    }

        
    private static GameObject FindRecursive(GameObject obj, string search)
    {
        GameObject result = null;
        foreach(Transform child in obj.transform)
        {
            if(child.name.Equals(search)) return child.gameObject;

            result = FindRecursive (child.gameObject, search);

            if(result) break;
        }

        return result;
    }
    
    void Awake()
    {
        EventManager.OnWin += win;
        EventManager.OnSceneClose += kill;

    }
    void kill() 
    {
        EventManager.OnWin -= win;
        EventManager.OnSceneClose -= kill;
    }

    void win() 
    {
        GameObject wintextObj =  Find("YOU WON L");
        
        wintextObj.SetActive(true);
        GameObject nextLevelObj =  Find("Next Level");
        nextLevelObj.SetActive(true);
    }
}
