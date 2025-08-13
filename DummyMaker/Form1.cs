using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyMaker
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            comboDrive.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                {
                    comboDrive.Items.Add(drive.Name);
                }
            }

            if (comboDrive.Items.Count > 0)
                comboDrive.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            btnFill.Enabled = false;
            lblResult.Text = "준비 중...";
            progressBar.Value = 0;

            stopwatch = Stopwatch.StartNew();

            int targetPercent = (int)numPercent.Value;  // 퍼센트 가져오기

            await Task.Run(() => FillDisk(targetPercent));

            stopwatch.Stop();
            lblResult.Text = $"완료! 총 소요 시간: {stopwatch.Elapsed.TotalSeconds:F1}초";
            btnFill.Enabled = true;
        }
        private void FillDisk(int targetPercent)
        {
            try
            {
                string driveLetter = comboDrive.Invoke(() => comboDrive.SelectedItem.ToString().TrimEnd('\\'));
                DriveInfo drive = new DriveInfo(driveLetter);

                long totalBytes = drive.TotalSize;
                long freeBytes = drive.AvailableFreeSpace;
                long usedBytes = totalBytes - freeBytes;
                long targetUsed = (long)(totalBytes * (targetPercent / 100.0));
                long bytesToFill = targetUsed - usedBytes;

                if (bytesToFill <= 0)
                {
                    UpdateStatus($"이미 {targetPercent}% 이상 사용 중입니다.");
                    return;
                }

                string dummyPath = Path.Combine(driveLetter + "\\", $"dummy_fill_{DateTime.Now.ToFileTime()}.dat");

                const int bufferSize = 1024 * 1024; // 1MB
                byte[] buffer = new byte[bufferSize];
                long written = 0;

                using (FileStream fs = new FileStream(dummyPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    int totalSteps = (int)(bytesToFill / bufferSize);
                    for (int i = 0; i < totalSteps; i++)
                    {
                        fs.Write(buffer, 0, bufferSize);
                        written += bufferSize;

                        if (i % 50 == 0) // 너무 자주 업데이트하면 UI 부담
                        {
                            int progress = (int)((double)written / bytesToFill * 100);
                            UpdateProgress(progress, written);
                        }
                    }
                }

                UpdateProgress(100, written);
            }
            catch (Exception ex)
            {
                UpdateStatus("오류: " + ex.Message);
            }
        }
        private void UpdateProgress(int percent, long writtenBytes)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = percent;
                lblStatus.Text = $"진행률: {percent}% | 작성: {writtenBytes / (1024 * 1024)} MB | 경과: {stopwatch.Elapsed.TotalSeconds:F1}초";
            });
        }

        private void UpdateStatus(string message)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                lblStatus.Text = message;
            }));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string driveLetter = comboDrive.Invoke(() => comboDrive.SelectedItem.ToString().TrimEnd('\\'));
            var files = Directory.GetFiles(driveLetter + "\\", "dummy_fill_*.dat");
            foreach (var file in files)
                File.Delete(file);
            lblResult.Text = $"{driveLetter}\\dummy_fill.dat 삭제";
            lblStatus.Text = "";
            progressBar.Value = 0;
        }
    }
}
