using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
    public string NameOFLVL;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(NameOFLVL);
        }
    }
}
