using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WindowsInput.Native;

namespace GenshinLyreMidiPlayer.WPF.Core;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "StringLiteralTypo")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
public static class Keyboard
{
    public enum Instrument
    {
        WindsongLyre,
        FloralZither,
        VintageLyre,
        LifeAfter
    }

    public enum Layout
    {
        QWERTY,
        QWERTZ,
        AZERTY,
        DVORAK,
        DVORAKLeft,
        DVORAKRight,
        Colemak,
        QWERTY_LA
    }

    public static readonly Dictionary<Instrument, string> InstrumentNames = new()
    {
        [Instrument.WindsongLyre] = "Windsong Lyre",
        [Instrument.FloralZither] = "Floral Zither",
        [Instrument.VintageLyre] = "Vintage Lyre",
        [Instrument.LifeAfter] = "LifeAfter"
    };

    public static readonly Dictionary<Layout, string> LayoutNames = new()
    {
        [Layout.QWERTY] = "QWERTY",
        [Layout.QWERTZ] = "QWERTZ",
        [Layout.AZERTY] = "AZERTY",
        [Layout.DVORAK] = "DVORAK",
        [Layout.DVORAKLeft] = "DVORAK Left Handed",
        [Layout.DVORAKRight] = "DVORAK Right Handed",
        [Layout.Colemak] = "Colemak",
        [Layout.QWERTY_LA] = "QWERTY for LifeAfter"
    };

    private static readonly IReadOnlyList<VirtualKeyCode> AZERTY = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.OEM_COMMA,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_J,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> Colemak = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_Y,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_I
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAK = new List<VirtualKeyCode>
    {
        VirtualKeyCode.OEM_2,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_I,
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_L,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.OEM_1,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_C,

        VirtualKeyCode.VK_X,
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_F
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAKLeft = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_L,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_6,

        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_5,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_8,

        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T
    };

    private static readonly IReadOnlyList<VirtualKeyCode> DVORAKRight = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_L,
        VirtualKeyCode.OEM_COMMA,
        VirtualKeyCode.VK_P,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_7,

        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_K,
        VirtualKeyCode.VK_8,
        VirtualKeyCode.OEM_PERIOD,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_5,

        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_M,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_J,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_I
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTY = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_J,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTZ = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_X,
        VirtualKeyCode.VK_C,
        VirtualKeyCode.VK_V,
        VirtualKeyCode.VK_B,
        VirtualKeyCode.VK_N,
        VirtualKeyCode.VK_M,

        VirtualKeyCode.VK_A,
        VirtualKeyCode.VK_S,
        VirtualKeyCode.VK_D,
        VirtualKeyCode.VK_F,
        VirtualKeyCode.VK_G,
        VirtualKeyCode.VK_H,
        VirtualKeyCode.VK_J,

        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_E,
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_Z,
        VirtualKeyCode.VK_U
    };

    private static readonly IReadOnlyList<VirtualKeyCode> QWERTY_LFAFTER = new List<VirtualKeyCode>
    {
        VirtualKeyCode.VK_1,
        VirtualKeyCode.VK_Q,
        VirtualKeyCode.VK_2,
        VirtualKeyCode.VK_W,
        VirtualKeyCode.VK_3,
        VirtualKeyCode.VK_E,
        
        VirtualKeyCode.VK_R,
        VirtualKeyCode.VK_5,
        VirtualKeyCode.VK_T,
        VirtualKeyCode.VK_6,
        VirtualKeyCode.VK_Y,
        VirtualKeyCode.VK_U,
        VirtualKeyCode.VK_7,
        VirtualKeyCode.VK_I,
        VirtualKeyCode.VK_8,
        VirtualKeyCode.VK_O,
        VirtualKeyCode.VK_9,
        VirtualKeyCode.VK_P,

        VirtualKeyCode.VK_OEM_4,
        VirtualKeyCode.VK_OEM_MINUS,
        VirtualKeyCode.VK_OEM_6,
        VirtualKeyCode.VK_OEM_PLUS,
        VirtualKeyCode.VK_OEM_2
    };

    private static readonly List<int> DefaultNotes = new()
    {
        48, // C3
        50, // D3
        52, // E3
        53, // F3
        55, // G3
        57, // A3
        59, // B3

        60, // C4
        62, // D4
        64, // E4
        65, // F4
        67, // G4
        69, // A4
        71, // B4

        72, // C5
        74, // D5
        76, // E5
        77, // F5
        79, // G5
        81, // A5
        83  // B5
    };

    private static readonly List<int> VintageNotes = new()
    {
        48, // C3
        50, // D3
        51, // Eb3
        53, // F3
        55, // G3
        57, // A3
        58, // Bb3

        60, // C4
        62, // D4
        63, // Eb4
        65, // F4
        67, // G4
        69, // A4
        70, // Bb4

        72, // C5
        74, // Db5
        76, // Eb5
        77, // F5
        79, // G5
        80, // Ab5
        82  // Bb5
    };

    private static readonly List<int> LifeAfterNotes = new()
    {
        30, // Gb1
        31, // G1
        32, // Ab1
        33, // A1
        34, // Bb1
        35, // B1

        36, // C2
        37, // Db2
        38, // D2
        39, // Eb2
        40, // E2
        41, // F2
        42, // Gb2
        43, // G2
        44, // Ab2
        45, // A2
        46, // Bb2
        47, // B2

        48, // C3
        49, // Db3
        50, // D3
        51, // Eb3
        52  // E3
    };

    public static IEnumerable<VirtualKeyCode> GetLayout(Layout layout) => layout switch
    {
        Layout.QWERTY      => QWERTY,
        Layout.QWERTZ      => QWERTZ,
        Layout.AZERTY      => AZERTY,
        Layout.DVORAK      => DVORAK,
        Layout.DVORAKLeft  => DVORAKLeft,
        Layout.DVORAKRight => DVORAKRight,
        Layout.Colemak     => Colemak,
        Layout.QWERTY_LA   => QWERTY_LFAFTER,
        _                  => QWERTY
    };

    public static IList<int> GetNotes(Instrument instrument) => instrument switch
    {
        Instrument.WindsongLyre => DefaultNotes,
        Instrument.FloralZither => DefaultNotes,
        Instrument.VintageLyre  => VintageNotes,
        Instrument.LifeAfter    => LifeAfterNotes,
        _                       => DefaultNotes
    };
}