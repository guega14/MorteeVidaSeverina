using System.Collections;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public static SpikeGenerator miguel;

    public GameObject[] spike;

    public SpriteRenderer currentBackground, currentGround, currentAster;
    public Sprite fundonoite, chaonoite, lua;
    public Sprite fundodia, chaodia, sol;
    public Sprite passarobranco, passaropreto;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;
    public float timeToIncrease;
    public float timetospawnmin, timetospawnmax;

    public float timetoChange;
    // Start is called before the first frame update
    void Awake()
    {
        miguel = this;
        currentSpeed = Random.Range(MinSpeed, MaxSpeed);
        StartCoroutine(spikeloop());
        StartCoroutine(AumentarVelocidade());
        StartCoroutine(MudarCenario());
    }

    public void generateSpike()
    {
        int random = Random.Range(0, spike.Length);
        GameObject SpikeIns = Instantiate(spike[random], transform.position, transform.rotation);
        if (currentBackground.sprite == fundonoite)
        {
            if (random == 1)
            {
                SpikeIns.GetComponent<SpriteRenderer>().sprite = passarobranco;
            }
        }
        else
        {
            if (random == 1)
            {
                SpikeIns.GetComponent<SpriteRenderer>().sprite = passaropreto;
            }
        }
        SpikeIns.GetComponent<Spike>().spikeGenerator = this;
    }

    IEnumerator spikeloop()
    {
        generateSpike();
        yield return new WaitForSeconds(Random.Range(timetospawnmin, timetospawnmax));
        StartCoroutine(spikeloop());
    }
    IEnumerator AumentarVelocidade()
    {

        yield return new WaitForSeconds(timeToIncrease);
        currentSpeed += SpeedMultiplier;
        StartCoroutine(AumentarVelocidade());
    }
    IEnumerator MudarCenario()
    {

        yield return new WaitForSeconds(timetoChange);
        if (currentBackground.sprite == fundodia)
        {
            currentBackground.sprite = fundonoite;
            currentGround.sprite = chaonoite;
            currentAster.sprite = lua;
        }
        else
        {
            currentBackground.sprite = fundodia;
            currentGround.sprite = chaodia;
            currentAster.sprite = sol;
        }
        StartCoroutine(MudarCenario());
    }
}