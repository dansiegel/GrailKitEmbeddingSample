using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UXDivers.Grial;
using static System.Net.Mime.MediaTypeNames;

#if ANDROID
using Android.App;
using Android.Content;
using Android.Content.PM;
#endif

namespace GrialKitEmbeddingSample;

public static class AppBuilderExtensions
{
	public static MauiAppBuilder UseMauiControls(this MauiAppBuilder builder)
	{
#if __IOS__
		var theme = new ThemeColorsBase(new Dictionary<string, Color>
		{
			{ "AccentColor", Color.FromArgb("#FF3F75FF") }
		});

		GrialKit.Init(theme, "GrialKitEmbeddingSample.MauiControls.GrialLicense");
#else
        Context context = Android.App.Application.Context;

		var lbl = ((PackageItemInfo)context.ApplicationInfo).LoadLabel(context.PackageManager);
		var lbl2 = ((PackageItemInfo)context.ApplicationInfo).NonLocalizedLabel;

		GrialKit.Init("GrialKitEmbeddingSample.MauiControls.GrialLicense");
#endif
		return builder
			.UseGrial()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("GrialKitEmbeddingSample/Assets/Fonts/OpenSansRegular.ttf", "OpenSansRegular");
				fonts.AddFont("GrialKitEmbeddingSample/Assets/Fonts/OpenSansSemibold.ttf", "OpenSansSemibold");
			});
	}
}