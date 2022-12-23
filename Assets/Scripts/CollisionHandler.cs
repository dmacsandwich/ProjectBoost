using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;
    float delay = 1f;
    bool isTransitioning = false;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
        {
            if (isTransitioning)
            {
                return;
            }

            switch(other.gameObject.tag)
            {
                case "Friendly":
                    break;
                case "Finish":
                    StartLoadSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;   
            }
        }

    void StartLoadSequence()
    {
        audioSource.Stop();
        isTransitioning = true;
        audioSource.PlayOneShot(success);
        GetComponent<MovePlayer>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<MovePlayer>().enabled = false;
        Invoke("ReloadLevel", delay);
    }
    void ReloadLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScenceIndex = currentSceneIndex + 1;

        if (nextScenceIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextScenceIndex = 0;
        }
        SceneManager.LoadScene(nextScenceIndex);
    }
}
