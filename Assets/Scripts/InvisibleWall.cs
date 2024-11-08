using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvisbleWall : MonoBehaviour
{
    public int maxHealth = 10;
    public int playerHealth;
    public GameObject player;
    public Transform SpawnPoint;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

   

    // Update is called once per frame
    public void PlayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }

    void Update()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Death", LoadSceneMode.Additive);
    }
   
   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "InvisibleWall")
        {

            Debug.Log("You have been spotted!");


            this.playerHealth -= 10;

        }
        {
            if (gameObject.tag == "Player")
            {
                player.transform.position = SpawnPoint.transform.position;
            }
        }

    }



}
