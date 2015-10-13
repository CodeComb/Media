# Media

App Veyor: [![Build status](https://ci.appveyor.com/api/projects/status/lthpo7x04l4b9dgt/branch/master?svg=true)](https://ci.appveyor.com/project/Kagamine/media/branch/master)

Travis: [![Build status](https://travis-ci.org/CodeComb/Media.svg)](https://travis-ci.org/CodeComb/Media)

An cross-plat media library, available for DNX451 / DNXCORE50 / NET45 / NET46

When you run it at first time, it will take a few minutes to restore some resources.

It is easy to convert a video or image format:

```
var media = new Video("C:\\test\\test.flv");
media.Convert(".mp4", Quality.Smallest).SaveAs(@"C:\\test\\test.mp4");
```