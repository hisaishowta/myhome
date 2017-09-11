using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace MyHome
{
    enum GamePhase
    {
        INIT,
        TITLE,
        GAMECLEAR,
        GAMEOVER,
        STAGE
    };
    
    class Selector
    {
        bool mSoundLoaded;
        static public MediaPlayer mMediast;

        GameScene mScene = null;
        GamePhase mPhase;
        internal static int num;

        public Selector()
        {
            mPhase = GamePhase.INIT;
        }

        public void Update()
        {
            SceneExitCode ret;
            switch (mPhase)
            {
                case GamePhase.INIT:
                    mScene = new GameTitle();
                    mPhase = GamePhase.TITLE;
                    break;

                case GamePhase.TITLE:
                    ret = mScene.Update();
                    if (KeyState.Enter == true)
                    {
                        mScene = new GameStage();
                        mPhase = GamePhase.STAGE;
                        KeyState.Enter = false;
                        mSoundLoaded = true;
                        num = 1;
                        StageState.mStage_num = 0;
                    }
                    break;

                case GamePhase.STAGE:
                    ret = mScene.Update();
                    mSoundLoaded = false;
                    if (KeyState.Enter == true)
                    {
                        ++num;
                        if (num > 4)
                        {
                            mScene = new GameClear();
                            mPhase = GamePhase.GAMECLEAR;
                            mMediast.Stop();
                        }
                        KeyState.Enter = false;
                    }
                    if (StageState.mStage_num == 1)
                    {
                        mScene = new GameOver();
                        mPhase = GamePhase.GAMEOVER;
                        mMediast.Stop();
                    }
                    if (StageState.mStage_num == 2)
                    {
                        mScene = new GameClear();
                        mPhase = GamePhase.GAMECLEAR;
                        mMediast.Stop();
                    }
                    break;

                case GamePhase.GAMECLEAR:
                    ret = mScene.Update();
                    if (KeyState.Enter == true)
                    {
                        mScene = new GameTitle();
                        mPhase = GamePhase.TITLE;
                        KeyState.Enter = false;
                        mMediast.Stop();
                    }
                    break;

                case GamePhase.GAMEOVER:
                    ret = mScene.Update();
                    if (KeyState.Enter == true)
                    {
                        mScene = new GameTitle();
                        mPhase = GamePhase.TITLE;
                        KeyState.Enter = false;
                        mMediast.Stop();
                    }
                    break;
            }
        }

        public void Render(DrawingContext dc)
        {
            if (mScene != null)
                mScene.Render(dc);

            if (mSoundLoaded)
            {
                if (Selector.num >= 1 && Selector.num <= 4)
                {
                    mMediast = new MediaPlayer();
                    string path = System.IO.Directory.GetCurrentDirectory();
                    path = System.IO.Directory.GetParent(path) + "\\music\\adventurers.mp3";
                    mMediast.Open(new Uri(path));
                    mMediast.Play();
                    mMediast.MediaEnded += (sender, e) =>
                    {
                        mMediast.Position = TimeSpan.FromMilliseconds(1);
                        mMediast.Play();
                    };
                }
            }
        }
    }
}