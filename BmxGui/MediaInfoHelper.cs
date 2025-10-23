using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BmxGui
{
    public class MediaInfoHelper : IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool isLoaded = false;
        private string filePath = "";

        // === Импорт функций MediaInfo.dll ===
        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr MediaInfo_New();

        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void MediaInfo_Delete(IntPtr handle);

        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr MediaInfo_Open(IntPtr handle, string fileName);

        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void MediaInfo_Close(IntPtr handle);

        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern IntPtr MediaInfo_Get(
            IntPtr handle,
            StreamKind streamKind,
            int streamNumber,
            string parameter,
            InfoKind kindOfInfo,
            InfoKind kindOfSearch);

        [DllImport("MediaInfo.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int MediaInfo_Count_Get(IntPtr handle, StreamKind streamKind, int streamNumber);

        // === Перечисления ===
        public enum StreamKind
        {
            General,
            Video,
            Audio,
            Text,
            Other,
            Image,
            Menu
        }

        public enum InfoKind
        {
            Name,
            Text,
            Measure,
            Options,
            NameText,
            MeasureText,
            Info,
            HowTo
        }

        // === Конструктор ===
        public MediaInfoHelper(string path)
        {
            filePath = path;

            try
            {
                handle = MediaInfo_New();
                if (handle == IntPtr.Zero)
                    throw new Exception("MediaInfo_New() вернул NULL — библиотека не инициализировалась.");

                var result = MediaInfo_Open(handle, path);
                if (result == IntPtr.Zero)
                    throw new Exception("Не удалось открыть файл через MediaInfo.");

                isLoaded = true;
            }
            catch (DllNotFoundException)
            {
                throw new Exception("❌ MediaInfo.dll не найден. Помести DLL рядом с BmxGui.exe (x64 версия).");
            }
            catch (BadImageFormatException)
            {
                throw new Exception("❌ Ошибка формата DLL — версия MediaInfo.dll не совпадает с архитектурой приложения (x64/x86).");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка инициализации MediaInfo: {ex.Message}");
            }
        }

        // === Основной метод ===
        public string Get(StreamKind kind, int index, string param)
        {
            try
            {
                if (!isLoaded || handle == IntPtr.Zero)
                    return "";

                IntPtr ptr = MediaInfo_Get(handle, kind, index, param, InfoKind.Text, InfoKind.Name);
                if (ptr == IntPtr.Zero)
                    return "";

                return Marshal.PtrToStringUni(ptr) ?? "";
            }
            catch
            {
                return "";
            }
        }

        // === Универсальные обертки ===
        public string GetGeneralParameter(string name)
            => Get(StreamKind.General, 0, name);

        public string GetVideoParameter(int index, string name)
            => Get(StreamKind.Video, index, name);

        public string GetAudioParameter(int index, string name)
            => Get(StreamKind.Audio, index, name);

        public string GetGOP()
            => Get(StreamKind.Video, 0, "GOP");

        public string GetColorSpace()
            => Get(StreamKind.Video, 0, "colour_space");

        public string GetAspectRatio()
            => Get(StreamKind.Video, 0, "DisplayAspectRatio/String");

        public string GetUMID()
            => Get(StreamKind.General, 0, "UMID");

        // === Подсчёт треков ===
        public int VideoCount
        {
            get
            {
                try
                {
                    return MediaInfo_Count_Get(handle, StreamKind.Video, -1);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int AudioCount
        {
            get
            {
                try
                {
                    return MediaInfo_Count_Get(handle, StreamKind.Audio, -1);
                }
                catch
                {
                    return 0;
                }
            }
        }

        // === Закрытие ===
        public void Close()
        {
            if (handle != IntPtr.Zero)
            {
                try { MediaInfo_Close(handle); } catch { }
                try { MediaInfo_Delete(handle); } catch { }
                handle = IntPtr.Zero;
                isLoaded = false;
            }
        }

        public void Dispose()
        {
            Close();
        }
    }
}