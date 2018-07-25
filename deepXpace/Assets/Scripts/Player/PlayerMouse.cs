using UnityEngine;

public class PlayerMouse : MonoBehaviour {
	public float speed;				// Valores ajustados a la escena piloto actual
	public float layer;				//0
	public float mLeftBorder;		//-0.4f
	public float mRightBorder;		//0.4f
	public float mTopBorder;		//-0.9f
	public float mBottomBorder;		//0.9f
	private Transform mTransform;

	void Awake () {
		mTransform = transform;
	}

	void Start () { //incializamos al jugador al fondo y en el centro
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(0,mBottomBorder,Camera.main.nearClipPlane));
		mTransform.position = pos;
		Cursor.visible = false;
	}
	
	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(speed+Input.mousePosition.x,speed+Input.mousePosition.y,Camera.main.nearClipPlane));
		pos.x = Mathf.Clamp(pos.x,mLeftBorder,mRightBorder);
		pos.y = Mathf.Clamp(pos.y,mTopBorder,mBottomBorder);
		pos.z = layer;
		mTransform.position = pos;
	}

}