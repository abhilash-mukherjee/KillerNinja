using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public Camera arCam;
    public GameObject redExplosion;
    public Text scoreBoard;

    float scoreUpdate = 0;
    // Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Shoot Object working");
        Debug.Log(gameObject.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.anyKeyDown){
        //     gameObject.GetComponent<AudioSource>().Play();
        // }
        // Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            var ray = arCam.ViewportPointToRay(new Vector3(0.5f,0.5f));
            if(Physics.Raycast(ray,out hit)){

                Debug.Log("Shoot Object Hit");
                Debug.Log(hit.transform.tag);

                if(hit.transform.tag == "Enemy"){
                    scoreUpdate += hit.transform.gameObject.GetComponent<EnemyScore>().GetScore();
                    scoreBoard.text = scoreUpdate.ToString();
                    Destroy(hit.transform.gameObject);
                    redExplosion.SetActive(true);
                    Instantiate(redExplosion,hit.transform.position,hit.transform.rotation);
                    gameObject.GetComponent<AudioSource>().Play();
                    redExplosion.SetActive(false);
                                        
                }
            }
        }
    }
}
