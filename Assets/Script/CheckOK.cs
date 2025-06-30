using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class CheckOK : MonoBehaviour{

    public string nextSceneName; // 设置要跳转的场景名称

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Char"))
        {
            

            //可以立即触发UI&音效
            StartCoroutine(SuccesDelayed());

        }
            

           
    }

    IEnumerator SuccesDelayed()
{
    // 第一个延迟
    yield return new WaitForSeconds(0.5f);
    Debug.Log("成功");
    //此处可以填写触发congr的ui啦！

    // 第二个延迟
    yield return new WaitForSeconds(1f);
    //SceneManager.LoadScene("NextScene");

}




}
    