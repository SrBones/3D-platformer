using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayLittle());
    }

    IEnumerator DelayLittle()
    {
        yield return new WaitForSeconds(17);
        Application.Quit();
    }
}
