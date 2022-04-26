
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{

    string obstacleType;
    void OnCollisionEnter(Collision other) {
        obstacleType=other.gameObject.tag;
        switch (obstacleType){
            case "Friendly":
                Debug.Log("You hit the Launchpad.");
                break;
            case "Fuel":
                Debug.Log("You hit the Fuel.");
                break;
            case "Finish":
                Debug.Log("You hit the Finish.");
                break;
            default:
                ReloadLevel();
                
                break;
        }
        void ReloadLevel(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
            

        
    }

}
