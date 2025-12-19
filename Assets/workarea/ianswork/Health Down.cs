using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class HealthDown : MonoBehaviour
{
    [SerializeField] private int LivesLeft = 3;
    [SerializeField] private List<GameObject> HealthObjects = new List<GameObject>();
    public GameManager manager;
    [SerializeField]
    private GameObject Effect;
    private ParticleControler Pcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pcon = Effect.GetComponent<ParticleControler>();
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        // Destroy(obj.gameObject);
        obj.gameObject.SetActive(false);
        Pcon.PlayEffect();
        // HealthObjects.Remove(HealthObjects[LivesLeft])

        StartCoroutine(PlayAnimationCoroutine(LivesLeft-1));
        //Destroy(HealthObjects[(LivesLeft-1)].gameObject);
        //LivesLeft--;
        LivesLeft--;
        //Debug.Log("triggered");

    }
   
        // Update is called once per frame
        void Update()
        {
          if (LivesLeft < 0 || LivesLeft == 0)
          {
            //Debug.Log("Gameover");
            manager.GameOver();
          }
        
        }
    System.Collections.IEnumerator PlayAnimationCoroutine(int index)
    {
      
       
        HealthObjects[(index)].gameObject.GetComponent<TestHeartControler>().PlayAnimation();
        //Animator m_Animator = HealthObjects[(index)].gameObject.GetComponent<Animator>();
        //yield return new WaitUntil(() => m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        yield return new WaitForSeconds(1.9f);
        HealthObjects[(index)].gameObject.GetComponent<ParticleControler>().PlayEffect();
        HealthObjects[(index)].gameObject.GetComponent<SpriteRenderer>().enabled = false;
     



    }
}
