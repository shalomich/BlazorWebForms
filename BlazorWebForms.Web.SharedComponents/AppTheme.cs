using MudBlazor;

namespace BlazorWebForms.Web.SharedComponents;

/// <summary>
/// Theme.
/// </summary>
internal class AppTheme
{
    /// <summary>
    /// Create theme.
    /// </summary>
    public static MudTheme Create() =>
        CreateInternal(
            background: "#ECF3FF",
            surface: "#FFFFFF");

    /// <summary>
    /// Create theme for public website (sign up page, welcome page, etc.)
    /// </summary>
    public static MudTheme CreatePublic() =>
        CreateInternal(
            background: "#F8FAFF",
            surface: "#F8FAFF");

    private static MudTheme CreateInternal(
        string background,
        string surface)
    {
        return new MudTheme
        {
            PaletteLight = new PaletteLight()
            {
                AppbarBackground = "#FFFFFF",
                TextPrimary = "#191919",
                TextSecondary = "#666666",
                Background = background,
                Surface = surface,
                Primary = "#3A6BC5",
                PrimaryLighten = "#ECF3FF",
                PrimaryDarken = "#2152AC",
                ActionDefault = "#5D667D",
                WarningContrastText = "#AF5400",
                Warning = "#FFEFE0",
                WarningDarken = "#FFEFE1",
                Success = "#2F8C33",
                SuccessLighten = "#DFFFE0",
                InfoContrastText = "#4759FF",
                SuccessContrastText = "#000000",
                Error = "#D83535",
                ErrorLighten = "#FFECEC",
                ErrorContrastText = "#000000",
                AppbarText = "#191919",
                BackgroundGray = "#FAFAFA",
                GrayDefault = "#666666",
                GrayLight = "#F2F2F2",
                GrayDarker = "#B3B3B3",
                GrayDark = "#999999",
                LinesDefault = "#CCCCCC",
                GrayLighter = "#333333",
                Secondary = "#194AA40F"
            },
            Typography = new Typography
            {
                Default = new Default
                {
                    FontFamily = ["Roboto", "sans-serif"]
                },
                Body1 = new Body1
                {
                    FontWeight = 400,
                    FontSize = "16px",
                    LineHeight = 1.5,
                    LetterSpacing = "0.5px"
                },
                Body2 = new Body2
                {
                    FontWeight = 400,
                    FontSize = "14px",
                    LineHeight = 1.5,
                    LetterSpacing = "0.25px"
                },
                H4 = new H4
                {
                    FontWeight = 400,
                    FontSize = "34px",
                    LineHeight = 1.2,
                    LetterSpacing = "0.25px"
                },
                H5 = new H5
                {
                    FontWeight = 400,
                    FontSize = "24px",
                    LineHeight = 1.3
                },
                H6 = new H6
                {
                    FontWeight = 500,
                    FontSize = "20px",
                    LineHeight = 1.2,
                    LetterSpacing = "0.15px"
                },
                Button = new Button
                {
                    FontWeight = 500,
                    FontSize = "14px",
                    LineHeight = 1.5,
                    LetterSpacing = "0.1px",
                    TextTransform = "none"
                },
                Overline = new Overline
                {
                    FontWeight = 400,
                    FontSize = "10px",
                    LineHeight = 1.2,
                    LetterSpacing = "1.5px"
                },
                Subtitle1 = new Subtitle1
                {
                    FontWeight = 400,
                    FontSize = "16px",
                    LineHeight = 1.25,
                    LetterSpacing = "0.15px"
                },
                Caption = new Caption
                {
                    FontWeight = 400,
                    FontSize = "12px",
                    LineHeight = 1.3,
                    LetterSpacing = "0.4px"
                },
            }
        };
    }
}
