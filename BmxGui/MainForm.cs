using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmxGui
{
    public class MainForm : Form
    {
        private ComboBox cmbTool;
        private TextBox txtInput;
        private Button btnBrowseInput;
        private TextBox txtArgs;
        private Button btnRun;
        private TextBox txtLog;
        private Button btnSettings;
        private Button btnOpenOutput;
        private Label lblStatus;
        private OpenFileDialog ofd;
        private DataGridView dgvChecks;
        private Button btnFixAndSave;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private ProgressBar progressBar;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cmbTool = new ComboBox();
            btnSettings = new Button();
            txtInput = new TextBox();
            btnBrowseInput = new Button();
            txtArgs = new TextBox();
            btnRun = new Button();
            btnOpenOutput = new Button();
            lblStatus = new Label();
            dgvChecks = new DataGridView();
            progressBar = new ProgressBar();
            txtLog = new TextBox();
            btnFixAndSave = new Button();
            ofd = new OpenFileDialog();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvChecks).BeginInit();
            SuspendLayout();
            // 
            // cmbTool
            // 
            cmbTool.Items.AddRange(new object[] { "raw2bmx", "bmxtranswrap", "mxf2raw", "bmxparse", "h264dump", "j2cdump", "jp2extract", "movdump", "vc2dump" });
            cmbTool.SelectedIndex = 2;
            cmbTool.Location = new Point(93, 12);
            cmbTool.Name = "cmbTool";
            cmbTool.Size = new Size(121, 23);
            //cmbTool.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(12, 13);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Настройки";
            btnSettings.Click += BtnSettings_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(93, 42);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(496, 23);
            txtInput.TabIndex = 2;
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Location = new Point(12, 41);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(75, 23);
            btnBrowseInput.TabIndex = 3;
            btnBrowseInput.Text = "Обзор";
            btnBrowseInput.Click += BtnBrowseInput_Click;
            // 
            // txtArgs
            // 
            txtArgs.Location = new Point(223, 12);
            txtArgs.Name = "txtArgs";
            txtArgs.PlaceholderText = "Additional arguments (e.g. --essence-track=0 --output=my.mxf)";
            txtArgs.Size = new Size(366, 23);
            txtArgs.TabIndex = 4;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(12, 71);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 5;
            btnRun.Text = "Запустить";
            btnRun.Click += BtnRun_Click;
            // 
            // btnOpenOutput
            // 
            btnOpenOutput.Location = new Point(93, 100);
            btnOpenOutput.Name = "btnOpenOutput";
            btnOpenOutput.Size = new Size(97, 23);
            btnOpenOutput.TabIndex = 6;
            btnOpenOutput.Text = "Открыть папку";
            btnOpenOutput.Click += BtnOpenOutput_Click;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(196, 100);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(393, 23);
            lblStatus.TabIndex = 7;
            // 
            // dgvChecks
            // 
            dgvChecks.AllowUserToAddRows = false;
            dgvChecks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvChecks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChecks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvChecks.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Consolas", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvChecks.DefaultCellStyle = dataGridViewCellStyle3;
            dgvChecks.EnableHeadersVisualStyles = false;
            dgvChecks.GridColor = Color.LightGray;
            dgvChecks.Location = new Point(12, 129);
            dgvChecks.Name = "dgvChecks";
            dgvChecks.ReadOnly = true;
            dgvChecks.RowHeadersVisible = false;
            dgvChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChecks.Size = new Size(1148, 620);
            dgvChecks.TabIndex = 10;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(93, 71);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(496, 23);
            progressBar.TabIndex = 9;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(595, 12);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(565, 111);
            txtLog.TabIndex = 8;
            // 
            // btnFixAndSave
            // 
            btnFixAndSave.Location = new Point(12, 100);
            btnFixAndSave.Name = "btnFixAndSave";
            btnFixAndSave.Size = new Size(75, 23);
            btnFixAndSave.TabIndex = 11;
            btnFixAndSave.Text = "Исправить";
            btnFixAndSave.Click += BtnFixAndSave_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.FillWeight = 40F;
            dataGridViewTextBoxColumn1.HeaderText = "Категория";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.FillWeight = 30F;
            dataGridViewTextBoxColumn2.HeaderText = "Статус";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.HeaderText = "Детали";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(1172, 761);
            Controls.Add(cmbTool);
            Controls.Add(btnSettings);
            Controls.Add(txtInput);
            Controls.Add(btnBrowseInput);
            Controls.Add(txtArgs);
            Controls.Add(btnRun);
            Controls.Add(btnOpenOutput);
            Controls.Add(lblStatus);
            Controls.Add(txtLog);
            Controls.Add(progressBar);
            Controls.Add(dgvChecks);
            Controls.Add(btnFixAndSave);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BMX GUI - Visual wrapper for bmx tools";
            ((System.ComponentModel.ISupportInitialize)dgvChecks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            using var sf = new SettingsForm();
            sf.ShowDialog(this);
        }

        private void BtnBrowseInput_Click(object? sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                txtInput.Text = ofd.FileName;
        }

        private async void BtnRun_Click(object? sender, EventArgs e)
        {
            txtLog.Clear();
            lblStatus.Text = "Building command...";

            string bmxPath = Properties.Settings.Default.BmxPath;
            if (string.IsNullOrWhiteSpace(bmxPath) || !Directory.Exists(bmxPath))
            {
                MessageBox.Show("Please set the path to bmx binaries in Settings.", "bmx path not set",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tool = cmbTool.SelectedItem.ToString();
            string exe = Path.Combine(bmxPath, tool + (OperatingSystem.IsWindows() ? ".exe" : ""));
            if (!File.Exists(exe))
            {
                MessageBox.Show($"Cannot find {exe}.", "Executable not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string args = BuildArgs(tool);
            lblStatus.Text = $"Running {tool}...";
            btnRun.Enabled = false;

            try
            {
                var result = await ToolRunner.RunAsync(exe, args, AppendLog, AppendLog);
                lblStatus.Text = $"Exit {result.ExitCode}";
                AppendLog("=== Анализ MXF ===");
                await DeepVerifyMXF(txtInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run tool: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRun.Enabled = true;
            }
        }

        private void BtnOpenOutput_Click(object? sender, EventArgs e)
        {
            var dir = Path.GetDirectoryName(txtInput.Text);
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Invalid folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start(new ProcessStartInfo { FileName = dir, UseShellExecute = true });
        }

        private string BuildArgs(string tool)
        {
            var args = txtArgs.Text ?? "";
            if (!string.IsNullOrWhiteSpace(txtInput.Text) && !args.Contains(txtInput.Text))
                args = $"\"{txtInput.Text}\" " + args;
            return args;
        }

        private void AppendLog(string text)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke((MethodInvoker)(() => AppendLog(text)));
                return;
            }

            txtLog.AppendText(text + Environment.NewLine);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        // === Расширенная проверка MXF ===
        private async Task DeepVerifyMXF(string filePath)
        {
            try
            {
                dgvChecks.Rows.Clear();
                progressBar.Value = 0;
                lblStatus.Text = "Проверка MXF...";
                AppendLog("=== Анализ MXF ===");

                string metadataPath = Path.Combine(Path.GetDirectoryName(filePath) ?? "", "metadata.txt");

                // Создаём metadata.txt при необходимости
                if (!File.Exists(metadataPath))
                    await EnsureMetadataExists(filePath, metadataPath);

                string metadata = File.Exists(metadataPath) ? File.ReadAllText(metadataPath) : "";
                using var mi = new MediaInfoHelper(filePath);

                // Список всех проверок
                var checks = new (string name, Func<(string, string, Color)> func)[]
                {
            ("Соответствие стандартам", () => CheckStandards(metadata, mi)),
            ("Целостность контейнера", () => CheckContainer(metadata, mi)),
            ("Потоки данных", () => CheckStreams(mi)),
            ("Метаданные", () => CheckMetadata(metadata)),
            ("Кодирование", () => CheckEncoding(mi)),
            ("FrameRate / Timecode", () => CheckFrameRateTimecode(mi)),
            ("Аудио каналы", () => CheckAudioChannels(mi)),
            ("Синхронизация A/V", () => CheckDurationSync2(mi)),
            ("Видео параметры", () => CheckVideoSpecs(mi)),
            ("Audio Sample Rate", () => CheckAudioSampleRate(mi)),
            ("Длительность потоков", () => CheckDurationSync(mi)),
            ("Идентификаторы", () => CheckIdentifiers(mi)),

            // Новые профессиональные проверки
            ("Цветовая схема", () => CheckColorimetry(mi)),
            ("Соотношение сторон", () => CheckAspectRatio(mi)),
            ("GOP структура", () => CheckGopStructure(mi)),
            ("Битрейт / Профиль", () => CheckBitrateProfile(mi)),
            ("Timecode Continuity", () => CheckTimecodeContinuity(mi))

                };

                progressBar.Maximum = checks.Length;
                progressBar.Value = 0;

                foreach (var check in checks)
                {
                    var result = check.func();
                    AddCheck(check.name, result);
                    progressBar.PerformStep();
                    await Task.Delay(150);
                }

                AppendLog("");
                AppendLog("=== Результаты расширенной проверки ===");
                foreach (DataGridViewRow row in dgvChecks.Rows)
                    AppendLog($"{row.Cells[0].Value}: {row.Cells[1].Value} - {row.Cells[2].Value}");
                AppendLog("============================================");
                AppendLog("");
                lblStatus.Text = "Проверка завершена ✅";
            }
            catch (Exception ex)
            {
                AppendLog("❌ Ошибка DeepVerifyMXF: " + ex.Message);
                MessageBox.Show("Ошибка анализа MXF:\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка анализа ❌";
            }
        }



        // === Генерация metadata.txt ===
        private async Task<bool> EnsureMetadataExists(string filePath, string metadataPath)
        {
            string bmxPath = Properties.Settings.Default.BmxPath;
            if (string.IsNullOrWhiteSpace(bmxPath) || !Directory.Exists(bmxPath))
            {
                AppendLog("❌ Путь к bmx не настроен.");
                return false;
            }

            string? mxf2rawExe = Directory.GetFiles(bmxPath, "mxf2raw.exe", SearchOption.AllDirectories).FirstOrDefault();
            if (mxf2rawExe == null)
            {
                AppendLog("❌ Не найден mxf2raw.exe. Попробую использовать bmxparse.exe.");
                mxf2rawExe = Directory.GetFiles(bmxPath, "bmxparse.exe", SearchOption.AllDirectories).FirstOrDefault();
                if (mxf2rawExe == null)
                {
                    AppendLog("❌ Не найден ни mxf2raw.exe, ни bmxparse.exe.");
                    return false;
                }
            }

            AppendLog($"Запуск генерации metadata.txt через: {Path.GetFileName(mxf2rawExe)}");
            AppendLog($"Команда: \"{mxf2rawExe}\" --info --info-file \"{metadataPath}\" \"{filePath}\"");

            var result = await ToolRunner.RunAsync(mxf2rawExe,
                $"--info --info-file \"{metadataPath}\" \"{filePath}\"",
                s => AppendLog(s), s => AppendLog("[stderr] " + s));

            AppendLog($"Exit code: {result.ExitCode}");
            for (int i = 0; i < 10; i++)
            {
                if (File.Exists(metadataPath))
                {
                    AppendLog("✅ metadata.txt успешно создан.");
                    return true;
                }
                await Task.Delay(500);
            }

            AppendLog("❌ metadata.txt не найден после выполнения команды.");
            return false;
        }

        private void AddCheck(string category, (string Status, string Details, Color Color) result)
        {
            int idx = dgvChecks.Rows.Add(category, result.Status, result.Details);

            // Цвет текста
            dgvChecks.Rows[idx].Cells[1].Style.ForeColor = result.Color;

            // Цвет фона всей строки по уровню серьезности
            if (result.Color == Color.Red)
                dgvChecks.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
            else if (result.Color == Color.Orange)
                dgvChecks.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
            else if (result.Color == Color.Green)
                dgvChecks.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);

            // Добавляем иконку в первую колонку
            dgvChecks.Rows[idx].HeaderCell.Value = result.Color == Color.Red ? "❌" :
                                                   result.Color == Color.Orange ? "⚠️" :
                                                   "✅";

            // Увеличиваем высоту строки для читаемости
            dgvChecks.Rows[idx].Height = 28;
        }

        private (string, string, Color) CheckStandards(string metadata, MediaInfoHelper mi)
        {
            // Пробуем вытащить Operational Pattern через разные ключи
            string[] keys = { "OperationalPattern", "Format_Profile", "Format_Commercial_IfAny", "Format" };
            string op = "";

            foreach (var key in keys)
            {
                op = mi.GetGeneralParameter(key);
                if (!string.IsNullOrWhiteSpace(op))
                    break;
            }

            if (!string.IsNullOrEmpty(op))
            {
                if (op.Contains("OP1a", StringComparison.OrdinalIgnoreCase) ||
    op.Contains("OP-1a", StringComparison.OrdinalIgnoreCase))
                    return ("ОК", $"Operational Pattern: {op}", Color.Green);
                if (op.Contains("OPAtom", StringComparison.OrdinalIgnoreCase))
                    return ("ОК", $"Operational Pattern: {op}", Color.Green);
                return ("Предупреждение", $"Operational Pattern: {op} (нестандартный или нераспознанный)", Color.Orange);
            }

            // fallback — по metadata.txt
            bool hasOp = metadata.IndexOf("OP1a", StringComparison.OrdinalIgnoreCase) >= 0;
            if (hasOp)
                return ("ОК", "Operational Pattern: OP1a (из metadata.txt)", Color.Green);

            return ("Ошибка", "Не удалось определить Operational Pattern (ST 377-1 не подтверждён)", Color.Red);
        }

        private (string, string, Color) CheckContainer(string metadata, MediaInfoHelper mi)
        {
            if (string.IsNullOrEmpty(metadata))
            {
                if (mi.VideoCount > 0 || mi.AudioCount > 0)
                    return ("ОК", "Контейнер читается корректно (по MediaInfo)", Color.Green);
                return ("Ошибка", "metadata.txt отсутствует и потоки не обнаружены", Color.Red);
            }

            bool hasPartition = metadata.Contains("Partition");
            bool hasEssence = metadata.Contains("Essence");
            if (hasPartition && hasEssence)
                return ("ОК", "Контейнер целый", Color.Green);
            if (hasPartition || hasEssence)
                return ("Предупреждение", "Частично неполная структура", Color.Orange);
            return ("Ошибка", "Missing Partition; Missing Essence;", Color.Red);
        }

        private (string, string, Color) CheckStreams(MediaInfoHelper mi)
        {
            if (mi.VideoCount == 0 && mi.AudioCount == 0)
                return ("Ошибка", "Отсутствуют потоки видео/аудио", Color.Red);
            return ("ОК", $"Видео: {mi.VideoCount}, Аудио: {mi.AudioCount}", Color.Green);
        }

        private (string, string, Color) CheckMetadata(string metadata)
        {
            if (string.IsNullOrEmpty(metadata))
                return ("Предупреждение", "metadata.txt отсутствует", Color.Orange);

            bool hasMaterial = metadata.IndexOf("Material Package", StringComparison.OrdinalIgnoreCase) >= 0;
            bool hasFile = metadata.IndexOf("File Package", StringComparison.OrdinalIgnoreCase) >= 0 ||
                           metadata.IndexOf("Source Package", StringComparison.OrdinalIgnoreCase) >= 0;
            if (hasMaterial && hasFile)
                return ("ОК", "Material/File Package присутствуют", Color.Green);
            if (hasFile)
                return ("ОК", "File Package присутствует (Material отсутствует — допустимо)", Color.Green);
            if (hasMaterial)
                return ("ОК", "Material Package присутствует", Color.Green);
            return ("Предупреждение", "Пакеты не найдены", Color.Orange);
        }

        private (string, string, Color) CheckEncoding(MediaInfoHelper mi)
        {
            string vcodec = mi.GetVideoParameter(0, "Format");
            string acodec = mi.GetAudioParameter(0, "Format");
            if (string.IsNullOrEmpty(vcodec) && string.IsNullOrEmpty(acodec))
                return ("Ошибка", "Не определены кодеки", Color.Red);

            string details = $"Video: {vcodec}, Audio: {acodec}";
            if (vcodec.Contains("MPEG", StringComparison.OrdinalIgnoreCase) ||
                vcodec.Contains("DNxHD", StringComparison.OrdinalIgnoreCase) ||
                vcodec.Contains("AVC", StringComparison.OrdinalIgnoreCase))
                return ("ОК", details, Color.Green);
            return ("Предупреждение", details + " (нестандартное кодирование)", Color.Orange);
        }

        private (string, string, Color) CheckColorimetry(MediaInfoHelper mi)
        {
            string color = mi.GetVideoParameter(0, "ColorSpace") ?? "";
            string primaries = mi.GetVideoParameter(0, "ColorPrimaries") ?? "";

            if (string.IsNullOrWhiteSpace(color) && string.IsNullOrWhiteSpace(primaries))
                return ("Предупреждение", "Не указано цветовое пространство", Color.Orange);

            if (primaries.Contains("BT.709", StringComparison.OrdinalIgnoreCase))
                return ("ОК", $"Colorimetry: Rec.709 ({color})", Color.Green);

            if (primaries.Contains("BT.2020", StringComparison.OrdinalIgnoreCase))
                return ("Предупреждение", $"Colorimetry: Rec.2020 (HDR контент)", Color.Orange);

            return ("Ошибка", $"Неизвестное цветовое пространство ({primaries})", Color.Red);
        }

        private (string, string, Color) CheckAspectRatio(MediaInfoHelper mi)
        {
            string aspect = mi.GetVideoParameter(0, "DisplayAspectRatio") ?? "";
            if (string.IsNullOrWhiteSpace(aspect))
                return ("Предупреждение", "Соотношение сторон не указано", Color.Orange);

            if (aspect.StartsWith("16:9"))
                return ("ОК", "Соотношение 16:9", Color.Green);
            if (aspect.StartsWith("4:3"))
                return ("ОК", "Соотношение 4:3", Color.Green);

            return ("Предупреждение", $"Нетипичное соотношение ({aspect})", Color.Orange);
        }

        private (string, string, Color) CheckGopStructure(MediaInfoHelper mi)
        {
            string gop = mi.GetVideoParameter(0, "GOP") ?? "";
            string frameCount = mi.GetVideoParameter(0, "FrameCount") ?? "";

            if (string.IsNullOrEmpty(gop))
                return ("Предупреждение", "Информация о GOP недоступна", Color.Orange);

            if (int.TryParse(gop, out int gopLength))
            {
                if (gopLength <= 12)
                    return ("ОК", $"GOP длина: {gopLength}", Color.Green);
                if (gopLength <= 15)
                    return ("Предупреждение", $"GOP длина: {gopLength} (на грани допустимого)", Color.Orange);
                return ("Ошибка", $"Слишком длинный GOP ({gopLength})", Color.Red);
            }

            // Альтернатива — текстовый анализ
            if (gop.Contains("I") && gop.Contains("P"))
                return ("ОК", "GOP структура содержит ключевые кадры", Color.Green);

            return ("Ошибка", "Невозможно определить GOP структуру", Color.Red);
        }




        private async void BtnFixAndSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text) || !File.Exists(txtInput.Text))
            {
                MessageBox.Show("Выберите действительный MXF-файл для исправления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string input = txtInput.Text;
            string fixedFile = Path.Combine(
                Path.GetDirectoryName(input)!,
                Path.GetFileNameWithoutExtension(input) + "_fixed.mxf"
            );

            string bmxPath = Properties.Settings.Default.BmxPath;
            string exe = Path.Combine(bmxPath, "bmxtranswrap.exe");

            if (!File.Exists(exe))
            {
                MessageBox.Show("Не найден bmxtranswrap.exe. Укажите путь в Settings.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AppendLog("\r\n=== Исправление MXF ===");

            string args = $"-t op1a -o \"{fixedFile}\" --check-complete --min-part \"{input}\"";
            var result = await ToolRunner.RunAsync(exe, args, s => AppendLog(s), s => AppendLog(s));

            if (result.ExitCode == 0 && File.Exists(fixedFile))
            {
                AppendLog($"Исправленный файл сохранён как: {fixedFile}");
                MessageBox.Show($"Файл успешно исправлен и сохранён как:\n{fixedFile}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppendLog("\r\n=== Повторная проверка исправленного файла ===");
                await DeepVerifyMXF(fixedFile);
            }
            else
            {
                AppendLog("Ошибка исправления файла. Подробности в логе.");
                MessageBox.Show("Не удалось исправить файл. См. лог для подробностей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Дополнительные проверки MXF ===

        private (string, string, Color) CheckFrameRateTimecode(MediaInfoHelper mi)
        {
            string frameRate = mi.GetVideoParameter(0, "FrameRate");
            string timecode = mi.GetGeneralParameter("TimeCode_FirstFrame");

            if (string.IsNullOrEmpty(frameRate))
                return ("Предупреждение", "Не удалось определить FrameRate", Color.Orange);

            if (string.IsNullOrEmpty(timecode))
                return ("Предупреждение", "Отсутствует Timecode", Color.Orange);

            if (frameRate.StartsWith("25") && timecode.Contains("DF", StringComparison.OrdinalIgnoreCase))
                return ("Ошибка", $"Drop-Frame при 25 fps (timecode: {timecode})", Color.Red);

            return ("ОК", $"FrameRate: {frameRate}, Timecode: {timecode}", Color.Green);
        }

        private (string, string, Color) CheckAudioChannels(MediaInfoHelper mi)
        {
            if (mi.AudioCount == 0)
                return ("Ошибка", "Аудио потоки отсутствуют", Color.Red);

            if (mi.AudioCount != 8)
                return ("Предупреждение", $"Обнаружено {mi.AudioCount} каналов (ожидалось 8)", Color.Orange);

            return ("ОК", $"Количество каналов: {mi.AudioCount}", Color.Green);
        }

        private (string, string, Color) CheckVideoSpecs(MediaInfoHelper mi)
        {
            string width = mi.GetVideoParameter(0, "Width");
            string bitrate = mi.GetVideoParameter(0, "BitRate");

            if (string.IsNullOrEmpty(width) || string.IsNullOrEmpty(bitrate))
                return ("Предупреждение", "Не удалось определить разрешение или битрейт", Color.Orange);

            if (int.TryParse(width, out int w) && int.TryParse(bitrate, out int br))
            {
                if (w < 1920 || br < 50000000)
                    return ("Предупреждение", $"Разрешение: {width}px, Битрейт: {br / 1000000} Мбит/с (ниже нормы для XDCAM HD422)", Color.Orange);
                return ("ОК", $"Разрешение: {width}px, Битрейт: {br / 1000000} Мбит/с", Color.Green);
            }

            return ("Предупреждение", "Не удалось интерпретировать параметры видео", Color.Orange);
        }

        private (string, string, Color) CheckAudioSampleRate(MediaInfoHelper mi)
        {
            string sampleRate = mi.GetAudioParameter(0, "SamplingRate");
            if (string.IsNullOrEmpty(sampleRate))
                return ("Предупреждение", "Не удалось определить частоту дискретизации", Color.Orange);

            if (!sampleRate.Contains("48000"))
                return ("Ошибка", $"Неверная частота дискретизации: {sampleRate} Hz (ожидалось 48000)", Color.Red);

            return ("ОК", $"Audio Sample Rate: {sampleRate} Hz", Color.Green);
        }

        private (string, string, Color) CheckDurationSync(MediaInfoHelper mi)
        {
            string vDurStr = mi.GetVideoParameter(0, "Duration");
            string aDurStr = mi.GetAudioParameter(0, "Duration");

            if (double.TryParse(vDurStr, out double vDur) && double.TryParse(aDurStr, out double aDur))
            {
                double diff = Math.Abs(vDur - aDur);
                if (diff > 40)
                    return ("Предупреждение", $"Несовпадение длительности: Δ={diff:F0} мс", Color.Orange);
                return ("ОК", $"Video: {vDur:F0} мс, Audio: {aDur:F0} мс", Color.Green);
            }
            return ("Предупреждение", "Не удалось определить длительность потоков", Color.Orange);
        }

        private (string, string, Color) CheckIdentifiers(MediaInfoHelper mi)
        {
            string umid = mi.GetGeneralParameter("UniqueID");
            string uuid = mi.GetGeneralParameter("UUID");

            if (string.IsNullOrEmpty(umid) && string.IsNullOrEmpty(uuid))
                return ("Предупреждение", "Отсутствуют UMID/UUID идентификаторы", Color.Orange);

            return ("ОК", $"UMID: {(umid ?? "—")}, UUID: {(uuid ?? "—")}", Color.Green);
        }

        private (string, string, Color) CheckBitrateProfile(MediaInfoHelper mi)
        {
            string format = mi.GetVideoParameter(0, "Format") ?? "";
            string profile = mi.GetVideoParameter(0, "Format_Profile") ?? "";
            string bitrateStr = mi.GetVideoParameter(0, "BitRate") ?? "";
            string width = mi.GetVideoParameter(0, "Width") ?? "";
            string height = mi.GetVideoParameter(0, "Height") ?? "";

            double.TryParse(bitrateStr.Replace(" ", "").Replace("bps", "").Replace("k", "000").Replace("M", "000000"), out double bitrate);

            // 🧩 1. Определяем стандарт по комбинации формата + профиля + разрешения
            if (format.Contains("MPEG Video", StringComparison.OrdinalIgnoreCase) && bitrate > 40000000 && width.Contains("1920"))
            {
                return ("ОК", $"XDCAM HD422, Bitrate ≈ {bitrate / 1000000:F1} Mbps", Color.Green);
            }
            if (format.Contains("DNxHD", StringComparison.OrdinalIgnoreCase) && bitrate > 180000000)
            {
                return ("ОК", $"DNxHD 185/220, {bitrate / 1000000:F1} Mbps", Color.Green);
            }
            if (format.Contains("AVC", StringComparison.OrdinalIgnoreCase) && bitrate > 95000000)
            {
                return ("ОК", $"AVC-Intra 100, {bitrate / 1000000:F1} Mbps", Color.Green);
            }
            if (format.Contains("AVC", StringComparison.OrdinalIgnoreCase) && bitrate > 45000000)
            {
                return ("ОК", $"AVC-Intra 50, {bitrate / 1000000:F1} Mbps", Color.Green);
            }

            // 🧩 2. Если битрейт слишком низкий
            if (bitrate > 0 && bitrate < 10000000)
                return ("Ошибка", $"Слишком низкий битрейт ({bitrate / 1000000:F1} Mbps)", Color.Red);

            // 🧩 3. Если MediaInfo не вернул Bitrate
            if (bitrate == 0)
                return ("Предупреждение", "Не удалось определить битрейт — возможно, VBR или недоступно", Color.Orange);

            // 🧩 4. По умолчанию
            return ("Предупреждение", $"{format} / {profile}, Bitrate: {bitrate / 1000000:F1} Mbps", Color.Orange);
        }

        private (string, string, Color) CheckDurationSync2(MediaInfoHelper mi)
        {
            try
            {
                // Получаем длительности потоков
                double.TryParse(mi.GetVideoParameter(0, "Duration").Replace(",", ".") ?? "0", out double videoDuration);
                double.TryParse(mi.GetAudioParameter(0, "Duration").Replace(",", ".") ?? "0", out double audioDuration);

                // Получаем реальный FrameRate (например 25.0, 29.97, 50, 59.94)
                string frameRateStr = mi.GetVideoParameter(0, "FrameRate") ?? "25.0";
                frameRateStr = frameRateStr.Replace(",", ".");
                double.TryParse(frameRateStr, out double frameRate);

                if (frameRate <= 0)
                    frameRate = 25.0; // fallback

                double frameDuration = 1000.0 / frameRate; // миллисекунд на кадр

                if (videoDuration == 0 || audioDuration == 0)
                    return ("Предупреждение", "Не удалось определить длительность видео/аудио", Color.Orange);

                // Разница в миллисекундах
                double diffMs = Math.Abs(videoDuration - audioDuration);
                double diffFrames = diffMs / frameDuration;

                // Формируем текст с деталями
                string details = $"Δ {diffFrames:F2} кадров ({diffMs:F0} мс), FPS: {frameRate:F2}";

                if (diffFrames <= 1)
                    return ("ОК", "A/V синхронизация в норме — " + details, Color.Green);
                if (diffFrames <= 5)
                    return ("Предупреждение", "Небольшое расхождение длительностей — " + details, Color.Orange);

                return ("Ошибка", "Рассинхронизация A/V — " + details, Color.Red);
            }
            catch (Exception ex)
            {
                return ("Предупреждение", "Ошибка при проверке синхронизации: " + ex.Message, Color.Orange);
            }
        }

        private (string, string, Color) CheckTimecodeContinuity(MediaInfoHelper mi)
        {
            try
            {
                string startTC = mi.GetGeneralParameter("TimeCode_FirstFrame") ??
                                 mi.GetVideoParameter(0, "TimeCode_FirstFrame") ??
                                 mi.GetGeneralParameter("TimeCode_Start") ??
                                 mi.GetVideoParameter(0, "TimeCode_Start");

                string endTC = mi.GetGeneralParameter("TimeCode_LastFrame") ??
                               mi.GetVideoParameter(0, "TimeCode_LastFrame") ??
                               mi.GetGeneralParameter("TimeCode_End") ??
                               mi.GetVideoParameter(0, "TimeCode_End");

                string durationStr = mi.GetVideoParameter(0, "Duration");
                double.TryParse(durationStr?.Replace(",", ".") ?? "0", out double durationMs);

                if (string.IsNullOrWhiteSpace(startTC) && string.IsNullOrWhiteSpace(endTC))
                    return ("Предупреждение", "Таймкод не найден в метаданных MXF", Color.Orange);

                if (!TimeSpan.TryParse(startTC.Replace(';', ':'), out var startTime))
                    startTime = TimeSpan.Zero;

                if (!TimeSpan.TryParse(endTC.Replace(';', ':'), out var endTime))
                    endTime = TimeSpan.Zero;

                // вычисляем длительность по таймкоду (в секундах)
                double tcDuration = (endTime - startTime).TotalMilliseconds;
                if (tcDuration < 0)
                    tcDuration += 24 * 60 * 60 * 1000; // если переход через сутки

                // реальная длительность
                double diff = Math.Abs(tcDuration - durationMs);

                string details = $"Start TC: {startTC}, End TC: {endTC}, Δ={diff / 1000:F2} сек";

                if (diff < 100) // до 0.1 секунды
                    return ("ОК", "Таймкод соответствует длительности — " + details, Color.Green);
                if (diff < 1000)
                    return ("Предупреждение", "Незначительное расхождение таймкода — " + details, Color.Orange);

                return ("Ошибка", "Разрыв таймкода или несоответствие длительности — " + details, Color.Red);
            }
            catch (Exception ex)
            {
                return ("Предупреждение", "Ошибка анализа таймкода: " + ex.Message, Color.Orange);
            }
        }


    }
}
