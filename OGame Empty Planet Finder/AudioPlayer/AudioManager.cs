using System;
using NAudio.Wave;

namespace OGameEmptyPlanetFinder.AudioPlayer
{
    public class AudioManager
    {
        private IWavePlayer waveOutDevice;
        private LoopStream mainOutputStream;

        public void PlayAudioFile(string audioFile)
        {
            if (waveOutDevice == null)
            {
                waveOutDevice = new WaveOut();
                mainOutputStream = CreateInputStream(audioFile);
                waveOutDevice.Init(mainOutputStream);
                waveOutDevice.Play();
            }
        }

        public void Stop()
        {
            CloseWaveOut();
        }

        private LoopStream CreateInputStream(string fileName, bool loop = true)
        {
            LoopStream loopStream = null;
            if (fileName.EndsWith(".mp3"))
            {
                Mp3FileReader mp3Reader = new Mp3FileReader(fileName);
                loopStream = new LoopStream(mp3Reader);
            }
            else if (fileName.EndsWith(".wav"))
            {
                WaveFileReader wavReader = new WaveFileReader(fileName);
                loopStream = new LoopStream(wavReader);
            }
            else
            {
                throw new InvalidOperationException("Unsupported extension");
            }
            loopStream.EnableLooping = loop;
            return loopStream;
        }

        public void CloseWaveOut()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
            if (mainOutputStream != null)
            {
                mainOutputStream.Close();
                mainOutputStream = null;
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
        }
    }
}
