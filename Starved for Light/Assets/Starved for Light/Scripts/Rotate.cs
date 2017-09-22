using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform yourCharacter;
    public float angleGoal;
    public float angle;
    public float smooth = 0.3F;
    public Quaternion goal;

    public GameObject Follow;
    void FixedUpdate()
    {
        this.gameObject.transform.position = new Vector3(Follow.transform.position.x, Follow.transform.position.y, this.gameObject.transform.position.z);

        RaycastHit2D[] hits = new RaycastHit2D[5];
        //int h = Physics2D.RaycastNonAlloc(transform.position, -Vector2.up, hits); //cast downwards

            //if we hit something do stuff
            Debug.Log(hits[1].normal);

            angleGoal = (Mathf.Atan2(hits[0].normal.x, hits[0].normal.y) * Mathf.Rad2Deg);
       
        Debug.Log(angleGoal);
        angleGoal = -angleGoal;

        StartCoroutine(ChangeSpeed(angle, angleGoal, 2f));
        goal = Quaternion.Euler(0, 0, angle);



        Follow.transform.rotation = Quaternion.Lerp(Follow.transform.rotation, goal, 16 * Time.deltaTime);

    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            angle = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += 16 * Time.deltaTime;
            yield return null;
        }

    }
}