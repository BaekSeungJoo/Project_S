//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase.Auth;
//using UnityEngine.UI;
//using TMPro;
//using Unity.VisualScripting;

//public static class PlayerUser
//{
//    public static string userID;
//    public static string userNickName;

//    // LEGACY:
//    // public static string username;

//    public static void Initialize_User(string userID)
//    {
//        PlayerUser.userID = userID;

//        // LEGACY:
//        // User.username = username;
//    }
//}

//public class FirebaseAuthManager : MonoBehaviour
//{
//    public static FirebaseAuthManager instance;

//    private FirebaseAuth auth;  // �α��� | ȸ������ � ��� => ������ ������ ��ü
//    private FirebaseUser user;  // ������ �Ϸ�� ���� ����

//    [SerializeField] private TMP_InputField emailField;         // �̸��� �Է¹��� �ʵ�
//    [SerializeField] private TMP_InputField passField;          // ��й�ȣ �Է¹��� �ʵ�
//    [SerializeField] private TMP_InputField nickNameField;      // �г��� �Է¹��� �ʵ�

//    void Awake()
//    {
//        instance = this;

//        // ��ü �ʱ�ȭ
//        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

//    }

//    public void register()
//    {
//        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� ȸ������ ���� ��
//        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passField.text).ContinueWith(
//            task => {
//                if(task.IsCanceled) 
//                {
//                    Debug.Log("ȸ������ ĵ����.\n");
//                    return;
//                }

//                if(task.IsFaulted) 
//                {
//                    Debug.Log("���� �߻�\n" + task.Exception);
//                    return;
//                }

//                AuthResult result = task.Result;
//                Debug.Log($"ȸ������ ���� : {result.User.DisplayName}, {result.User.UserId}");
//            }
//            );
//    }

//    public void login()
//    {
//        // �����Ǵ� �Լ� : �̸��ϰ� ��й�ȣ�� �α��� ���� ��
//        auth.SignInWithEmailAndPasswordAsync(emailField.text, passField.text).ContinueWith(
//            task => {
//                if (task.IsCanceled)
//                {
//                    Debug.Log("�α��� ĵ����.\n");
//                    return;
//                }

//                if (task.IsFaulted)
//                {
//                    Debug.Log("�α��� ���� �߻�\n" + task.Exception);
//                    return;
//                }

//                AuthResult result = task.Result;
//                Debug.Log($"�α��� ���� : {emailField.text}, {result.User.UserId}");
//                PlayerUser.Initialize_User(result.User.UserId.ToString());

//                // �г��� ����
//                PlayerUser.userNickName = nickNameField.text;

//            }
//        );
//    }

//    public void LogOut()
//    {
//        auth.SignOut(); // �α׾ƿ��� �ڵ����� �ȴ�.
//        Debug.Log("�α׾ƿ�");
//        PlayerUser.userID = null;
//    }
//}