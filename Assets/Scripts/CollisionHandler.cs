
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayInvoke=1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] ParticleSystem successEffect;
    AudioSource AS;

    string obstacleType;
    bool isTransitioning = false;
    bool collisionsEnabled = true;

    void Start()
    {
        AS= GetComponent<AudioSource>();
       
          
    }

    private void Update() {
        if (Input.GetKey(KeyCode.L))
        {
            NextLevel();

        }
        if (Input.GetKey(KeyCode.C))
        {
            collisionsEnabled=!collisionsEnabled; 

        }
    }
    
    void OnCollisionEnter(Collision other) {
        if(isTransitioning || !collisionsEnabled){ return; }
        obstacleType=other.gameObject.tag;
        switch (obstacleType){
            case "Friendly":
                Debug.Log("You hit the Launchpad.");
                break;
            case "Finish":
                StartSuccesssSequence();
                break;
            default:
                StartCrashSequence();                
                break;
        }
    }

    private void StartSuccesssSequence()
    {
        AS.Stop();
        AS.PlayOneShot(successSound);
        successEffect.Play();
        GetComponent<Movements>().enabled = false;
        isTransitioning=true;
        Invoke("NextLevel",delayInvoke);
    }

    void StartCrashSequence(){
            AS.Stop();
            AS.PlayOneShot(crashSound);
            crashEffect.Play();
            GetComponent<Movements>().enabled = false;
            isTransitioning=true;
            Invoke("ReloadLevel",delayInvoke);
        }

        void ReloadLevel(){

            int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        void NextLevel(){
            int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex!=(SceneManager.sceneCountInBuildSettings-1)){
                SceneManager.LoadScene(currentSceneIndex+1);
            }else{
                SceneManager.LoadScene(0); //We have reached the end and we are back to the beginning
            }
            
        }
        
            

        
    

}
