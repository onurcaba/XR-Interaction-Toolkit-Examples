using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerS : MonoBehaviour
{
    public float time = 2;
    public string sceneName;
    public void SceneLoad()
    {
        StartCoroutine(SceneLoadCoroutine());
    }

    IEnumerator SceneLoadCoroutine()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
