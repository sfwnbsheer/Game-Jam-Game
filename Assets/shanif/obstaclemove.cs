using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    public float upY = 0f;        
    public float downY = -1.5f;   
    public float speed = 8f;
    public float waitTime = 1f;

    void Start()
    {
        StartCoroutine(PopUpRoutine());
    }

    IEnumerator PopUpRoutine()
    {
        while (true)
        {
            // move up
            while (transform.position.y < upY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            // move down
            while (transform.position.y > downY)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
