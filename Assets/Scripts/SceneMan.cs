using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{

    [SerializeField] Animator transition;
    [SerializeField] float transitionTime;
    public void LoadLevel()
    {
        StartCoroutine(PlayTransition("Level"));
    }

    public void LoadHelp()
    {
        StartCoroutine(PlayTransition("Help"));
    }

    public void LoadStart()
    {
        StartCoroutine(PlayTransition("Start"));
    }

    public void LoadWin()
    {
        StartCoroutine(PlayTransition("Win"));
    }

    public void LoadLose()
    {
        StartCoroutine(PlayTransition("Lose"));
    }

    IEnumerator PlayTransition(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
