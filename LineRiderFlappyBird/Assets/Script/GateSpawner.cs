using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour {

    public GameObject pillar;
    private Player player;

    private float gate_distance = 20;
    private float number_of_gates = 0;
    private float decre_gap = 0;

    public void Reset()
    {
      gate_distance = 20;
      number_of_gates = 0;
      decre_gap = 0;
}


    void Start()
    {
        player = FindObjectOfType<Player>();
        // first gate
        
    }


    void Update()
    {
        if(player.transform.position.x > gate_distance * number_of_gates)
        {
            number_of_gates++;

            pillar_script temp = Instantiate(pillar, new Vector2(player.transform.position.x + gate_distance, 0), Quaternion.identity).GetComponent<pillar_script>();

            if (temp != null)
            {
                temp.lowerGap(decre_gap);
            }

            if(decre_gap < 3.2f)
            {
                decre_gap += 0.2f;
            }
           
            if(gate_distance < 2) { 
            gate_distance--;
            }

        }
    }


}
