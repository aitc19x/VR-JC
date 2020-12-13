// Source: https://qiita.com/NON906/items/9ce03e2640c3e16eb4f6
// Copyright by @NON906 on Qiita

using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

namespace Library
{
    public class Track : MonoBehaviour
    {
        // 非表示のままにしておくオブジェクト
        List<GameObject> hideObjs_ = new List<GameObject>();
        // 認識した床
        DetectedPlane plane_ = null;
        // カメラ画像のRenderer
        ARCoreBackgroundRenderer backgroundRenderer_;

        void Start()
        {
            // 子オブジェクトを全て非表示に
            foreach (Transform trans in transform)
            {
                if (trans.gameObject.activeSelf)
                {
                    trans.gameObject.SetActive(false);
                }
                else
                {
                    // すでに非表示にしているものは除外
                    hideObjs_.Add(trans.gameObject);
                }
            }

            backgroundRenderer_ = FindObjectOfType<ARCoreBackgroundRenderer>();
        }

        void Update()
        {
            // タッチされていたら位置をリセット
            if (Input.touchCount > 0)
            {
                ResetPosition();
            }

            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            if (plane_ == null || plane_.TrackingState == TrackingState.Stopped)
            {
                // 新しい床の取得
                plane_ = null;
                List<DetectedPlane> planes = new List<DetectedPlane>();
                Session.GetTrackables<DetectedPlane>(planes, TrackableQueryFilter.All);
                foreach (DetectedPlane plane in planes)
                {
                    if (plane.PlaneType != DetectedPlaneType.Vertical)
                    {
                        plane_ = plane;

                        transform.position = new Vector3(transform.position.x, plane_.CenterPose.position.y, transform.position.z);

                        // 子オブジェクトを表示
                        foreach (Transform trans in transform)
                        {
                            if (!hideObjs_.Contains(trans.gameObject))
                            {
                                trans.gameObject.SetActive(true);
                            }
                        }

                        // カメラ画像を非表示
                        backgroundRenderer_.enabled = false;

                        break;
                    }
                }

                if (plane_ == null)
                {
                    // 子オブジェクトを非表示
                    foreach (Transform trans in transform)
                    {
                        if (!hideObjs_.Contains(trans.gameObject))
                        {
                            trans.gameObject.SetActive(false);
                        }
                    }

                    // カメラ画像を表示
                    backgroundRenderer_.enabled = true;
                }
            }
        }

        // 位置のリセット
        public void ResetPosition()
        {
            Transform transCamera = Camera.main.transform;
            if (plane_ != null)
            {
                transform.position = new Vector3(transCamera.position.x, plane_.CenterPose.position.y, transCamera.position.z);
            }
            else
            {
                transform.position = transCamera.position;
            }
        }
    }
}