using UnityEngine;

public class AN_Viewer : MonoBehaviour
{
    [TextArea]
    public string Description = "use it on empty obj with Camera as children. WASDQE - walk, RT - rotation, Shift - run";
    public float Walk = 1f, Run = 6f, RotateSpeed = 10f;
    public int Sensitivity = 100;
    public bool HideCursor = false;

    Vector3 Move;
    Transform Cam;
    float xmouse, ymouse, yRotation, Speed, upaxe, rotate_on_key;

    [SerializeField] GameObject player;
    [SerializeField] private AudioClip audiosteps = null;
    private AudioSource perso_audiosource;
    private bool isMoving;


    private void Awake(){
        perso_audiosource = GetComponent<AudioSource>(); 
        perso_audiosource.clip = audiosteps; // Assigner le clip des pas à l'AudioSource
        perso_audiosource.loop = true; // Activer la boucle pour les pas
        perso_audiosource.volume = 2f;

    }

    void Start()
    {
        Cam = transform.GetChild(0).transform;

        if (HideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; // freeze cursor on screen centre
            Cursor.visible = false; // invisible cursor
        }
    }

    void Update() // camera rotation
    {
        //axis
        xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;

        // rotation by keys RT
        if (Input.GetKey(KeyCode.R)) rotate_on_key = -RotateSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.T)) rotate_on_key = RotateSpeed * Time.deltaTime;
        else rotate_on_key = 0f;

        // result rotation
        transform.Rotate(Vector3.up * (xmouse + rotate_on_key));
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        Cam.localRotation = Quaternion.Euler(yRotation, 0, 0);

        // walk/run
        if (Input.GetKey(KeyCode.LeftShift)) Speed = Run;
        else Speed = Walk;

        // up-axe moving
        if (Input.GetKey(KeyCode.E)) upaxe = Speed;
        else if (Input.GetKey(KeyCode.Q)) upaxe = -Speed;
        else upaxe = 0f;

        // result moving
        Move = Cam.forward * Speed * Input.GetAxis("Vertical") +
            Cam.right * Speed * Input.GetAxis("Horizontal") +
            Cam.up * upaxe;
        Move *= Time.deltaTime;
        player.transform.position += Move;

        
        isMoving = Move != Vector3.zero;
        if (isMoving && !perso_audiosource.isPlaying)
        {
            perso_audiosource.Play(); // Jouer le son si le joueur commence à bouger
        }
        else if (!isMoving && perso_audiosource.isPlaying)
        {
            perso_audiosource.Stop(); // Arrêter le son si le joueur s'arrête
        }
        
    }
}
