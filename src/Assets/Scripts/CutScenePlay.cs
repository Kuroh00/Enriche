using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenePlay : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine("CutScenes");
    }

    IEnumerator CutScenes()
    {
        yield return new WaitForSeconds(2);

        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        transform.GetChild(8).gameObject.SetActive(false);
        AsyncOperation aSyncLoad = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex) + 1);

        while (!aSyncLoad.isDone)
        {
            yield return null;
        }

    }
}
