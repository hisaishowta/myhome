using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace MyHome
{
    class GameTitle : GameScene
    {
        int mCount;

        //  読み込んだ画像の保存場所
        BitmapImage[] mPicture = new BitmapImage[2];
        string[] path = new string[2];
        FormattedText mText = null;
        FormattedText mText2 = null;
        Typeface mTypeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Medium);
        System.Globalization.CultureInfo mCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");
        RenderTargetBitmap mTarget = null;

        public GameTitle()
        {
            Image screen = new Image();
            screen.Width = 630;    //  スクリーンの幅
            screen.Height = 600;    //  スクリーンの高
            mTarget = new RenderTargetBitmap
                ((int)screen.Width,
                (int)screen.Height,
                96.0,
                96.0,
                PixelFormats.Default);

            //  画像読み込み
            //  img フォルダからタイトルのファイルを読む
            string cwd = System.IO.Directory.GetCurrentDirectory();
            //string cwd2 = System.IO.Directory.GetCurrentDirectory();
            path[0] = System.IO.Directory.GetParent(cwd) + "\\img\\title\\start.gif";
            path[1] = System.IO.Directory.GetParent(cwd) + "\\img\\title\\title.gif";

            for (int i = 0; i < 2; ++i)
            {
                mPicture[i] = new BitmapImage(new Uri(path[i]));
            }

            mText = new FormattedText("Push Enter Key",
                mCulture,
                FlowDirection.LeftToRight,
                mTypeface,
                50,
                Brushes.White);
            mText2 = new FormattedText
                ("使用音楽\n"  + 
                 "「adventurers.mp3」\n" +
                 "音楽素材提供：Music-Note.jp \n" +
                 "URL：http://www.music-note.jp/ \n" +
 　	             "運営：株式会社ピクセル \n" + 
                 "URL：http://pixel-co.com/ \n",
                mCulture,
                FlowDirection.LeftToRight,
                mTypeface,
                10,
                Brushes.White);
            if (KeyState.Enter)
            {
                mCount = 0;
            }
        }

        public override SceneExitCode Update()
        {
            return SceneExitCode.ExitDefault;
        }
        public override void Render(DrawingContext dc)
        {
            DrawingVisual dv = new DrawingVisual();
            dc.DrawImage(mPicture[0], new Rect(0, 0, mPicture[0].Width, mPicture[0].Height));
            dc.DrawImage(mPicture[1], new Rect(0, 0, mPicture[1].Width, mPicture[1].Height));

            dc.DrawText(mText2, new Point(0, 500));
            mCount = (mCount + 1) % 30;
            if (mCount < 15)
            {
                double x = (mTarget.Width - mText.Width) / 2;
                dc.DrawText(mText, new Point(x, 450));
            }
        }
    }
}