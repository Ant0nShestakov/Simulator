using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 1f;

    private PlayerUIManger _playerUIManger;
    private PlayerDialogsManager _playerDialogsManager;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _playerUIManger = GetComponentInChildren<PlayerUIManger>();
        _playerDialogsManager = GetComponent<PlayerDialogsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance))
        {
            if (hit.collider.TryGetComponent<Execute>(out Execute ex))
            {
                _playerUIManger.ActivateUIHelper(ex.Command);
                if (Input.GetKey(KeyCode.E))
                    ex.Executing();
            }
            else if(hit.collider.TryGetComponent<QuestGiveManager>(out QuestGiveManager questGiver))
            {
                _playerUIManger.ActivateUIHelper();
                if (Input.GetKey(KeyCode.E))
                {
                    questGiver.StartTask();
                    _playerDialogsManager.StartDialog();
                }
                if (Input.GetKey(KeyCode.F))
                    questGiver.SetDanceAnimation();
            }
        }
        else
            _playerUIManger.ResetState();
    }
}
