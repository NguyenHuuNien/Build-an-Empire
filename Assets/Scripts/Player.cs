using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Hero
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isCom;
    private bool trongTamDanh;
    private GameObject targetObject;
    private float timeWait;
    private void Update() {
        Debug.DrawLine(transform.position,transform.position + (isCom?-1:1) * Vector3.right * TamDanh,Color.white);
        trongTamDanh = Check();
    }
    void FixedUpdate()
    {
        if(!trongTamDanh){
            Move();
        }else{
            rb.velocity = Vector2.zero;
            Attack();
        }
    }
    private void Attack(){
        if(timeWait >= TocDoDanh){
            targetObject.GetComponent<Player>().Mau -= this.SatThuong;
            timeWait = 0;
        }else{
            timeWait += Time.fixedDeltaTime * 1.2f;
        }
    }
    private void Move(){
        rb.velocity = Vector2.right * this.TocDoDiChuyen * (isCom?-1:1);
    }
    private bool Check(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right,this.TamDanh,layerMask);
        targetObject = hit.collider!=null ? hit.collider.gameObject : null;
        return hit.collider != null;
    }
}
