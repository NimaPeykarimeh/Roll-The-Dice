using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceParticle : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] Quaternion _rotation;
    [SerializeField] Vector3 _position;

    // Start is called before the first frame update
    private void Start()
    {
        _position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject _particle = Instantiate(particle, position: _position, rotation: _rotation);
        _particle.transform.parent = gameObject.transform;
        _particle.transform.localScale = Vector3.one;
        _particle.SetActive(false);

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="diceBG")
        {

            Instantiate(particle, position: _position, rotation:_rotation);
        }
    }
    */
}
