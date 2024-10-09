namespace PracticeABC;

class Program
{
    // интерфйс для видеоплеера
    public interface IVideoPlayer
    {
        void NotifyVideoPlayed();
    }

    public class Mp4Player : IVideoPlayer
    {
        public void NotifyVideoPlayed()
        {
            Console.WriteLine("видео mp4 воспроизводится!");
        }
    }


    //интерфйс для аудиоплеера
    public interface IAudioPlayer
    {
        void NotifyAudioPlayed();
    }

    // kласс для mp3 плеера
    public class Mp3Player : IAudioPlayer
    {
        public void NotifyAudioPlayed()
        {
            Console.WriteLine("audio mp3 воспроизводится!");
        }
    }

    // kласс для wav плеера
    public class WavPlayer : IAudioPlayer
    {
        public void NotifyAudioPlayed()
        {
            Console.WriteLine("audio wav воспроизводится!");
        }
    }


    public class MultimediaPlayer
    {
        public void PlayFile(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            if (extension == ".mp4")
            {
                IVideoPlayer videoPlayer = new Mp4Player();
                videoPlayer.NotifyVideoPlayed();
            }

            if (extension == ".mp3")
            {
                IAudioPlayer audioPlayer = new Mp3Player();
                audioPlayer.NotifyAudioPlayed();
            }

            if (extension == ".wav")
            {
                IAudioPlayer audioPlayer = new WavPlayer();
                audioPlayer.NotifyAudioPlayed();
            }

            else
            {
                Console.WriteLine("неизвестный формат файла");
            }
        }
    }
    static void Main(string[] args)
    {
        MultimediaPlayer multimediaPlayer = new MultimediaPlayer();

        multimediaPlayer.PlayFile("orops.mp4");
        multimediaPlayer.PlayFile("sonfjsljzg.mp3");
        multimediaPlayer.PlayFile("flajzk.wav");
        multimediaPlayer.PlayFile("kdsgfilk;z.txt");
    }
}
