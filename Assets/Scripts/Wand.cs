using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public float rateOfFire = 0;
    public float spellDamage = 10;
    public LayerMask notHit;

    public Transform SpellPathPrefab;
    public Transform SpellFlashPrefab;
    float spawnEffectTime = 0;
    public float spawnEffectRate = 10;

    float fireTime = 0;
    Transform spellLP;

    // Start is called before the first frame update
    void Awake()
    {
        spellLP = transform.Find("SpellLP");
        if (spellLP == null)
        {
            Debug.LogError("No Spell Launch Point?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rateOfFire == 0)
        {
            if (Input.GetButtonDown ("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > fireTime)
            {
                fireTime = Time.time + 1 / rateOfFire;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        Vector2 spellLPPosition = new Vector2 (spellLP.position.x, spellLP.position.y);
        RaycastHit2D hit = Physics2D.Raycast (spellLPPosition, mousePosition-spellLPPosition, 100, notHit);
        if (Time.time >= spawnEffectTime)
        {
            Effect();
            spawnEffectTime = Time.time + 1/spawnEffectRate;
        }
        Debug.DrawLine(spellLPPosition, (mousePosition-spellLPPosition)*100, Color.black);
        if (hit.collider != null)
        {
            Debug.DrawLine(spellLPPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + spellDamage + " damage.");
        }
    }

    void Effect()
    {
        Instantiate(SpellPathPrefab, spellLP.position, spellLP.rotation);
        Transform clone = Instantiate(SpellFlashPrefab, spellLP.position, spellLP.rotation) as Transform;
        clone.parent = spellLP;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
    }
}
