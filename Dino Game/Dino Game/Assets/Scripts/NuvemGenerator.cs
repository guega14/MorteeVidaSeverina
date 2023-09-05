using System.Collections;
using UnityEngine;

public class NuvemGenerator : MonoBehaviour
{
    public GameObject[] nuvem;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    public float timetospawnmin, timetospawnmax;
    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        StartCoroutine(nuvemloop());
    }

    public void generateNuvem()
    {
        GameObject NuvemIns = Instantiate(nuvem[Random.Range(0, nuvem.Length)], new Vector3(transform.position.x, transform.position.y + Random.Range(-2, 2), 0), Quaternion.identity);
        NuvemIns.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 0);


        NuvemIns.GetComponent<Nuvem>().nuvemGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
    IEnumerator nuvemloop()
    {
        generateNuvem();
        yield return new WaitForSeconds(Random.Range(timetospawnmin, timetospawnmax));
        StartCoroutine(nuvemloop());
    }
}