using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace BreakoutGameLab001
{
    class CustomizedPanel : Panel
    {
        // 定義 Timer 控制項
        private Timer timer = new Timer();
        //
        private int X= 0;
        private int Y= 0;
        public CustomizedPanel(int width, int height)
        { 
            // this.DoubleBuffered = true;
            this.BackColor = Color.LightSteelBlue; 
            this.Size = new Size(width, height);
        }
        //
        public void Initialize() { 
            // Timer : 每 20 毫秒觸發一次 Timer_Tick 事件 ==> 更新遊戲畫面
            // 也可以利用 Thread 類別來實現 類似的功能!!
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 更新遊戲狀態
            // 移動球的位置, 檢查碰撞事件 ...
            X += 10;
            Y += 10;
            // 要求遊戲畫面重繪
            Invalidate(); // --> 觸發 OnPaint 事件
            //
        }

        // 處理畫面的重繪事件
        protected override void OnPaint(PaintEventArgs e)
        {
            // 呼叫基底類別的 OnPaint 方法 --> 這樣才能正確繪製 Panel 控制項
            base.OnPaint(e);

            // 取得 Graphics 物件
            Graphics gr = e.Graphics;

            // 繪製遊戲畫面
            gr.FillEllipse(new SolidBrush(Color.LightSalmon), X, Y, 50, 50);
            //
            Point[] points = { new Point(150, 200), new Point(185, 150), new Point(250, 250) };
            gr.DrawCurve(new Pen(Color.LightGreen, 3),points);
            //
            gr.DrawRectangle(new Pen(Color.SaddleBrown,2),200,200,100,50);
            
        }
    }
}
