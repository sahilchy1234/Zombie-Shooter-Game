using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostageManager : MonoBehaviour
{
    public bool isRescueCompleted;
    public Rigidbody[] rb_bodies;
    public int explodedObject;
    private string sceneName;

    public static HostageManager instance;

    public void Exploded()
    {
        explodedObject++;
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        instance = this;
    }
    bool k;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (sceneName == "Level 2")
        {


            /// All function for the hostages for level 2

            if (explodedObject == 3 && k == false)
            {
                k = true;
                for (int i = 0; i < rb_bodies.Length; i++)
                {
                    rb_bodies[i].isKinematic = false;
                }

                isRescueCompleted = true;

            }
        }


        
        if (sceneName == "Level 3")
        {


            /// All function for the hostages for level 3

            if (explodedObject == 3 && k == false)
            {
                k = true;
                for (int i = 0; i < rb_bodies.Length; i++)
                {
                    rb_bodies[i].isKinematic = false;
                }

                isRescueCompleted = true;

            }
        }

        
        if (sceneName == "Level 4")
        {
            /// All function for the hostages for level 4

            if (explodedObject == 6 && k == false)
            {
                k = true;
                for (int i = 0; i < rb_bodies.Length; i++)
                {
                    rb_bodies[i].isKinematic = false;
                }

                isRescueCompleted = true;

            }
        }

            if (sceneName == "Level 5")
        {
            /// All function for the hostages for level 4

            if (explodedObject == 9 && k == false)
            {
                k = true;
                for (int i = 0; i < rb_bodies.Length; i++)
                {
                    rb_bodies[i].isKinematic = false;
                }

                isRescueCompleted = true;

            }
        }

              if (sceneName == "Level 6")
        {
            /// All function for the hostages for level 4

            if (explodedObject == 10 && k == false)
            {
                k = true;
                for (int i = 0; i < rb_bodies.Length; i++)
                {
                    rb_bodies[i].isKinematic = false;
                }

                isRescueCompleted = true;

            }
        }
    }
}
