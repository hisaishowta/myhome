using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MyHome
{
    //キー
    internal class KeyState
    {
        //キャラクタ移動//キャラクタ切り替え用
        static internal bool Left;
        static internal bool Right;
        static internal bool Space;
        static internal bool Enter;
        static internal bool Up;
        static internal bool Down;
    }

    internal class StageState
    {
        static internal bool mCrackCheck;   //割れ地面確認用フラグ
        static internal int[,] mCrackBox=new int[20,14];  //割れ地面確認用
        static internal bool mLever;        //レバースイッチ
        static internal bool mStageState;   //ステージ用
        static internal int mStage_num;     //ゲーム切り替え

    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread mThread = null;
        bool mLoop = true;

        volatile bool mDrawing = false;
        RenderTargetBitmap mTarget = null;

        //  状態クラス
        Selector mSelector = null;

        public MainWindow()
        {
            InitializeComponent();
            //フォームを一番左端に寄せる
            this.Left = 100;
            //フォームを10ピクセル下に移動させる
            this.Top = 30;

            mSelector = new Selector();

            //  描画ターゲットの生成
            Image screen = new Image();

            //  スクリーンの幅・高さ
            screen.Width = 630;    
            screen.Height = 600; 

            mTarget = new RenderTargetBitmap((int)screen.Width, (int)screen.Height, 96.0, 96.0, PixelFormats.Default);
            screen.Source = mTarget;

            //  ウィンドウサイズの調整と描画ターゲットの割り当て
            this.Width = screen.Width;
            this.Height = screen.Height;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.AddChild(screen);


            //  Thread を生成して開始
            mThread = new Thread(this.DoThread);
            mThread.Start();

            //キー押す
            this.AddHandler(PreviewKeyDownEvent, new KeyEventHandler(this.KeyDown));
            this.AddHandler(PreviewKeyUpEvent, new KeyEventHandler(this.KeyUp));
        }

        //  キーが押された
        public void KeyDown(Object sender, KeyEventArgs e)
        {
            //  左右
            if (e.Key == Key.Left)
            {
                KeyState.Left = true;
            }
            if (e.Key == Key.Right)
            {
                KeyState.Right = true;
            }
            //  Spaceキー(ジャンプ)
            if (e.Key == Key.Space)
            {
                KeyState.Space = true;
            }
            //  Enter
            if (e.Key == Key.Enter)
            {
                KeyState.Enter = true;
            }
            //  Up
            if (e.Key == Key.Up)
            {
                KeyState.Up = true;
            }
            //  Down
            if (e.Key == Key.Down)
            {
                KeyState.Down = true;
            }
        }

        //  キーが離された
        public void KeyUp(Object sender, KeyEventArgs e)
        {
            //  左右
            if (e.Key == Key.Left)
            {
                KeyState.Left = false;
            }
            else if (e.Key == Key.Right)
            {
                KeyState.Right = false;
            }
            // spaceキー(ジャンプ)
            if (e.Key == Key.Space)
            {
                KeyState.Space = false;
            }
            //  Enter
            if (e.Key == Key.Enter)
            {
                KeyState.Enter = false;
            }
            //  Up
            if (e.Key == Key.Up)
            {
                KeyState.Up = false;
            }
            //  Down
            if (e.Key == Key.Down)
            {
                KeyState.Down = false;
            }
        }

        //  ウィンドウの再描画
        protected override void OnRender(DrawingContext dc)
        {
            mDrawing = true;

            DrawingVisual dv = new DrawingVisual();
            //  背景色
            Brush bg = new SolidColorBrush(Color.FromRgb(0, 0, 0));   
            DrawingContext dc2 = dv.RenderOpen();
            dc2.DrawRectangle(bg, null, new Rect(0, 0, mTarget.Width, mTarget.Height));

            if (mSelector != null)
            {
                mSelector.Update();
                mSelector.Render(dc2);
            }

            mDrawing = false;

            dc2.Close();
            mTarget.Render(dv);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            mLoop = false;
            mThread.Interrupt();
        }

        //  スレッドの処理
        public void DoThread()
        {
            while (mLoop)
            {
                try
                {
                    //  画面書き換えを指示する
                    this.Dispatcher.Invoke(delegate() { this.InvalidateVisual(); });
                    Thread.Sleep(30);
                }
                catch (ThreadInterruptedException e)
                {
                }
            }
        }
    }
}