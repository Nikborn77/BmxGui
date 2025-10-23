using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BmxGui
{
    public class ToolResult
    {
        public int ExitCode { get; set; }
        public string StdOut { get; set; } = "";
        public string StdErr { get; set; } = "";
    }

    public static class ToolRunner
    {
        public static Task<ToolResult> RunAsync(string exePath, string args, Action<string>? onStdOut = null, Action<string>? onStdErr = null)
        {
            return Task.Run(() =>
            {
                var psi = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                var p = new Process { StartInfo = psi };
                var stdout = new StringBuilder();
                var stderr = new StringBuilder();

                p.OutputDataReceived += (s, e) =>
                {
                    if (e.Data != null)
                    {
                        stdout.AppendLine(e.Data);
                        onStdOut?.Invoke(e.Data + Environment.NewLine);
                    }
                };
                p.ErrorDataReceived += (s, e) =>
                {
                    if (e.Data != null)
                    {
                        stderr.AppendLine(e.Data);
                        onStdErr?.Invoke(e.Data + Environment.NewLine);
                    }
                };

                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();

                return new ToolResult
                {
                    ExitCode = p.ExitCode,
                    StdOut = stdout.ToString(),
                    StdErr = stderr.ToString()
                };
            });
        }
    }
}
