using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneToLoad;
    public Animator fadeAnim;
    public float fadeTime = 0.5f;
    public Vector2 newPLayerPosition;
    private Transform player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            fadeAnim.Play("FadeToBlack");
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPLayerPosition;
        SceneManager.LoadScene(SceneToLoad);
    }
}
