using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseClickTimer
{
    public partial class MainForm : Form
    {
        private Timer countdownTimer;
        private int remainingSeconds;
        private bool isRunning = false;
        private int currentLoop = 0;
        private int totalLoops = 1;

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1秒更新一次
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                // 倒计时结束，执行鼠标点击
                PerformMouseClick();
                currentLoop++;

                // 检查是否完成所有循环
                if (currentLoop >= totalLoops)
                {
                    // 所有循环完成
                    StopTimer();
                    MessageBox.Show($"所有循环已完成！共执行了 {totalLoops} 次点击。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // 还有剩余循环，重新开始倒计时
                    int minutes = (int)nudMinutes.Value;
                    remainingSeconds = minutes * 60;
                    UpdateCountdownDisplay();
                    UpdateLoopDisplay();
                }
            }
            else
            {
                UpdateCountdownDisplay();
            }
        }

        private void UpdateCountdownDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            lblCountdown.Text = $"剩余时间: {minutes:D2}:{seconds:D2}";
        }

        private void UpdateLoopDisplay()
        {
            lblCurrentLoop.Text = $"当前循环: {currentLoop} / {totalLoops}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartTimer();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                StopTimer();
            }
        }

        private void StartTimer()
        {
            try
            {
                int minutes = (int)nudMinutes.Value;
                if (minutes <= 0)
                {
                    MessageBox.Show("请输入大于0的分钟数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                totalLoops = (int)nudLoopCount.Value;
                if (totalLoops <= 0)
                {
                    MessageBox.Show("循环次数必须大于0！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentLoop = 0;
                remainingSeconds = minutes * 60;
                isRunning = true;
                countdownTimer.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                nudMinutes.Enabled = false;
                nudLoopCount.Enabled = false;
                UpdateCountdownDisplay();
                UpdateLoopDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTimer()
        {
            countdownTimer.Stop();
            isRunning = false;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            nudMinutes.Enabled = true;
            nudLoopCount.Enabled = true;
            lblCountdown.Text = "剩余时间: 00:00";
            lblCurrentLoop.Text = "当前循环: 0 / 0";
            currentLoop = 0;
        }

        // Windows API 函数声明，用于模拟鼠标点击
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private void PerformMouseClick()
        {
            // 获取当前鼠标位置
            Point currentPos = Cursor.Position;

            // 模拟鼠标左键按下
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)currentPos.X, (uint)currentPos.Y, 0, 0);

            // 短暂延迟
            System.Threading.Thread.Sleep(10);

            // 模拟鼠标左键释放
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)currentPos.X, (uint)currentPos.Y, 0, 0);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isRunning)
            {
                countdownTimer?.Stop();
            }
            base.OnFormClosing(e);
        }
    }
}
