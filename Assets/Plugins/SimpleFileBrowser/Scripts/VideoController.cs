using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFileBrowser
{
    public class VideoController : MonoBehaviour
    {
        private GameObject camera;
        private Main main;
        private UnityEngine.Video.VideoPlayer videoPlayer;
        private float volume = 1.0f;
        FileBrowser fileBrowser;

        // Start is called before the first frame update
        void Start()
        {
            camera = GameObject.Find("Main Camera");
            main = GameObject.Find("Manager").GetComponent<Main>();
            fileBrowser = GameObject.Find("SimpleFileBrowserCanvas").GetComponent<FileBrowser>();
            videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();


            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            // videoPlayer.targetCameraAlpha = 0.5f;

            // *** URL

            // *** 되감기, 빨리감기
            // videoPlayer.frame = 100;

            // *** 반복재생할까?
            // videoPlayer.isLooping = true;

            // videoPlayer.loopPointReached += EndReached;
            videoPlayer.SetDirectAudioVolume(0, volume);
            //videoPlayer.Play();\
        }


        // Update is called once per frame
        void Update()
        {
            if (fileBrowser.isSuccess)
            {
                videoPlayer.url = fileBrowser.videoPath;
                fileBrowser.isSuccess = false;
                Play();
            }
            //print(videoPlayer.frameRate);
            if (main.isIndexActivate && videoPlayer.isPlaying)
            {
                if (main.isMoveUp && volume < 1.0f)
                {
                    volume += 0.05f;
                    videoPlayer.SetDirectAudioVolume(0, volume);
                    print("볼륨 늘리기 "  + (int) (videoPlayer.GetDirectAudioVolume(0) * 100.0f));
                }
                if (main.isMoveDown && volume > 0.0f)
                {
                    volume -= 0.05f;
                    videoPlayer.SetDirectAudioVolume(0, volume);
                    print("볼륨 줄이기 " + (int) (videoPlayer.GetDirectAudioVolume(0) * 100.0f));
                }
                if (main.isMoveLeft)
                {
                    videoPlayer.frame -= (int)(videoPlayer.frameRate * 5.0f);
                    print("5초 뒤로");
                }
                if (main.isMoveRight)
                {
                    videoPlayer.frame += (int)(videoPlayer.frameRate * 5.0f);
                    print("5초 앞으로");
                }
            }

            if (main.isFingerClickActivate && main.isReadyToPinchActivate)
            {
                if (videoPlayer.isPlaying)
                {
                    Pause();
                    
                    print("정지");
                }
                else
                {
                    Play();
                    
                    print("시작");
                }

                main.isFingerClickActivate = false;
            }
        }

        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            vp.playbackSpeed = vp.playbackSpeed / 10.0f;
        }

        public void Play()
        {
            if (!videoPlayer.url.Equals(""))
            {
                camera.transform.position = new Vector3(0, 0, 1.0f);
                videoPlayer.Play();
            }
        }

        public void Pause()
        {
            camera.transform.position = new Vector3(0, 0, 0);
            videoPlayer.Pause();
        }

    }


    //vp.Play()//영상을 재생합니다.
    //vp.Pause()//영상을 일시정지합니다
    //vp.Stop()//영상을 완전 정지시킵니다(시간대가 0으로 돌아갑니다
    //vp.time//읽기 속성으로 현재 재생 시간대를 알려줍니다.
    //vp.cilp.length//현재 영상의 길이를 알려줍니다
    //vp.frameRate//현재 영상의 프레임 속도를 실시간으로 알려줍니다.
    //isPlaying // 영상이 재생되고있는지 아닌지 유무를 확인합니다.
    //isPrepared//영상 재생이 준비되었는지 아닌지를 확인합니다.
    //isLooping//영상이 반복되었는지 아닌지를 확인합니다.
}