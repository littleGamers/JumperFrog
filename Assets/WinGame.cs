using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
