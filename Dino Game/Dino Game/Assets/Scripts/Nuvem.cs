using UnityEngine;

public class Nuvem : MonoBehaviour
{
    public NuvemGenerator nuvemGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * nuvemGenerator.currentSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            // spikeGenerator.generateSpike();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}