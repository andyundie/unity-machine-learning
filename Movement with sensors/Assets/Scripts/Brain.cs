using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Brain : MonoBehaviour
{
    int DNALength = 2;
    public float timeAlive;
    public DNA dna;
    public GameObject eyes;

    bool alive = true;
    bool seeGround = true;

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    // Initialise DNA
    public void Init()
    {
        // 0 Forward
        // 1 Left
        // 2 Right
        dna = new DNA(DNALength, 3);
        timeAlive = 0;
        alive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!alive) return;

        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, 10);
        seeGround = false;
        RaycastHit hit;
        if (Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        {
            if (hit.collider.gameObject.tag == "platform")
            {
                seeGround = true;
            }
        }
        timeAlive = PopulationManager.elapsed

        // Read DNA
        float h = 0;
        float v = 0;

        if (seeGround)
        {
            if (dna.GetGene(0) == 0) v = 1;
            else if (dna.GetGene(0) == 1) h = -90;
            else if (dna.GetGene(0) == 1) h = 90;
        }
        else
        {
            if (dna.GetGene(1) == 0) v = 1;
            else if (dna.GetGene(1) == 1) h = -90;
            else if (dna.GetGene(1) == 2) h = 90;
        }

        this.transform.Translate(0, 0, v * 0.1f);
        this.transform.Rotate(0, h, 0);
    }
}
