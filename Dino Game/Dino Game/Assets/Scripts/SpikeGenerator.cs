using System.Collections;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject[] spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    public float timetospawnmin, timetospawnmax;
    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        StartCoroutine(spikeloop());
    }

    public void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike[Random.Range(0,spike.Length)], transform.position, transform.rotation);
    
        SpikeIns.GetComponent<Spike>().spikeGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
      
        if(currentSpeed< MaxSpeed) 
        {
            currentSpeed += SpeedMultiplier;        
        }
    }
    IEnumerator spikeloop()
    {
        generateSpike();
        yield return new WaitForSeconds(Random.Range(timetospawnmin,timetospawnmax));
        StartCoroutine(spikeloop());
    }
}