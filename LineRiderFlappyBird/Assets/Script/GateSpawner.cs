using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour {

    public GameObject pillar;
    private Player player;

    public Transform parent;
    private float gate_distance = 20;
    private float number_of_gates = 0;
    private float decre_gap = 0;
    private List<pillar_script> pillar_list = new List<pillar_script>();

    public void Reset()
    {
        // reset spawn values
      gate_distance = 20;
      number_of_gates = 0;
      decre_gap = 0;


        // remove old gates
        foreach (pillar_script p in FindObjectsOfType<pillar_script>())
        {
               Destroy(p.gameObject);
        }

        // clear list
        pillar_list.Clear();
    }


    void Start()
    {
        player = FindObjectOfType<Player>();
       
    }


    void Update()
    {
        if(player.transform.position.x > gate_distance * number_of_gates)
        {
            number_of_gates++;

            pillar_script temp = Instantiate(pillar, new Vector2(player.transform.position.x + gate_distance, 0), Quaternion.identity).GetComponent<pillar_script>();

            temp.GetComponent<Transform>().SetParent(parent);

            pillar_list.Add(temp);

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
