using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject debugSphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is clicked.
        if(Input.GetMouseButtonDown(0))
        {
            //Create a ray cast from this point. ( Middle of the screen )
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(960, 540));

            //If the raycast hits a collider in the distance of 2 units, output it into a variable called hit.
            if (Physics.Raycast(ray, out RaycastHit hit, 2))
            {
                //Move the debug sphere to the position that the raycast hit.
                debugSphere.transform.position = hit.point;

                //If the raycast hits a collider on a game object that has the tag of enemy.
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    //Make a new variable to store the script component on the enemy.
                    EnemyCharacter enemy = hit.collider.gameObject.GetComponent<EnemyCharacter>();



                    //Decrement the health variable inside the enemy script component.
                    enemy.TakeDamage;
                }
            }
        }
    }
}
