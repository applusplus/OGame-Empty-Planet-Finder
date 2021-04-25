using System;
using System.IO;
using OGameEmptyPlanetFinder.AudioPlayer;

namespace OGameEmptyPlanetFinder.Autoplay
{
    public class AlertManager
    {
        private AudioManager audioManager;

        public AlertManager() 
        {
            audioManager = new AudioManager();
        }

        public Exception PlayRandomSound(string directory)
        {
            Exception exception = null;
            try
            {
                string[] mp3Paths = Directory.GetFiles(directory, "*.mp3");
                string[] wavPaths = Directory.GetFiles(directory, "*.wav");
                string[] allPaths = new string[mp3Paths.Length + wavPaths.Length];
                Array.Copy(mp3Paths, allPaths, mp3Paths.Length);
                Array.Copy(wavPaths, 0, allPaths, mp3Paths.Length, wavPaths.Length);
                if (allPaths.Length > 0)
                {
                    int randomIndex = new Random().Next(allPaths.Length);
                    audioManager.PlayAudioFile(allPaths[randomIndex]);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                exception = ex;
            }
            catch (IOException ex)
            {
                exception = ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                exception = ex;
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }
            return exception;
        }

        public void Stop()
        {
            audioManager.Stop();
        }
    }
}
