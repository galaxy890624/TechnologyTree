using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// <br>Distance �p�������ۤv���Z���A���̵u�C</br>
/// <br>Find �O�_���ݨ������V�C</br>
/// <br>CanSee �����O�_�i�H�����C</br>
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
/// <summary>�A�Ω�3D�H�Ψ��⪺AI���h�A�t�X���z�BRootMotion�A���AYEStatusBehaviour�C</summary>
public class AYEMonster<StatusEnum> : AYEStatusBehaviour<StatusEnum> where StatusEnum : Enum
{
    public NavMeshAgent nav = null;
    public Animator anim = null;
    private void Reset()
    {
        GetAllComponent();
    }
    protected override void Start()
    {
        base.Start();
        GetAllComponent();
        nav.updatePosition = false;
        nav.updateRotation = false;
        nav.updateUpAxis = false;
    }
    void GetAllComponent()
    {
        if (nav == null)
            nav = this.gameObject.GetComponent<NavMeshAgent>();
        if (nav == null)
            nav = this.gameObject.AddComponent<NavMeshAgent>();
        if (anim == null)
            anim = this.gameObject.GetComponent<Animator>();
        if (anim == null)
            anim = this.gameObject.AddComponent<Animator>();
    }
    float faceForceTime = 0f;
    protected override void Update()
    {
        base.Update();
        nav.nextPosition = this.transform.position;
        // �b�ݬY�ӪF��� �p�G���פӤj�N�|�ਭ
        if (isFace)
        {
            // ���h����N�����ݪF��
            if (tempLookTarget == null)
            {
                CancelFace();
                return;
            }
            Vector3 t = tempLookTarget.position + tempOffset;
            t.y = this.transform.position.y;
            if (Vector3.Angle(this.transform.forward, t - this.transform.position) > 80f)
                faceForceTime = 0.5f;
            if (faceForceTime > 0f)
            {
                Quaternion q = Quaternion.LookRotation(t - transform.position, Vector3.up);
                // ���U���u�t�ץu��3����1���u�t�סC
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, q, Time.deltaTime * (tempSpeed * 0.33f));
                faceForceTime -= Time.deltaTime;
            }
        }
    }
    #region �̿�I���������z�ʽ��˩w��
    float lastFindTime = 0f;
    /// <summary>
    /// �P�w�O�_��ݨ��ӹ�H
    /// </summary>
    /// <param name="cd">�bUpdate�ɥi�H�a�Jcd�`�٩ʯ�</param>
    /// <param name="m">���u�Z��</param>
    /// <param name="angle">����</param>
    /// <param name="eye">�ۨ�����</param>
    /// <param name="player">��X�ݨ쪺��H(��컷)</param>
    /// <param name="blockMask">�|���׵��u���ϼh</param>
    /// <param name="canLookMask">�ؼЭn�ݪ��ϼh</param>
    /// <returns>�O�_���ݨ������V</returns>
    public Collider PhysicsFindCanSeeLayer(float cd, Transform eye, LayerMask canLookMask, LayerMask blockMask, float m, float angle)
    {
        if (cd > 0f && Time.time < lastFindTime + cd)
            return null;
        lastFindTime = Time.time;
        // ��ΧP�w
        Collider[] overlapSphere = Physics.OverlapSphere(eye.position, m, canLookMask);
        // �˩w�O�_�b���Τ�
        for (int i = 0; i < overlapSphere.Length; i++)
        {
            float n = Vector3.Angle(eye.forward, overlapSphere[i].transform.position - eye.position);
            if (n < angle * 0.5f)
            {
                // �i�H�������Q����
                if (IsCanSee(eye.position, overlapSphere[i].transform.position, blockMask))
                {
                    return overlapSphere[i];
                }
            }
        }
        return null;
    }
    float lastFindTagTime = 0f;
    /// <summary>�^�Ǫ��񦳬����аO���F��</summary>
    public Transform PhysicsFindTag(float cd, Transform eye, string tagName, float m = 5f, float angle = 360f)
    {
        if (Time.time < lastFindTagTime + cd)
            return null;
        lastFindTagTime = Time.time;
        // �p�G�P�䦳���쪺�F��N�n�۬�
        Collider[] stuff = Physics.OverlapSphere(eye.position, m);
        for (int i = 0; i < stuff.Length; i++)
        {
            if (Vector3.Angle(eye.forward, stuff[i].transform.position - eye.transform.position) < angle * 0.5f)
            {
                if (stuff[i].tag == tagName)
                {
                    return stuff[i].transform;
                }
            }
        }
        return null;
    }
    float lastFindCanSeeTagTime = 0f;
    /// <summary>�^�Ǫ��񦳬����аO�åB�i�H����������ê���F��</summary>
    public Transform PhysicsFindCanSeeTag(float cd, Transform eye, string tagName, LayerMask blockMask, float m = 5f, float angle = 360f)
    {
        if (Time.time < lastFindCanSeeTagTime + cd)
            return null;
        lastFindCanSeeTagTime = Time.time;
        // �p�G�P�䦳���쪺�F��N�n�۬�
        Collider[] stuff = Physics.OverlapSphere(eye.position, m);
        for (int i = 0; i < stuff.Length; i++)
        {
            if (Vector3.Angle(eye.forward, stuff[i].transform.position - eye.transform.position) < angle * 0.5f)
            {
                if (stuff[i].tag == tagName)
                {
                    if (IsCanSee(eye.position, stuff[i].transform.position, blockMask))
                        return stuff[i].transform;
                }
            }
        }
        return null;
    }
    #endregion
    #region ���˩w
    /// <summary>�O�_�b���פ�</summary>
    public bool IsOverAngle(Transform eye, Vector3 target, float m = 5f, float angle = 360f)
    {
        return Vector3.Angle(eye.forward, target - eye.position) < (angle * 0.5f);
    }
    float lastFindCanSeeTime = 0f;
    /// <summary>�O�_�b���ץB�ઽ��</summary>
    public bool IsOverAngleCanSee(float cd, Transform eye, Vector3 target, LayerMask blockMask, float m = 5f, float angle = 360f)
    {
        if (Time.time < lastFindCanSeeTime + cd)
            return false;
        lastFindCanSeeTime = Time.time;
        if (IsOverAngle(eye, target, m, angle))
        {
            return IsCanSee(eye.position, target, blockMask);
        }
        return false;
    }
    /// <summary>�����O�_�i�H����</summary>
    public bool IsCanSee(Vector3 a, Vector3 b, LayerMask blockMask)
    {
        Vector3 direction = b - a;
        float maxDistance = Vector3.Distance(a, b);
        // ���Q���ת�ܥi�H����
        return !Physics.Raycast(a, direction, direction.magnitude, blockMask);
    }
    /// <summary>�O�_������</summary>
    public bool IsClose(Vector3 pos, bool ignoreY, float range = 0.3f)
    {
        if (ignoreY)
            pos.y = this.transform.position.y;
        return Vector3.Distance(pos, this.transform.position) < range;
    }
    /// <summary>�p�������ۤv���Z���A���̵u�C</summary>
    public float GetMinDistance(params Vector3[] poss)
    {
        float d = 9999f;
        float n = 0f;
        for (int i = 0; i < poss.Length; i++)
        {
            n = Vector3.Distance(this.transform.position, poss[i]);
            if (n < d)
                d = n;
        }
        return d;
    }
    /// <summary>�ت��a���|����</summary>
    public bool IsPathComplete(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();
        if (nav.CalculatePath(target, path))
        {
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>�b�w�q�d�򤺧�M�@�ӥi�H��F����m</summary>
    /// <param name="minDistance">�̤p�Z��</param>
    /// <param name="maxDistance">�̤j�Z��</param>
    /// <param name="showLog">Log�t�⦸��</param>
    /// <param name="start">�_�l��m�A�����w�N�q�ۤv�}�l</param>
    /// <param name="maxPathLength">�i�H�������̻��Z�� -1�������P�_</param>
    /// <returns>�i�h�I</returns>
    public Vector3 GetRandomAIPos(float minDistance, float maxDistance, Vector3? start = null, float maxPathLength = -1f, bool showLog = false)
    {
        // �C�@�����I���ѴN�|�W�[1�̮e�\�d��A�e�\�d��V�j�����̪�q�U���̤p�̤j�Z���|�V���A���]��O�Ҥ@�w����y�СA�N���J0�]�@�ˡC
        float tryRange = 1f;
        // �����ȴN�έ�
        Vector3 startPos = this.transform.position;
        if (start != null)
            startPos = (Vector3)start;
        Vector3 randomDirection = Vector3.zero;
        NavMeshHit navMeshHit;
        int tryTimes = 0;
        bool done = false;
        Vector3 finalPos = this.transform.position;
        // �̤j�W��999���t���קK����
        while (done == false || tryTimes > 999)
        {
            tryTimes++;
            // �S�������I�N�W�[�e�\�d��A�դ@��
            randomDirection = UnityEngine.Random.insideUnitSphere.normalized * UnityEngine.Random.Range(minDistance, maxDistance);
            randomDirection += startPos;
            bool ��즳���I = NavMesh.SamplePosition(randomDirection, out navMeshHit, tryRange, NavMesh.AllAreas);
            if (��즳���I == false)
            {
                tryRange++;
                continue;
            }
            // �o�Ӯy�Цp�G�L�k��F�]������
            if (IsPathComplete(navMeshHit.position) == false)
            {
                tryRange++;
                continue;
            }
            // �p�G���ݭn�P�w�Z���W���ɤ~�P�_
            if (maxPathLength != -1)
            {
                if (GetPathDistance(navMeshHit.position) > maxPathLength)
                {
                    tryRange++;
                    continue;
                }
            }
            finalPos = navMeshHit.position;
            done = true;
        }
        if (showLog)
            Debug.Log("GetAIPos X " + tryTimes);
        return finalPos;
    }
    /// <summary>������o���I�̪񪺥i���y��</summary>
    public Vector3 GetAIPos(Vector3 pos, bool showLog = false)
    {
        NavMeshHit navMeshHit;
        float tryRange = 0.01f;
        int tryTimes = 0;
        bool done = false;
        Vector3 finalPos = this.transform.position;
        while (done == false || tryTimes > 999)
        {
            tryTimes++;
            bool ��즳���I = NavMesh.SamplePosition(pos, out navMeshHit, tryRange, NavMesh.AllAreas);
            if (��즳���I == false)
            {
                tryRange++;
                continue;
            }
            // �o�Ӯy�Цp�G�L�k��F�]������
            if (IsPathComplete(navMeshHit.position) == false)
            {
                tryRange++;
                continue;
            }
            done = true;
            finalPos = navMeshHit.position;
        }
        if (showLog)
            Debug.Log("GetOkPoint X " + tryTimes);
        return finalPos;
    }
    /// <summary>�p���Y�B���M���Z��</summary>
    public float GetPathDistance(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();
        if (nav.CalculatePath(targetPosition, path))
        {
            float distance = 0f;
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                distance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
            }
            return distance;
        }
        return -1f; // �p�G�L�k�p����|�A��^-1
    }
    #endregion
    #region ���|��V�P��ı��V
    Vector3[] eight = new Vector3[]
    {
    new Vector3(0, 0, 1),
    new Vector3(0, 0, -1),
    new Vector3(-1, 0, 0),
    new Vector3(1, 0, 0),
    new Vector3(-0.75f, 0, 0.75f),
    new Vector3(0.75f, 0, 0.75f),
    new Vector3(-0.75f, 0, -0.75f),
    new Vector3(0.75f, 0, -0.75f),
    };
    float lastWayChange = 0f;
    Vector3 lastWay = Vector3.zero;
    /// <summary>�b�ϥ�UpdateWay�i�HŪ�������U���ਤ������</summary>
    public float wayAngle
    {
        get { return Vector3.Angle(transform.forward, wayTarget - transform.position); }
    }
    Vector3 wayTarget = Vector3.zero;
    /// <summary>�C�V��s�]�w���ʪ���V�A������ws�Bad�Ȥ��X���ʵe�t�ΡA�аȥ��N���⪺���γ]�w�K��C(��X�ɯ�y�ШѰѦҥ�)</summary>
    public void UpdateWay(Vector3 target, float rotateSpeed = 5f, float animMixSpeed = 5f)
    {
        // �ɯ�
        nav.SetDestination(target);
        wayTarget = nav.steeringTarget;
        // ���פ@�P
        wayTarget.y = this.transform.position.y;
        // �p�G�S�����V�ݨD�N���ۤv�v���t�X��V
        if (isFace == false)
        {
            if (wayTarget - transform.position != Vector3.zero)
            {
                Quaternion q = Quaternion.LookRotation(wayTarget - transform.position, Vector3.up);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, q, Time.deltaTime * rotateSpeed);
                SetWSADAnim(Vector2.up);
            }
        }
        else
        {
            // �p��X�۹��m
            Vector3 ab = target - this.transform.position;
            // �N�@�ɤ�V�ର���a��V
            Vector3 localab = this.transform.InverseTransformDirection(ab);
            // ���w���צ����V�q
            localab = Vector3.ClampMagnitude(localab * 999f, 1f);
            float d = 999f;
            int win = 0;
            for (int i = 0; i < eight.Length; i++)
            {
                float n = Vector3.Distance(eight[i], localab);
                if (n < d)
                {
                    d = n;
                    win = i;
                }
            }
            localab = eight[win];
            if (lastWay != localab && Time.time > lastWayChange + 0.5f)
            {
                lastWay = localab;
                lastWayChange = Time.time;
            }
            // Ū���ʵe�쥻���ƭ�
            Vector2 wsad = new Vector2(anim.GetFloat("ad"), anim.GetFloat("ws"));
            // ����
            wsad = Vector2.Lerp(wsad, new Vector2(lastWay.x, lastWay.z), Time.deltaTime * animMixSpeed);
            // �ʵe��X
            SetWSADAnim(wsad);
        }
    }
    Vector2 lastWSAD = Vector2.zero;
    void SetWSADAnim(Vector2 wsad)
    {
        if (lastWSAD != wsad)
        {
            lastWSAD = wsad;
            /*anim.SetFloat("ad", wsad.x);
            anim.SetFloat("ws", wsad.y);*/ //�Ԩ��i�H��wsad
        }
    }
    Transform tempLookTarget = null;
    Vector3 tempOffset = Vector3.zero;
    float tempSpeed = 0f;
    /// <summary>�����ݪF����Y��^�Ӫ��t��</summary>
    public float stopFaceSpeed = 2f;
    bool isFace = false;
    /// <summary>�]�w���¬Y�ӪF�� �ݭn�f�tCancelFace�ϥ�</summary>
    public void Face(Transform target, float speed = 3f)
    {
        Face(target, Vector3.zero, speed);
    }
    /// <summary>���V�Y�ӪF��</summary>
    public void Face(Transform target, Vector3 offset, float speed = 3f)
    {
        tempSpeed = speed;
        tempLookTarget = target;
        this.tempOffset = offset;
        isFace = true;
    }
    /// <summary>�������V�Y�ӪF��</summary>
    public void CancelFace()
    {
        isFace = false;
    }
    /// <summary>���u�v��</summary>
    float lookAtWeight = 0f;
    /// <summary>�ݪ��ؼ�</summary>
    Vector3 lookPoint = Vector3.zero;
    private void OnAnimatorIK(int layerIndex)
    {
        if(isFace)
            lookAtWeight = Mathf.Lerp(lookAtWeight, 1f, Time.deltaTime * tempSpeed);
        else
            lookAtWeight = Mathf.Lerp(lookAtWeight, 0f, Time.deltaTime * stopFaceSpeed);
        anim.SetLookAtWeight(lookAtWeight);
        if (tempLookTarget != null)
            anim.SetLookAtPosition(tempLookTarget.position + tempOffset);
    }
    #endregion
}