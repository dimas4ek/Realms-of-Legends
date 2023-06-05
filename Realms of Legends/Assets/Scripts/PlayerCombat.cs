using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Collider[] colliders;
    private Collider sword;
    public Animator animator;
    public AnimatorStateInfo stateInfo;

    void Start()
    {
        animator = GetComponent<Animator>();

        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            if (col.name == "SwordPolyart")
            {
                sword = col;
            }
        }

        //sword = transform.Find("SwordPolyart").GetComponent<Collider>();
    }

    void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (stateInfo.IsName("Attack"))
        {
            if (stateInfo.IsName("Attack") && collision.gameObject.tag == "enemy" && sword.bounds.Intersects(collision.collider.bounds))
            {
                Destroy(collision.gameObject);
                EnemySpawn.enemyCount--;
            }
        }

        if (EnemySpawn.enemyCount <= 0)
        {
            //EnemyCount.button = EnemyCount.CreateButton();
            //EnemyCount.button.onClick.AddListener(EnemyCount.OnButtonClick);
            EnemyCount.aaa();
            return;
        }
        Debug.Log(EnemySpawn.enemyCount);
    }
}
