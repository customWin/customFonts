using System;
using System.Collections.Generic;
using System.Drawing;
using customFonts.Views;
using Microsoft.Win32;

namespace customFonts.Models
{
    /// <summary>
    /// This is the class that customFonts uses to patch fonts.
    /// </summary>
    public static class fontPatchTool
    {
        /// <summary>
        /// Patches Segoe UI with a custom font.
        /// </summary>
        /// <param name="font">The font that is chosen.</param>
        /// <remarks>This uses the Registry to patch it, and requires at least, logging off and logging back to apply the patch.</remarks>
        /// <exception cref="fontPatchException">Thrown when if there are problems patching the font. This will automatically revert the changes when there is a problem.</exception>
        public static void PatchSegoeUI(FontFamily font)
        {
            using (var softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            using (var microsoftKey = softwareKey?.OpenSubKey("Microsoft", true))
            using (var windowsNTKey = microsoftKey?.OpenSubKey("Windows NT", true))
            using (var currentVersionKey = windowsNTKey?.OpenSubKey("CurrentVersion", true))
            {
                try
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Segoe UI (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Bold (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Bold Italic (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Italic (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Light (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Semibold (TrueType)", "");
                        fontsKey.SetValue("Segoe UI Symbol (TrueType)", "");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.SetValue("Segoe UI", font.Name);
                    }
                }
                catch (Exception e) {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Segoe UI (TrueType)", "segoeui.ttf");
                        fontsKey.SetValue("Segoe UI Bold (TrueType)", "segoeuib.ttf");
                        fontsKey.SetValue("Segoe UI Bold Italic (TrueType)", "segoeuiz.ttf");
                        fontsKey.SetValue("Segoe UI Italic (TrueType)", "segoeuii.ttf");
                        fontsKey.SetValue("Segoe UI Light (TrueType)", "segoeuil.ttf");
                        fontsKey.SetValue("Segoe UI Semibold (TrueType)", "seguisb.ttf");
                        fontsKey.SetValue("Segoe UI Symbol (TrueType)", "seguisym.ttf");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.DeleteValue("Segoe UI");
                    }

                    new fontPatchException(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Patches Segoe UI Variable with a custom font.
        /// </summary>
        /// <param name="font">The font that is chosen.</param>
        /// <remarks>This uses the Registry to patch it, and requires at least, logging off and logging back to apply the patch. Requires <c>Windows 11 10.0.22000.x</c> or later.</remarks>
        /// <exception cref="fontPatchException">Thrown when if there are problems patching the font. This will automatically revert the changes when there is a problem.</exception>
        /// <exception cref="PlatformNotSupportedException">Thrown when the version of Windows is unsupported.</exception>
        public static void PatchSegoeUIVar(FontFamily font)
        {
            if (!mainForm.IsWindows11()) new PlatformNotSupportedException(String.Format(resourceLoader.Requires11(), "Segoe UI Variable"));

            using (var softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            using (var microsoftKey = softwareKey?.OpenSubKey("Microsoft", true))
            using (var windowsNTKey = microsoftKey?.OpenSubKey("Windows NT", true))
            using (var currentVersionKey = windowsNTKey?.OpenSubKey("CurrentVersion", true))
            {
                try
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Segoe UI Variable (TrueType)", "");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.SetValue("Segoe UI Variable", font.Name);
                    }
                }
                catch (Exception e) {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Segoe UI Variable (TrueType)", "SegUIVar.ttf");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.DeleteValue("Segoe UI Variable");
                    }
                    throw new fontPatchException(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Patches MS Sans Serif with a custom font.
        /// </summary>
        /// <param name="font">The font that is chosen.</param>
        /// <remarks>This uses the Registry to patch it, and requires at least, logging off and logging back to apply the patch.</remarks>
        /// <exception cref="fontPatchException">Thrown when if there are problems patching the font. This will automatically revert the changes when there is a problem.</exception>
        public static void PatchMSSansSerif(FontFamily font)
        {
            using (var softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            using (var microsoftKey = softwareKey?.OpenSubKey("Microsoft", true))
            using (var windowsNTKey = microsoftKey?.OpenSubKey("Windows NT", true))
            using (var currentVersionKey = windowsNTKey?.OpenSubKey("CurrentVersion", true))
            {
                try
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("MS Sans Serif 8,10,12,14,18,24", "");
                        fontsKey.SetValue("MS Sans Serif 8,10,12,14,18,24 (120)", "");
                        fontsKey.SetValue("Microsoft Sans Serif (TrueType)", "");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.SetValue("MS Sans Serif", font.Name);
                        fontSubstitutesKey.SetValue("Microsoft Sans Serif (TrueType)", font.Name);
                    }
                }
                catch (Exception e) {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("MS Sans Serif 8,10,12,14,18,24", "SSERIFE.FON");
                        fontsKey.SetValue("MS Sans Serif 8,10,12,14,18,24 (120)", "SSERIFF.FON");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.DeleteValue("MS Sans Serif");
                    }

                    throw new fontPatchException(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Patches Consolas with a custom font.
        /// </summary>
        /// <param name="font">The font that is chosen.</param>
        /// <remarks>This uses the Registry to patch it, and requires at least, logging off and logging back to apply the patch.</remarks>
        /// <exception cref="fontPatchException">Thrown when if there are problems patching the font. This will automatically revert the changes when there is a problem.</exception>
        public static void PatchConsolas(FontFamily font)
        {
            using (var softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            using (var microsoftKey = softwareKey?.OpenSubKey("Microsoft", true))
            using (var windowsNTKey = microsoftKey?.OpenSubKey("Windows NT", true))
            using (var currentVersionKey = windowsNTKey?.OpenSubKey("CurrentVersion", true))
            {
                try
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Consolas (TrueType)", "");
                        fontsKey.SetValue("Consolas Bold (TrueType)", "");
                        fontsKey.SetValue("Consolas Bold Italic (TrueType)", "");
                        fontsKey.SetValue("Consolas Italic (TrueType)", "");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.SetValue("Consolas", font.Name);
                    }
                }
                catch (Exception e)
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        fontsKey.SetValue("Consolas (TrueType)", "consola.ttf");
                        fontsKey.SetValue("Consolas Bold (TrueType)", "consolab.ttf");
                        fontsKey.SetValue("Consolas Bold Italic (TrueType)", "consolaz.ttf");
                        fontsKey.SetValue("Consolas Italic (TrueType)", "consolai.ttf");
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.DeleteValue("Consolas");
                    }

                    throw new fontPatchException(e.Message, e.InnerException);
                }
            }
        }

        /// <summary>
        /// Patches selected font with a custom font.
        /// </summary>
        /// <param name="selected">The font to be patched.</param>
        /// <param name="font">The font that is chosen.</param>
        /// <remarks>This uses the Registry to patch it, and requires at least, logging off and logging back to apply the patch.</remarks>
        /// <exception cref="fontPatchException">Thrown when if there are problems patching the font. This will automatically revert the changes when there is a problem.</exception>
        public static void PatchFont(FontFamily selected, FontFamily font)
        {
            using (var softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true))
            using (var microsoftKey = softwareKey?.OpenSubKey("Microsoft", true))
            using (var windowsNTKey = microsoftKey?.OpenSubKey("Windows NT", true))
            using (var currentVersionKey = windowsNTKey?.OpenSubKey("CurrentVersion", true))
            {
                Dictionary<string, string> str = new Dictionary<string, string>();
                try
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        var fontsKeyNames = fontsKey.GetValueNames();

                        foreach (var name in fontsKeyNames)
                        {
                            if (name.Contains(selected.Name))
                            {
                                str.Add(name, fontsKey.GetValue(name).ToString());
                                fontsKey.SetValue(name, "");
                            }
                        }
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.SetValue(selected.Name, font.Name);
                    }
                }
                catch (Exception e)
                {
                    var fontsKey = currentVersionKey?.OpenSubKey("Fonts", true);
                    if (fontsKey != null)
                    {
                        var fontsKeyNames = fontsKey.GetValueNames();

                        foreach (var name in fontsKeyNames)
                        {
                            if (name.Contains(selected.Name))
                            {
                                if (name.Contains(patchForm.font.Name))
                                    fontsKey.SetValue(name, str[name]);
                            }
                        }
                    }

                    var fontSubstitutesKey = currentVersionKey?.OpenSubKey("FontSubstitutes", true);
                    if (fontSubstitutesKey != null)
                    {
                        fontSubstitutesKey.DeleteValue(selected.Name);
                    }

                    throw new fontPatchException(e.Message, e.InnerException);
                }
            }
        }
    }
}
