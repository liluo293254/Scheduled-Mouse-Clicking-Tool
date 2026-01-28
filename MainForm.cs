using System;
using System.Drawing;
using System.IO;
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
        private int fixedClickX = 0;
        private int fixedClickY = 0;

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
                    countdownTimer.Stop();
                    isRunning = false;
                    AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ========== 所有任务已完成 ==========");
                    AddLog($"  总循环数: {totalLoops} 个");
                    AddLog($"  总点击次数: {totalLoops * 3} 次");
                    AddLog("");

                    // 恢复系统休眠设置
                    SetThreadExecutionState(ES_CONTINUOUS);
                    AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 已恢复系统休眠设置");

                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    nudMinutes.Enabled = true;
                    nudLoopCount.Enabled = true;
                    nudClickX.Enabled = true;
                    nudClickY.Enabled = true;
                    lblCountdown.Text = "剩余时间: 00:00";
                    lblCurrentLoop.Text = "当前循环: 0 / 0";
                    currentLoop = 0;

                    MessageBox.Show($"所有循环已完成！共执行了 {totalLoops} 个循环，每个循环点击3次，总计 {totalLoops * 3} 次点击。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // 获取固定坐标
                fixedClickX = (int)nudClickX.Value;
                fixedClickY = (int)nudClickY.Value;

                currentLoop = 0;
                remainingSeconds = minutes * 60;
                isRunning = true;
                countdownTimer.Start();

                // 防止系统休眠和屏幕关闭
                SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED | ES_AWAYMODE_REQUIRED);
                AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 已启用防止系统休眠功能");

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                nudMinutes.Enabled = false;
                nudLoopCount.Enabled = false;
                nudClickX.Enabled = false;
                nudClickY.Enabled = false;
                UpdateCountdownDisplay();
                UpdateLoopDisplay();

                // 记录开始日志
                AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ========== 开始执行任务 ==========");
                AddLog($"  倒计时: {minutes} 分钟");
                AddLog($"  循环次数: {totalLoops} 次");
                AddLog($"  每次循环点击: 3 次，间隔 2 秒");
                AddLog($"  固定点击坐标: ({fixedClickX}, {fixedClickY})");
                AddLog("");
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

            // 恢复系统休眠设置（允许系统正常休眠）
            SetThreadExecutionState(ES_CONTINUOUS);
            AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 已恢复系统休眠设置");

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            nudMinutes.Enabled = true;
            nudLoopCount.Enabled = true;
            nudClickX.Enabled = true;
            nudClickY.Enabled = true;
            lblCountdown.Text = "剩余时间: 00:00";
            lblCurrentLoop.Text = "当前循环: 0 / 0";

            // 记录停止日志
            if (currentLoop > 0)
            {
                AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ========== 任务已停止 ==========");
                AddLog($"  已完成循环: {currentLoop} / {totalLoops}");
                AddLog($"  总计点击: {currentLoop * 3} 次");
                AddLog("");
            }
            else
            {
                AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 任务已取消");
                AddLog("");
            }

            currentLoop = 0;
        }

        // Windows API 函数声明，用于模拟鼠标点击
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        // Windows API 函数声明，用于防止系统休眠
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint SetThreadExecutionState(uint esFlags);

        private const uint ES_CONTINUOUS = 0x80000000;
        private const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private const uint ES_DISPLAY_REQUIRED = 0x00000002;
        private const uint ES_AWAYMODE_REQUIRED = 0x00000040;

        private void PerformMouseClick()
        {
            // 使用固定坐标
            int clickX = fixedClickX;
            int clickY = fixedClickY;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 记录循环开始
            AddLog($"[{timestamp}] 开始执行第 {currentLoop + 1} 个循环的鼠标点击 (固定坐标: {clickX}, {clickY})");

            // 执行三次点击，每次间隔2000毫秒（2秒）
            for (int i = 0; i < 3; i++)
            {
                // 先移动鼠标到固定坐标位置
                SetCursorPos(clickX, clickY);
                
                // 短暂延迟，确保鼠标移动到位
                System.Threading.Thread.Sleep(50);

                // 验证鼠标位置（可选，用于日志）
                Point actualPos;
                GetCursorPos(out actualPos);
                
                // 模拟鼠标左键按下
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

                // 短暂延迟
                System.Threading.Thread.Sleep(10);

                // 模拟鼠标左键释放
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                // 记录每次点击
                string clickTime = DateTime.Now.ToString("HH:mm:ss.fff");
                AddLog($"  [{clickTime}] 第 {i + 1} 次点击完成 (目标坐标: {clickX}, {clickY}, 实际位置: {actualPos.X}, {actualPos.Y})");

                // 如果不是最后一次点击，等待2000毫秒
                if (i < 2)
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }

            // 记录循环完成
            AddLog($"[{DateTime.Now:HH:mm:ss}] 第 {currentLoop + 1} 个循环完成，共点击3次");
        }

        private void AddLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(AddLog), message);
                return;
            }

            txtLog.AppendText(message + Environment.NewLine);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();

            // 保存日志到文件
            SaveLogToFile(message);
        }

        private void SaveLogToFile(string message)
        {
            try
            {
                // 获取程序目录
                string appDirectory = Application.StartupPath;
                string logDirectory = Path.Combine(appDirectory, "Logs");

                // 如果日志目录不存在，创建它
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // 使用日期作为文件名
                string fileName = $"MouseClickLog_{DateTime.Now:yyyy-MM-dd}.txt";
                string filePath = Path.Combine(logDirectory, fileName);

                // 追加写入日志文件
                File.AppendAllText(filePath, message + Environment.NewLine, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // 如果写入文件失败，只在调试时显示错误（避免影响主程序运行）
                System.Diagnostics.Debug.WriteLine($"保存日志失败: {ex.Message}");
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 日志窗口已清空（文件日志未清空）");
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string appDirectory = Application.StartupPath;
                string logDirectory = Path.Combine(appDirectory, "Logs");

                // 如果日志目录不存在，创建它
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // 打开日志文件夹
                System.Diagnostics.Process.Start("explorer.exe", logDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开日志文件夹失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetCurrentPosition_Click(object sender, EventArgs e)
        {
            // 获取当前鼠标位置并设置到坐标输入框
            Point currentPos = Cursor.Position;
            nudClickX.Value = currentPos.X;
            nudClickY.Value = currentPos.Y;
            AddLog($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 已获取当前鼠标位置: ({currentPos.X}, {currentPos.Y})");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isRunning)
            {
                countdownTimer?.Stop();
                // 恢复系统休眠设置
                SetThreadExecutionState(ES_CONTINUOUS);
            }
            base.OnFormClosing(e);
        }
    }
}
