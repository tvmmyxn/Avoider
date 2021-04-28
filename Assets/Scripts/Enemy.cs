using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float detectionRange = 5f;
    public bool pauseAtWaypoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        
    }
}