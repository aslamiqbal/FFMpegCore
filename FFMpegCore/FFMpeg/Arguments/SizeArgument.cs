using System.Drawing;

namespace FFMpegCore.Arguments
{
    /// <summary>
    /// Represents size parameter
    /// </summary>
    public class SizeArgument : IArgument
    {
        public readonly Size? Size;
        public SizeArgument(Size? size)
        {
            Size = size;
        }

        public SizeArgument(int width, int height) : this(new Size(width, height)) { }

        public string Text => Size == null ? string.Empty : $"-s {Size.Value.Width}x{Size.Value.Height}";
    }
    public class CropArgument : IArgument
    {
        public readonly Size? Size;
        public readonly Size? Pos;
        public CropArgument(Size? size, Size? pos)
        {
            Size = size;
            Pos = pos;
        }

        public CropArgument(int width, int height,int posWidth,int posHeight) : this(new Size(width, height)
            , new Size(posWidth,posHeight)) { }
        //ffmpeg -i input.mp4 -vf "crop=1000:1080:820:0" out3.mp4

        public string Text => (Size == null || Pos==null) ? string.Empty 
            : $"-vf \"crop={Size.Value.Width}:{Size.Value.Height}:{Pos.Value.Width}:{Pos.Value.Height}\" ";
        //"-i \"input.mp4\" -vf  \"crop=720:720:820:0\" \"output.mp4\" -y"

        //public string Text => Size == null ? string.Empty : $"-s {Size.Value.Width}x{Size.Value.Height}";
    }

    public class VintageArgument : IArgument
    { 
       public readonly string _input1;
       public readonly string _input2;
       public readonly string _output1;
       public readonly int _fastfps;
       public readonly int _delayInms;
        public readonly float _colorchannelmixer;
       public readonly string _tmpPath;

        private readonly string _rttxt = "";
        public VintageArgument(string input1, string input2, string output1, int fastfps, int delayInms, float colorchannelmixer,string tmpPath)
        {
            var tmpPath2 = DateTime.UtcNow.Ticks.ToString()+"2.mp4";
            var tmpPath3 = DateTime.UtcNow.Ticks.ToString() + "3.mp4";
            _input1 = input1;
            _input2 = input2;
            _output1 = output1;
            _fastfps = fastfps;
            _delayInms = delayInms;
            _colorchannelmixer = colorchannelmixer;
            _tmpPath= tmpPath;
            var mpg =  "ffmpeg ";
            _rttxt =  $"{mpg} -i {input1} -filter:v fps=fps={_fastfps} {tmpPath} -y\r\n";
            _rttxt += $"{mpg} -i {tmpPath} -vf curves=vintage {tmpPath2} -y\r\n";
            _rttxt += $"{mpg} -i {input2} -vf scale=1920:1080,setsar=1:1 {tmpPath3} -y\r\n";
            var quateVal = $"\"[0]format=rgba,colorchannelmixer=aa={colorchannelmixer}[fg];[1][fg]overlay[out]\" ";
            _rttxt += $"{mpg} -i {tmpPath3} -i {tmpPath2} -filter_complex  {quateVal} -map [out] -pix_fmt yuv420p -c:v libx264 -crf 18 {tmpPath3} -y\r\n";
            _rttxt += $"{mpg} -i {tmpPath3} -i {input1} -c:v copy -c:a aac {output1} -y\r\n";

        } 
        public string Text => _rttxt;
     }
}
