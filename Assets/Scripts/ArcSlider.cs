using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;


public class ArcSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// HSL值
    /// </summary>
    private float h;
    private float s;
    private float l;

    private Vector2 localPos;
    public GameObject bullets;
    /// <summary>
    /// 玩家
    /// </summary>
    public GameObject player;
    /// <summary>
    /// 色轮旋转后停留的区域
    /// </summary>
    public Vector3 endRotate;
    /// <summary>
    /// 实例化出来的子弹
    /// </summary>
    private GameObject bulletObj;
    
    // Start is called before the first frame update

    public Texture2D heatMapImage;
    public Color outputColor;

    public Image handleButton;
    float circleRadius = 0.0f;

    bool isPointerDown = false;
    public Text showColor;
    
    private Timer timer;
    private GameObject camera;
    public GameObject yourScore;

    
    //忽略圈内的交互
    public float ignoreInTouchRadiusHandleOffset = 10;

    Vector3 handleButtonLocation;

    [Tooltip("初始角度到终止角度")]
    public float firstAngle = 30;
    public float secondAngle = 150;

    float tempAngle = 30;//用来缓动

    public float width;
    public float height;
    public void Start()
    {
        circleRadius = Mathf.Sqrt(Mathf.Pow(handleButton.GetComponent<RectTransform>().localPosition.x, 2) + Mathf.Pow(handleButton.GetComponent<RectTransform>().localPosition.y, 2));
        ignoreInTouchRadiusHandleOffset = circleRadius - ignoreInTouchRadiusHandleOffset;

        handleButtonLocation = handleButton.GetComponent<RectTransform>().localPosition;
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
        transform.GetComponent<RepeatOn>().OnRelease.AddListener(InstantiateBullet);
        
        timer = GameObject.FindWithTag("GameController").GetComponent<Timer>();
        camera = GameObject.Find("Main Camera").gameObject;
        
    }

    //重置初始位置
    public void ReSet()
    {
        handleButton.GetComponent<RectTransform>().localPosition = handleButtonLocation;
    }
    public void OnPointerEnter( PointerEventData eventData )
	{
		StartCoroutine( "TrackPointer" );
	}
	//如果需要移动到外部时仍然有效可以去掉这里的
	public void OnPointerExit( PointerEventData eventData )
	{
		StopCoroutine( "TrackPointer" ); //停止
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown= true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown= false;
	}
    
    
	IEnumerator TrackPointer()
	{
		var ray = GetComponentInParent<GraphicRaycaster>();
		var input = FindObjectOfType<StandaloneInputModule>();


		if( ray != null && input != null )
		{
			while( Application.isPlaying )
			{
                //这个是左侧的
                if (isPointerDown)
                {
                    
                    //获取鼠标当前位置out里赋值
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos);
                    //showColor.text = "SelectColor:" + GetHeatMapColor((int)(localPos.x+ width/2), (int)(localPos.y+height/2));
                    
                    Color newColor = heatMapImage.GetPixel((int)(localPos.x + heatMapImage.width / 2), (int)(localPos.y + heatMapImage.height / 2));
                    
                    handleButton.GetComponent<Image>().color = new Color(newColor.r, newColor.g, newColor.b, 255);
                    handleButton.transform.DOScale(new Vector3(3, 3, 0), 1f);
                    
                    //半径
                    float mouseRadius = Mathf.Sqrt(localPos.x * localPos.x + localPos.y * localPos.y);
                    //阻止圆内部点击的响应，只允许在一个圆环上进行响应
                    if (mouseRadius > ignoreInTouchRadiusHandleOffset)
                    {
                        //0-180  -180-0偏移后的角度 从第一象限校正到0-360
                        float angle = (Mathf.Atan2(localPos.y, -localPos.x)) * Mathf.Rad2Deg;
                        if ((angle < 0 && tempAngle > 0))
                        {
                            tempAngle = 360 + angle;
                        }
                        if((angle > 0 && tempAngle > 330))
                        {
                            tempAngle = angle;
                        }
                        if (angle < 0) angle = 360 + angle;;

                        if (angle < firstAngle) angle = firstAngle;
                        if (angle > secondAngle) angle = secondAngle;

                        angle = (tempAngle + angle) / 2f;
                        tempAngle = angle;
                        //改变小圆的位置
                        handleButton.GetComponent<RectTransform>().localPosition = new Vector3(Mathf.Cos(-angle / Mathf.Rad2Deg + 45.0f * Mathf.PI) * circleRadius, Mathf.Sin(-angle / Mathf.Rad2Deg + 45.0f * Mathf.PI) * circleRadius, 0);
                        
                    }
                }
				yield return 0;
			}        
		}   
	}
    public Color GetHeatMapColor(int x, int y)
    {
        outputColor = new Color(heatMapImage.GetPixel(x, y).r, heatMapImage.GetPixel(x, y).g, heatMapImage.GetPixel(x, y).b, 1);
        return outputColor;
    }

    //实例化子弹
    private void InstantiateBullet()
    {
	    UIManager.bulletTime--;
	    if (UIManager.bulletTime < 0)
	    {
		    timer.HadSuccess = 1;
		    camera.transform.DOMove(new Vector3(0.2799f, -1.010172f, 7.6226f), 2.0f);
		    camera.transform.DORotate(new Vector3(0, 0, 0), 2.0f);
		    Camera.main.orthographic = true;
		    Camera.main.orthographicSize = 4.2f;
		    camera.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
		    
		    StartCoroutine(CallYourScores());
		    Debug.Log("show");
		    return;
	    }
        bulletObj = Instantiate(bullets, player.transform.position, Quaternion.identity);
        bulletObj.GetComponent<Renderer>().material.color = heatMapImage.GetPixel((int)(localPos.x + heatMapImage.width / 2), (int)(localPos.y + heatMapImage.height / 2));

        GetHeatMapColor((int) (localPos.x + heatMapImage.width / 2), (int) (localPos.y + heatMapImage.height / 2));
        
        bulletObj.transform.DOMove(player.transform.position + player.transform.forward * 200, 15.0f);
        
        handleButton.GetComponent<Image>().color = heatMapImage.GetPixel((int)(localPos.x + heatMapImage.width / 2), (int)(localPos.y + heatMapImage.height / 2));
        handleButton.transform.DOScale(new Vector3(1, 1, 0), 1f);
    }
    
    IEnumerator CallYourScores()
    {
	    yield return new WaitForSeconds(2);
	    yourScore.SetActive(true);
	    yourScore.transform.DOScale(new Vector3(1, 1, 0), 1f);
    }
}
