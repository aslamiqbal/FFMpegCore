using System.Drawing;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Extensions.SkiaSharp;
using FFMpegCore.Extensions.System.Drawing.Common;
using FFMpegCore.Pipes;
using SkiaSharp;
using FFMpegImage = FFMpegCore.Extensions.System.Drawing.Common.FFMpegImage;

//var inputPath = "/path/to/input";
//var outputPath = "/path/to/output";

var inputPath = "in1.mp4";
var outputPath = "output.mp4";

{
    var mediaInfo = FFProbe.Analyse(inputPath);
}

{
    var mediaInfo = await FFProbe.AnalyseAsync(inputPath);
    //X=1280
    //Y=720
     
    //FFMpeg.Crop(inputPath, outputPath,440,720,820,0);
    var input1 = "in1.mp4";
    var input2 = "in2.mp4";
    var output1 = "out1.mp4";
    var delayInms = 1000;
    var fastfps = 10;
    var colorchannelmixer = 0.25f;

    FFMpeg.Vintage(input1,input2,output1,fastfps,delayInms,colorchannelmixer);
    //FFMpeg.Vintage(input1, input2, output1, fastfps, delayInms, colorchannelmixer);
}
/*
 ffmpeg.exe -i td-10sec.mp4 -filter:v fps=fps=10 td-fast.mp4

ffmpeg.exe -i output.mp4 -vf curves=vintage td-vintage-fast.mp4


ffmpeg -i td-vintage-fast.mp4 -vf scale=1920:1080,setsar=1:1 oldFilm1080.mp4

--ffmpeg -ss 00:01:00 -to 00:02:00 -i input.mp4 -c copy output.mp4

ffmpeg -ss 00:00:01  -i oldFilm1080.mp4 -c copy output2.mp4

ffmpeg.exe -i oldFilm1080.mp4 -i td-vintage-fast.mp4 -filter_complex "[0]format=rgba,colorchannelmixer=aa=0.25[fg];
[1][fg]overlay[out]" -map [out] -pix_fmt yuv420p -c:v libx264 -crf 18 touchdown-vintage.mp4



ffmpeg -i touchdown-vintage.mp4 -i audio.mp4 -c:v copy -c:a aac output.mp4
 */


var isreturn = true;
if (isreturn)
{
    return;
}

{
    FFMpegArguments
        .FromFileInput(inputPath)
        .OutputToFile(outputPath, false, options => options
            .WithVideoCodec(VideoCodec.LibX264)
            .WithConstantRateFactor(21)
            .WithAudioCodec(AudioCodec.Aac)
            .WithVariableBitrate(4)
            .WithVideoFilters(filterOptions => filterOptions
                .Scale(VideoSize.Hd))
            .WithFastStart())
        .ProcessSynchronously();
}

{
    // process the snapshot in-memory and use the Bitmap directly
    var bitmap = FFMpegImage.Snapshot(inputPath, new Size(200, 400), TimeSpan.FromMinutes(1));

    // or persists the image on the drive
    FFMpeg.Snapshot(inputPath, outputPath, new Size(200, 400), TimeSpan.FromMinutes(1));
}

var inputStream = new MemoryStream();
var outputStream = new MemoryStream();

{
    await FFMpegArguments
        .FromPipeInput(new StreamPipeSource(inputStream))
        .OutputToPipe(new StreamPipeSink(outputStream), options => options
            .WithVideoCodec("vp9")
            .ForceFormat("webm"))
        .ProcessAsynchronously();
}

{
    FFMpeg.Join(@"..\joined_video.mp4",
        @"..\part1.mp4",
        @"..\part2.mp4",
        @"..\part3.mp4"
    );
}

{
    FFMpeg.JoinImageSequence(@"..\joined_video.mp4", frameRate: 1, @"..\1.png", @"..\2.png", @"..\3.png");
}

{
    FFMpeg.Mute(inputPath, outputPath);
}

{
    FFMpeg.ExtractAudio(inputPath, outputPath);
}

var inputAudioPath = "/path/to/input/audio";
{
    FFMpeg.ReplaceAudio(inputPath, inputAudioPath, outputPath);
}

var inputImagePath = "/path/to/input/image";
{
    FFMpeg.PosterWithAudio(inputPath, inputAudioPath, outputPath);
    // or using FFMpegCore.Extensions.System.Drawing.Common
#pragma warning disable CA1416
    using var image = Image.FromFile(inputImagePath);
    image.AddAudio(inputAudioPath, outputPath);
#pragma warning restore CA1416
    // or using FFMpegCore.Extensions.SkiaSharp
    using var skiaSharpImage = SKBitmap.Decode(inputImagePath);
    skiaSharpImage.AddAudio(inputAudioPath, outputPath);
}

IVideoFrame GetNextFrame() => throw new NotImplementedException();
{
    IEnumerable<IVideoFrame> CreateFrames(int count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return GetNextFrame(); //method of generating new frames
        }
    }

    var videoFramesSource = new RawVideoPipeSource(CreateFrames(64)) //pass IEnumerable<IVideoFrame> or IEnumerator<IVideoFrame> to constructor of RawVideoPipeSource
    {
        FrameRate = 30 //set source frame rate
    };
    await FFMpegArguments
        .FromPipeInput(videoFramesSource)
        .OutputToFile(outputPath, false, options => options
            .WithVideoCodec(VideoCodec.LibVpx))
        .ProcessAsynchronously();
}

{
    // setting global options
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./bin", TemporaryFilesFolder = "/tmp" });
    // or
    GlobalFFOptions.Configure(options => options.BinaryFolder = "./bin");

    // or individual, per-run options
    await FFMpegArguments
        .FromFileInput(inputPath)
        .OutputToFile(outputPath)
        .ProcessAsynchronously(true, new FFOptions { BinaryFolder = "./bin", TemporaryFilesFolder = "/tmp" });

    // or combined, setting global defaults and adapting per-run options
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = "./bin", TemporaryFilesFolder = "./globalTmp", WorkingDirectory = "./" });

    await FFMpegArguments
        .FromFileInput(inputPath)
        .OutputToFile(outputPath)
        .Configure(options => options.WorkingDirectory = "./CurrentRunWorkingDir")
        .Configure(options => options.TemporaryFilesFolder = "./CurrentRunTmpFolder")
        .ProcessAsynchronously();
}
