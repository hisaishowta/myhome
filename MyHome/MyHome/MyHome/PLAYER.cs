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


    //  キャラクタークラス
    public class Player
    {
        //  読み込んだ画像位置
        internal double mX, mY;
        internal double num = 0;
        int count = 0; //アニメーション用カウント
        internal double subX, subY;
        BitmapImage[] r_mPicture = new BitmapImage[6];        //  キャラクタ右用
        BitmapImage[] l_mPicture = new BitmapImage[6];        //  キャラクタ左用

        //プレイヤーの横幅と縦幅用の変数
        internal double Width, Height;

        //重力
        double Gravity = 0.5;
        //加速度
        double mVelocity = 0;
        //地面判定
        bool mOnTheGround;
        bool mSpaceKeyFlag = true;

        //梯子にいるかの状態判断
        bool mOnTheLadder = false;

        //歩数計
        int walkcounter = 1;

        //足音の引数
        static int k = 0;

        public Player()
        {
            //初期化
            mX = mY = 0;

            //  カレントディレクトリは、bin/debugフォルダなので1つ上にたどってから
            string cwd = System.IO.Directory.GetCurrentDirectory();

            //キャラクター:右向き
            string[] r_path = new[]{
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r00.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r01.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r02.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r03.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r04.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\right\\r05.gif"};
            //キャラクター:左向き
            string[] l_path = new[]{
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l00.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l01.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l02.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l03.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l04.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\chara\\left\\l05.gif"};
            for (int i = 0; i < 6; ++i)
            {
                r_mPicture[i] = new BitmapImage(new Uri(r_path[i]));
                l_mPicture[i] = new BitmapImage(new Uri(l_path[i]));
            }
        }

        //  アニメーション
        public void move()
        {
            //プレイヤーの横幅と縦幅を定める
            Width = mX + 25;
            Height = mY + 44;
            ////GameStageクラス梯子判定メソッドにPlayerの座標を渡す
            mOnTheLadder = GameStage.ladder(this.mX, this.mY, Width, Height);
            //梯子マスの範囲にいる時
            if (mOnTheLadder)
            {
                moveOnTheLadder();
            }
            //梯子マスの範囲にいない時
            else
            {
                moveNormally();
            }

            switch (Selector.num)
            {
                case 1:
                    if (num == 0)
                    {
                        mX = mY = 0;
                        StageState.mLever = false;
                        StageState.mCrackCheck = false;
                        num++;
                    }
                    break;
                case 2:
                    if (num == 1)
                    {
                        mX = mY = 0;
                        StageState.mLever = false;
                        StageState.mCrackCheck = false;
                        num++;
                    }
                    break;
                case 3:
                    if (num == 2)
                    {
                        mX = 46;
                        mY = 0;
                        StageState.mLever = false;
                        StageState.mCrackCheck = false;
                        num++;
                    }
                    break;
                case 4:
                    if (num == 3)
                    {
                        mX = mY = 0;
                        StageState.mLever = false;
                        StageState.mCrackCheck = false;
                        num = 0;
                    }
                    break;

            }

            double newX, newY, centerX, centerY;
            newX = mX;
            double aniX = mX, aniY = mY;
            //左右の動き
            if (KeyState.Left)
            {
                newX = mX - 3;
                ++walkcounter;
                if (mOnTheGround == true)
                {
                    if (walkcounter % 25 == 0)
                    {
                        k = 1;
                        Sound.Play(k);
                    }
                }
            }
            else
            {
                newX = mX;
            }
            if (KeyState.Right)
            {
                newX = mX + 3;
                ++walkcounter;
                if (mOnTheGround == true)
                {
                    if (walkcounter % 25 == 0)
                    {
                        k = 1;
                        Sound.Play(k);
                    }
                }
            }

            //ジャンプキー
            if (KeyState.Space)
            {
                if (!mSpaceKeyFlag)
                {
                    if (mOnTheGround)
                    {
                        mVelocity -= 7.7;
                        mOnTheGround = false;
                    }
                }
                mSpaceKeyFlag = true;
            }
            else
            {
                mSpaceKeyFlag = false;
            }

            //中心X座標を算出
            centerX = newX + 12;

            //壁チェック
            //壁に挟まれるシチュエーションはとりあえず考慮しない
            //よって左右一択とする(右優先)
            double wallX;
            wallX = GameStage.R_HitCheck(centerX + 1.0, mY, newX + 24, mY + 44);
            if (newX + 25 > wallX)
            {
                newX = wallX - 25;
            }

            else
            {
                wallX = GameStage.L_HitCheck(newX, mY, centerX, mY + 44);
                if (newX < wallX)
                {
                    newX = wallX;
                }
            }

            //死亡
            if (wallX == 1000)
            {
                StageState.mStage_num = 1;
            }

            //ジャンプ制御
            double old = mVelocity;
            mVelocity += Gravity;
            newY = mY + (mVelocity + old) / 2;

            //中心Y座標チェック
            centerY = newY + 22;

            //天井チェック
            double ceil = GameStage.T_HitCheck(newX, newY, newX + 24, centerY);
            if (ceil == 1000)
            {
                StageState.mStage_num = 1;
            }
            if (ceil > newY)
            {
                newY = ceil;
            }

            //梯子チェック
            bool bLadder = false;
            bLadder = GameStage.ladder(newX, newY, newX + 44, newY + 44);

            //床チェック
            double floor = GameStage.B_HitCheck(newX, centerY + 1.0, newX + 24, newY + 44);
            if (newY >= floor)
            {
                if (!bLadder)
                {
                    //梯子に乗っていなければブロックに乗る
                    newY = floor;
                }
                else if (mY < floor)
                {
                    //落ちてきて梯子に乗ったとき
                    newY = floor;
                }
                else if (newY > mY)
                {
                    //落下させない
                    newY = mY;
                }

                mVelocity = 0;
                mOnTheGround = true;
            }

            mX = newX;
            mY = aniY = newY;

            //キャラクタ動き
            if (aniX != mX)
            {
                ++count;
                aniX = mX;
                this.mX = aniX;
                this.mY = aniY;

                if (count >= 59)
                {
                    count = 0;
                }
            }

            if (this.mY >= 700 && !(Selector.num == 4))
            {
                KeyState.Enter = true;
            }
            if (Selector.num == 4)
            {
                if (this.mY >= 555)
                {
                    this.mY = 555;
                }
                if (wallX == 1001)
                {
                    StageState.mStage_num = 2;
                }
            }

            if (this.mY <= 0)
            {
                this.mY = 0;
            }
        }

        //梯子マス範囲内では、上下動あり、重力働かず
        public void moveOnTheLadder()
        {
            Gravity = 0;
            mVelocity = 0;
            if (KeyState.Up)
            {
                double newY = mY - 4;
                double floor = GameStage.B_HitCheck(this.mX, this.mY, this.mX + 24, mY + 44, true);
                double top = GameStage.T_HitCheck(this.mX, this.mY - 2, this.mX + 24, mY + 43);

                if (floor > newY)
                {
                    newY = floor;
                }
                if (top > newY)
                {
                    newY = top;
                }
                mY = newY;
            }


            if (KeyState.Down)
            {
                double newY = mY + 4;
                //床チェック
                double floor = GameStage.B_HitCheck(this.mX + 3, newY + 16, this.mX + 27, newY + 47, false);
                if (floor < newY)
                {
                    newY = floor;
                }
                mY = newY;
            }
        }

        //梯子の上でない時のmoveメソッド・梯子に乗ってない時(梯子マス範囲外時)は梯子を床として判定
        public void moveNormally()
        {
            //梯子以外でも下がるバグが出ないための処置
            bool ladderCheck = GameStage.ladder(this.mX, this.mY, Width, Height + 5);
            //重力が無くなったままにならない為の処理
            Gravity = 0.5;
            if (KeyState.Down)
            {
                //空中で下キーを押しても落下速度をいじらせないための処理
                if (mOnTheGround == false)
                {
                    KeyState.Down = false;
                }
                if (ladderCheck)
                {
                    //キーを押している間だけ重力がなくなる
                    Gravity = 0;
                    mVelocity = 0;
                    subY = 5;
                    mY += subY;
                }
            }
        }

        //  描画
        public void draw(DrawingContext dc)
        {
            if (KeyState.Right)
            {
                dc.DrawImage(r_mPicture[count / 10],
                    new Rect(
                        Math.Floor(this.mX),
                        Math.Floor(this.mY),
                        r_mPicture[count / 10].Width,
                        r_mPicture[count / 10].Height));
            }
            if (KeyState.Left)
            {
                dc.DrawImage(l_mPicture[count / 10],
                    new Rect(
                        Math.Floor(this.mX),
                        Math.Floor(this.mY),
                        l_mPicture[count / 10].Width,
                        l_mPicture[count / 10].Height));
            }
            else
            {
                dc.DrawImage(r_mPicture[count / 10],
                    new Rect(
                        Math.Floor(this.mX),
                        Math.Floor(this.mY),
                        r_mPicture[count / 10].Width,
                        r_mPicture[count / 10].Height));
            }
        }
    }
}