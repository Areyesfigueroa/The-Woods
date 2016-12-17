using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Working");
            PlayerManager.Instance.PeopleKilled++;
			AkSoundEngine.PostEvent ("NPCCap", gameObject);
            Destroy(other.gameObject, .2f);
        }
    }
}
