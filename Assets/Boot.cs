using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class Boot : MonoBehaviour
{
    public IEnumerator Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/LoadTarget.unity", UnityEngine.SceneManagement.LoadSceneMode.Additive);

        var unloadCor = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Assets/LoadTarget.unity");
        while (!unloadCor.isDone)
        {
            yield return null;
        }
        Debug.Log("succeeded to loadSync then unloadAsync.");
    }


    [UnityTest]
    public IEnumerator Async()
    {
        var cor = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Assets/LoadTarget.unity", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        while (!cor.isDone)
        {
            yield return null;
        }

        var unloadCor = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Assets/LoadTarget.unity");
        while (!unloadCor.isDone)
        {
            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator Sync()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/LoadTarget.unity", UnityEngine.SceneManagement.LoadSceneMode.Additive);

        // unloadCor is null.
        var unloadCor = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Assets/LoadTarget.unity");
        while (!unloadCor.isDone)
        {
            yield return null;
        }
    }
}
