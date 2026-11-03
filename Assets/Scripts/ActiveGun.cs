using UnityEngine;

public class ActiveGun : MonoBehaviour
{
    public GameObject handgunObject;
    public GameObject GlobalObject;
    public GameObject playerCasting;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handgunObject.SetActive(false);
        GlobalObject.GetComponent<HandgunFire>().enabled = false;
        GlobalObject.SetActive(false);
        playerCasting.GetComponent<PlayerCasting>().enabled = false;
    }

    public void PickedUpGun()
    {
        handgunObject.SetActive(true);
        GlobalObject.GetComponent<HandgunFire>().enabled = true;
        GlobalObject.SetActive(true);
        playerCasting.GetComponent<PlayerCasting>().enabled = true;
    }
}
