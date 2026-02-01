using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class hitPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerhit = false;
    public float attackRange = 2f;
    public LayerMask enemyLayer;
    void Start()
    {
        //Colis = GetComponent<CapsuleCollider2D>;
    }

    // Update is called once per frame
    void Update()
    {
        bool playerHit = PlayerInRange();
        string currentScene = SceneManager.GetActiveScene().name;
        if (playerHit)
        {
            Debug.Log("player has been hit");
            //SceneManager.LoadScene("youDied");
            
            FindObjectOfType<SceneFader>().FadeToScene(currentScene);
        }
        ;
    }

    bool PlayerInRange()
    {
        return Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
    }
}
